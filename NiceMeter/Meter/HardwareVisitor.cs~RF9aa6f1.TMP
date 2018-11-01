using NiceMeter.Interfaces;
using NiceMeter.ViewModels;
using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.ObjectModel;

namespace NiceMeter.Meter
{
    class HardwareVisitor : IVisitor, IVisitorObservable
    {
        private ObservableCollection<IMeter> collection = new ObservableCollection<IMeter>();

        public void VisitComputer(IComputer computer)
        {
            var x = 0;
        }

        public void VisitHardware(IHardware hardware)
        {
            switch (hardware.HardwareType)
            {
                case HardwareType.Mainboard:
                    collection.Add(new MainboardMeter(hardware.Name).FormatSensors(null));
                    break;

                case HardwareType.CPU:
                    collection.Add(new CpuMeter(hardware.Name).FormatSensors(hardware.Sensors));
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

        public ObservableCollection<IMeter> UpdateCollection()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<IMeter> GetDisplayValue()
        {
            foreach (var item in collection)
            {
                item.GetDisplayValue();
            }

            return collection;
        }
    }
}
