# The Simple (Windows) Meter

[![Build status](https://ci.appveyor.com/api/projects/status/6g8u1m4cj3574tnp?svg=true)](https://ci.appveyor.com/project/micheled/simple-windows-meter)

An unintrusive hardware meter monitor UI, based on [OpenHardwareMonitor](https://openhardwaremonitor.org/)

## Setup
1. Install [Paket](https://fsprojects.github.io/Paket/get-started.html#NET-Core-preferred) and [chocolatey](https://chocolatey.org/install#individual)
1. `dotnet tool restore`
1. `dotnet paket restore`
1. `dotnet paket install`
1. `git submodule update --init --recursive`
1. Open the solution `NiceMeter/NiceMeter.sln`
1. Run the tests in the `NiceMeterTest` project
1. `choco install opencover.portable`
1. `choco install codecov`
1. `OpenCover.Console.exe -register:user -target:"C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\MSTest.exe" -targetargs:"/testcontainer:.\NiceMeterTests\bin\Debug\NiceMeterTests.dll" -filter:"+[NiceMeterTests*]* -[Test*]*" -output:".\NiceMeter_coverage.xml"`
1. `codecov -f .\NiceMeter_coverage.xml -t the_secret_token`
