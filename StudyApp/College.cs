using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace StudyApp
{
    class College
    {
        public string Name { get; set; }
        public List<Group> groups = new List<Group>();
        public List<Teacher> teachers = new List<Teacher>();
        public List<Subject> subjects = new List<Subject>();
        public College(string name)
        {
            Name = name;
        }
        public Group GetGroup(int group_id)
        {
            return groups.FirstOrDefault(g => g.Id == group_id);
        }              
        public Group FindGroupByStudentId(int student_id)
        {
            foreach (var g in groups)
                foreach (var s in g.students) {
                    if (s.Id == student_id)
                        return g;
                }
            return null;
        }
        public void PrintGroups()
        {
            Console.WriteLine($"  College {Name}");
            Console.WriteLine("There are the groups in the college:");
            Console.WriteLine("---------------------------");
            Console.WriteLine(" N  Id   Name      Speciality");
            Console.WriteLine("---------------------------");
            int i = 0;
            foreach (Group g in groups) {
                Console.WriteLine($"{i + 1} | {g.Id} | {g.Name} | {g.Speciality}");
                i++;
            }
        }

        public Teacher GetTeacher(int teacher_id)
        {
            return teachers.FirstOrDefault(t => t.Id == teacher_id);
        }
        
        
        

        public void SortTeachersByLastname()
        {
            var SortedTeachers = (from t in teachers orderby t.LastName select t).ToList();
            teachers = SortedTeachers;
        }

        private StreamReader StreamReader(string v)
        {
            throw new NotImplementedException();
        }
        public void GetSubjectsFromFile()
        {
            var exePath = AppDomain.CurrentDomain.BaseDirectory;//path to exe file
            var path = Path.Combine(exePath, @"Info\\subject.txt");
            List<string> subJects_names = new List<string>();
            string subject_name;
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                while ((subject_name = sr.ReadLine()) != null)
                {
                subJects_names.Add(subject_name);
            }
            foreach (var sn in subJects_names) {
                Subject subject = new Subject(sn);
                subjects.Add(subject);
            }
        }
        public void PrintSubjects()
        {
            Console.WriteLine("There are the subjects in the college:");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine( " ID             Subject");
            Console.WriteLine("---------------------------------------");
            foreach(var s in subjects)
                Console.WriteLine($" {s.Id}  {s.Name}");
            Console.WriteLine("---------------------------------------");
        }

    }
}
