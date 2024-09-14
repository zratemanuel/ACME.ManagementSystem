using System;
using ManagementSystem.Core;
using ManagementSystem.Core.Models;
using ManagementSystem.ConsoleApp.Services;
using ManagementSystem.Core.Repositories;
using ACME.ManagementSystem.Core.Utils;

namespace ManagementSystem.ConsoleApp
{
    class Program
    {
        private static IEnrollmentService _enrollmentService;
        private static IStudentService _studentService;
        private static ICourseService _courseService;

        static void Main(string[] args)
        {
            InitializeServices();

            while (true)
            {
                DisplayMenu();
                var option = Console.ReadLine();

                try
                {
                    ExecuteOption(option);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        private static void InitializeServices()
        {
            _enrollmentService = new EnrollmentService(new PaymentValidator(), new CourseRepository());
            _studentService = new StudentService(new StudentRepository());
            _courseService = new CourseService(new CourseRepository());
        }

        private static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine(Constants.MENU_OPTION_1);
            Console.WriteLine(Constants.MENU_OPTION_2);
            Console.WriteLine(Constants.MENU_OPTION_3);
            Console.WriteLine(Constants.MENU_OPTION_4);
            Console.WriteLine(Constants.MENU_OPTION_5);
        }

        private static void ExecuteOption(string option)
        {
            switch (option)
            {
                case "1":
                    PrintHeader("Register Student");
                    RegisterStudent();
                    break;
                case "2":
                    PrintHeader("Register Course");
                    RegisterCourse();
                    break;
                case "3":
                    PrintHeader("Enroll Student in Course");
                    EnrollStudentInCourse();
                    break;
                case "4":
                    PrintHeader("List Courses with Enrolled Students");
                    ListCoursesWithEnrolledStudents();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine(Constants.INVALID_OPTION);
                    break;
            }
            PromptReturnToMenu();
        }

        private static void PrintHeader(string title)
        {
            Console.Clear();
            int totalWidth = Console.WindowWidth;
            int titleWidth = title.Length + 10; // Adding space for padding
            int sideWidth = (totalWidth - titleWidth) / 2;
            string side = new string('-', sideWidth);
            Console.WriteLine($"{side} {title} {side}");
        }

        private static void PromptReturnToMenu()
        {
            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
            Console.Clear();
        }

        private static void RegisterStudent()
        {
            Console.Write(Constants.ENTER_STUDENT_NAME);
            var name = Console.ReadLine();

            Console.Write(Constants.ENTER_STUDENT_AGE);
            if (!int.TryParse(Console.ReadLine(), out var age) || age < 18)
            {
                Console.WriteLine(Constants.ONLY_ADULTS);
                return;
            }

            var student = new Student(name, age);
            _studentService.RegisterStudent(student);
            Console.WriteLine(string.Format(Constants.STUDENT_REGISTERED, student.Name));
        }

        private static void RegisterCourse()
        {
            Console.Write(Constants.ENTER_COURSE_NAME);
            var name = Console.ReadLine();

            Console.Write(Constants.ENTER_REGISTRATION_FEE);
            if (!decimal.TryParse(Console.ReadLine(), out var registrationFee))
            {
                Console.WriteLine(Constants.INVALID_REGISTRATION_FEE);
                return;
            }

            Console.Write(Constants.ENTER_START_DATE);
            if (!DateTime.TryParse(Console.ReadLine(), out var startDate))
            {
                Console.WriteLine(Constants.INVALID_START_DATE);
                return;
            }

            Console.Write(Constants.ENTER_END_DATE);
            if (!DateTime.TryParse(Console.ReadLine(), out var endDate))
            {
                Console.WriteLine(Constants.INVALID_END_DATE);
                return;
            }

            var course = new Course(name, registrationFee, startDate, endDate);
            _courseService.RegisterCourse(course);
            Console.WriteLine(string.Format(Constants.COURSE_REGISTERED, course.Name));
        }

        private static void EnrollStudentInCourse()
        {
            Console.Write(Constants.ENTER_STUDENT_NAME);
            var studentName = Console.ReadLine();

            Console.Write(Constants.ENTER_COURSE_NAME);
            var courseName = Console.ReadLine();

            Console.Write(Constants.ENTER_AMOUNT_PAID);
            if (!decimal.TryParse(Console.ReadLine(), out var amountPaid))
            {
                Console.WriteLine(Constants.INVALID_AMOUNT_PAID);
                return;
            }

            var student = _studentService.GetStudentByName(studentName);
            var course = _courseService.GetCourseByName(courseName);

            if (student == null || course == null)
            {
                Console.WriteLine(Constants.STUDENT_NOT_FOUND);
                return;
            }

            try
            {
                _enrollmentService.RegisterStudentForCourse(student, course, amountPaid);
                Console.WriteLine(string.Format(Constants.ENROLLMENT_SUCCESS, student.Name, course.Name));
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ListCoursesWithEnrolledStudents()
        {
            Console.Write(Constants.ENTER_START_DATE);
            if (!DateTime.TryParse(Console.ReadLine(), out var startDate))
            {
                Console.WriteLine(Constants.INVALID_START_DATE);
                return;
            }

            Console.Write(Constants.ENTER_END_DATE);
            if (!DateTime.TryParse(Console.ReadLine(), out var endDate))
            {
                Console.WriteLine(Constants.INVALID_END_DATE);
                return;
            }

            var coursesWithStudents = _enrollmentService.GetCoursesWithStudentsEnrolledWithinDateRange(startDate, endDate);

            if (coursesWithStudents.Any())
            {
                foreach (var courseWithStudents in coursesWithStudents)
                {
                    Console.WriteLine($"Course: {courseWithStudents.Course.Name}");
                    if (courseWithStudents.Students.Any())
                    {
                        Console.WriteLine("Enrolled Students:");
                        foreach (var student in courseWithStudents.Students)
                        {
                            Console.WriteLine($" - {student.Name}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No students enrolled.");
                    }
                }
            }
            else
            {
                Console.WriteLine("No courses available.");
            }
        }
    }
}
