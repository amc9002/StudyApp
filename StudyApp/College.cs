using System;
using System.Collections.Generic;
using System.Linq;

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
        
    }
}
