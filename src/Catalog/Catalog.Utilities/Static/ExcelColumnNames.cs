namespace Catalog.Utilities.Static
{
    public class ExcelColumnNames
    {
        public static List<TableColumn> GetColumns(IEnumerable<(string ColumnName, string PropertyName)> columnsProperties)
        {
            var columns = new List<TableColumn> ();

            foreach (var (ColumnName, PropertyName) in columnsProperties) {
                var column = new TableColumn() { 
                    Label = ColumnName,
                    PropertyName = PropertyName
                };
              columns.Add(column);
            }

            return columns;
        }

        #region columnsTechStackApp
        public static List<(string ColumnName, string PropertyName)> GetColumnTechStackApp()
        {
            var columnsProperties = new List<(string ColumnName, string PropertyName)>
            {
                ("ReleaseDate", "ReleaseDateApp"),
                ("NOMBRE", "NameApp"),
                ("URL","LiveLinkApp")
            };
            return columnsProperties;
        }
        #endregion

        #region columnsTechnolgy
        public static List<(string ColumnName, string PropertyName)> GetColumnTechnology()
        {
            var columnsProperties = new List<(string ColumnName, string PropertyName)>
            {
                ("NOMBRE", "Name"),
                ("VERSIÓN", "Version"),
                ("DESCRIPCIÓN","Description")
            };
            return columnsProperties;
        }
        #endregion



    }
}
