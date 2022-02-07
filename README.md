# .NET Client for Harbor Remote API

This library allows you to interact with [Harbor REST API]  endpoints in your .NET applications.

## Versioning

Support Harbor v2.3.3
## Installation

[![NuGet latest release](https://img.shields.io/nuget/v/Horbor.Client.svg)](https://www.nuget.org/packages/Harbor.Client)

You can add this library to your project using [NuGet][nuget].

**Package Manager Console**
Run the following command in the “Package Manager Console”:

> PM> Install-Package Horbor.Client

**Visual Studio**
Right click to your project in Visual Studio, choose “Manage NuGet Packages” and search for ‘Harbor.Client’ and click ‘Install’.
([see NuGet Gallery][nuget-gallery].)

**.NET Core Command Line Interface**
Run the following command from your favorite shell or terminal:

> dotnet add package Horbor.Client


## Usage

You can initialize the client like the following:

```csharp
using Horbor.Client;
using Horbor.Client.Group.Model;
using System.Threading.Tasks;

        HorborClientConfiguratio _horborClientConfiguratio = new HorborClientConfiguratio(new HarborConfig("admin", "Harbor12345", "192.168.189.99:8088"));

         using (HorborClient _horborClient = _horborClientConfiguratio.CreatHorborClient())
            {
                var result = await _horborClient.Repository.ListRepositoriesByProject(new Horbor.Client.Group.Model.ListRepositoriesByProjectParam()
                {
                    project_name = projectname
                });
            }
```