using Catalog.Application.Commons.Bases;
using Catalog.Application.Dtos.User.Request;

namespace Catalog.Application.Interfaces
{
    public interface IUserApplication
    {
        Task<BaseEntityResponse<bool>> CreateUser(UserRequestDto requestDto);
        Task<BaseEntityResponse<string>> GenerateToken(TokenRequestDto requestDto);
    }
}
