using AutoMapper;
using Catalog.Application.Commons.Bases.Request;
using Catalog.Application.Commons.Bases.Response;
using Catalog.Application.Commons.Ordering;
using Catalog.Application.Dtos.TechStackApp.Request;
using Catalog.Application.Dtos.TechStackApp.Response;
using Catalog.Application.Interfaces;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Persistences.Interfaces;
using Catalog.Utilities.Static;
using Microsoft.EntityFrameworkCore;
using WatchDog;

namespace Catalog.Application.Services
{
    public class TechStackAppApplication : ITechStackAppApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IOrderingQuery _orderingQuery;

        public TechStackAppApplication(IUnitOfWork unitOfWork,
            IMapper mapper,
            IOrderingQuery orderingQuery)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _orderingQuery = orderingQuery;

        }

        public async Task<BaseResponse<bool>> CreateTechStachApp(TechStackAppRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();

            try
            {
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
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_EXCEPTION;
                WatchLogger.Log(ex.Message);
            }

            return response;
        }

        public async Task<BaseResponse<bool>> DeleteTechStackApp(int techStackAppId)
        {
            var response = new BaseResponse<bool>();

            try
            {
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
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_EXCEPTION;
                WatchLogger.Log(ex.Message);
            }

            return response;
        }

        public async Task<BaseResponse<IEnumerable<TechStackAppResponseDto>>> ListTechStackApps(BaseFiltersRequest filters)
        {
            var response = new BaseResponse<IEnumerable<TechStackAppResponseDto>>();

            try
            {
                var techStackApps = _unitOfWork.TechStackApp.GetAllQueryable()
                    .Include(x => x.App)
                    .Include(x => x.Technology)
                    .AsQueryable();

                if (filters.NumFilter is not null && !string.IsNullOrEmpty(filters.TextFilter))
                {
                    switch (filters.NumFilter)
                    {
                        // Filtro por nombre de la aplicación
                        case 1:
                            techStackApps = techStackApps.Where(x => x.App.Name.Contains(filters.TextFilter));
                            break;
                    }
                }

                //filtro por rango de fechas del campo ReleaseDate
                if (filters.StartDate is not null && filters.EndDate is not null)
                {
                    techStackApps = techStackApps.Where(x =>
                    x.App.ReleaseDate >= Convert.ToDateTime(filters.StartDate) && x.App.ReleaseDate <= Convert.ToDateTime(filters.EndDate)
                    .AddDays(1));
                }

                //Ordenamiento por Id por defecto
                if (filters.Sort is null) filters.Sort = "Id";
                var items = await _orderingQuery.Ordering(filters, techStackApps, !(bool)filters.Download!).ToListAsync();

                response.IsSuccess = true;
                response.TotalRecords = await techStackApps.CountAsync();
                response.Data = _mapper.Map<IEnumerable<TechStackAppResponseDto>>(items);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_EXCEPTION;
                WatchLogger.Log(ex.Message);
            }

            return response;
        }

        public async Task<BaseResponse<TechStackAppResponseDto>> TechStackAppById(int techStackAppId)
        {
            var response = new BaseResponse<TechStackAppResponseDto>();

            try
            {
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
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_EXCEPTION;
                WatchLogger.Log(ex.Message);
            }

            return response;
        }

        public async Task<BaseResponse<bool>> UpdateTechStackApp(int techStackAppId, TechStackAppRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();

            try
            {
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
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_EXCEPTION;
                WatchLogger.Log(ex.Message);
            }

            return response;
        }
    }
}
