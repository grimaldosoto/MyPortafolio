using Catalog.Infrastructure.Commons.Bases.Response;
using Catalog.Utilities;

namespace Catalog.Infrastructure.FileExcel
{
    public interface IGenerateExcel
    {
        MemoryStream GenerateToExcel<T>(BaseEntityResponse<T> data, List<TableColumn> columns);
    }
}
