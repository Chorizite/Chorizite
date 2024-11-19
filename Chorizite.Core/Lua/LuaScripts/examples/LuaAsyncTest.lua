local AsyncTask = require("framework.AsyncTask")
local logger = require("framework.Logger")

local Resources = CS.UnityEngine.Resources
local GameObject = CS.UnityEngine.GameObject
local Task = CS.System.Threading.Tasks.Task
local Process = CS.System.Diagnostics.Process
local Time = CS.UnityEngine.Time
local TimeSpan = CS.System.TimeSpan
local WWW = CS.UnityEngine.WWW
local UnityWebRequest = CS.UnityEngine.Networking.UnityWebRequest
local AssetBundle = CS.UnityEngine.AssetBundle
local WaitForSeconds = CS.UnityEngine.WaitForSeconds
local WaitForUpdate = CS.UnityEngine.WaitForUpdate
local WaitForEndOfFrame = CS.UnityEngine.WaitForEndOfFrame
local WaitForBackgroundThread = CS.WaitForBackgroundThread

local AssetBundleSampleUrl = "http://www.stevevermeulen.com/wp-content/uploads/2017/09/teapot.unity3d";
local AssetBundleSampleAssetName = "Teapot";

local LuaAsyncTest = {}

-- async from coroutine
local RunAsyncFromCoroutineTest = async(function()
    local AsyncFromCoroutine = async(function()
        await(WaitForSeconds(1))
    end)

    logger.debug("Waiting 1 second...")
    await(WaitForSeconds(1))
    logger.debug("Waiting 1 second again...")
    await(AsyncFromCoroutine())
    logger.debug("Waiting Awaiters.Seconds 1 second ...");
    await(CS.Awaiters.Seconds(1))
    logger.debug("Done")
end)

-- 多线程测试
local RunMultipleThreadsTestAsync = async(function()
    logger.debug("Start");
    await(Task.Delay(TimeSpan.FromSeconds(1)))
    logger.debug("After delay");
    await(WaitForBackgroundThread());
    logger.debug("After WaitForBackgroundThread");
    logger.debug("Waiting 1 second...");
    await(Task.Delay(TimeSpan.FromSeconds(1)))
    -- We will still running from the threadpool after the delay here
    logger.debug("After Waiting");
    -- We can place any unity yield instruction here instead and it will return to the unity thread
    await(WaitForUpdate());
    logger.debug("After WaitForUpdate");
end)

-- www
local RunWwwAsync = async(function()
    logger.debug("Downloading asset bundle using WWW");
    local www = await(WWW(AssetBundleSampleUrl))
    logger.debug("www success")
    logger.debug(www.size)
    logger.debug("Downloaded " .. (www.size / 1024) .. " kb");
end)

-- open notpad
local RunOpenNotepadTestAsync = async(function()
    logger.debug("Waiting for user to close notepad...");
    await(Process.Start("notepad.exe"))
    logger.debug("Closed notepad");
end)

-- unhandled exception
local RunUnhandledExceptionTestAsync = async(function()
    local exception = async(function()
        logger.debug("waitfor exception")
        await(WaitForSeconds(1.5))
        error("asdf")
    end)

    await(exception())
end)

-- try-catch exception
local RunTryCatchExceptionTestAsync = async(function()
    local NestedRunAsync = async(function()
        logger.debug("wait 1 seconds")
        await(WaitForSeconds(1))
        error("foo")
    end)

    try{
        function()	
            --这是主函数
            await(NestedRunAsync());
        end,
        catch=function(e)
            --这是catch函数
            logger.error("Caught exception! " .. e);
        end
    }
end)

-- async operation
local RunAsyncOperationAsync = async(function()
    local DownloadRawDataAsync = async(function(url)
        local request = UnityWebRequest.Get(url);
        await(request:SendWebRequest())
        return request.downloadHandler.data;
    end)

    local InstantiateAssetBundleAsync = async(function(abUrl, assetName)
        -- We could use WWW here too which might be easier
        logger.debug("Downloading asset bundle data...");
        local data = await(DownloadRawDataAsync(abUrl))
        local assetBundle = await(AssetBundle.LoadFromMemoryAsync(data))
        local prefab = await(assetBundle:LoadAssetAsync(assetName,typeof(GameObject)))
    
        GameObject.Instantiate(prefab);
        assetBundle:Unload(false);
        logger.debug("Asset bundle instantiated");
    end)

    try{
        function()
            await(InstantiateAssetBundleAsync(AssetBundleSampleUrl, AssetBundleSampleAssetName))
        end,
        catch=function(e)
            logger.error("Caught exception! " .. e);
        end
    }
end)

-- await string
local RunWhileStringTestAsync = async(function()
    local WaitForString = async(function()
        logger.debug("start while...")
        local startTime = Time.realtimeSinceStartup;
        while(Time.realtimeSinceStartup - startTime < 2)do
            await(WaitForEndOfFrame())
        end
        return "bsdfgas";
    end)

    logger.debug("Waiting for ienumerator...");
    logger.debug("Done! Result: " .. await(WaitForString()))
end)

-- untyped string
local RunUntypedStringTestAsync = async(function()
    local WaitForStringUntyped = async(function()
        await(WaitForSeconds(1.5))
        return "qwer";
    end)

    logger.debug("Waiting for ienumerator...");
    local result = await(WaitForStringUntyped())
    logger.debug("Done! Result: " .. result);
end)

-- await return value
local RunReturnValueTestAsync = async(function()
    local GetValueExampleAsync = async(function()
        await(WaitForSeconds(1));
        return 123456;
    end)

    try{
        function()
            logger.debug("Waiting to get value...");
            local result = await(GetValueExampleAsync());
            logger.debug("Got value: " .. result);
        end,
        catch=function(e)
            logger.error("Caught exception! " .. e);
        end
    }
end)

-- resource load
local RunResourceLoadAsync = async(function()
    local getPosition = async(function(x, y, z)
        return x / 1000.0, y / 1000.0, z / 1000.0
    end)

    local x,y,z = await(getPosition(1200,2200,3200))
    logger.debug(string.format("x=%s y=%s z=%s", x, y, z))

    local goTemplate = await(Resources.LoadAsync("Prefabs/Cube", typeof(GameObject)))
    local go = GameObject.Instantiate(goTemplate)
    go.transform.localPosition = CS.UnityEngine.Vector3(x,y,z)
    logger.debug("create cube...")
end)

-- 在Lua中使用async和await
function LuaAsyncTest.Run()
    RunAsyncFromCoroutineTest()
    -- RunMultipleThreadsTestAsync()
    -- RunWwwAsync()
    -- RunOpenNotepadTestAsync()
    -- RunUnhandledExceptionTestAsync()
    -- RunTryCatchExceptionTestAsync()
    -- RunAsyncOperationAsync()
    -- RunWhileStringTestAsync()
    -- RunUntypedStringTestAsync()
    -- RunReturnValueTestAsync()
    -- RunResourceLoadAsync()
end

return LuaAsyncTest
