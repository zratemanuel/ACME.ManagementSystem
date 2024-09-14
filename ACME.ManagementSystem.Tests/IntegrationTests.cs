using System;
using Xunit;
using ManagementSystem.Core;
using ManagementSystem.Core.Models;
using ManagementSystem.ConsoleApp.Services;
using ManagementSystem.Core.Repositories;
using Moq;
using ManagementSystem.Tests.Repositories;
using ACME.ManagementSystem.Core.Utils;
using FluentAssertions;

public class IntegrationTests
{
    private readonly IEnrollmentService _enrollmentService;
    private readonly IStudentService _studentService;
    private readonly ICourseService _courseService;

    public IntegrationTests()
    {
        var studentRepository = new InMemoryStudentRepository();
        var courseRepository = new InMemoryCourseRepository();
        var paymentValidator = new PaymentValidator();
        var enrollmentRepository = new InMemoryEnrollmentRepository();

        _studentService = new StudentService(studentRepository);
        _courseService = new CourseService(courseRepository);
        _enrollmentService = new EnrollmentService(paymentValidator, courseRepository);
    }

    [Fact]
    public void RegisterStudent_ShouldSucceed()
    {
        var student = new Student("Alice", 25);
        _studentService.RegisterStudent(student);

        var retrievedStudent = _studentService.GetStudentByName("Alice");

        retrievedStudent.Should().NotBeNull();
        retrievedStudent.Name.Should().Be("Alice");
    }

    [Fact]
    public void RegisterCourse_ShouldSucceed()
    {
        var course = new Course("Math", 100m, DateTime.Today, DateTime.Today.AddMonths(1));
        _courseService.RegisterCourse(course);

        var retrievedCourse = _courseService.GetCourseByName("Math");

        retrievedCourse.Should().NotBeNull();
        retrievedCourse.Name.Should().Be("Math");
    }

    [Fact]
    public void EnrollStudentInCourse_ShouldSucceed()
    {
        var student = new Student("Bob", 30);
        _studentService.RegisterStudent(student);
        var course = new Course("Science", 150m, DateTime.Today, DateTime.Today.AddMonths(2));
        _courseService.RegisterCourse(course);

        _enrollmentService.RegisterStudentForCourse(student, course, 150m);

        var coursesWithStudents = _enrollmentService.GetCoursesWithStudentsEnrolledWithinDateRange(DateTime.Today, DateTime.Today.AddMonths(3));

        var courseWithStudents = coursesWithStudents.Should().ContainSingle().Subject;
        courseWithStudents.Course.Name.Should().Be("Science");
        courseWithStudents.Students.Should().Contain(student);
    }
}
