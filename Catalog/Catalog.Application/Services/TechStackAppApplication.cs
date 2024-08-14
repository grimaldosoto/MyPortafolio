using AutoMapper;
using Catalog.Application.Commons.Bases;
using Catalog.Application.Dtos.TechStackApp;
using Catalog.Application.Interfaces;
using Catalog.Infrastructure.Commons.Bases.Request;
using Catalog.Infrastructure.Commons.Bases.Response;
using Catalog.Infrastructure.Persistences.Interfaces;
using Catalog.Utilities.Static;

namespace Catalog.Application.Services
{
    public class TechStackAppApplication : ITechStackAppApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TechStackAppApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<BaseEntityResponse<TechStackAppResponseDto>>> ListTechStackApps(BaseFiltersRequest filters)
        {
            var response = new BaseResponse<BaseEntityResponse<TechStackAppResponseDto>>();
            var techStackApps = await _unitOfWork.TechStackApp.ListTechStackApps(filters);

            if(techStackApps is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<BaseEntityResponse<TechStackAppResponseDto>>(techStackApps);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }
    }
}
