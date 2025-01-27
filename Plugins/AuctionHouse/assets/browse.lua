local rx = require('rx')

local state = rx:CreateState({

})

local BrowseAuctionView = function(state)
  return rx:Div({
    class = "auction-browse",
  }, "Browse")
end

document:Mount(function() return BrowseAuctionView(state) end, "#browse")
