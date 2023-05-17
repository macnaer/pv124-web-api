using Compass.Core.DTO_s;
using Compass.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compass.Core.Interfaces
{
    public interface ICourseService
    {
        Task<List<CourseDto>> GetAll();
        Task<CourseDto?> Get(int id);
        Task Create(CourseDto course);
        Task Update(CourseDto course);
        Task Delete(int id);
        Task<List<CourseDto>> GetByCategory(int id);
    }
}
