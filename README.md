# The Nice (Windows) Meter

A nicer Windows stats meter. Based on [OpenHardwareMonitor](https://openhardwaremonitor.org/). Requires Windows admin priviledges to run.

## Development Setup
Install .NET Core if you don't have it already as it's needed by [Paket](https://fsprojects.github.io/Paket/get-started.html#NET-Core-preferred).

Then install dependencies form the root of the project and create the VS 2019 solution:
1. Run `dotnet tool restore`
1. Run `dotnet paket restore`
1. Run `dotnet paket install`
1. Open the solution file located at `NiceMeter/NiceMeter.sln`
1. Run the tests in the `NiceMeterTest` project

All should be fine now to start working.

## Errors
The application logs to a file located in this path `${USERPROFILE}\AppData\Roaming\NiceMeter\nice-meter.log`. Logs contain error messages and other useful troubleshooting information.

In addition, this is the list of the program's error exit codes:
- 901 -> 1000 (Program-related errors)
    - `901` = No observable meters provided. Cannot Create the view
    - `909` = An exception occurred
