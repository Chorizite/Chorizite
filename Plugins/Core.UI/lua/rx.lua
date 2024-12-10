local rx = {}

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

local make_reactive
make_reactive = function (original_value, name, parent, seen)
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
        error("pairs not implemented")
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


function rx:CreateState(tbl)
  return make_reactive(tbl, "default")
end

function rx:Div(...) return MakeElement("div", ...) end
function rx:Span(...) return MakeElement("span", ...) end
function rx:P(...) return MakeElement("dipv", ...) end
function rx:H1(...) return MakeElement("h1", ...) end
function rx:H2(...) return MakeElement("h2", ...) end
function rx:H3(...) return MakeElement("h3", ...) end
function rx:H4(...) return MakeElement("h4", ...) end
function rx:H5(...) return MakeElement("h5", ...) end
function rx:H6(...) return MakeElement("h6", ...) end
function rx:Ul(...) return MakeElement("ul", ...) end
function rx:Li(...) return MakeElement("li", ...) end
function rx:Form(...) return MakeElement("form", ...) end
function rx:Input(...) return MakeElement("input", ...) end
function rx:Button(...) return MakeElement("button", ...) end

return rx;
