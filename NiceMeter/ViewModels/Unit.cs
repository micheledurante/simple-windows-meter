namespace NiceMeter.ViewModels
{
    public class Unit
    {
        private float? value;
        public float? Value
        {
            set { this.value = value; }
        }
        private readonly string measurementUnit;
        private readonly string formatSpecifier;

        public Unit(float? value, string measurementUnit, string formatSpecifier)
        {
            this.value = value;
            this.measurementUnit = measurementUnit;
            this.formatSpecifier = formatSpecifier;
        }

        public override string ToString()
        {
            return string.Format("{0}{1}", string.Format(formatSpecifier, value), measurementUnit);
        }
    }
}
