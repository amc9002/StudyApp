using System;
using System.Collections.Generic;

namespace StudyApp
{
    class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Subject> subjects;

        public static int count = 0;

        public Teacher(string firstName, string lastName)
        {
            Id = ++Teacher.count;
            FirstName = firstName;
            LastName = lastName;
            List<Subject> subjects = new List<Subject>();
        }
        public void AddSubjectDialogue()
        {
            Console.WriteLine("Adding of subject to teacher");
            Console.WriteLine("----------------------------");
            Console.WriteLine("");
            Console.WriteLine("Enter names of subjects");
            Console.WriteLine("0 - done");
            while(true)
            {
                string subject_name = Console.ReadLine();
                if(subject_name == "0") { break; }
                Subject subject = new Subject(subject_name);
                subjects.Add(subject);
            }
            Console.WriteLine($"Teacher {FirstName} {LastName} teaches the subjects:");
            foreach (Subject s in subjects) { Console.WriteLine(s.Name); }
        }
        public void PrintTeacher()
        {
            Console.WriteLine($"{Id} {LastName} {FirstName}  ");
        }
        public void PrintTeacherWithSubjects()
        {
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine(" ID   Last name    First name     Subjects");
            Console.WriteLine("-----------------------------------------------------------");
            Console.Write   ($"{Id} {LastName}   {FirstName}  ");
            for(int i = 0; i < subjects.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(subjects[i].Name);
                    continue;
                }
                Console.WriteLine($"                               {subjects[i].Name}");      
            }
            Console.WriteLine("-----------------------------------------------------------");
        }

    }

}
