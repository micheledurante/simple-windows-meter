using NiceMeter.Meters.Converters;
using System.Windows.Controls;

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
        /// What this value should be called
        /// </summary>
        public readonly string Label;
        public TextBlock TextBlock { get; set; }
        protected readonly string measurementUnit;
        protected readonly string numberFormat;
        protected readonly IUnitConverter unitConverter;

        public Unit(string Label, float? Value, string measurementUnit, string numberFormat, IUnitConverter unitConverter = null)
        {
            this.Label = Label;
            this.Value = Value;
            this.measurementUnit = measurementUnit;
            this.numberFormat = numberFormat;
            this.unitConverter = unitConverter ?? new SimpleUnitConverter();
        }

        /// <inheritdoc/>
        public IUnit Convert()
        {
            TextBlock = unitConverter.Convert(Value, measurementUnit, numberFormat);
            return this;
        }

        public TextBlock GetTextBlock()
        {
            return TextBlock;
        }
    }
}
