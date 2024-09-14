using System;
using System.Collections.Generic;
using ManagementSystem.Core.Models;

namespace ManagementSystem.Core
{
    public interface IStudentService
    {
        void RegisterStudent(Student student);
        Student GetStudentByName(string name);
    }
}


