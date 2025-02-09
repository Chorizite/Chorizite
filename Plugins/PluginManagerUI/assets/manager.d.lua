---@meta

---@class PluginManagerUIState
---@field isLoading boolean
---@field isLoadingDetails boolean
---@field showBetas boolean
---@field selectedVersion string
---@field selectedPluginDetails? PluginReleaseInfo
---@field selectedPlugin string
---@field availablePlugins { [string]: PluginInfo }
---@field installedPlugins { [string]: PluginInfo }

---@class PluginInfo
---@field name string
---@field version string
---@field latestVersion? string
---@field isInstalled boolean
---@field description string
---@field author string

---@class ReleaseJson
---@field Plugins { [string]: PluginReleaseInfo }

---@class ReleaseInfo
---@field Name string
---@field Version? string
---@field IsBeta? boolean
---@field Changelog? string
---@field DownloadUrl? string
---@field Date? string

---@class PluginReleaseInfo
---@field Name string
---@field Description string
---@field Author string
---@field RepoUrl? string
---@field Latest ReleaseInfo
---@field LatestBeta? ReleaseInfo
---@field Releases? ReleaseInfo[]