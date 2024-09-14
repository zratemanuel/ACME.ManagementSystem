using System;
using System.Collections.Generic;
using System.Linq;
using ACME.ManagementSystem.Core.Models;
using ACME.ManagementSystem.Core.Utils;
using ManagementSystem.Core.Models;
using ManagementSystem.Core.Repositories;

namespace ManagementSystem.Core
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly List<Enrollment> _enrollments = new List<Enrollment>();
        private readonly IPaymentValidator _paymentValidator;
        private readonly ICourseRepository _courseRepository;

        public EnrollmentService(IPaymentValidator paymentValidator, ICourseRepository courseRepository)
        {
            _paymentValidator = paymentValidator;
            _courseRepository = courseRepository;
        }

        public void RegisterStudentForCourse(Student student, Course course, decimal amountPaid)
        {
            _paymentValidator.Validate(amountPaid, course.RegistrationFee);
            var enrollment = new Enrollment(student, course);
            _enrollments.Add(enrollment);
        }
        public IEnumerable<CourseWithStudents> GetCoursesWithStudentsEnrolledWithinDateRange(DateTime startDate, DateTime endDate)
        {
            var coursesWithEnrollments = _enrollments
                .Where(e => e.Course.StartDate >= startDate && e.Course.EndDate <= endDate)
                .GroupBy(e => e.Course)
                .Select(g => g.Key)
                .ToList();

            var allCourses = _courseRepository.GetAllCourses(); 
            var coursesWithStudents = new Dictionary<Course, List<Student>>();

            foreach (var course in allCourses)
            {
                coursesWithStudents[course] = new List<Student>();
            }

            foreach (var enrollment in _enrollments)
            {
                if (enrollment.Course.StartDate >= startDate && enrollment.Course.EndDate <= endDate)
                {
                    if (coursesWithStudents.ContainsKey(enrollment.Course))
                    {
                        coursesWithStudents[enrollment.Course].Add(enrollment.Student);
                    }
                }
            }

            var coursesWithStudentsList = coursesWithStudents.Select(csm => new CourseWithStudents
            {
                Course = csm.Key,
                Students = csm.Value
            }).ToList();

            return coursesWithStudentsList;
        }

        public IEnumerable<Enrollment> GetEnrollments()
        {
            return _enrollments;
        }

    }
}
