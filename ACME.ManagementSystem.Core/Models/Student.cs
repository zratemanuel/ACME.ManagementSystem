using ACME.ManagementSystem.Core.Utils;
using System;

namespace ManagementSystem.Core
{
    public class Student
    {
        public string Name { get; }
        public int Age { get; }

        public Student(string name, int age)
        {
            if (age < Constants.MINIMUM_AGE)
                throw new ArgumentException(ErrorMessages.AGE_RESTRICTION);

            Name = name;
            Age = age;
        }
    }
}
