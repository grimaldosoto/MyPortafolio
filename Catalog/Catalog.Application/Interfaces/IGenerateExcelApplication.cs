using Catalog.Infrastructure.Commons.Bases.Response;

namespace Catalog.Application.Interfaces
{
    public interface IGenerateExcelApplication
    {
        byte[] GenerateToExcel<T>(BaseEntityResponse<T> data, List<(string ColumnName, string PropertyName)> columns);

    }
}
