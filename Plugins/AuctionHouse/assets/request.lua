local backend = require('ClientBackend')
local BinaryReader = CS.System.IO.BinaryReader
local MemoryStream = CS.System.IO.MemoryStream
local PacketWriter = CS.Chorizite.Core.Backend.Client.PacketWriter
local json = require('json')
local utils = require('utils')
local constants = require('constants')

local request = {}

local function write(opcode, payload)
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

function request.read(rawData)
  local stream = MemoryStream(rawData)
  local reader = BinaryReader(stream)
  local length = reader:ReadUInt32()
  local jsonBytes = reader:ReadBytes(length)
  local response = json.decode(jsonBytes)
  reader:Dispose()

  return response;
end

function request.FetchPostListings(searchQuery, sortDirection, sortColumn)
  local fetchPostListingsRequest = {
    SearchQuery = searchQuery,
    SortBy = utils.getEnumRepresentation(constants.listingColumnEnumMap, sortColumn),
    SortDirection = sortDirection
  }
  write(0x10003, {
    Data = fetchPostListingsRequest
  })
end

function request.CreateSellOrder(sellAuctionRequest)
  write(0x10001, {
    Data = sellAuctionRequest
  })
end

return request
