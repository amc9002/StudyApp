using System;
using System.Collections.Generic;

namespace StudyApp
{
    class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public static int count = 0;

        public Student(string firstName, string lastName)
        {
            Student.count++;
            Id = Student.count;
            FirstName = firstName;
            LastName = lastName;
        }
        public void PrintStudent()
        {
            Console.WriteLine($"{Id} | {LastName} {FirstName}");
        }
    }

}
