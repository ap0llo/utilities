# Utilities

## Overview

[![Build Status](https://dev.azure.com/ap0llo/OSS/_apis/build/status/utilities?branchName=master)](https://dev.azure.com/ap0llo/OSS/_build/latest?definitionId=8?branchName=master)

| Package | NuGet.org | MyGet|
|-|-|-|
| `Grynwald.Utilities`               | [![NuGet](https://img.shields.io/nuget/v/Grynwald.Utilities.svg)](https://www.nuget.org/packages/Grynwald.Utilities) | [![MyGet](https://img.shields.io/myget/ap0llo-utilities/vpre/Grynwald.Utilities.svg?label=myget)](https://www.myget.org/feed/ap0llo-utilities/package/nuget/Grynwald.Utilities) |
| `Grynwald.Utilities.Configuration` | [![NuGet](https://img.shields.io/nuget/v/Grynwald.Utilities.Configuration.svg)](https://www.nuget.org/packages/Grynwald.Utilities.Configuration) | [![MyGet](https://img.shields.io/myget/ap0llo-utilities/vpre/Grynwald.Utilities.Configuration.svg?label=myget)](https://www.myget.org/feed/ap0llo-utilities/package/nuget/Grynwald.Utilities.Configuration) |
| `Grynwald.Utilities.Logging` | [![NuGet](https://img.shields.io/nuget/v/Grynwald.Utilities.Logging.svg)](https://www.nuget.org/packages/Grynwald.Utilities.Logging) | [![MyGet](https://img.shields.io/myget/ap0llo-utilities/vpre/Grynwald.Utilities.Logging.svg?label=myget)](https://www.myget.org/feed/ap0llo-utilities/package/nuget/Grynwald.Utilities.Logging) |

- *Grynwald.Utilities* is a collection of utility functions for usage in C#/.NET projects.
- *Grynwald.Utilities.Configuration* provides some utilties for working with coniguration, based on [`IConfiguration`](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-3.1)
- *Grynwald.Utilities.Logging* provides a simple console logger implementation of  [`ILogger`](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-3.1)

## Installation

The libraries are distributed as NuGet package.

- Prerelease builds are available on [MyGet](https://www.myget.org/feed/ap0llo-utilities/package/nuget/Grynwald.Utilities)
- Release versions are available on [NuGet.org](https://www.nuget.org/packages/Grynwald.Utilities)

## API Reference

For documentation of the types in this libary, have a look at the API docs:

- [Utilities](docs/api/Utilities/Grynwald/Utilities/index.md)
- [Utilities.Configuration](docs/api/Utilities.Configuration/Grynwald/Utilities/Configuration/index.md)
- [Utilities.Logging](docs/api/Utilities.Logging/Grynwald/Utilities/Logging/index.md)

## Building from source

Utilities is a .NET Standard library and can be built using the .NET SDK (requires the .NET SDK version 3.1.200 as specified in [global.json](./global.json))

```bat
  dotnet restore .\src\Utilities.sln

  dotnet build .\src\Utilities.sln

  dotnet pack .\src\Utilities.sln
```

## Acknowledgments

*Grynwald.Utilities* was made possible through a number of libraries (aside from .NET Core and .NET Standard).
Thanks to all the people contribution to these projects:

- [Nerdbank.GitVersioning](https://github.com/AArnott/Nerdbank.GitVersioning/)
- [SourceLink](https://github.com/dotnet/sourcelink)
- [xUnit](http://xunit.github.io/)

## Versioning and Branching

The version of the library is automatically derived from git and the information in `version.json` using [Nerdbank.GitVersioning](https://github.com/AArnott/Nerdbank.GitVersioning):

- The master branch  always contains the latest version. Packages produced from master are always marked as pre-release versions (using the `-pre` suffix).
- Stable versions are built from release branches. Build from release branches will have no `-pre` suffix
- Builds from any other branch will have both the `-pre` prerelease tag and the git commit hash included in the version string

To create a new release branch use the [`nbgv` tool](https://www.nuget.org/packages/nbgv/) (at least version `3.0.4-beta`):

```ps1
dotnet tool install --global nbgv --version 3.0.4-beta
nbgv prepare-release
```
