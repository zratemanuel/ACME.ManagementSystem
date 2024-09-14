using Xunit;
using Moq;
using ManagementSystem.Core.Models;
using ManagementSystem.Core.Repositories;
using ACME.ManagementSystem.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using ManagementSystem.Core;
using FluentAssertions;

public class EnrollmentServiceTests
{
    private readonly IEnrollmentService _enrollmentService;
    private readonly Mock<IPaymentValidator> _paymentValidatorMock;
    private readonly Mock<ICourseRepository> _courseRepositoryMock;
    private readonly Mock<IEnrollmentRepository> _enrollmentRepositoryMock;

    public EnrollmentServiceTests()
    {
        _courseRepositoryMock = new Mock<ICourseRepository>();
        _enrollmentRepositoryMock = new Mock<IEnrollmentRepository>();
        _paymentValidatorMock = new Mock<IPaymentValidator>();
        _enrollmentService = new EnrollmentService(_paymentValidatorMock.Object, _courseRepositoryMock.Object);
    }

    [Fact]
    public void RegisterStudentForCourse_ShouldAddEnrollmentToList()
    {
        var student = new Student("Eva", 29);
        var course = new Course("Biology", 175m, DateTime.Today, DateTime.Today.AddMonths(3));
        _paymentValidatorMock.Setup(v => v.Validate(175m, course.RegistrationFee)).Verifiable();

        _enrollmentService.RegisterStudentForCourse(student, course, 175m);

        _paymentValidatorMock.Verify();
    }

    [Fact]
    public void RegisterStudentForCourse_ShouldCallRepositoryAdd()
    {
        var student = new Student("Eva", 29);
        var course = new Course("Biology", 175m, DateTime.Today, DateTime.Today.AddMonths(3));
        _paymentValidatorMock.Setup(v => v.Validate(175m, course.RegistrationFee)).Verifiable();

        _enrollmentService.RegisterStudentForCourse(student, course, 175m);

        var enrollments = _enrollmentService.GetEnrollments();

        enrollments.Should().Contain(e => e.Student == student && e.Course == course);
    }

    [Fact]
    public void GetCoursesWithStudentsEnrolledWithinDateRange_ShouldReturnCourses()
    {
        var course1 = new Course("Physics", 200m, DateTime.Today.AddDays(-1), DateTime.Today.AddDays(2));
        var course2 = new Course("Chemistry", 150m, DateTime.Today.AddDays(-3), DateTime.Today.AddDays(4));
        var course3 = new Course("Math", 175m, DateTime.Today.AddMonths(1), DateTime.Today.AddDays(3));

        var student1 = new Student("Frank", 31);
        var student2 = new Student("Alice", 25);

        _courseRepositoryMock.Setup(repo => repo.GetAllCourses()).Returns(new List<Course> { course1, course2, course3 });

        _enrollmentService.RegisterStudentForCourse(student1, course1, 200m);
        _enrollmentService.RegisterStudentForCourse(student2, course2, 150m);

        var courses = _enrollmentService.GetCoursesWithStudentsEnrolledWithinDateRange(DateTime.Today.AddDays(-5), DateTime.Today.AddDays(5));

        courses.Should().NotBeEmpty();

        var physicsCourse = courses.SingleOrDefault(c => c.Course.Name == "Physics");
        var chemistryCourse = courses.SingleOrDefault(c => c.Course.Name == "Chemistry");

        physicsCourse.Should().NotBeNull();
        chemistryCourse.Should().NotBeNull();

        physicsCourse.Students.Should().Contain(student1);
        chemistryCourse.Students.Should().Contain(student2);
    }
}
