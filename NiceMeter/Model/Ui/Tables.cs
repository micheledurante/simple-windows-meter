using System.Collections.Generic;

/// <summary>
/// Defines a container with behaviour for Table classes
/// </summary>
namespace NiceMeter.Model.Ui
{
    /// <summary>
    /// The container of Table classes
    /// </summary>
    public class Tables : UiAbstract
    {
        /// <summary>
        /// Get and set all tables
        /// </summary>
        public List<Table> AllTables { get; set; }

        /// <summary>
        /// Indicates if the current instance has any data
        /// </summary>
        public bool Data { get; set; }

        /// <summary>
        /// Check if the instance has any data
        /// </summary>
        /// <returns></returns>
        public override bool HasData()
        {
            Data = AllTables.Count != 0;
            return Data;
        }
    }
}
