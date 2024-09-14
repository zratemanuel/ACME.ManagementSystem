using System.Collections.Generic;
using System.Linq;
using ManagementSystem.Core;
using ManagementSystem.Core.Models;
using ManagementSystem.Core.Repositories;

namespace ManagementSystem.Tests.Repositories
{
    public class InMemoryCourseRepository : ICourseRepository
    {
        private readonly List<Course> _courses = new List<Course>();

        public void Add(Course course)
        {
            _courses.Add(course);
        }

        public Course FindByName(string name)
        {
            return _courses.FirstOrDefault(c => c.Name == name);
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _courses;
        }
    }
}
