# `NiceMeter.Models`
Contain the application's internal models extending OpenHardwareMonitor's functionality not related to UI models. See `ViewModels` for that.

A `ComputerModel` instance is a collection of enabled hardware (really, enabled sensors). It accepts a visitor class that will hold the raw sensor values, pre-processed by OpenHardwareMonitor anyway.

A `ComputerModel` exposes some convenience methods to quickly access sensors as this is a common operations and the data structure inherited from OpenHardwareMonitor is not suitable for our usage.
