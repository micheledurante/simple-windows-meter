using NiceMeter.Visitors.Converters;
using System.Globalization;
using System.Windows.Controls;

namespace NiceMeterTests.ViewModels.Converters
{
    class BaseConverterMock : BaseConverter
    {
        public override TextBlock Convert(float? value, string measurementUnit, string numberFormat, CultureInfo culture = null)
        {
            throw new System.NotImplementedException(); // No need to implement any methods on test mocks
        }
    }
}
