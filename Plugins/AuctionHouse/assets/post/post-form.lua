local rx = require("rx")
local backend = require('ClientBackend')
local ac = require('Plugins.Core.AC').Game
local Net = require(typeof(CS.Chorizite.Core.Net.NetworkParser))
local ChatType = CS.Chorizite.Core.Backend.ChatType
local PropertyInt = CS.Chorizite.Common.Enums.PropertyInt
local ObjectClass = CS.Chorizite.Common.Enums.ObjectClass
local request = require("request")
local utils = require("utils")

local state = rx:CreateState({
  selectedId = 0,
  selectedIcon = "",
  selectedName = nil,
  selectedCurrencyId = 0,
  selectedCurrencyIcon = "",
  selectedCurrencyName = nil,
  selectedCurrencyWcid = 0,
  listings = nil,
  pageSize = 25,
  stackSize = 1,
  stackCount = 1,
  startingPrice = 1,
  buyoutPrice = 1,
  duration = 1,
  isDragging = false,
  allowDragging = true,
  auctionError = "",
  dragError = "",
  canStack = false,
  ClearPostForm = function(self)
    self.selectedId = 0
    self.selectedIcon = ""
    self.selectedName = nil
    self.selectedCurrencyId = 0
    self.selectedCurrencyIcon = ""
    self.selectedCurrencyName = nil
    self.selectedCurrencyWcid = 0
    self.listings = nil
    self.stackSize = 1
    self.stackCount = 1
    self.startingPrice = 1
    self.buyoutPrice = 1
    self.duration = 1
    self.isDragging = false
    self.allowDragging = true
    self.auctionError = ""
    self.dragError = ""
    self.canStack = false
  end,
  SelectItem = function(self, objectId)
    local wobject = ac.World:Get(objectId)
    self.canStack = wobject.IsStackable
    if not self.canStack then
      self.stackSize = 1
      self.stackCount = 1
    else
      self.stackSize = wobject:Value(PropertyInt.StackSize)
    end
  end,
  SetMaximumStackCount = function(self)
    utils.printTable(self, 1)
  end,
  SetMaximumStackSize = function(self)
    local wobject = ac.World:Get(self.selectedId)
    if wobject == nil or not wobject.IsStackable then return end
    local stackSize = math.min(wobject:Value(PropertyInt.StackSize), wobject:Value(PropertyInt.MaxStackSize))
    self.stackSize = stackSize
  end,
  CreateSellOrder = function(self)
    if self.selectedId == 0 then
      backend:AddChatText("Select an item first!", ChatType.HelpChannel)
      return
    end
    print(string.format("Sending: Number: %d, String: %s", self.selectedId, self.selectedName))

    self.loading = true

    local sellAuctionRequest = {
      ItemId = self.selectedId,
      StackSize = self.stackSize,
      NumberOfStacks = self.stackCount,
      StartPrice = self.startingPrice,
      BuyoutPrice = self.buyoutPrice,
      CurrencyWcid = self.selectedCurrencyWcid,
      HoursDuration = self.duration
    }

    request.createSellOrder(sellAuctionRequest)
  end,
  HandleSellOrderResponse = function(self, response)
    self.loading = false
    if response.Success then
      self.ClearPostForm()
      request.fetchPostListings("", 1, "name", 1, self.pageSize)
    else
      self.auctionError = response.ErrorMessage
    end
  end,
})

local PostFormItemDrop = function(state)
  return rx:Div({ class = "post-form-item-container" }, {
    rx:H4("Auction Item"),
    rx:Div({
      class = "post-form-item",
      ondragdrop = function(evt)
        if state.allowDragging == false then return end
        if evt.Params.ObjectId == nil or evt.Params.ObjectName == nil then return end

        state.selectedId = evt.Params.ObjectId
        state.selectedIcon = string.format(
          "dat://0x%08X?underlay=0x%08X&overlay=0x%08X&uieffect=%s",
          evt.Params.IconId,
          evt.Params.IconUnderlay,
          evt.Params.IconOverlay,
          evt.Params.IconEffects:ToString()
        )
        state.selectedName = evt.Params.ObjectName
        state:SelectItem(state.selectedId)
      end,
      ondragover = function(evt)
        state.isDragging = true
        state.allowDragging = evt.Params.IsSpell == false
        state.dragError = ""

        if not evt.Params.IsSpell then
          local wobject = ac.World:Get(evt.Params.ObjectId)
          if wobject.ObjectClass == ObjectClass.Container then
            state.allowDragging = false
            state.dragError = "Containers are not allowed on the Auction House"
            return
          elseif wobject.IsAttuned then
            state.allowDragging = false
            state.dragError = "Can't sell attuned items on the Auction House"
            return
          end
        end
      end,
      ondragout = function(evt)
        state.isDragging = false
        state.dragError = ""
      end
    }, {
      rx:Div({ class = "icon-stack" }, {
        rx:Div({
          class = "icon-item",
          style = state.selectedId == 0 and "" or string.format("decorator: image( %s )", state.selectedIcon)
        }),
        rx:Div({ class = "icon-drag-accept" }),
        rx:Div({ class = "icon-drag-invalid" }),
      }),
      rx:Div({ class = "icon-stack-label" }, state.selectedName or "Drop an item here"),
    })
  })
end

local PostFormItemStackSize = function(state)
  return rx:Div({ class = "post-form-item-container" }, {
    rx:H4("Stack Size"),
    rx:Div({ class = "post-form-item" }, {
      rx:Input({
        type = "text",
        id = "post-item-stack-size",
        onChange = function(evt) state.stackSize = tonumber(evt.Params.value) end,
        value = state.stackSize,
        disabled = not state.canStack
      }),
      rx:Button({
        class = "secondary",
        disabled = not state.canStack,
        onclick = function(evt) state:SetMaximumStackSize() end
      }, "Max"),
    })
  })
end

local PostFormItemStacks = function(state)
  return rx:Div({ class = "post-form-item-container" }, {
    rx:H4("Number of Stacks"),
    rx:Div({ class = "post-form-item" }, {
      rx:Input({
        type = "text",
        id = "post-item-stacks",
        onChange = function(evt) state.stackCount = tonumber(evt.Params.value) end,
        value = state.stackCount,
        disabled = not state.canStack
      })
    })
  })
end

local PostFormItemStartPrice = function(state)
  return rx:Div({ class = "post-form-item-container" }, {
    rx:H4("Starting Price"),
    rx:Div({ class = "post-form-item" }, {
      rx:Input({
        type = "text",
        id = "post-item-stack-size",
        onChange = function(evt) state.startingPrice = tonumber(evt.Params.value) end,
        value = state.startingPrice
      })
    })
  })
end

local PostFormItemBuyoutPrice = function(state)
  return rx:Div({ class = "post-form-item-container" }, {
    rx:H4("Buyout Price"),
    rx:Div({ class = "post-form-item" }, {
      rx:Input({
        type = "text",
        id = "post-item-stack-size",
        onChange = function(evt) state.buyoutPrice = tonumber(evt.Params.value) end,
        value = state.buyoutPrice
      })
    })
  })
end

local PostFormDuration = function(state)
  return rx:Div({
    class = {
      ["post-form-item-container"] = true,
    }
  }, {
    rx:H4("Duration"),
    rx:Div({ class = "post-form-item" }, {
      rx:Input({
        type = "text",
        id = "post-item-duration",
        onChange = function(evt) state.duration = tonumber(evt.Params.value) end,
        value = state.duration
      })
    })
  })
end

local PostFormCurrencyType = function(state)
  return rx:Div({ class = "post-form-item-container" }, {
    rx:H4("Currency Type"),
    rx:Div({
      class = "post-form-item",
      ondragdrop = function(evt)
        if state.allowDragging == false then return end

        if evt.Params.ObjectId == nil or evt.Params.ObjectName == nil then return end
        local wobject = ac.World:Get(evt.Params.ObjectId)
        if wobject.ItemWorkmanship > 0 then return end

        state.selectedCurrencyId = evt.Params.ObjectId
        state.selectedCurrencyIcon = string.format("dat://0x%08X?underlay=0x%08X&overlay=0x%08X&uieffect=%s",
          evt.Params.IconId, evt.Params.IconUnderlay, evt.Params.IconOverlay, evt.Params.IconEffects:ToString())
        state.selectedCurrencyName = evt.Params.ObjectName
        state.selectedCurrencyWcid = wobject.ClassId
      end,
      ondragover = function(evt)
        state.isDragging = true
        state.allowDragging = evt.Params.IsSpell == false
        state.dragError = ""

        if not evt.Params.IsSpell then
          local wobject = ac.World:Get(evt.Params.ObjectId)
          if wobject.ObjectClass == ObjectClass.Container then
            state.allowDragging = false
            state.dragError = "Containers are not allowed on the Auction House"
            return
          elseif wobject.ItemWorkmanship > 0 then
            state.allowDragging = false
            state.dragError = "Currency cannot be an item with workmanship"
            return
          elseif wobject.IsAttuned then
            state.allowDragging = false
            state.dragError = "Can't sell attuned items on the Auction House"
            return
          end
        end
      end,
      ondragout = function(evt)
        state.isDragging = false
        state.dragError = ""
      end
    }, {
      rx:Div({ class = "icon-stack" }, {
        rx:Div({
          class = "icon-item",
          style = state.selectedCurrencyId == 0 and "" or
              string.format("decorator: image( %s )", state.selectedCurrencyIcon)
        }),
        rx:Div({ class = "icon-drag-accept" }),
        rx:Div({ class = "icon-drag-invalid" }),
      }),
      rx:Div({ class = "icon-stack-label" }, state.selectedCurrencyName or "Drop a currency item here"),
    })
  })
end

local PostFormSubmit = function(state)
  return rx:Div({ class = "post-form-item-container" }, {
    rx:Div({ class = "post-form-item" }, {
      rx:Button({
        class = "primary post-form-submit",
        onclick = function() state:CreateSellOrder() end
      }, "Create Auction")
    })
  })
end

local PostAuctionError = function(state)
  return rx:Div({
    rx:Div({ class = "post-auction-error" }, state.auctionError)
  })
end

local PostFormTitle = function(state)
  return rx:Div({
    class = {
      ["post-form-title"] = true,
    }
  }, {
    rx:H4("Create a Sell Order")
  })
end

local OpCodeHandlers = {
  [0x10002] = function(evt)
    print("-> CreateSellOrderResponse Event Handler")
    local sellOrderResponse = request.read(evt.RawData)
    state.HandleSellOrderResponse(sellOrderResponse)
  end
}

local onMount = function()
  Net.Messages:OnUnknownMessage('+', function(sender, evt)
    if OpCodeHandlers[evt.OpCode] then
      OpCodeHandlers[evt.OpCode](evt)
    end
  end)
end

local PostForm = function(state)
  return rx:Div({
    class = {
      ["post-form"] = true,
      ["has-item"] = state.selectedId ~= 0 or state.selectedCurrencyId ~= 0,
      ["has-drag-over"] = state.isDragging and state.allowDragging,
      ["has-drag-over-invalid"] = state.isDragging and not state.allowDragging,
    },
    onMount = function() onMount() end
  }, {
    PostFormTitle(state),
    PostFormItemDrop(state),
    PostFormItemStackSize(state),
    PostFormItemStacks(state),
    PostFormCurrencyType(state),
    PostFormItemStartPrice(state),
    PostFormItemBuyoutPrice(state),
    PostFormDuration(state),
    PostFormSubmit(state),
  })
end

document:Mount(function() return PostForm(state) end, ".post-auction-form")
