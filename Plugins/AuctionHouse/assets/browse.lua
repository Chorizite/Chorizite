local rx = require('rx')
local backend = require('backend')
local ac = require('ac')
local PacketWriter = CS.Chorizite.Core.Backend.PacketWriter
local Net = require(typeof(CS.Chorizite.Core.Net.NetworkParser))
local BinaryReader = CS.System.IO.BinaryReader
local MemoryStream = CS.System.IO.MemoryStream
local hex = function(number) return string.format("0x%08X", number) end
--local json = require "json"


local ClientState = CS.Core.AC.API.ClientState

local state = rx:CreateState({
	items = { { ListingId = 1, Info = "Test" } },
	loading = true,
	testProp = false,
	update = function (self) 
		self.loading = false
		self.testProp = true
	end
})

local OpCodeHandlers = {
  [0x0317] = function(evt)
    print("-> AuctionQueryListings Event Handler")
    local stream = MemoryStream(evt.RawData)
    local reader = BinaryReader(stream)
    local length = reader:ReadUInt32()
    local jsonBytes = reader:ReadBytes(length)
    --local items = json.decode(jsonBytes)
	reader:Dispose()

	state:update(items)
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
	
local BrowseAuctionView = function(state)
  print("Rendering BrowwseAuctionView")
  return rx:Div(state.loading and "loading..." or "loaded", { onMount = function () onBrowseMount() end })
end

document:Mount(function() return BrowseAuctionView(state) end, "#browse")
