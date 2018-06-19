/// <summary>
/// Abstract class for NiceMeter UI elements
/// </summary>
namespace NiceMeter.Model.Ui
{
    /// <summary>
    /// Enforces implementing a method for knowing if the instance of an elements has any data
    /// </summary>
    public abstract class UiAbstract
    {
        public abstract bool HasData();
    }
}
