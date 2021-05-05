using System.Globalization;
using System.Threading;

namespace NiceMeter.Meters.Units
{
    /// <summary>
    /// Represent a meter value, define a value, its measurement unit and the instance of its NiceMeter.ViewModels.Converters
    /// </summary>
    public class Unit : IUnit
    {
        /// <summary>
        /// A copy of the visited hardware sensor's data
        /// </summary>
        public float? Value { get; set; }
        /// <summary>
        /// What this value should be called in our UI
        /// </summary>
        public readonly string Label;

        /// <summary>
        /// OpenHardwareMonitor's name for the sensor
        /// </summary>
        public string OHName { get; set; }
        public readonly string measurementUnit;
        public readonly string numberFormat;

        public Unit(string OHName, string Label, float? Value, string measurementUnit, string numberFormat)
        {
            this.OHName = OHName;
            this.Label = Label;
            this.Value = Value;
            this.measurementUnit = measurementUnit;
            this.numberFormat = numberFormat;
        }

        /// <summary>
        /// Format the given float value according to the given number format and culture
        /// </summary>
        /// <param name="value"></param>
        /// <param name="numberFormat"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public string FormatFloatValue(float? value, string numberFormat, CultureInfo culture = null)
        {
            return string.Format(culture ?? Thread.CurrentThread.CurrentCulture, numberFormat, value);
        }

        public override string ToString()
        {
            return string.Format("{0}: {1} {2}", Label, FormatFloatValue(Value, numberFormat), measurementUnit);
        }
    }
}
