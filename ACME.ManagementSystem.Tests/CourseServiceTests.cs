using System;
using Xunit;
using Moq;
using ManagementSystem.Core;
using ManagementSystem.Core.Models;
using ManagementSystem.Core.Repositories;
using ManagementSystem.ConsoleApp.Services;
using FluentAssertions;

public class CourseServiceTests
{
    private readonly ICourseService _courseService;
    private readonly Mock<ICourseRepository> _courseRepositoryMock;

    public CourseServiceTests()
    {
        _courseRepositoryMock = new Mock<ICourseRepository>();
        _courseService = new CourseService(_courseRepositoryMock.Object);
    }

    [Fact]
    public void RegisterCourse_ShouldCallRepositoryAdd()
    {
        var course = new Course("History", 120m, DateTime.Today, DateTime.Today.AddMonths(1));

        _courseService.RegisterCourse(course);

        _courseRepositoryMock.Verify(repo => repo.Add(course), Times.Once);
    }

    [Fact]
    public void GetCourseByName_ShouldReturnCourse()
    {
        var course = new Course("Geography", 200m, DateTime.Today, DateTime.Today.AddMonths(2));
        _courseRepositoryMock.Setup(repo => repo.FindByName("Geography")).Returns(course);

        var retrievedCourse = _courseService.GetCourseByName("Geography");

        retrievedCourse.Should().NotBeNull();
        retrievedCourse.Name.Should().Be("Geography");
    }
}
