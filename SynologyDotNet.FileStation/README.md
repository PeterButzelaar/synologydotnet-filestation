# SynologyDotNet.FileStation
Synology FileStation client for .NET.

* Requires [SynologyDotNet.Core](https://www.nuget.org/packages/SynologyDotNet.Core/)
* Targets **.NET Standard 2.0**

## [NuGet package](https://www.nuget.org/packages/SynologyDotNet.FileStation/)
```
Install-Package SynologyDotNet.FileStation
```

## Usage examples

### Basic example with SynoClient

In order to consume data, you may also add other NuGet packages like **SynologyDotNet.FileStation**.
This example shows how to configure the connection and login with username and password.  

```
// Create an FileStationClient
var fileStation = new FileStationClient();

// Create the SynoClient which communicates with the server, this can be re-used across all Station Clients.
var client = new SynoClient(new Uri("https://MySynolgyNAS:5001/")).Add(fileStation);

// Login
await client.LoginAsync("username", "password");

// Get all the shared folders.
var response = await fileStation.ListSharedFoldersAsync();
foreach(var share in response.Data.Shares)
    Console.WriteLine(share);
```
