using Catalog.Application.Commons.Bases.Response;
using Catalog.Application.Dtos.User.Request;

namespace Catalog.Application.Interfaces
{
    public interface IUserApplication
    {
        Task<BaseResponse<bool>> CreateUser(UserRequestDto requestDto);
        Task<BaseResponse<string>> GenerateToken(TokenRequestDto requestDto);
    }
}
