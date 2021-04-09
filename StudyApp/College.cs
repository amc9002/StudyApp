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
        public void PrintListOfGroups()
        {
            Console.WriteLine($"  College {Name}");
            Console.WriteLine("There are the groups in the college:");
            Console.WriteLine("---------------------------");
            Console.WriteLine(" N  Id   Name      Speciality");
            Console.WriteLine("---------------------------");
            int i = 0;
            foreach (Group g in groups)
            {
                Console.WriteLine($"{i + 1} | {g.Id} | {g.Name} | {g.Speciality}");
                i++;
            }
        }
        public void AddGroup()
        {
            string group_name;
            Console.WriteLine("Adding of group");
            Console.WriteLine("-------------------");

            if (groups.Count < 1)
            {
                Console.WriteLine("There are no groups yet there");
                Console.WriteLine("Enter name of the first group or 0 - done: ");
            }
            else
            {
                PrintListOfGroups();
                Console.WriteLine("Enter, please, name of another group or 0 - done");
            }

            while (true)
            {
                group_name = Console.ReadLine();
                if (group_name == "0")
                    break;
                Console.WriteLine("Enter, please, speciality of group");
                string speciality_name = Console.ReadLine();
                Group group = new Group(group_name, speciality_name);

                groups.Add(group);

                PrintListOfGroups();
                Console.WriteLine("Enter, please, name of another group or 0 - done");
            }
            Console.WriteLine("Done!");

            PrintListOfGroups();
        }
        public int ChooseGroup()
        {
            Console.WriteLine("Enter Id of group: ");
            int group_id = int.Parse(Console.ReadLine());
            return group_id;
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

        public void AddStudentDialogue()
        {
            int group_id;
            PrintListOfGroups();

            Console.WriteLine("Adding of a student");
            Console.WriteLine("-------------------");

            while (true)
            {
                group_id = ChooseGroup();
                if (GetGroup(group_id) != null) { break; }

                Console.WriteLine($"There are no group with ID {group_id}");
                Console.WriteLine("Make, please, the right choise");
            }
            GetGroup(group_id).PrintGroup();
            Console.WriteLine("Enter the name of student to add (first name last name): ");
            Console.WriteLine("0 - done");

            while (true)
                if (!GetGroup(group_id).AddStudent()) { break; }

            GetGroup(group_id).PrintGroup();
            Console.WriteLine("Done!");
        }
        public void UpdateStudentDialogue()
        {
            Console.WriteLine("Updating of student");
            Console.WriteLine("-------------------");
            Console.WriteLine("What to update?");
            Console.WriteLine("- change the name of student  - 1");
            Console.WriteLine("- transferring to other group - 2");
            Console.WriteLine("- nothing to change           - 0");
            string choose = Console.ReadLine();
            int from_group_id, to_group_id;
            switch (choose)
            {
                case "1":
                    PrintListOfGroups();

                    from_group_id = ChooseGroup();
                    GetGroup(from_group_id).PrintGroup();

                    GetGroup(from_group_id).UpdateStudent();
                    GetGroup(from_group_id).PrintGroup();

                    break;
                case "2":
                    PrintListOfGroups();
                    Console.WriteLine("What group to transfer from?");
                    from_group_id = ChooseGroup();
                    GetGroup(from_group_id).PrintGroup();

                    Console.WriteLine("Choose ID of student: ");
                    int student_id = int.Parse(Console.ReadLine());

                    Console.WriteLine(" Id     Student");
                    Console.WriteLine("----------------------");

                    GetGroup(from_group_id).GetStudent(student_id).PrintStudent();
                    Student temp_student = GetGroup(from_group_id).GetStudent(student_id);

                    Console.WriteLine("What group to transfer to?");
                    to_group_id = ChooseGroup();
                    GetGroup(to_group_id).PrintGroup();

                    Console.WriteLine("Are you sure? (Y/N)");
                    string sure = Console.ReadLine();
                    if (sure == "Y" || sure == "y")
                    {
                        Console.WriteLine("Transfer");
                        GetGroup(from_group_id).RemoveStudent(student_id);
                        GetGroup(to_group_id).AddStudent(temp_student);
                    }
                    break;
                default:
                    break;
            }
            Console.WriteLine("Done!");
        }
        public void RemoveStudentDialogue()
        {
            int student_id;

            Console.WriteLine("Removing of a student");
            Console.WriteLine("---------------------");

            PrintAllStudents();
            Console.WriteLine("Enter Id of student to remove: ");
            student_id = int.Parse(Console.ReadLine());

            Console.WriteLine("Are you sure? (Y/N)");
            string sure = Console.ReadLine();

            if (sure == "Y" || sure == "y")
                foreach (Group g in groups)
                {
                    g.RemoveStudent(student_id);
                    break;
                }
            Console.WriteLine("Done!");
        }
        public void PrintAllStudents()
        {
            Console.WriteLine($"  College {Name}");
            int numberOfStudent = 0;
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("   N   Id         Student                   Group  Group_ID       Speciality");
            Console.WriteLine("------------------------------------------------------------------------------");
            foreach (Group g in groups)
                foreach (Student s in g.students)
                {
                    numberOfStudent++;
                    Console.WriteLine($" {numberOfStudent,3}  {s.Id,3}  " +
                        $"{s.LastName,-15} {s.FirstName,-10}  " +
                        $"{g.Name,10}   {g.Id,3}   {g.Speciality,20}");
                }
        }

        public void AddMarkDialogue()
        {
            HelpFindTeacherId();
            Console.WriteLine("Enter, please, your teachers ID:");
            int teacher_id = int.Parse(Console.ReadLine());
            Console.Write("Teacher ");
            GetTeacher(teacher_id).PrintTeacher();

            HelpFindStudentsId();
            
            Console.WriteLine("Enter, please, ID of a student:");
            int student_id = int.Parse(Console.ReadLine());
            Student student = FindGroupByStudentId(student_id).GetStudent(student_id);
            while (true) {
                
                if (FindGroupByStudentId(student_id) != null) {
                    FindGroupByStudentId(student_id).AddMark(student_id, teacher_id);
                    break;
                } 
                Console.WriteLine($"There are no student with ID {student_id}");
                Console.WriteLine("Enter, please, ID of a student:");
                student_id = int.Parse(Console.ReadLine());
            }

            string firstname = FindGroupByStudentId(student_id).GetStudent(student_id).FirstName;
            string lastname  = FindGroupByStudentId(student_id).GetStudent(student_id).LastName;

            Console.WriteLine($"Student {firstname} {lastname} is getting:");

            datetime date = findgroupbystudentid(student_id).getstudent(student_id).marks.findlast().date;
            console.writeline(" date    |       subjects name       | score |   teacher");
            console.writeline($"{datetime.now}  {getsubject(subject_id)}    {mark.score}  ");
        }
        public void HelpFindStudentsId()
        {
            Console.WriteLine("You need ID of student ");
            Console.WriteLine("Do you need help to find them (Y/N):");
            string needHelp = Console.ReadLine();
            if (needHelp == "Y" || needHelp == "y")
            {
                Console.WriteLine("1 - List of all students");
                Console.WriteLine("2 - Search by group");
                Console.WriteLine("0 - Done");
                string search = Console.ReadLine();
                if (search == "1")
                    PrintAllStudents();
                if (search == "2")
                {
                    PrintListOfGroups();
                    GetGroup(ChooseGroup()).PrintGroup();
                }
            }
        }

        public Teacher GetTeacher(int teacher_id)
        {
            return teachers.FirstOrDefault(t => t.Id == teacher_id);
        }
        public void AddTeacher()
        {
            string[] teacher_name;

            string teacher_name_ = Console.ReadLine();
            if (teacher_name_ == "0") { return; }

            teacher_name = teacher_name_.Split(' ');
            Teacher new_teacher = new Teacher(teacher_name[0], teacher_name[1]);

            teachers.Add(new_teacher);
            SortTeachersByLastname();
        }
        public void AddTeacherDialogue()
        {
            Console.WriteLine("Adding of a teacher");
            Console.WriteLine("-------------------");
            Console.WriteLine("Enter the name of a new teacher to add (first name, last name): ");
            Console.WriteLine("0 - done");

            AddTeacher();
            Console.WriteLine("Done!");
        }
        public void UpdateTeacherDialogue()
        {
            Console.WriteLine("Updating of teacher");
            Console.WriteLine("-------------------");
            Console.WriteLine("What to update?");
            Console.WriteLine("- change the name of teacher  - 1");
            Console.WriteLine("- add/remove of a subject     - 2");
            Console.WriteLine("- nothing to change           - 0");
            string choose = Console.ReadLine();
            switch (choose)
            {
                case "1":
                    int teacher_id;
                    string firstName, lastName;

                    HelpFindTeacherId();

                    Console.WriteLine("Enter Id of a teacher to update: ");
                    teacher_id = int.Parse(Console.ReadLine());
                    firstName = GetTeacher(teacher_id).FirstName;
                    Console.WriteLine($"Enter first name of a teacher to update ({firstName}): ");
                    firstName = Console.ReadLine();
                    lastName = GetTeacher(teacher_id).LastName;
                    Console.WriteLine($"Enter last name of a teacher to update ({lastName}): ");
                    lastName = Console.ReadLine();

                    GetTeacher(teacher_id).FirstName = firstName;
                    GetTeacher(teacher_id).LastName = lastName;

                    break;
                case "2":

                    break;
                default:
                    break;
            }
        }
        public void PrintAllTeachers()
        {
            Console.WriteLine("There are teachers in the college:");
            Console.WriteLine(" ID |     Name    ");
            foreach (Teacher t in teachers)
                Console.WriteLine($"{t.Id}    {t.LastName} {t.FirstName}");
        }
        public void SortTeachersByLastname()
        {
            var SortedTeachers = (from s in teachers orderby s.LastName select s).ToList();
            teachers = SortedTeachers;
        }
        public void HelpFindTeacherId()
        {
            Console.WriteLine("You need your teachers ID");
            Console.WriteLine("Do you need help to find them (Y/N):");
            string needHelp = Console.ReadLine();
            if (needHelp == "Y" || needHelp == "y")
                PrintAllTeachers();
        }
    }
}
