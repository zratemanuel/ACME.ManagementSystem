using System;
using System.Collections.Generic;
using System.Linq;
using ACME.ManagementSystem.Core.Utils;
using ManagementSystem.Core;
using ManagementSystem.Core.Models;

namespace ManagementSystem.Core.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private static readonly List<Student> _students = new List<Student>();

        public void Add(Student student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));

            _students.Add(student);
        }

        public Student FindByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(ErrorMessages.STUDENT_NAME_INVALID, nameof(name));

            return _students.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
