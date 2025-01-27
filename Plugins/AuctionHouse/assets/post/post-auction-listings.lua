local rx = require("rx")
local request = require("request")
local Net = require(typeof(CS.Chorizite.Core.Net.NetworkParser))
local ac = require('Plugins.Core.AC').Game

local state = rx:CreateState({
  loading = true,
  listings = nil,
  auctionError = "",
  sortColumn = "name",
  sortDirection = 1,
  sortNameDirection = 1,
  sortStackSizeDirection = 1,
  sortBuyoutPriceDirection = 1,
  sortStartPriceDirection = 1,
  sortSellerDirection = 1,
  sortCurrencyDirection = 1,
  searchQuery = "",
  UpdateSortState = function(self, column)
    self.loading = true

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
    request.FetchPostListings(self.searchQuery, self.sortDirection, self.sortColumn)
  end,
  HandleGetListingsResponse = function(self, response)
    self.loading = false;
    if response.Success then
      self.listings = response.Data
    else
      self.auctionError = response.ErrorMessage
    end
  end
})

local OpCodeHandlers = {
  [0x10004] = function(evt)
    print("-> GetListingsResponse Event Handler")
    local getListingsResponse = request.read(evt.RawData)
    state.HandleGetListingsResponse(getListingsResponse)
  end
}


local onMount = function()
  request.FetchPostListings("", 1, "name")
  Net.Messages:OnUnknownMessage('+', function(sender, evt)
    if OpCodeHandlers[evt.OpCode] then
      OpCodeHandlers[evt.OpCode](evt)
    end
  end)
end

local AuctionListingsTitle = function(state)
  return rx:Div({ class = "post-auction-listings-title" }, {
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
  return rx:Tr({ class = "post-auction-listings-item", key = item.Id }, {
    rx:Td({
      rx:Div({ class = "post-auction-listings-item-name-container" }, {
        rx:Div({
          style = string.format("decorator: image( %s )", itemIcon),
          class = "post-auction-listings-item-icon"
        }),
        rx:Div({ class = "post-auction-listings-item-name" }, item.ItemName),
      })
    }),
    rx:Td("x" .. (item.StackSize or "1")),
    rx:Td(tostring(item.BuyoutPrice)),
    rx:Td(tostring(item.StartPrice)),
    rx:Td(tostring(item.SellerName)),
    rx:Td({
      rx:Div({ class = "post-auction-listings-item-name-container" }, {
        rx:Div({
          style = string.format("decorator: image( %s )", currencyIcon),
          class = "post-auction-listings-item-icon"
        }),
        rx:Div({ class = "post-auction-listings-item-name" }, item.CurrencyName),
      })
    }),
  })
end

local AuctionListingsList = function(state)
  return rx:Div({
    class = {
      ["has-item"] = true,
      ["post-auction-listings-list"] = true
    }
  }, {
    rx:Table({ class = "post-auction-listings-table" }, {
      rx:Thead({ class = "post-auction-listings-header" }, {
        rx:Tr({
          rx:Td({
            class = "post-auction-listings-header-item",
            onClick = function() state.UpdateSortState("name") end
          }, {
            rx:Div({ class = "post-auction-listings-header-item-container" }, {
              rx:Div("Name"),
              rx:Img({
                sprite = state.sortNameDirection == 1
                    and "combo-up-arrow"
                    or "combo-down-arrow"
              }),
            })
          }),
          rx:Td({
            class = "post-auction-listings-header-item",
            onClick = function() state.UpdateSortState("stackSize") end
          }, {
            rx:Div({ class = "post-auction-listings-header-item-container" }, {
              rx:Div("Stack Size"),
              rx:Img({
                sprite = state.sortStackSizeDirection == 1
                    and "combo-up-arrow"
                    or "combo-down-arrow"
              }),
            })
          }),
          rx:Td({
            class = "post-auction-listings-header-item",
            onClick = function() state.UpdateSortState("buyoutPrice") end
          }, {
            rx:Div({ class = "post-auction-listings-header-item-container" }, {
              rx:Div("Buyout Price"),
              rx:Img({
                sprite = state.sortBuyoutPriceDirection == 1
                    and "combo-up-arrow"
                    or "combo-down-arrow"
              }),
            })
          }),
          rx:Td({
            class = "post-auction-listings-header-item",
            onClick = function() state.UpdateSortState("startPrice") end
          }, {
            rx:Div({ class = "post-auction-listings-header-item-container" }, {
              rx:Div("Start Price"),
              rx:Img({
                sprite = state.sortStartPriceDirection == 1
                    and "combo-up-arrow"
                    or "combo-down-arrow"
              }),
            })
          }),
          rx:Td({
            class = "post-auction-listings-header-item",
            onClick = function() state.UpdateSortState("seller") end
          }, {
            rx:Div({ class = "post-auction-listings-header-item-container" }, {
              rx:Div("Seller"),
              rx:Img({
                sprite = state.sortSellerDirection == 1
                    and "combo-up-arrow"
                    or "combo-down-arrow"
              }),
            })
          }),
          rx:Td({
            class = "post-auction-listings-header-item",
            onClick = function() state.UpdateSortState("currency") end
          }, {
            rx:Div({ class = "post-auction-listings-header-item-container" }, {
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
  print("RENDERED AUCTION LISTINGS")
  return rx:Div({
    class = "post-auction-listings-container",
    onMount = function() onMount() end
  }, {
    AuctionListingsTitle(state),
    AuctionListingsList(state),
  })
end

document:Mount(function() return AuctionListings(state) end, ".post-auction-listings")
