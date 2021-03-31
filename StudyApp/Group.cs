using System;
using System.Collections.Generic;
using System.Linq;

namespace StudyApp
{
    class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
    
        public List<Student> Students;

        public static int count = 0;
        public Group(string name)
        {
            Group.count++;
            Id = Group.count;
            Name = name;
            Students = new List<Student>();
        }
        public Student GetStudent(int student_id)
        {
            return Students.FirstOrDefault(s => s.Id == student_id);
        }
        public void AddStudent(Student student)
        {
            Students.Add(student);
            SortByLastname();
        }
        public void RemoveStudent(int student_id)
        {
            Students.RemoveAll(s => s.Id == student_id);
            SortByLastname();
        }
        public void UpdateStudent(Student student, string firstName, string lastName)
        {
            student.FirstName = firstName;
            student.LastName = lastName;
        }
        public void SortByLastname()
        {
            var SortedStudents = (from s in Students orderby s.LastName select s).ToList();
            Students = SortedStudents;
        }
        public void PrintGroup()
        {
            Console.WriteLine("Group " + Name);
            Console.WriteLine("---------------------------");
            Console.WriteLine(" N  Id     Student");
            Console.WriteLine("---------------------------");
            for (int i = 0; i < Students.Count; i++)
            {
                Console.Write($" {i + 1} | ");
                Students[i].PrintStudent();
            }
        }
    }

}
