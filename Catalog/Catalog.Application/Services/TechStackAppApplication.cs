﻿using AutoMapper;
using Catalog.Application.Commons.Bases;
using Catalog.Application.Dtos.TechStackApp.Request;
using Catalog.Application.Dtos.TechStackApp.Response;
using Catalog.Application.Interfaces;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Commons.Bases.Request;
using Catalog.Infrastructure.Commons.Bases.Response;
using Catalog.Infrastructure.Persistences.Interfaces;
using Catalog.Utilities.Static;
using WatchDog;

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

        public async Task<Commons.Bases.BaseEntityResponse<bool>> CreateTechStachApp(TechStackAppRequestDto requestDto)
        {
            var response = new Commons.Bases.BaseEntityResponse<bool>();

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

        public async Task<Commons.Bases.BaseEntityResponse<bool>> DeleteTechStackApp(int techStackAppId)
        {
            var response = new Commons.Bases.BaseEntityResponse<bool>();

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

        public async Task<Commons.Bases.BaseEntityResponse<Infrastructure.Commons.Bases.Response.BaseEntityResponse<TechStackAppResponseDto>>> ListTechStackApps(BaseFiltersRequest filters)
        {
            var response = new Commons.Bases.BaseEntityResponse<Infrastructure.Commons.Bases.Response.BaseEntityResponse<TechStackAppResponseDto>>();

            try
            {
                var techStackApps = await _unitOfWork.TechStackApp.ListTechStackApps(filters);

                if (techStackApps is not null)
                {
                    response.IsSuccess = true;
                    response.Data = _mapper.Map<Infrastructure.Commons.Bases.Response.BaseEntityResponse<TechStackAppResponseDto>>(techStackApps);
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

        public async Task<Commons.Bases.BaseEntityResponse<TechStackAppResponseDto>> TechStackAppById(int techStackAppId)
        {
            var response = new Commons.Bases.BaseEntityResponse<TechStackAppResponseDto>();

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

        public async Task<Commons.Bases.BaseEntityResponse<bool>> UpdateTechStackApp(int techStackAppId, TechStackAppRequestDto requestDto)
        {
            var response = new Commons.Bases.BaseEntityResponse<bool>();

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
