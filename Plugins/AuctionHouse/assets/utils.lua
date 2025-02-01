local utils = {}

function utils.printTable(tbl, indent)
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

function utils.getEnumRepresentation(columnMap, column)
  local enumValue = columnMap[column]
  if not enumValue then
    error("Invalid column name: " .. tostring(column))
  end
  return enumValue
end

return utils
