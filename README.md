# The Nice (Windows) Stats Meter

A nicer Windows stats meter. Based on [OpenHardwareMonitor](https://openhardwaremonitor.org/). Requires Windows admin priviledges to run.

## Setup
1. Run `.paket/paket.exe install` from the root directory to install the project dependencies
1. Run all tests located in the `NiceMeterTests/` project

## Errors
The application logs to a file located in this path `${USERPROFILE}\AppData\Roaming\NiceMeter\nice-meter.log`. Logs contain error messages and other useful troubleshooting information.

In addition, this is the list of the program's error exit codes:
- 901 -> 1000 (Program-related errors)
    - `901` = No observable meters provided. Cannot Create the view
    - `909` = An exception occurred
