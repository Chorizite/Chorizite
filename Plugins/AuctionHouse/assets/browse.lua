local rx = require('rx')
local backend = require('ClientBackend')
local ac = require('Plugins.Core.AC').Game
local PacketWriter = CS.Chorizite.Core.Backend.Client.PacketWriter
local Net = require(typeof(CS.Chorizite.Core.Net.NetworkParser))
local BinaryReader = CS.System.IO.BinaryReader
local MemoryStream = CS.System.IO.MemoryStream
local hex = function(number) return string.format("0x%08X", number) end
local json = require('json')

local BrowseAuctionView = function(state)
  return rx:Div({
    rx:Div({
      class = "auction-browse",
    }, {

    }),
  return rx:Div({ class = "auction-browse", onMount = function () onMount() end }, {
      BrowseHeader(state),
      BrowseSearch(state),
      BrowseItems(state)
  })
end

document:Mount(function() return BrowseAuctionView(state) end, "#browse")
