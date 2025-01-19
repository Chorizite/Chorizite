local rx = require('rx')
local backend = require('ClientBackend')
local ac = require('Plugins.Core.AC').Game
local PacketWriter = CS.Chorizite.Core.Backend.Client.PacketWriter
local Net = require(typeof(CS.Chorizite.Core.Net.NetworkParser))
local BinaryReader = CS.System.IO.BinaryReader
local MemoryStream = CS.System.IO.MemoryStream
local hex = function(number) return string.format("0x%08X", number) end
local json = require('json')

local ClientState = CS.Core.AC.API.ClientState

local state = rx:CreateState({
    items = { { ListingId = 1, Info = "Test" } },
    searchTerm = "",
    loading = true,
})

local OpCodeHandlers = {
  [0x10000] = function(evt)
    print("-> AuctionGetAllListings Event Handler")
    local stream = MemoryStream(evt.RawData)
    local reader = BinaryReader(stream)
    local length = reader:ReadUInt32()
    local jsonBytes = reader:ReadBytes(length)
    local items = json.decode(jsonBytes)
	reader:Dispose()

	state.loading = false;
  end
}

local fetchAuctionListings = function () 
    print("Fetching auction listings")
    backend:InvokeChat("/ah-list")
end

local onMount = function () 
	print("BrowseMount")
	Net.Messages:OnUnknownMessage('+', function(sender, evt)
	  if OpCodeHandlers[evt.OpCode] then
		OpCodeHandlers[evt.OpCode](evt)
	  end
	end)

	fetchAuctionListings()
end

local BrowseHeader = function (state) 
    return rx:Div({ class = "browse-header"}, {
        rx:H4("Auction Items"),
        rx:P("Browse and buy unique items")
    })
end

local BrowseSearch = function (state) 
    return rx:Div({ class = "browse-search" }, {
        rx:Input({ type = "text", placeholder = "Serach items", value = state.searchTerm })
    })
end

local BrowseLoader = function () 
    return rx:Div("Loading...")
end

local BrowseItems = function(state)
    if state.loading then
        return BrowseLoader()
    end

    return rx:Ul(function()
        local ret = {}
        for i, item in ipairs(state.items) do
            table.insert(ret, rx:Li({ key = item.Id }, {
                rx:P({
					rx:Span(tostring(i) .. ". "),
                    rx:Span(item.Info)
                })
            }))
        end
        return ret
    end)
end

local BrowseAuctionView = function(state)
  return rx:Div({ class = "auction-browse", onMount = function () onMount() end }, {
      BrowseHeader(state),
      BrowseSearch(state),
      BrowseItems(state)
  })
end

document:Mount(function() return BrowseAuctionView(state) end, "#browse")
