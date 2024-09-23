using Microsoft.AspNetCore.Http;

namespace Catalog.Infrastructure.FileStorage
{
    public interface IAzureStorage
    {
        Task<string> SaveFile(string container, IFormFile file);
        Task<string> EditFile(string container, IFormFile file, string route);
        Task RemoveFile(string container, string route);

    }
}
