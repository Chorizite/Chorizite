-- global lua init, this is called each time a lua script is loaded in a new LuaEnv
require('framework.System')
local TaskAwaiter = require('framework.AsyncTask')

function sleep(milliseconds)
	local result = __sleep(milliseconds);
	local status, awaiter
	if type(result)=='table' and iskindof(result,"TaskAwaiter") then	
		awaiter = result
	elseif type(result) == 'userdata' or type(result) == 'table' then
		status, awaiter = pcall(result.GetAwaiter,result)
		if not status then
			error("The parameter of the await() is error,not found the GetAwaiter() in the "..tostring(result))
		end
	else
		error("The parameter of the await() is error, this is a function, please enter a table or userdata")
	end
	
	if awaiter.IsCompleted then
		local value = awaiter:GetResult()
		if type(value) == 'table' and awaiter.Packaged then
			return table.unpack(value)
		else
			return value
		end
	end
	
	local id = coroutine.running()
	local isYielded = false
	awaiter:OnCompleted(function()			
			if isYielded then
				coroutine.resume(id)
			end
		end)
	
	if not awaiter.IsCompleted then
		isYielded = true
		coroutine.yield()
	end
	
	local value = awaiter:GetResult()
	if type(value) == 'table' and awaiter.Packaged then
		return table.unpack(value)
	else
		return value
	end
end