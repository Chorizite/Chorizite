# 🚀  ACUI

A hot-reloadable [Decal](https://decaldev.com/) v2.9.8.3 plugin that builds against .NET Framework 4.8 and [UtilityBelt.Service](https://gitlab.com/utilitybelt/utilitybelt.service) for the views.


## 🔧 Developing

  * The plugin code is located in the `ACUI` project. You can ignore the `ACUI.Loader` project, it contains the hot-reloader and doesn't need to be edited unless you are doing something out of the ordinary.
    * `ACUI/PluginCore.cs` is the main Plugin class. It contains the plugin startup / shutdown methods.
    * `ACUI/ExampleUI.cs` includes some demo UI code.
    * `ACUI/scripts/installer.nsi` is the NSIS script used to generate the installer.
  * Build the new plugin solution in Visual Studio with `Ctrl+Shift+B`, or by going to `Build -> Build Solution`.
  * Add both `ACUI.dll` and `ACUI.Loader.dll` to decal by opening decal from the tray and selecting `Add -> Browse -> <YourProjectPath>/bin/Release/net481/`. (Select each dll file individually.)
  * Disable `ACUI` in decal by unchecking it under the `Plugins` list.
    * During development you should have `ACUI` (under `Plugins`) disabled, and `ACUI.Loader` enabled (under `Network Filters`) in decal. This allows for hot-reloading of the plugin without logging out / restarting the client.
    * To hot-reload, just recompile the plugin while ingame. You should see a message in the chat window showing that the plugin has reloaded.

## 📦 Releasing

  * Right click the Plugin project and choose `Properties`. Scroll down and update the version number.
  * Build the latest release version.
  * In decal, enable your Plugin under the `Plugins` section, and disable `ACUI.Loader` under Network Filters. This allows you to test the plugin with hot-reloading disabled.
  * Ensure the plugin works as expected ingame.
  * Test the installer in `bin/Release/`.
  * Distribute the installer.
  
## Build Server Requirements
  * Either use the docker image at `TODO` or use a build server with the following requirements:
    * All build servers:
      * [Powershell](https://learn.microsoft.com/en-us/powershell/) is in the environment `PATH` by calling `powershell`.
    * Non-Windows build servers:
      * [NSIS](https://nsis.sourceforge.io/Main_Page) is in the environment `PATH` by calling `makensis`.
      * DotNet 6 SDK installed.
  
## 💡 Tips

  * If you need to reference more decal dlls, make sure to copy them to `deps/` and reference from there to maintain linux build compatibility.
  * When hot-reloading, events like `CharacterFilter.LoginComplete` have already triggered when the plugin reloads so the plugin will never see them. During plugin startup, you can check the current login state to determine if this is a normal load, or a hot one.
  ```csharp
    protected override void Startup() {
        var isHotReload = CoreManager.Current.CharacterFilter.LoginStatus == 3;
    }
  ```
  * If hot-reloading is being prevented because `<YourPlugin>.Loader` is trying to be recompiled and is locked by acclient, you can right click the `<YourPlugin>.Loader` project in the Visual Studio `Solution Explorer` and select `Unload Project` to prevent it from being rebuilt. **Note:** You must build `<YourPlugin>.Loader` at least once before unloading the project, if you want to use hot-reloading.
