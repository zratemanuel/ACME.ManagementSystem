namespace ACME.ManagementSystem.Core.Utils
{
    public static class Constants
    {
        public const int MINIMUM_AGE = 18;
        public const decimal DEFAULT_REGISTRATION_FEE = 0;
        public const decimal DEFAULT_REGISTRATION_MAKER = 0;

        public const string MENU_OPTION_1 = "1. Register a student";
        public const string MENU_OPTION_2 = "2. Register a course";
        public const string MENU_OPTION_3 = "3. Enroll a student in a course";
        public const string MENU_OPTION_4 = "4. List courses with enrolled students";
        public const string MENU_OPTION_5 = "5. Exit";
        public const string INVALID_OPTION = "Invalid option. Please try again.";

        public const string ENTER_STUDENT_NAME = "Enter student's name: ";
        public const string ENTER_STUDENT_AGE = "Enter student's age: ";
        public const string ONLY_ADULTS = "Only adults (18 or older) can register.";

        public const string ENTER_COURSE_NAME = "Enter course name: ";
        public const string ENTER_REGISTRATION_FEE = "Enter registration fee: ";
        public const string INVALID_REGISTRATION_FEE = "Invalid registration fee.";
        public const string ENTER_START_DATE = "Enter start date (yyyy-mm-dd): ";
        public const string ENTER_END_DATE = "Enter end date (yyyy-mm-dd): ";
        public const string INVALID_START_DATE = "Invalid start date.";
        public const string INVALID_END_DATE = "Invalid end date.";

        public const string ENTER_AMOUNT_PAID = "Enter amount paid: ";
        public const string INVALID_AMOUNT_PAID = "Invalid amount paid.";
        public const string STUDENT_NOT_FOUND = "Student or course not found.";
        public const string ENROLLMENT_SUCCESS = "Student {0} enrolled in course {1} successfully.";
        public const string COURSE_REGISTERED = "Course {0} registered successfully.";
        public const string STUDENT_REGISTERED = "Student {0} registered successfully.";
    }
}
