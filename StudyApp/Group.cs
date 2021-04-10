using System;
using System.Collections.Generic;
using System.Linq;

namespace StudyApp
{
    class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Speciality { get; set; }
        public List<Student> students = new List<Student>();
        public List<int> subjectsId = new List<int>();

        public List<Subject> subjects;

        public static int count = 0;
        public Group(string name, string speciality)
        {
            Group.count++;
            Id = Group.count;
            Name = name;
            Speciality = speciality;
            subjects = new List<Subject>();
        }
        public void PrintGroup()
        {
            Console.WriteLine($"Group {Name}  {Speciality}");
            Console.WriteLine("---------------------------");
            Console.WriteLine(" N  Id     Student");
            Console.WriteLine("---------------------------");
            for (int i = 0; i < students.Count; i++)
            {
                Console.Write($" {i + 1} | ");
                students[i].PrintStudent();
            }
        }

        public Student GetStudent(int student_id)
        {
            return students.FirstOrDefault(s => s.Id == student_id);
        }
        public bool AddStudent()
        {
            string[] student_name;

            string student_name_ = Console.ReadLine();
            if (student_name_ == "0") { return false; }

            student_name = student_name_.Split(' ');
            Student new_student = new Student(student_name[0], student_name[1]);

            students.Add(new_student);
            SortStudentsByLastname();
            return true;
        }
        public void AddStudent(Student student)
        {
            students.Add(student);
            SortStudentsByLastname();
        }
        public void RemoveStudent(int student_id)
        {
            students.RemoveAll(s => s.Id == student_id);
            SortStudentsByLastname();
        }
        public void SortStudentsByLastname()
        {
            var SortedStudents = (from s in students orderby s.LastName select s).ToList();
            students = SortedStudents;
        }

        public void AddMark(int student_id, int teacher_id)
        {
            Console.WriteLine("You need an ID of a subject. Do you need a help (Y/N)");
            string need_help = Console.ReadLine();
            if (need_help == "Y" || need_help == "y")
                PrintListOfSubjects();

            Console.WriteLine("Enter ID of a subject: ");
            int subject_id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter score: ");
            int score = int.Parse(Console.ReadLine());

            Mark mark = new Mark(DateTime.Now, teacher_id, subject_id, score);

            GetStudent(student_id).marks.Add(mark);
            
        }
        public void PrintMarksOfStudentBySubject(Student student, int subject_id)
        {
            Console.WriteLine(GetSubject(subject_id).Name);
            student.PrintMarksBySubjectId(subject_id);
        }
        public void PrintAllMarksOfStudent(Student student)
        {
            student.PrintStudent();
            
            foreach (Subject s in subjects)
                PrintMarksOfStudentBySubject(student.Id, s.Id);
        }

        public Subject GetSubject(int subject_id)
        {
            return subjects.FirstOrDefault(s => s.Id == subject_id);
        }
        public void PrintListOfSubjects()
        {
            Console.WriteLine($"There are subjects in the group {Name}");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("     Name                   ID");
            Console.WriteLine("----------------------------------");
            foreach (var s in subjects)
                Console.WriteLine($" {s.Name, -15}      { s.Id }");
            Console.WriteLine("----------------------------------");
        }
    }

}
