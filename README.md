# .NET Client for Harbor Remote API

This library allows you to interact with [Harbor REST API]  endpoints in your .NET applications.

## Versioning

Support Harbor v2.3.3
## Installation

[![NuGet latest release](https://img.shields.io/nuget/v/Harbor.Client.svg)](https://www.nuget.org/packages/Harbor.Client)

You can add this library to your project using [NuGet][nuget].

**Package Manager Console**
Run the following command in the “Package Manager Console”:

> PM> Install-Package Harbor.Client

**Visual Studio**
Right click to your project in Visual Studio, choose “Manage NuGet Packages” and search for ‘Harbor.Client’ and click ‘Install’.
([see NuGet Gallery][nuget-gallery].)

**.NET Core Command Line Interface**
Run the following command from your favorite shell or terminal:

> dotnet add package Harbor.Client


## Usage

You can initialize the client like the following:

```csharp
using Harbor.Client;
using Harbor.Client.Group.Model;
using System.Threading.Tasks;

        HarborClientConfiguration _HarborClientConfiguration = new HarborClientConfiguration(new HarborConfig("admin", "Harbor12345", "192.168.189.99:8088"));

         using (HarborClient _HarborClient = _HarborClientConfiguration.CreatHarborClient())
            {
                var result = await _HarborClient.Repository.ListRepositoriesByProject(new Harbor.Client.Group.Model.ListRepositoriesByProjectParam()
                {
                    project_name = projectname
                });
            }
```