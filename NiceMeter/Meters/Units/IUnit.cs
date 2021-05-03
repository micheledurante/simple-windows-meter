using System.Windows.Controls;

namespace NiceMeter.Meters.Units
{
    public interface IUnit
    {
        /// <summary>
        /// Use the internal Converter object to convert to a TextBlock object
        /// </summary>
        /// <returns></returns>
        IUnit Convert();

        TextBlock GetTextBlock();
    }
}
