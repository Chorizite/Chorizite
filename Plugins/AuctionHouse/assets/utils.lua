local utils = {}

utils.printTable = function(tbl, indent)
  indent = indent or 0
  local indentString = string.rep("  ", indent)

  for key, value in pairs(tbl) do
    if type(value) == "table" then
      print(indentString .. tostring(key) .. ":")
      utils.printTable(value, indent + 1)
    else
      print(indentString .. tostring(key) .. ": " .. tostring(value))
    end
  end
end

utils.getEnumRepresentation = function(columnMap, column)
  local enumValue = columnMap[column]
  if not enumValue then
    error("Invalid column name: " .. tostring(column))
  end
  return enumValue
end

utils.debounce = function(func, delay)
  local timeoutRef = nil

  return function(...)
    local args = { ... }
    if timeoutRef then
      clearTimeout(timeoutRef)
    end

    timeoutRef = setTimeout(function()
      func(table.unpack(args))
      timeoutRef = nil
    end, delay)
  end
end

return utils
