
  -- Split version and pre-release parts
  local function splitVersionParts(v)
    local version, prerelease = v:match("^([^-]+)%-?(.*)$")
    return version, prerelease
end

-- Split version numbers into table
local function parseVersion(v)
    local nums = {}
    for num in v:gmatch("%d+") do
        table.insert(nums, tonumber(num))
    end
    return nums
end

-- Compare version numbers
local function compareNumbers(n1, n2)
    for i = 1, math.max(#n1, #n2) do
        local num1 = n1[i] or 0
        local num2 = n2[i] or 0
        if num1 ~= num2 then
            return num1 - num2
        end
    end
    return 0
end
local function comparePrerelease(pre1, pre2)
    -- If one has pre-release and other doesn't, the one without pre-release is greater
    if pre1 == "" and pre2 ~= "" then return 1 end
    if pre1 ~= "" and pre2 == "" then return -1 end
    if pre1 == "" and pre2 == "" then return 0 end
    
    -- Split pre-release parts
    local parts1 = {}
    local parts2 = {}
    
    for part in pre1:gmatch("[^-]+") do
        table.insert(parts1, part)
    end
    
    for part in pre2:gmatch("[^-]+") do
        table.insert(parts2, part)
    end
    
    -- Compare each part
    for i = 1, math.max(#parts1, #parts2) do
        local p1 = parts1[i] or ""
        local p2 = parts2[i] or ""
        
        -- Try to convert to numbers if possible
        local n1 = tonumber(p1)
        local n2 = tonumber(p2)
        
        if n1 and n2 then
            if n1 ~= n2 then
                return n1 - n2
            end
        else
            if p1 ~= p2 then
                return p1 < p2 and -1 or 1
            end
        end
    end
    
    return #parts1 - #parts2
end


--- Compare version strings.
--- Returns -integer if v1 is less than v2.
--- returns 0 if v1 is equal to v2.
--- returns +integer if v1 is greater than v2.
---@param v1 string
---@param v2 string
---@return integer
local function compareVersions(v1, v2)
  -- Main comparison logic
  local version1, prerelease1 = splitVersionParts(v1)
  local version2, prerelease2 = splitVersionParts(v2)
  
  local nums1 = parseVersion(version1)
  local nums2 = parseVersion(version2)
  
  -- First compare version numbers
  local versionCompare = compareNumbers(nums1, nums2)
  if versionCompare ~= 0 then
      return versionCompare
  end
  
  -- If versions are equal, compare pre-release tags
  return comparePrerelease(prerelease1, prerelease2)
end

return {
  compare = compareVersions
}