using AutoMapper;
using Catalog.Application.Commons.Bases.Request;
using Catalog.Application.Commons.Bases.Response;
using Catalog.Application.Commons.Ordering;
using Catalog.Application.Dtos.Category.Request;
using Catalog.Application.Dtos.Category.Response;
using Catalog.Application.Interfaces;
using Catalog.Application.Validators.Technology;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Persistences.Interfaces;
using Catalog.Utilities.Static;
using Microsoft.EntityFrameworkCore;
using WatchDog;

namespace Catalog.Application.Services
{
    public class TechnologyApplication : ITechnologyApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly TechnologyValidator _validatorRules;
        private readonly IOrderingQuery _orderingQuery;

        public TechnologyApplication(IUnitOfWork unitOfWork,
            IMapper mapper,
            TechnologyValidator validatorRules,
            IOrderingQuery orderingQuery)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validatorRules = validatorRules;
            _orderingQuery = orderingQuery;
        }

        public async Task<BaseResponse<bool>> CreateTechnology(TechnologyRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var validationResult = await _validatorRules.ValidateAsync(requestDto);

                if (!validationResult.IsValid)
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_VALIDATE;
                    response.Errors = validationResult.Errors;

                    return response;
                }

                var technology = _mapper.Map<Technology>(requestDto);
                response.Data = await _unitOfWork.Technology.CreateAsync(technology);

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
        public async Task<BaseResponse<IEnumerable<TechnologyResponseDto>>> ReadTechnologies(BaseFiltersRequest filters)
        {
            var response = new BaseResponse<IEnumerable<TechnologyResponseDto>>();

            try
            {
                var technologies = _unitOfWork.Technology.GetAllQueryable();

                // ==> Filtros
                // Filtro por Nombre o Descripción
                if (filters.NumFilter is not null && !string.IsNullOrEmpty(filters.TextFilter))
                {
                    switch (filters.NumFilter)
                    {
                        case 1:
                            technologies = technologies.Where(x => x.Name!.Contains(filters.TextFilter));
                            break;
                        case 2:
                            technologies = technologies.Where(x => x.Description!.Contains(filters.TextFilter));
                            break;
                    }
                }
                // Ordenamiento por default TechnologyID
                if (filters.Sort is null) filters.Sort = "Id";
                var items = await _orderingQuery.Ordering(filters, technologies, !(bool)filters.Download!).ToListAsync();
                // ==> EndFiltros

                response.IsSuccess = true;
                response.TotalRecords = await technologies.CountAsync();
                response.Data = _mapper.Map<IEnumerable<TechnologyResponseDto>>(items);
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
        public async Task<BaseResponse<bool>> UpdateTechnology(int technologyId, TechnologyRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var technolgyUpdate = await TechnologyById(technologyId);

                if (technolgyUpdate.Data is null)
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;

                    return response;
                }

                var technology = _mapper.Map<Technology>(requestDto);
                technology.Id = technologyId;
                response.Data = await _unitOfWork.Technology.UpdateAsync(technology);

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
        public async Task<BaseResponse<bool>> DeleteTechnology(int technologyId)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var technology = await TechnologyById(technologyId);

                if (technology.Data is null)
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                }

                response.Data = await _unitOfWork.Technology.DeleteAsync(technologyId);

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

        public async Task<BaseResponse<IEnumerable<TechnologySelectResponseDto>>> ListSelectTechnologies()
        {
            var response = new BaseResponse<IEnumerable<TechnologySelectResponseDto>>();
            try
            {
                var technologies = await _unitOfWork.Technology.GetAllAsync();

                if (technologies is null)
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                    return response;
                }
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<TechnologySelectResponseDto>>(technologies);
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
        public async Task<BaseResponse<TechnologyResponseDto>> TechnologyById(int technologyId)
        {
            var response = new BaseResponse<TechnologyResponseDto>();
            try
            {
                var tecnology = await _unitOfWork.Technology.GetByIdAsync(technologyId);

                if (tecnology is null)
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;

                    return response;
                }

                response.IsSuccess = true;
                response.Data = _mapper.Map<TechnologyResponseDto>(tecnology);
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

    }
}
