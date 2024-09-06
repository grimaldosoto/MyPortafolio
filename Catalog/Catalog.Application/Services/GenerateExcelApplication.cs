using Catalog.Application.Interfaces;
using Catalog.Infrastructure.FileExcel;
using Catalog.Utilities.Static;

namespace Catalog.Application.Services
{
    public class GenerateExcelApplication : IGenerateExcelApplication
    {  
        private readonly IGenerateExcel _generateExcel;

        public GenerateExcelApplication(IGenerateExcel generateExcel)
        {
            _generateExcel = generateExcel;
        }

        public byte[] GenerateToExcel<T>(IEnumerable<T> data, List<(string ColumnName, string PropertyName)> columns)
        {
            var excelColumns = ExcelColumnNames.GetColumns(columns);
            var memoryStreamExcel = _generateExcel.GenerateToExcel(data, excelColumns);
            var fileBytes = memoryStreamExcel.ToArray();

            return fileBytes;

        }

    }
}
