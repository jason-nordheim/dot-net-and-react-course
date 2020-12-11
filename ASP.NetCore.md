# DotNet API

## Web API Project Structure

```sh
API  # ← root directory
│
│ # ↓ contains project configuration information
├── API.csproj
│
│ #↓ controllers for API endpoints
├── Controllers
│
│ # ↓ Program starts here (main method)
├── Program.cs
│
├── Properties
│   │
│   │  # ↓ Configuration settings for the API (host, port, etc. )
│   └── launchSettings.json
│
│ # ↓ Configuration af API on startup
├── Startup.cs
│
│ # ↓ development settings (overrides default appsettings.json)
├── appsettings.Development.json
│
│ # ↓ global configuration file
├── appsettings.json
│
│ # ↓ folder generated upon compile
├── bin
│   │
│   └── Debug
│       └── netcoreapp3.1
│
│ # ↓ folder generated upon compile
└── obj
    ├── API.csproj.nuget.dgspec.json
    ├── API.csproj.nuget.g.props
    ├── API.csproj.nuget.g.targets
    ├── Debug
    │   └── netcoreapp3.1
    │       ├── API.AssemblyInfo.cs
    │       ├── API.AssemblyInfoInputs.cache
    │       ├── API.assets.cache
    │       ├── API.csprojAssemblyReference.cache
    │       └── project.razor.json
    ├── project.assets.json
    └── project.nuget.cache
```

## Controllers

Controllers in .NET Core use _attribute based routing_ to determine route handling.

-   Controller must inherit from `Microsoft.AspNetCore.Mvc.ControllerBase`
-   Decorators define the routing for a controller → `("api/[controller])`. The name of the controller will be substituted in place of `[controller]`, so a controller named `ValuesController` would result in the endpoint `"api/values/"`

```cs
[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
```
