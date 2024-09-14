using System;
using System.Collections.Generic;
using ManagementSystem.Core.Models;

namespace ManagementSystem.Core
{
    public interface ICourseService
    {
        void RegisterCourse(Course course);
        Course GetCourseByName(string name);
    }
}


