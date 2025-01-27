local helpers = {}

function helpers.printTable(tbl, indent)
  indent = indent or 0
  local indentString = string.rep("  ", indent)

  for key, value in pairs(tbl) do
    if type(value) == "table" then
      print(indentString .. tostring(key) .. ":")
      helpers.printTable(value, indent + 1)
    else
      print(indentString .. tostring(key) .. ": " .. tostring(value))
    end
  end
end

function helpers.getEnumRepresentation(columnMap, column)
  local enumValue = columnMap[column]
  if not enumValue then
    error("Invalid column name: " .. tostring(column))
  end
  return enumValue
end

return helpers
