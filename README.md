# MagicHat

**MagicHat** is an open-source plugin manager for the game *Asheron's Call*. It enables the integration and management of plugins that extend the game's functionality. This project includes core plugins for various features such as HTML/CSS-based UI design, DAT file reading, and Lua scripting support.

## Table of Contents

- [Introduction](#introduction)
- [Dependencies](#dependencies)
- [Installation](#installation)
- [Project Overview](#project-overview)
- [Roadmap](#roadmap)
- [Contributing](#contributing)
- [License](#license)

## Introduction

MagicHat serves as a plugin framework for *Asheron's Call*, allowing developers to create and manage plugins for the game. It provides essential tools for interfacing with the game files, rendering HTML/CSS-based interfaces, and scripting with Lua.

## Dependencies

- [.NET 8.0+](https://dotnet.microsoft.com/en-us/download/dotnet)
- [Microsoft Visual C++ Redistributable](https://aka.ms/vs/17/release/vc_redist.x86.exe)

## Installation

1. Install [Dependencies](#dependencies)

## Project Overview

- **MagicHat.Core**
  - The main MagicHat project.  This is responsible for starting up the plugin system.
- **Launcher/Launcher**
  - The Launcher app. 
  - Implements the required backend interfaces for running **MagicHat.Core** in a launcher environment.
- **Launcher/MagicHat.Injector**
  - Launches acclient and uses **Launcher/MagicHat.Bootstrapper** to inject **Launcher/MagicHat.Loader.Standalone** (and optionally decal).
  - A separate app from the launcher is used because this is x86 where the launcher is x64. This makes it easier to do the injection.
- **Launcher/MagicHat.Bootstrapper**
  - Used to bootstrap dotnet inside the client, and loads **Launcher/MagicHat.Loader.Standalone**.
- **Launcher/MagicHat.Loader.Standalone**
  - Implements the required backend interfaces for running **MagicHat.Core** in a client environment.
- **Plugins**
  - **Core.Client**
    - Provides API / Hooks for interacting with the game client.
  - **Core.Launcher**
    - Provides API / Hooks for interacting with the launcher.
  - **Core.DatService**
    - Provides API / Hooks for reading / writing game dat files.
  - **Core.UI**
    - Provides UI interface for both the client and launcher using [RmlUI](https://github.com/mikke89/RmlUi).
  - **Core.Lua**
    - Provides lua scripting for plugins and RmlUI scripts.

## Roadmap

- [ ] Plugin System
  - [X] CSharp plugins
  - [ ] Lua plugins
- [ ] UI:
  - [ ] Launcher Screens: <strike>Simple</strike>, Advanced
  - [ ] Game screens: <strike>DatPatch</strike>, <strike>Intro</strike>, <strike>CharSelect</strike>, GamePlay, Disconnected
  - [ ] Lua: lua scripting within rmlui.
  - [ ] ImGui
- [ ] API:
  - [ ] Game API / Hooks
- [ ] Server Integration:
  - [ ] Custom UIs from server 
  - [ ] Custom plugins from server

## Contributing

Contributions are welcome! To contribute:
1. Fork the repository.
2. Create a new branch for your feature or bugfix.
3. Submit a pull request with a detailed description.

## License

This project is licensed under the [MIT License](LICENSE.md).