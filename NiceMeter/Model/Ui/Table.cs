using System.Collections.Generic;

/// <summary>
/// Defines the UI model for displaying/adding/removing table data
/// </summary>
namespace NiceMeter.Model.Ui
{
    /// <summary>
    /// Defines data structure and behaviour of a table instance
    /// </summary>
    public class Table : UiAbstract
    {
        /// <summary>
        /// Table header data
        /// </summary>
        public Dictionary<string, string> Header { get; set; }

        /// <summary>
        /// Individual table row data
        /// </summary>
        public IList<Dictionary<string, string>> Rows;

        /// <summary>
        /// Indicates if the current instance has any data
        /// </summary>
        public bool Data { get; set; }

        /// <summary>
        /// Adds a row to the current table instance
        /// </summary>
        /// <param name="Row"></param>
        public void AddRow(Dictionary<string, string> Row)
        {
            Rows.Add(Row);
        }

        /// <summary>
        /// Returns the current instance as a formatted data structure for a table UI
        /// </summary>
        /// <returns></returns>
        public List<Dictionary<string, string>> GetTable()
        {
            if (!HasData())
                return null;

            var Table = new List<Dictionary<string, string>>();

            Table.Add(Header);

            foreach (var Row in Rows)
            {
                Table.Add(Row);
            }

            return Table;
        }

        /// <summary>
        /// Check if the instance has any data
        /// </summary>
        /// <returns>True or false</returns>
        public override bool HasData()
        {
            Data = Header != null && Rows != null;
            return Data;
        }
    }
}
