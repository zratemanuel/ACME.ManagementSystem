using ManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Core.Repositories
{
    public interface IEnrollmentRepository
    {
        void Add(Enrollment enrollment);
        IEnumerable<Enrollment> GetAll();
        IEnumerable<Enrollment> GetByStudent(Student student);
        IEnumerable<Enrollment> GetByCourse(Course course);
    }
}

