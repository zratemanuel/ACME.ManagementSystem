using ManagementSystem.Core;
using ManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using ManagementSystem.Tests.Repositories;
public static class TestUtilities
{
    public static Student CreateTestStudent(string name = "Test Student", int age = 20)
    {
        return new Student(name, age);
    }

    public static Course CreateTestCourse(string name = "Test Course", decimal registrationFee = 100m, DateTime startDate = default, DateTime endDate = default)
    {
        if (startDate == default) startDate = DateTime.Today;
        if (endDate == default) endDate = startDate.AddMonths(3);

        return new Course(name, registrationFee, startDate, endDate);
    }

    public static Enrollment CreateTestEnrollment(Student student = null, Course course = null)
    {
        student ??= CreateTestStudent();
        course ??= CreateTestCourse();
        return new Enrollment(student, course);
    }

    public static InMemoryStudentRepository CreateInMemoryStudentRepository(IEnumerable<Student> students = null)
    {
        var repo = new InMemoryStudentRepository();
        if (students != null)
        {
            foreach (var student in students)
            {
                repo.Add(student);
            }
        }
        return repo;
    }

    public static InMemoryCourseRepository CreateInMemoryCourseRepository(IEnumerable<Course> courses = null)
    {
        var repo = new InMemoryCourseRepository();
        if (courses != null)
        {
            foreach (var course in courses)
            {
                repo.Add(course);
            }
        }
        return repo;
    }

    public static InMemoryEnrollmentRepository CreateInMemoryEnrollmentRepository(IEnumerable<Enrollment> enrollments = null)
    {
        var repo = new InMemoryEnrollmentRepository();
        if (enrollments != null)
        {
            foreach (var enrollment in enrollments)
            {
                repo.Add(enrollment);
            }
        }
        return repo;
    }
}
