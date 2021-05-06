namespace NiceMeter.Models
{
    public class HardwareConfig : IHardwareConfig
    {
        public bool MainboardEnabled { get; set; } = false;
        public bool CPUEnabled { get; set; } = false;
        public bool RAMEnabled { get; set; } = false;
        public bool GPUEnabled { get; set; } = false;
        public bool FanControllerEnabled { get; set; } = false;
        public bool HDDEnabled { get; set; } = false;

        public HardwareConfig AllHardwareConfig()
        {
            return new HardwareConfig
            {
                MainboardEnabled = true,
                CPUEnabled = true,
                RAMEnabled = true,
                GPUEnabled = true,
                FanControllerEnabled = true,
                HDDEnabled = true
            };
        }

        public HardwareConfig TestingHardwareConfig()
        {
            return new HardwareConfig
            {
                MainboardEnabled = true,
                CPUEnabled = true,
                RAMEnabled = false,
                GPUEnabled = false,
                FanControllerEnabled = false,
                HDDEnabled = false
            };
        }
    }
}
