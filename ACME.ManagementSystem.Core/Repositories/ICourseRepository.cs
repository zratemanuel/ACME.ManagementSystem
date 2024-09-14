using ManagementSystem.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Core.Repositories
{
    public interface ICourseRepository
    {
        void Add(Course student);
        Course FindByName(string name);
        IEnumerable<Course> GetAllCourses();

    }
}
