local plugin = require('Plugins.Launcher')
local launcherBackend = require("LauncherBackend")
local rx = require('rx')
local json = require('json')

local SETTINGS_FILE = plugin.DataDirectory .. "/simplelogin.json"

---@class SimpleLoginDetails
---@field username string
---@field password string
---@field server string
---@field clientpath string


---@type SimpleLoginDetails
local settings = {
  clientpath = "",
  username = "",
  password = "",
  server = ""
}

local function loadSettings()
  -- read settings file
  local settingsfile = io.open(SETTINGS_FILE, "r")
  if settingsfile ~= nil then
    settings = json.decode(settingsfile:read("a"))
    settingsfile:close()
  end

  -- default settings
  if settings.clientpath == nil or #settings.clientpath == 0 then
    settings.clientpath = "C:\\Turbine\\Asheron's Call\\acclient.exe"
  end
  if settings.server == nil or #settings.server == 0 then
    settings.server = "play.coldeve.ac:9000"
  end

  return settings
end

---save settings from state to a file
---@param state SimpleLoginDetails
local function saveSettings(state)
  -- TODO: debounce
  local settingsfile = io.open(SETTINGS_FILE, "w")
  
  if settingsfile == nil then
    error("Error saving settings to file: ".. settingsfile)
  end

  settingsfile:write(json.encode({
    username = state.username,
    password = state.password,
    clientpath = state.clientpath,
    server = state.server
  }));

  settingsfile:flush()
  settingsfile:close()
end

---@type SimpleLoginDetails
local state = rx:CreateState(loadSettings())

local SimpleLoginView = function ()
  return rx:Div({ class = 'wrap' }, {
    rx:Div({ class = 'formline' }, {
      rx:Label("Username:", { ['for'] = 'username' }),
      rx:Input({
        type = 'text',
        name = 'username',
        value = state.username,
        onchange = function(evt)
          state.username = evt.Params.value
          saveSettings(state)
        end
      })
    }),
    rx:Div({ class = 'formline' }, {
      rx:Label("Password:", { ['for'] = 'password' }),
      rx:Input({
        type = 'password',
        name = 'password',
        value = state.password,
        onchange = function(evt)
          state.password = evt.Params.value
          saveSettings(state)
        end
      })
    }),
    rx:Div({ class = 'formline' }, {
      rx:Label("Server:", { ['for'] = 'server' }),
      rx:Input({
        type = 'text',
        name = 'server',
        value = state.server,
        onchange = function(evt)
          state.server = evt.Params.value
          saveSettings(state)
        end
      })
    }),
    rx:Div({ class = 'formline' }, {
      rx:Label("Client Path:", { ['for'] = 'clientpath' }),
      rx:Input({
        type = 'text',
        name = 'clientpath',
        value = state.clientpath,
        onchange = function(evt)
          state.clientpath = evt.Params.value
          saveSettings(state)
        end
      })
    }),
    rx:Div({ class = 'actions' }, {
      rx:Button({
        onclick = function()
          launcherBackend:LaunchClient(state.clientpath, state.server, state.username, state.password)
        end
      }, "Launch"),
    }),
  })
end

document:Mount(function () return SimpleLoginView() end, '#content')
