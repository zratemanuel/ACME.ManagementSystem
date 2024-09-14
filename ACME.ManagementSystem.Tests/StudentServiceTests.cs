using System;
using Xunit;
using Moq;
using ManagementSystem.Core;
using ManagementSystem.Core.Models;
using ManagementSystem.Core.Repositories;
using ManagementSystem.ConsoleApp.Services;
using FluentAssertions;

public class StudentServiceTests
{
    private readonly IStudentService _studentService;
    private readonly Mock<IStudentRepository> _studentRepositoryMock;

    public StudentServiceTests()
    {
        _studentRepositoryMock = new Mock<IStudentRepository>();
        _studentService = new StudentService(_studentRepositoryMock.Object);
    }

    [Fact]
    public void RegisterStudent_ShouldCallRepositoryAdd()
    {
        var student = new Student("Charlie", 22);

        _studentService.RegisterStudent(student);

        _studentRepositoryMock.Verify(repo => repo.Add(student), Times.Once);
    }

    [Fact]
    public void GetStudentByName_ShouldReturnStudent()
    {
        var student = new Student("David", 28);
        _studentRepositoryMock.Setup(repo => repo.FindByName("David")).Returns(student);

        var retrievedStudent = _studentService.GetStudentByName("David");

        retrievedStudent.Should().NotBeNull();
        retrievedStudent.Name.Should().Be("David");
    }
}
