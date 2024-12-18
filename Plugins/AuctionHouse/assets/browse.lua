local rx = require('rx')
local backend = require('backend')
local ac = require('ac')
local PacketWriter = CS.Chorizite.Core.Backend.PacketWriter
local Net = require(typeof(CS.Chorizite.Core.Net.NetworkParser))
local BinaryReader = CS.System.IO.BinaryReader
local MemoryStream = CS.System.IO.MemoryStream
local hex = function(number) return string.format("0x%08X", number) end
local json = require('json')


local ClientState = CS.Core.AC.API.ClientState

local state = rx:CreateState({
	items = { { ListingId = 1, Info = "Test" } },
	loading = true,
})

local OpCodeHandlers = {
  [0x0317] = function(evt)
    print("-> AuctionQueryListings Event Handler")
    local stream = MemoryStream(evt.RawData)
    local reader = BinaryReader(stream)
    local length = reader:ReadUInt32()
    local jsonBytes = reader:ReadBytes(length)
    local items = json.decode(jsonBytes)
	reader:Dispose()

	state.items = items;
	state.loading = false;
  end
}

local fetchAuctionListings = function () 
    print("Fetching auction listings")
    backend:InvokeChat("/ah-list")
end

local onBrowseMount = function () 
	print("BrowseMount")
	Net.Messages:OnUnknownMessage('+', function(sender, evt)
	  if OpCodeHandlers[evt.OpCode] then
		OpCodeHandlers[evt.OpCode](evt)
	  end
	end)

	fetchAuctionListings()
end

local BrowseHeader = function (state) 
    print(state.loading)
    return rx:Div({ class = "browse-header"},{
        rx:Span("Id"),
        rx:P("Info")
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
            print(string.format("Item %d: Id=%d, Info=%s", i, item.Id, item.Info))
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
  print("Rendering BrowwseAuctionView")
  print(state.loading)
  print(#state.items)
  return rx:Div({ onMount = function () onBrowseMount() end }, {
      BrowseHeader(state),
      BrowseItems(state)
  })
end

document:Mount(function() return BrowseAuctionView(state) end, "#browse")
