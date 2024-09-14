using System.Collections.Generic;
using System.Linq;
using ManagementSystem.Core;
using ManagementSystem.Core.Models;
using ManagementSystem.Core.Repositories;

namespace ManagementSystem.Tests.Repositories
{
    public class InMemoryEnrollmentRepository
    {
        private readonly List<Enrollment> _enrollments;

        public InMemoryEnrollmentRepository(IEnumerable<Enrollment> enrollments = null)
        {
            _enrollments = enrollments?.ToList() ?? new List<Enrollment>();
        }

        public void Add(Enrollment enrollment)
        {
            _enrollments.Add(enrollment);
        }

        public IEnumerable<Enrollment> GetAll()
        {
            return _enrollments;
        }

        public IEnumerable<Enrollment> GetByStudent(Student student)
        {
            return _enrollments.Where(e => e.Student.Equals(student));
        }

        public IEnumerable<Enrollment> GetByCourse(Course course)
        {
            return _enrollments.Where(e => e.Course.Equals(course));
        }
    }
}
