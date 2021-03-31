using System;
using System.Collections.Generic;

namespace StudyApp
{
    class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Teacher(string firstName, string lastName, int subject_id)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = subject_id;
        }
    }

}
