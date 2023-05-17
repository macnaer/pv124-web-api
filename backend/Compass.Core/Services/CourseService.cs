﻿using AutoMapper;
using Compass.Core.DTO_s;
using Compass.Core.Entities;
using Compass.Core.Entities.Specification;
using Compass.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compass.Core.Services
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> _courseRepo;
        private readonly IMapper _mapper;

        public CourseService(IRepository<Course> courseRepo, IMapper mapper)
        {
            _courseRepo = courseRepo;
            _mapper = mapper;
        }

        public async Task Create(CourseDto course)
        {
            await _courseRepo.Insert(_mapper.Map<Course>(course));
            await _courseRepo.Save();
        }

        public async Task Delete(int id)
        {
            var course = await _courseRepo.GetByID(id);
            if (course != null)
            {
                await _courseRepo.Delete(id);
                await _courseRepo.Save();
            }
        }

        public async Task<ServiceResponse> GetAll()
        {
            var result = await _courseRepo.GetListBySpec(new Courses.GetAll());
            var data = _mapper.Map<List<CourseDto>>(result);
            return new ServiceResponse
            {
                Message = "All courses loaded.",
                Success = true,
                Payload = data
            };
        }

        public async Task<CourseDto?> Get(int id)
        {
            if (id < 0)
                return null;
            var course = await _courseRepo.GetByID(id);
            return _mapper.Map<CourseDto>(course);
        }


        public async Task<List<CourseDto>> GetByCategory(int id)
        {
            var result = await _courseRepo.GetListBySpec(new Courses.ByCategory(id));
            return _mapper.Map<List<CourseDto>>(result);
        }

        public async Task Update(CourseDto course)
        {
            await _courseRepo.Update(_mapper.Map<Course>(course));
            await _courseRepo.Save();
        }
    }
}
