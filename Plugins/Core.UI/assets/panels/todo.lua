local rx = require('rx')

local _nextId = 0
function GetNextTodoId()
    _nextId = _nextId + 1
    return _nextId
end

local state = rx:CreateState({
  Title = "My Reactive Todo List",
  Todos = { { Id = GetNextTodoId(), Title = "Initial task" } },
  AddTodo = function(self, title)
    if #title == 0 then 
      local id = GetNextTodoId()
      title = string.format("A test todo: %s", id)
      table.insert(self.Todos, { Id = id, Title = title, IsCompleted = false })
    else
      table.insert(self.Todos, { Id = GetNextTodoId(), Title = title, IsCompleted = false })
    end
  end,
  ToggleTodo = function(self, todo)
    todo.IsCompleted = not todo.IsCompleted
  end,
  RemoveTodo = function(self, removeTodo)
    for i,todo in ipairs(self.Todos) do
      if todo.Id == removeTodo.Id then
        table.remove(self.Todos, i)
        return
      end
    end
  end
})

local TodoApp = function(state)
  return rx:Div({
    -- title
    rx:H1((state.Title or "Todo List") .. " (" .. tostring(#state.Todos) .. " todo)"),

    -- form
    rx:Div({ class = "actions" }, {
      rx:Input({ id = "new-todo-text", type = "text" }),
      rx:Button("Add Task", { onclick = function(evt)
        state:AddTodo(d("#new-todo-text"):GetValue())
        d("#new-todo-text"):SetValue("")
      end })
    }),

    -- todos
    rx:Ul(function()
      local ret = {}
      for i,todo in ipairs(state.Todos) do
        table.insert(ret, rx:Li({ key = todo.Id, class = todo.IsCompleted and "completed" or "" }, {
          rx:Input({ type = "checkbox", checked = todo.IsCompleted,
            onchange = function(evt) todo.IsCompleted = evt.TargetElement:HasAttribute("checked") end
          }),
          rx:Span(todo.Title, { onclick = function(evt) state.ToggleTodo(todo) end }),
          rx:Button("x", { class = "small", onclick = function(evt) state:RemoveTodo(todo) end })
        }))
      end
      return ret
    end)
  })
end

document:Mount(function() return TodoApp(state) end, "#app")
