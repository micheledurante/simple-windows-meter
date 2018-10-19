using NiceMeter.Interfaces;
using NiceMeter.ViewModels;
using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NiceMeter.Meter
{
    class HardwareVisitor : IVisitor
    {
        private ObservableCollection<IDictionary<int, IMeter>> collection = new ObservableCollection<IDictionary<int, IMeter>>();

        public void VisitComputer(IComputer computer)
        {
            var x = 0;
        }

        public void VisitHardware(IHardware hardware)
        {
            switch (hardware.HardwareType)
            {
                case HardwareType.Mainboard:
                    collection.Add(new Dictionary<int, IMeter> { { (int)HardwareType.Mainboard, new MainboardMeter(hardware.Name).FormatValues(hardware.Sensors) } });
                    break;

                case HardwareType.CPU:
                    collection.Add(new Dictionary<int, IMeter> { { (int)HardwareType.CPU, new CpuMeter(hardware.Name).FormatValues(hardware.Sensors) } });
                    break;
            }
        }

        public void VisitParameter(IParameter parameter)
        {
            throw new NotImplementedException();
        }

        public void VisitSensor(ISensor sensor)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<IDictionary<int, IMeter>> GetCollection()
        {
            return collection;
        }
    }
}
