using System;
using System.Collections.Generic;
using System.Linq;

namespace StudyApp
{
    class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Mark> marks;
        public static int count = 0;

        public Student(string firstName, string lastName)
        {
            Student.count++;
            Id = Student.count;
            FirstName = firstName;
            LastName = lastName;
            marks = new List<Mark>();
        }
        public Student(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
        public void PrintStudent()
        {
            Console.WriteLine($"{Id} | {LastName} {FirstName}");
        }
        public void PrintMarksBySubjectId(int subject_id)
        {
            Console.Write("   Date     |  Score  |");
            foreach (Mark m in marks)
                if (m.Subjects_Id == subject_id) 
                    Console.WriteLine($" |{m.Date.ToString("d")} | {m.Score}");
            Console.WriteLine();
        }

    }

}
