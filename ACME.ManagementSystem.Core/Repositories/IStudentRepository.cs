using ManagementSystem.Core;
using ManagementSystem.Core.Models;

namespace ManagementSystem.Core.Repositories
{
    public interface IStudentRepository
    {
        void Add(Student student);
        Student FindByName(string name);
    }
}
