using System;
using System.Collections.Generic;

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
        public void PrintGroups()
        {
            Console.WriteLine($"  College {Name}");
            Console.WriteLine("    Groups");
            Console.WriteLine("---------------------------");
            Console.WriteLine(" N  Id   Name");
            Console.WriteLine("---------------------------");
            for (int i = 0; i < groups.Count; i++)
                Console.WriteLine($"{i + 1} | {groups[i].Id} | {groups[i].Name}");
        }
        public void PrintGroupById(int group_id)
        {
            for (int g = 0; g < groups.Count; g++)
                if (groups[g].Id == group_id)
                {
                    groups[g].PrintGroup();
                    break;
                }
        }
        public void AddGroup(Group group)
        {
            groups.Add(group);
        }
        public void AddStudentToGroup(int groupId, Student student)
        {
            for (int g = 0; g < groups.Count; g++)
                if (groups[g].Id == groupId)
                {
                    groups[g].AddStudent(student);
                    break;
                }
        }
        public void UpdateStudentById(int student_id, string firstName, string lastName)
        {
            for (int g = 0; g < groups.Count; g++)
                for (int s = 0; s < groups[g].Students.Count; s++)
                    if (groups[g].Students[s].Id == student_id)
                    {
                        groups[g].UpdateStudent(groups[g].Students[s], firstName, lastName);
                        break;
                    }
        }
        public void RemoveStudentById(int student_id)
        {
            for (int g = 0; g < groups.Count; g++)
                groups[g].RemoveStudent(student_id);
        }
        public void PrintAllStudents()
        {
            Console.WriteLine($"  College {Name}");
            int numberOfStudent = 0;
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("   N   Id         Student                   Group  Group_ID");
            Console.WriteLine("-------------------------------------------------------------");
            for (int g = 0; g < groups.Count; g++)
                for (int s = 0; s < groups[g].Students.Count; s++)
                {
                    numberOfStudent++;
                    Console.WriteLine($" {numberOfStudent,3}  {groups[g].Students[s].Id,3}  " +
                        $"{groups[g].Students[s].LastName,-15} {groups[g].Students[s].FirstName,-10}  " +
                        $"{groups[g].Name,10}   {groups[g].Id,3}");
                }
        }
    }
}
