using System;
using System.Collections.Generic;
using System.Linq;
using ACME.ManagementSystem.Core.Utils;
using ManagementSystem.Core;
using ManagementSystem.Core.Models;

namespace ManagementSystem.Core.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private static readonly List<Course> _courses = new List<Course>();

        public void Add(Course course)
        {
            if (course == null)
                throw new ArgumentNullException(nameof(course));

            _courses.Add(course);
        }

        public Course FindByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(ErrorMessages.COURSE_NAME_INVALID, nameof(name));

            return _courses.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _courses;
        }
    }
}
