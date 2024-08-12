using AutoMapper;
using Catalog.Application.Dtos.User.Request;
using Catalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Mappers
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserRequestDto,User >();
            CreateMap<TokenRequestDto, User>();
        }
    }
}
