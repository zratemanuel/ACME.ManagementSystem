using ManagementSystem.Core;
using ManagementSystem.Core.Models;
using ManagementSystem.Core.Repositories;

namespace ManagementSystem.ConsoleApp.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            this._studentRepository = studentRepository;
        }

        public void RegisterStudent(Student student)
        {
            _studentRepository.Add(student);
        }

        public Student GetStudentByName(string name)
        {
            return _studentRepository.FindByName(name);
        }
    }
}
