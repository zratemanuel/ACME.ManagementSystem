using ManagementSystem.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.ManagementSystem.Core.Models
{    public class CourseWithStudents
    {
        public Course? Course { get; set; }
        public List<Student>? Students { get; set; }
    }

}
