using System;
using System.Collections.Generic;
using System.Linq;

namespace StudyApp
{
    class College
    {
        public string Name { get; set; }
        public List<Group> groups;
        public List<Teacher> teachers;
        public College(string name)
        {
            Name = name;
            groups = new List<Group>();
            teachers = new List<Teacher>();
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
