using System;
using System.Collections.Generic;
using ACME.ManagementSystem.Core.Models;
using ManagementSystem.Core.Models;

namespace ManagementSystem.Core
{
    public interface IEnrollmentService
    {
        /// <summary>
        /// Registers a student for a course, ensuring that the payment is sufficient.
        /// </summary>
        /// <param name="student">The student to be registered.</param>
        /// <param name="course">The course to register the student in.</param>
        /// <param name="amountPaid">The amount paid by the student.</param>
        void RegisterStudentForCourse(Student student, Course course, decimal amountPaid);

        /// <summary>
        /// Gets a list of courses with students enrolled within the specified date range.
        /// </summary>
        /// <param name="startDate">The start date of the range.</param>
        /// <param name="endDate">The end date of the range.</param>
        /// <returns>A collection of courses with students enrolled within the date range.</returns>
        IEnumerable<CourseWithStudents> GetCoursesWithStudentsEnrolledWithinDateRange(DateTime startDate, DateTime endDate);
        /// <summary>
        /// Gets a list of enrollments
        /// </summary>
        public IEnumerable<Enrollment> GetEnrollments();
    }
}

