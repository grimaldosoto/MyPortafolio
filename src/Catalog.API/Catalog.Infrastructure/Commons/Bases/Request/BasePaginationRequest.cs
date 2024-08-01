namespace Catalog.Infrastructure.Commons.Bases.Request
{
    public class BasePaginationRequest
    {
        public int NumPage { get; set; } = 1; // default un página
        public int NumRecordsPage { get; set; } = 10; // 10 registro por páginas
        public readonly int NumMaxRecordsPage = 50; // número máximo de registros por default
        public string Order { get; set; } = "asc"; // default ascendente
        public string? Sort { get; set; } = null;
        public int Records
        {
            get => NumRecordsPage;
            set
            {
                NumRecordsPage = value > NumMaxRecordsPage ? NumMaxRecordsPage : value;
            }
        }


    }
}
