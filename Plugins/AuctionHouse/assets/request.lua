local backend = require('ClientBackend')
local postConstants = require('post-constants')
local json = require('json')
local utils = require('utils')
local BinaryReader = CS.System.IO.BinaryReader
local MemoryStream = CS.System.IO.MemoryStream
local PacketWriter = CS.Chorizite.Core.Backend.Client.PacketWriter

local request = {}

local write = function(opcode, payload)
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

request.read = function(rawData)
  local stream = MemoryStream(rawData)
  local reader = BinaryReader(stream)

  local length = reader:ReadUInt32()
  local jsonBytes = reader:ReadBytes(length)

  if not jsonBytes then
    reader:Dispose()
    error("Failed to read JSON bytes")
  end

  local response = json.decode(jsonBytes)
  reader:Dispose()

  return response
end

request.fetchPostListings = function(searchQuery, sortDirection, sortColumn, pageNumber, pageSize)
  local fetchPostListingsRequest = {
    SearchQuery = searchQuery,
    SortBy = utils.getEnumRepresentation(postConstants.listingColumnEnumMap, sortColumn),
    SortDirection = sortDirection,
    PageNumber = pageNumber,
    PageSize = pageSize
  }
  write(0x10003, {
    Data = fetchPostListingsRequest
  })
end

request.createSellOrder = function(sellAuctionRequest)
  write(0x10001, {
    Data = sellAuctionRequest
  })
end

return request
