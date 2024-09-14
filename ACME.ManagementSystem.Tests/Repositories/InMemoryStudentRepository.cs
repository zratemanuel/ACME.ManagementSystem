using System.Collections.Generic;
using System.Linq;
using ManagementSystem.Core;
using ManagementSystem.Core.Models;
using ManagementSystem.Core.Repositories;

namespace ManagementSystem.Tests.Repositories
{
    public class InMemoryStudentRepository : IStudentRepository
    {
        private readonly List<Student> _students = new List<Student>();

        public void Add(Student student)
        {
            _students.Add(student);
        }

        public Student FindByName(string name)
        {
            return _students.FirstOrDefault(s => s.Name == name);
        }

        public IEnumerable<Student> GetAll()
        {
            return _students;
        }
    }
}