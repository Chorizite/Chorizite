local rx = require('rx')
local backend = require('backend')

local state = rx:CreateState({
  selectedId = 0,
  selectedIcon = "",
  selectedName = nil,
  stackSize = 1,
  stackCount = 1,
  price = 1,
  duration = 1,
  isDragging = false,
  allowDragging = true
})

local PostItemView = function(state)
  return rx:Div({ class="post flex" }, {
    -- post area
    rx:Div({ class = {
        ["post-area"] = true,
        ["has-item"] = state.selectedId ~= 0,
        ["has-drag-over"] = state.isDragging and state.allowDragging,
        ["has-drag-over-invalid"] = state.isDragging and not state.allowDragging,
      }}, {
        rx:H4("Auction Item"),
        rx:Div({
          class = "flex item",
          ondragdrop = function(evt)
            if state.allowDragging == false then return end

            if evt.Params.ObjectId == nil or evt.Params.ObjectName == nil then return end
            state.selectedId = evt.Params.ObjectId
            state.selectedIcon = string.format("dat://0x%08X?underlay=0x%08X&overlay=0x%08X&uieffect=%s", evt.Params.IconId, evt.Params.IconUnderlay, evt.Params.IconOverlay, evt.Params.IconEffects:ToString())
            state.selectedName = evt.Params.ObjectName
            print(state.selectedIcon)
          end,
          ondragover = function(evt)
            print("ondragover:", string.format("dat://0x%08X?underlay=0x%08X&overlay=0x%08X&uieffect=%s", evt.Params.IconId, evt.Params.IconUnderlay, evt.Params.IconOverlay, evt.Params.IconEffects:ToString()))
            state.isDragging = true
            state.allowDragging = evt.Params.IsSpell == false
          end,
          ondragout = function(evt)
            state.isDragging = false
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
          rx:Div({ class = "name" }, state.selectedName or "Drop an item here"),
      }),

      rx:H4("Stack Size"),
      rx:Div({ class = "flex" }, {
        rx:Input({ type = "text", id="post-item-stack-size", value = state.stackSize }),
        rx:Button({ class = "secondary" }, "Maximum"),
      }),

      rx:H4("Number of Stacks"),
      rx:Div({ class = "flex" }, {
        rx:Input({ type = "text", id="post-item-stacks", value = state.stackCount }),
        rx:Button({ class = "secondary" }, "Maximum"),
      }),

      rx:H4("Price"),
      rx:Div({ class = "flex" }, {
        rx:Input({ type = "text", id="post-item-stack-size", value = state.price })
      }),

      rx:H4("Duration"),
      rx:Div({ class = "flex" }, {
        rx:Input({ type = "text", id="post-item-duration", value = state.duration })
      }),

      rx:Button({ class = "primary create-auction-button" }, "Create Auction")
    }),

    rx:Div({ class="post-comparisons" }, "post comparison area....")
  })
end

document:Mount(function() return PostItemView(state) end, "#post")