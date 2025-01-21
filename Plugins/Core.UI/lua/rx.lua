---@meta rx
local rx = {}
local UI = require("Plugins.Core.UI")

---@alias VirtualNodeArg CS.Core.UI.Lib.RmlUi.VDom.VirtualNode | string | { [number]: CS.Core.UI.Lib.RmlUi.VDom.VirtualNode } | fun(): { [number]: CS.Core.UI.Lib.RmlUi.VDom.VirtualNode}


---Create a VirtualNode
---@param elType string The type of element (div, span, etc)
---@param ... VirtualNodeArg
---@return CS.Core.UI.Lib.RmlUi.VDom.VirtualNode
local MakeElement = function(elType, ...)
  local args = table.pack(...)
  local props = {}
  local children = {}
  local text = nil
  for i,v in ipairs(args) do
    if type(v) == "table" and #v > 0 then
      children = v
    elseif type(v) == "table" then
      props = v
    elseif type(v) == "userdata" then
      children = {v}
    elseif type(v) == "string" then
      text = v
    elseif type(v) == "function" then
      children = v()
    else
      error("Unhandled element argument: " .. type(v))
    end
  end
  if props.class ~= nil and type(props.class) == 'table' then
    local classStr = ""
    for k,v in pairs(props.class) do
      if props.class[k] then
        classStr = classStr .. (#classStr > 0 and (" " .. k) or k)
      end
    end
    props.class = classStr
  end
  return __Rx:El(elType, props, children, text)
end

local rx_marker = "rx"

local is_reactive = function (v)
  return type(v) == "table" and getmetatable(v) == rx_marker
end

function make_reactive(original_value, name, parent, seen)
  seen = seen or {}
  if is_reactive(original_value) then
    return original_value
  end

  if type(original_value) == "table" then
    local observable = document:Observable(tostring(name), parent)
    local observable_types = {}
    local func_table = {}
    local observables_table = {}
    local observable_table_types = {}

    local readValue = function(key)
      local value = nil
      if (observable_types[key] == "string") then
        value = observable:ReadString(key)
      elseif (observable_types[key] == "number") then
        value = observable:ReadNumber(key)
      elseif (observable_types[key] == "boolean") then
        value = observable:ReadBool(key)
      else
        value = observable:ReadObservable(key)
      end
      return value
    end

    local writeValue = function(t, key, value)
      if value == nil then
        observable_types[key] = nil
        observables_table[key] = nil
        observable:ClearProperty(key)
      elseif type(value) == "string" then
        observable_types[key] = type(value)
        observable:WriteString(key, value)
      elseif type(value) == "number" then
        observable_types[key] = type(value)
        observable:WriteNumber(key, value)
      elseif type(value) == "boolean" then
        observable_types[key] = type(value)
        observable:WriteBool(key, value)
      elseif type(value) == "table" then
        if is_reactive(value) then
          observables_table[key] = value
        else
          observables_table[key] = make_reactive(value, key, t.__observable, seen)
        end
        observable:AddObservable(key, observables_table[key].__observable)
      else
        error(string.format("Unhandled write: [%s] %s (%s)", key, value, type(value)))
      end
    end

    for k, v in pairs(original_value) do
      if (type(v) == "function") then
        func_table[k] = function(...)
          local args = table.pack(...)
          if #args > 0 and args[1] == original_value then
            table.remove(args, 1)
            v(original_value, table.unpack(args))
          else
            v(original_value, ...)
          end
        end
      elseif type(v) == "string" then
        observable:AddObservableString(k, v)
        observable_types[k] = type(v)
      elseif type(v) == "number" then
        observable:AddObservableNumber(k, v)
        observable_types[k] = type(v)
      elseif type(v) == "boolean" then
        observable:AddObservableBool(k, v)
        observable_types[k] = type(v)
      elseif type(v) == "table" then
        if is_reactive(v) then
          observables_table[k] = v
          observable:AddObservable(k, observables_table[k].__observable)
        else
          observables_table[k] = make_reactive(v, k, observable, seen)
          observable:AddObservable(k, observables_table[k].__observable)
        end
      else
        error("Unhandled rx type: " .. k .. " : " .. type(v))
      end
      original_value[k] = nil  -- Remove the key from the original table
    end

    -- Set the metatable on the original table to make it reactive
    local mt = {
      -- Redirect reads
      __index = function(t, key)
        if key == "__observable" then
          return observable
        elseif func_table[key] ~= nil then
          return func_table[key]
        elseif observables_table[key] ~= nil then
          readValue(key)
          return observables_table[key]
        else
          return readValue(key)
        end
      end,
      -- Prevent any modifications
      __newindex = function(t, k, v)
        writeValue(t, k, v)
      end,
      -- Lock the metatable
      __metatable = rx_marker,
      -- Custom ipairs iterator
      __ipairs = function(t)
        local function ipairs_iterator(t, i)
          i = i + 1
          local v = readValue(i)
          if v == nil then
            return nil
          else
            return i, v
          end
        end
        return ipairs_iterator, t, 0
      end,
      -- Custom pairs iterator
      __pairs = function(t)
        local function pairs_iterator(t, k)
          local nextKey = observable:NextKey(k)
          if nextKey == nil then
            return nil
          end
          
          local value = readValue(nextKey)
          
          return nextKey, value
        end
        return pairs_iterator, t, nil
      end,
      -- Custom len function
      __len = function()
        return observable.Length
      end,
    }

    setmetatable(original_value, mt)
    return original_value
  else
    error("Unknown type to make reactive: " .. type(original_value))
  end
end

local _nextStateId = 0

---Create an observable state from a table
---@generic T : any
---@param tbl T
---@param name? string An optional name for the state, used for debugging
---@return T
function rx:CreateState(tbl, name)
  _nextStateId = _nextStateId + 1
  return make_reactive(tbl, name or ("state_" .. _nextStateId))
end

---Create a reactive Div element
---@param ... VirtualNodeArg
---@return CS.Core.UI.Lib.RmlUi.VDom.VirtualNode
function rx:Div(...) return MakeElement("div", ...) end

---Create a reactive Span element
---@param ... VirtualNodeArg
---@return CS.Core.UI.Lib.RmlUi.VDom.VirtualNode
function rx:Span(...) return MakeElement("span", ...) end

---Create a reactive P element
---@param ... VirtualNodeArg
---@return CS.Core.UI.Lib.RmlUi.VDom.VirtualNode
function rx:P(...) return MakeElement("p", ...) end

---Create a reactive H1 element
---@param ... VirtualNodeArg
---@return CS.Core.UI.Lib.RmlUi.VDom.VirtualNode
function rx:H1(...) return MakeElement("h1", ...) end

---Create a reactive H2 element
---@param ... VirtualNodeArg
---@return CS.Core.UI.Lib.RmlUi.VDom.VirtualNode
function rx:H2(...) return MakeElement("h2", ...) end

---Create a reactive H3 element
---@param ... VirtualNodeArg
---@return CS.Core.UI.Lib.RmlUi.VDom.VirtualNode
function rx:H3(...) return MakeElement("h3", ...) end

---Create a reactive H4 element
---@param ... VirtualNodeArg
---@return CS.Core.UI.Lib.RmlUi.VDom.VirtualNode
function rx:H4(...) return MakeElement("h4", ...) end

---Create a reactive H5 element
---@param ... VirtualNodeArg
---@return CS.Core.UI.Lib.RmlUi.VDom.VirtualNode
function rx:H5(...) return MakeElement("h5", ...) end

---Create a reactive H6 element
---@param ... VirtualNodeArg
---@return CS.Core.UI.Lib.RmlUi.VDom.VirtualNode
function rx:H6(...) return MakeElement("h6", ...) end

---Create a reactive Ul element
---@param ... VirtualNodeArg
---@return CS.Core.UI.Lib.RmlUi.VDom.VirtualNode
function rx:Ul(...) return MakeElement("ul", ...) end

---Create a reactive Li element
---@param ... VirtualNodeArg
---@return CS.Core.UI.Lib.RmlUi.VDom.VirtualNode
function rx:Li(...) return MakeElement("li", ...) end

---Create a reactive Table element
---@param ... VirtualNodeArg
---@return CS.Core.UI.Lib.RmlUi.VDom.VirtualNode
function rx:Table(...) return MakeElement("table", ...) end

---Create a reactive Thead element
---@param ... VirtualNodeArg
---@return CS.Core.UI.Lib.RmlUi.VDom.VirtualNode
function rx:Thead(...) return MakeElement("thead", ...) end

---Create a reactive Th element
---@param ... VirtualNodeArg
---@return CS.Core.UI.Lib.RmlUi.VDom.VirtualNode
function rx:Th(...) return MakeElement("th", ...) end

---Create a reactive Tr element
---@param ... VirtualNodeArg
---@return CS.Core.UI.Lib.RmlUi.VDom.VirtualNode
function rx:Tr(...) return MakeElement("tr", ...) end

---Create a reactive Td element
---@param ... VirtualNodeArg
---@return CS.Core.UI.Lib.RmlUi.VDom.VirtualNode
function rx:Td(...) return MakeElement("td", ...) end

---Create a reactive Tbody element
---@param ... VirtualNodeArg
---@return CS.Core.UI.Lib.RmlUi.VDom.VirtualNode
function rx:Tbody(...) return MakeElement("tbody", ...) end

---Create a reactive Form element
---@param ... VirtualNodeArg
---@return CS.Core.UI.Lib.RmlUi.VDom.VirtualNode
function rx:Form(...) return MakeElement("form", ...) end

---Create a reactive Input element
---@param ... VirtualNodeArg
---@return CS.Core.UI.Lib.RmlUi.VDom.VirtualNode
function rx:Input(...) return MakeElement("input", ...) end

---Create a reactive Button element
---@param ... VirtualNodeArg
---@return CS.Core.UI.Lib.RmlUi.VDom.VirtualNode
function rx:Button(...) return MakeElement("button", ...) end

---Create a reactive Progress element
---@param ... VirtualNodeArg
---@return CS.Core.UI.Lib.RmlUi.VDom.VirtualNode
function rx:Progress(...) return MakeElement("progress", ...) end

---Create a reactive Br element
---@param ... VirtualNodeArg
---@return CS.Core.UI.Lib.RmlUi.VDom.VirtualNode
function rx:Br(...) return MakeElement("br", ...) end

---Create a reactive Img element
---@param ... VirtualNodeArg
---@return CS.Core.UI.Lib.RmlUi.VDom.VirtualNode
function rx:Img(...) return MakeElement("img", ...) end

---Create a reactive Handle element
---@param ... VirtualNodeArg
---@return CS.Core.UI.Lib.RmlUi.VDom.VirtualNode
function rx:Handle(...) return MakeElement("handle", ...) end

---Create a reactive Tabset element
---@param ... VirtualNodeArg
---@return CS.Core.UI.Lib.RmlUi.VDom.VirtualNode
function rx:Tabset(...) return MakeElement("tabset", ...) end

---Create a reactive Tab element
---@param ... VirtualNodeArg
---@return CS.Core.UI.Lib.RmlUi.VDom.VirtualNode
function rx:Tab(...) return MakeElement("tab", ...) end

---Create a reactive Panel element
---@param ... VirtualNodeArg
---@return CS.Core.UI.Lib.RmlUi.VDom.VirtualNode
function rx:Panel(...) return MakeElement("panel", ...) end

return rx;
