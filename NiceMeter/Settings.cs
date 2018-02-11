using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;

namespace NiceMeter
{
    class Settings : ISettings
    {
        private IDictionary<string, string> settings = new Dictionary<string, string>();

        public Settings(IDictionary<string, string> settings)
        {
            this.settings = settings;
        }

        public bool Contains(string name)
        {
            return settings.ContainsKey(name);
        }

        public string GetValue(string name, string value)
        {
            string result;
            if (settings.TryGetValue(name, out result))
                return result;
            else
                return value;
        }

        public void Remove(string name)
        {
            settings.Remove(name);
        }

        public void SetValue(string name, string value)
        {
            settings[name] = value;
        }
    }
}
