namespace ManagementSystem.Core.Models
{
    public class Enrollment
    {
        public Student Student { get; }
        public Course Course { get; }

        public Enrollment(Student student, Course course)
        {
            Student = student;
            Course = course;
        }
    }
}
