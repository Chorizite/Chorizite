local rx = require('rx')
local backend = require('ClientBackend')
local ac = require('Plugins.Core.AC').Game
local Net = require(typeof(CS.Chorizite.Core.Net.NetworkParser))
local ChatType = CS.Chorizite.Core.Backend.ChatType
local PacketWriter = CS.Chorizite.Core.Backend.Client.PacketWriter
local PropertyInt = CS.Chorizite.Common.Enums.PropertyInt
local ObjectClass = CS.Chorizite.Common.Enums.ObjectClass
local BinaryReader = CS.System.IO.BinaryReader
local MemoryStream = CS.System.IO.MemoryStream
local json = require('json')

local utils = {}

function utils.printTable(tbl, indent)
  indent = indent or 0
  local indentString = string.rep("  ", indent)

  for key, value in pairs(tbl) do
    if type(value) == "table" then
      print(indentString .. tostring(key) .. ":")
      utils.printTable(value, indent + 1)
    else
      print(indentString .. tostring(key) .. ": " .. tostring(value))
    end
  end
end

function utils.sendAuctionRequest(opcode, payload)
  if type(payload) ~= "table" then
    error("Payload must be a table")
  end

  local jsonString = json.encode(payload)
  local len = #jsonString
  local writer = PacketWriter()

  writer:WriteUInt32(opcode)
  writer:WriteUInt32(len)
  writer:WriteString(jsonString)
  backend:SendProtoUIMessage(writer)
  writer:Dispose()
end

function utils.getAuctionResponse(rawData)
  local stream = MemoryStream(rawData)
  local reader = BinaryReader(stream)
  local length = reader:ReadUInt32()
  local jsonBytes = reader:ReadBytes(length)
  local response = json.decode(jsonBytes)
  reader:Dispose()

  return response;
end

local columnEnumMap = {
  name = 1,         -- ListingColumn.Name
  stackSize = 2,    -- ListingColumn.StackSize
  buyoutPrice = 3,  -- ListingColumn.BuyoutPrice
  startPrice = 4,   -- ListingColumn.StartPrice
  seller = 5,       -- ListingColumn.Seller
  currency = 6,     -- ListingColumn.Currency
  highestBidder = 7 -- ListingColumn.HighestBidder
}

local function getEnumRepresentation(column)
  local enumValue = columnEnumMap[column]
  if not enumValue then
    error("Invalid column name: " .. tostring(column))
  end
  return enumValue
end

local state = rx:CreateState({
  selectedId = 0,
  selectedIcon = "",
  selectedName = nil,
  selectedCurrencyId = 0,
  selectedCurrencyIcon = "",
  selectedCurrencyName = nil,
  selectedCurrencyWcid = 0,
  listings = nil,
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
  sortColumn = "name",
  sortDirection = 1,
  sortNameDirection = 1,
  sortStackSizeDirection = 1,
  sortBuyoutPriceDirection = 1,
  sortStartPriceDirection = 1,
  sortSellerDirection = 1,
  sortCurrencyDirection = 1,
  UpdateSortState = function(self, column)
    local columnDirectionMap = {
      name = "sortNameDirection",
      stackSize = "sortStackSizeDirection",
      buyoutPrice = "sortBuyoutPriceDirection",
      startPrice = "sortStartPriceDirection",
      seller = "sortSellerDirection",
      currency = "sortCurrencyDirection"
    }

    local columnDirectionKey = columnDirectionMap[column]
    if not columnDirectionKey then
      error("Invalid column specified: " .. tostring(column))
    end

    self.sortColumn = column

    if self[columnDirectionKey] == 1 then
      self[columnDirectionKey] = 2
    elseif self[columnDirectionKey] == 2 then
      self[columnDirectionKey] = 1
    else
      error("Invalid sort direction. Direction must be either 1 (ascending) or 2 (descending).")
    end

    self.sortDirection = self[columnDirectionKey]
    self.listings = nil
    self.FetchAuctionListings()
  end,
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

    local requestPayload = {
      Data = sellAuctionRequest
    }

    utils.sendAuctionRequest(0x10001, requestPayload)
  end,
  FetchAuctionListings = function(self, data)
    data = data or {
      SearchQuery = "",
      SortBy = getEnumRepresentation(self.sortColumn),
      SortDirection = self.sortDirection
    }
    utils.sendAuctionRequest(0x10003, {
      Data = data
    })
  end,
  HandleSellOrderResponse = function(self, response)
    self.loading = false
    if response.Success then
      self.ClearPostForm()
      self.FetchAuctionListings()
    else
      self.auctionError = response.ErrorMessage
    end
  end,
  HandleGetListingsResponse = function(self, response)
    self.loading = false
    if response.Success then
      self.listings = response.Data
    else
      self.auctionError = response.ErrorMessage
    end
  end
})

local OpCodeHandlers = {
  [0x10002] = function(evt)
    print("-> CreateSellOrderResponse Event Handler")
    local sellOrderResponse = utils.getAuctionResponse(evt.RawData)
    state.HandleSellOrderResponse(sellOrderResponse)
  end,
  [0x10004] = function(evt)
    print("-> GetListingsResponse Event Handler")
    local getListingsResponse = utils.getAuctionResponse(evt.RawData)
    state.HandleGetListingsResponse(getListingsResponse)
  end
}

local onMount = function()
  state.FetchAuctionListings()
  Net.Messages:OnUnknownMessage('+', function(sender, evt)
    if OpCodeHandlers[evt.OpCode] then
      OpCodeHandlers[evt.OpCode](evt)
    end
  end)
end

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
      }, "Maximum"),
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
      }),
      rx:Button({
        class = "secondary",
        disabled = not state.canStack,
        onClick = function(evt) state:SetMaximumStackCount() end
      }, "Maximum"),
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
        class = "primary create-auction-button",
        onclick = function(evt) state:CreateSellOrder() end
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

local PostForm = function(state)
  return rx:Div({ class = "post-form" }, {
    rx:Div({
      class = {
        ["post-form-container"] = true,
        ["has-item"] = state.selectedId ~= 0 or state.selectedCurrencyId ~= 0,
        ["has-drag-over"] = state.isDragging and state.allowDragging,
        ["has-drag-over-invalid"] = state.isDragging and not state.allowDragging,
      }
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
    }),
  })
end

local AuctionListingsTitle = function(state)
  return rx:Div({ class = "auction-listings-title" }, {
    rx:H4(ac.Character.Name .. "'s" .. " Auctions")
  })
end

local AuctionListingsItem = function(item)
  local itemIcon = string.format(
    "dat://0x%08X?underlay=0x%08X&overlay=0x%08X&uieffect=%s",
    tonumber(item.ItemIconId),
    tonumber(item.ItemIconUnderlay),
    tonumber(item.ItemIconOverlay),
    "")

  local currencyIcon = string.format(
    "dat://0x%08X?underlay=0x%08X&overlay=0x%08X&uieffect=%s",
    tonumber(item.CurrencyIconId),
    tonumber(item.CurrencyIconUnderlay),
    tonumber(item.CurrencyIconOverlay),
    "")
  return rx:Tr({ class = "auction-listings-item", key = item.Id }, {
    rx:Td({
      rx:Div({ class = "auction-listings-item-name-container" }, {
        rx:Div({
          style = string.format("decorator: image( %s )", itemIcon),
          class = "auction-listings-item-icon"
        }),
        rx:Div({ class = "auction-listings-item-name" }, item.ItemName),
      })
    }),
    rx:Td("x" .. (item.StackSize or "1")),
    rx:Td(tostring(item.BuyoutPrice)),
    rx:Td(tostring(item.StartPrice)),
    rx:Td(tostring(item.SellerName)),
    rx:Td({
      rx:Div({ class = "auction-listings-item-name-container" }, {
        rx:Div({
          style = string.format("decorator: image( %s )", currencyIcon),
          class = "auction-listings-item-icon"
        }),
        rx:Div({ class = "auction-listings-item-name" }, item.CurrencyName),
      })
    }),
  })
end

local AuctionListingsList = function(state)
  return rx:Div({
    class = {
      ["has-item"] = true,
      ["auction-listings-list"] = true
    }
  }, {
    rx:Table({ class = "auction-listings-table" }, {
      rx:Thead({ class = "auction-listings-header" }, {
        rx:Tr({
          rx:Td({
            class = "auction-listings-header-item",
            onClick = function() state.UpdateSortState("name") end
          }, {
            rx:Div({ class = "auction-listings-header-item-container" }, {
              rx:Div("Name"),
              rx:Img({
                sprite = state.sortNameDirection == 1
                    and "combo-up-arrow"
                    or "combo-down-arrow"
              }),
            })
          }),
          rx:Td({
            class = "auction-listings-header-item",
            onClick = function() state.UpdateSortState("stackSize") end
          }, {
            rx:Div({ class = "auction-listings-header-item-container" }, {
              rx:Div("Stack Size"),
              rx:Img({
                sprite = state.sortStackSizeDirection == 1
                    and "combo-up-arrow"
                    or "combo-down-arrow"
              }),
            })
          }),
          rx:Td({
            class = "auction-listings-header-item",
            onClick = function() state.UpdateSortState("buyoutPrice") end
          }, {
            rx:Div({ class = "auction-listings-header-item-container" }, {
              rx:Div("Buyout Price"),
              rx:Img({
                sprite = state.sortBuyoutPriceDirection == 1
                    and "combo-up-arrow"
                    or "combo-down-arrow"
              }),
            })
          }),
          rx:Td({
            class = "auction-listings-header-item",
            onClick = function() state.UpdateSortState("startPrice") end
          }, {
            rx:Div({ class = "auction-listings-header-item-container" }, {
              rx:Div("Start Price"),
              rx:Img({
                sprite = state.sortStartPriceDirection == 1
                    and "combo-up-arrow"
                    or "combo-down-arrow"
              }),
            })
          }),
          rx:Td({
            class = "auction-listings-header-item",
            onClick = function() state.UpdateSortState("seller") end
          }, {
            rx:Div({ class = "auction-listings-header-item-container" }, {
              rx:Div("Seller"),
              rx:Img({
                sprite = state.sortSellerDirection == 1
                    and "combo-up-arrow"
                    or "combo-down-arrow"
              }),
            })
          }),
          rx:Td({
            class = "auction-listings-header-item",
            onClick = function() state.UpdateSortState("currency") end
          }, {
            rx:Div({ class = "auction-listings-header-item-container" }, {
              rx:Div("Currency"),
              rx:Img({
                sprite = state.sortCurrencyDirection == 1
                    and "combo-up-arrow"
                    or "combo-down-arrow"
              }),
            })
          }),
        })
      }),
      state.listings and rx:Tbody(function()
        local ret = {}
        for i, item in ipairs(state.listings) do
          table.insert(ret, AuctionListingsItem(item))
        end
        return ret
      end)
    })
  })
end

local AuctionListings = function(state)
  return rx:Div({ class = "auction-listings" }, {
    AuctionListingsTitle(state),
    AuctionListingsList(state)
  })
end

local PostAuctionView = function(state)
  return rx:Div({
    rx:Div({ class = "auction-post", onMount = function() onMount() end }, {
      PostForm(state),
      AuctionListings(state)
    }),
    PostAuctionError(state),
  })
end

document:Mount(function() return PostAuctionView(state) end, "#post")
