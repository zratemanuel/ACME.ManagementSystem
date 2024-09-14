using ACME.ManagementSystem.Core.Utils;
using ManagementSystem.Core;
using ManagementSystem.Core.Models;
using ManagementSystem.Core.Repositories;

namespace ManagementSystem.ConsoleApp.Services
{

    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            this._courseRepository = courseRepository;
        }

        public void RegisterCourse(Course course)
        {
            if (course == null)
                throw new ArgumentNullException(nameof(course));

            _courseRepository.Add(course);
        }

        public Course GetCourseByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(ErrorMessages.COURSE_NAME_INVALID, nameof(name));

            return _courseRepository.FindByName(name);
        }
    }
}
