using System;

namespace ManagementSystem.Core
{
    public class Course
    {
        public string Name { get; }
        public decimal RegistrationFee { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public Course(string name, decimal registrationFee, DateTime startDate, DateTime endDate)
        {
            Name = name;
            RegistrationFee = registrationFee;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
