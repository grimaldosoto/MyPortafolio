using AutoMapper;
using Catalog.Application.Commons.Bases;
using Catalog.Application.Dtos.TechStackApp.Request;
using Catalog.Application.Dtos.TechStackApp.Response;
using Catalog.Application.Interfaces;
using Catalog.Domain.Entities;
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

        public async Task<BaseResponse<bool>> CreateTechStachApp(TechStackAppRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var techStackApp = _mapper.Map<TechStackApp>(requestDto);

            response.Data = await _unitOfWork.TechStackApp.CreateAsync(techStackApp);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_CREATE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }
            return response;
            
        }

        public async Task<BaseResponse<bool>> DeleteTechStackApp(int techStackAppId)
        {
            var response = new BaseResponse<bool>();

            var techStackAppById = await TechStackAppById(techStackAppId);

            if (techStackAppById.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;

                return response;

            }

            response.Data = await _unitOfWork.TechStackApp.DeleteAsync(techStackAppId);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_DELETE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }
            return response;

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

        public async Task<BaseResponse<TechStackAppResponseDto>> TechStackAppById(int techStackAppId)
        {
            var response = new BaseResponse<TechStackAppResponseDto>();
            var techStackApp = await _unitOfWork.TechStackApp.GetByIdAsync(techStackAppId);

            if (techStackApp is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<TechStackAppResponseDto>(techStackApp);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

        public async Task<BaseResponse<bool>> UpdateTechStackApp(int techStackAppId, TechStackAppRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var techStackAppById = await TechStackAppById(techStackAppId);

            if (techStackAppById.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                
                return response;

            }
            var techStackApp = _mapper.Map<TechStackApp>(requestDto);
            techStackApp.Id = techStackAppId;
            response.Data = await _unitOfWork.TechStackApp.UpdateAsync(techStackApp);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_UPDATE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }
            return response;

        }
    }
}
