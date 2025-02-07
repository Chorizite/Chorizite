# Chorizite

**Chorizite** is an open-source plugin manager for the game *Asheron's Call*. It enables the integration and management of plugins that extend the game's functionality. This project includes core plugins for various features such as HTML/CSS-based UI design, DAT file reading, and Lua scripting support.

## Table of Contents

- [Introduction](#introduction)
- [Dependencies](#dependencies)
- [Installation](#installation)
- [Building](#building)
- [Roadmap](#roadmap)
- [Contributing](#contributing)
- [License](#license)

## Introduction

Chorizite serves as a plugin framework for *Asheron's Call*, allowing developers to create and manage plugins for the game. It provides essential tools for interfacing with the game files, rendering HTML/CSS-based interfaces, and scripting with Lua.

## Dependencies

- [.NET 8.0+](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
  - Runtime is needed for all users
  - SDK is needed for building
- [Microsoft Visual C++ Redistributable](https://aka.ms/vs/17/release/vc_redist.x86.exe)
- [DirectX End-User Runtimes (June 2010)](https://www.microsoft.com/en-ie/download/details.aspx?id=8109)

## Installation

1. Install [Dependencies](#dependencies)
2. Grab latest installer from releases

## Building

1. Install [Dependencies](#dependencies)
2. Clone repository: `git clone git@github.com:Chorizite/Chorizite.git`
3. Build `Release` in visual studio / `dotnet restore && dotnet build -c Release`
4. Run installer at bin/Chorizite-Installer*. Make sure you change the installation directory to the bin/net8.0/ directory you just built to (only needs to be done once)

## Contributing

Contributions are welcome! To contribute:
1. Fork the repository.
2. Create a new branch for your feature or bugfix.
3. Submit a pull request with a detailed description.

## License

This project is licensed under the [MIT License](LICENSE.md).