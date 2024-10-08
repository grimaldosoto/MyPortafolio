﻿using AutoMapper;
using Catalog.Application.Commons.Bases.Response;
using Catalog.Application.Dtos.User.Request;
using Catalog.Application.Interfaces;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.FileStorage;
using Catalog.Infrastructure.Persistences.Interfaces;
using Catalog.Utilities.Static;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WatchDog;

namespace Catalog.Application.Services
{
    public class UserApplication : IUserApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IAzureStorage _azureStorage;

        public UserApplication(IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IConfiguration configuration,
            IAzureStorage azureStorage)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
            _azureStorage = azureStorage;
        }

        public async Task<BaseResponse<bool>> CreateUser(UserRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var account = _mapper.Map<User>(requestDto);
                account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);

                if (requestDto.Image is not null)
                {
                    account.Image = await _azureStorage.SaveFile(AzureContainers.USERS, requestDto.Image);
                }

                response.Data = await _unitOfWork.User.CreateAsync(account);

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

        public async Task<BaseResponse<string>> GenerateToken(TokenRequestDto requestDto)
        {
            var response = new BaseResponse<string>();

            try
            {
                var account = await _unitOfWork.User.AccountByUserName(requestDto.UserName!);

                if (account is not null)
                {
                    if (BCrypt.Net.BCrypt.Verify(requestDto.Password, account.Password))
                    {
                        response.IsSuccess = true;
                        response.Data = GenerateToken(account);
                        response.Message = ReplyMessage.MESSAGE_TOKEN;

                        return response;
                    }
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_TOKEN_ERROR;
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

        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Email !),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.UserName !),
                new Claim(JwtRegisteredClaimNames.NameId, user.Email !),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, Guid.NewGuid().ToString(), ClaimValueTypes.Integer64)
            };

            var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Issuer"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:expires"])),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: credentials
                );



            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
