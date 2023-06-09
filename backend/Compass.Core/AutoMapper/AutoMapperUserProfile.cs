﻿using AutoMapper;
using Compass.Core.DTO_s;
using Compass.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compass.Core.AutoMapper
{
    internal class AutoMapperUserProfile : Profile
    {
        public AutoMapperUserProfile()
        {
            CreateMap<AppUser, ResiterUserDto>();
            CreateMap<AppUser, AllUsersDto>().ReverseMap();
            CreateMap<ResiterUserDto, AppUser>().ForMember(dst => dst.UserName, act => act.MapFrom(src => src.Email));
        }
    }
}
