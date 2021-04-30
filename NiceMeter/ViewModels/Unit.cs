using NiceMeter.ViewModels.Converters;
using System.Windows.Controls;

namespace NiceMeter.ViewModels
{
    /// <summary>
    /// Represent a meter value, define a value, its measurement unit and the instance of its NiceMeter.ViewModels.Converters
    /// </summary>
    public class Unit : IUnit
    {
        private float? value;
        public float? Value
        {
            set { this.value = value; }
        }
        private readonly string measurementUnit;
        private readonly string numberFormat;
        private readonly IUnitConverter unitConverter;

        public Unit(float? value, string measurementUnit, string numberFormat, IUnitConverter unitConverter = null)
        {
            this.value = value;
            this.measurementUnit = measurementUnit;
            this.numberFormat = numberFormat;
            this.unitConverter = unitConverter ?? new SimpleUnitConverter();
        }

        /// <inheritdoc/>
        public TextBlock Convert()
        {
            return unitConverter.Convert(value, measurementUnit, numberFormat);
        }
    }
}
