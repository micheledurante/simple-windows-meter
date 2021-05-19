# The Simple (Windows) Meter

[![Build status](https://ci.appveyor.com/api/projects/status/6g8u1m4cj3574tnp?svg=true)](https://ci.appveyor.com/project/micheled/simple-windows-meter)

An unintrusive hardware meter monitor UI, based on [OpenHardwareMonitor](https://openhardwaremonitor.org/)

## Setup
1. Install [Paket](https://fsprojects.github.io/Paket/get-started.html#NET-Core-preferred)
1. `dotnet tool restore`
1. `dotnet paket restore`
1. `dotnet paket install`
1. `git submodule update --init --recursive`
3. Open the solution `NiceMeter/NiceMeter.sln`
4. Run the tests in the `NiceMeterTest` project
