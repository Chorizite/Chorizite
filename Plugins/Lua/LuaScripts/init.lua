---@meta
-- global lua init, this is called each time a lua script is loaded in a new LuaEnv
local _sleep = __sleep
__sleep = nil
      
--- create a managed coroutine
--- (coroutine.resume will be called automatically for you until the thread is dead)
function coroutine.create_managed(func)
    local co = coroutine.create(func)
    context:AddManagedCoroutine(co)
    return co
end

---@class CS.System.Threading.Tasks.Task<T>: { Result: T }
      
---Block the current lua chunk from executing until the passed task is completed
---@generic T : any
---@param task CS.System.Threading.Tasks.Task<T>
---@return T
function await(task)
    assert(task ~= nil,"The task is nil")
    assert(type(task) == 'userdata' or type(task) == 'thread', "The task is should be a userdata Task or a lua thread")
    if (type(task) == 'thread') then
        -- convert the lua thread to a task
        task = context:AddManagedTask(task)
    end
            
    assert(task:GetType():IsAssignableTo(typeof(CS.System.Threading.Tasks.Task)), "The task is not castable to System.Threading.Task")
                      
    -- bail early if the tast is already completed
    if task.IsCompleted then
        return task.Result
    end
                        
    -- yield the task, this will wait to resume the coroutine until the task is completed
    coroutine.yield(task)
                
    if type(task.Result) == 'userdata' and task.Result:GetType():ToString() == 'System.Object[]' then
        if task.Result.Length == 0 then
            return
        end
        local res = {}
        for i=0,task.Result.Length-1 do
            table.insert(res, task.Result[i])
        end
        return table.unpack(res)
    end
      
    return task.Result
end
      

--- wrap a function into an async function that supports await / yielding
---@generic T : function
---@param func T the function to wrap
---@return T
function async(func)
    return function(...)
        return context:AddManagedCoroutine(coroutine.create(func), ...)
    end
end
      
--- sleep for a number of milliseconds
---@param milliseconds number number of milliseconds to sleep for
function sleep(milliseconds)
    coroutine.yield(_sleep(milliseconds))
end