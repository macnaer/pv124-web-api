using AutoMapper;
using Compass.Core.DTO_s;
using Compass.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compass.Core.Services
{
    public class UserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<ServiceResponse> IncertAsync(ResiterUserDto model)
        {
            var mappedUser = _mapper.Map<AppUser>(model);
            var result = await _userManager.CreateAsync(mappedUser, model.Password);
            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(mappedUser, model.Role);

                return new ServiceResponse
                {
                    Success = true,
                    Message = "User successfully created."
                };
            }
            else
            {

                return new ServiceResponse
                {
                    Success = true,
                    Message = result.Errors.Select(e => e.Description).FirstOrDefault()
                };
            }
        }
    }
}
