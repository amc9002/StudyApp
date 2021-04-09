using System;
using System.Collections.Generic;
using System.Linq;

namespace StudyApp
{
    class ConsoleUI
    {
        public void Run(College college)
        {
            Console.WriteLine($"College {college.Name}");
            Console.WriteLine("---------------------");

            //int choose = StartMenu(college);
            //switch (choose)
            //{
            //    case 1:
            //        StartGroupsMenu(college);
            //        break;
            //    case 2:
            //        //Menu: Operations with teachers
            //        break;
            //    case 3:
            //        //Menu: Operations with students
            //        break;
            //    default:
            //        //Exit
            //        return;

            //}

            AddGroup(college);

            AddStudent(college);

            if (college.groups.Count > 1)
            {
                AddStudent(college);
                Console.WriteLine();
            }

            PrintAllStudents(college);
            Console.WriteLine();

            Console.WriteLine("Test: Removing of student");
            RemoveStudent(college);
            PrintAllStudents(college);
            Console.WriteLine();

            Console.WriteLine("Test: updating of student");
            UpdateStudent(college);
            PrintAllStudents(college);
            Console.WriteLine();
            //StartGroupsMenu(college);
            //ViewGroupsMenu(group1);
            //CreateNewGroupMenu();
            //DeleteGroupMenu(college);
        }

        public void AddGroup(College college)
        {
            string group_name;
            Console.WriteLine("Adding of group");
            Console.WriteLine("-------------------");

            if (college.groups.Count < 1)
            {
                Console.WriteLine("There are no groups yet there");
                Console.WriteLine("Enter name of the first group or 0 - done: ");
            }
            else
            {
                PrintListOfGroups(college);
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


                college.groups.Add(group);

                PrintListOfGroups(college);
                Console.WriteLine("Enter, please, name of another group or 0 - done");
            }
            Console.WriteLine("Done!");

            PrintListOfGroups(college);
        }
        public int ChooseGroupId()
        {
            Console.WriteLine("Enter Id of group: ");
            int group_id = int.Parse(Console.ReadLine());
            return group_id;
        }
        public void PrintListOfGroups(College college)
        {
            Console.WriteLine($"  College {college.Name}");
            Console.WriteLine("There are the groups in the college:");
            Console.WriteLine("---------------------------");
            Console.WriteLine(" N  Id   Name      Speciality");
            Console.WriteLine("---------------------------");
            int i = 0;
            foreach (Group g in college.groups)
            {
                Console.WriteLine($"{i + 1} | {g.Id} | {g.Name} | {g.Speciality}");
                i++;
            }
        }

        public void AddStudent(College college)
        {
            int group_id;
            PrintListOfGroups(college);

            Console.WriteLine("Adding of a student");
            Console.WriteLine("-------------------");

            while (true)
            {
                group_id = ChooseGroupId();
                if (college.GetGroup(group_id) != null) { break; }

                Console.WriteLine($"There are no group with ID {group_id}");
                Console.WriteLine("Make, please, the right choise");
            }
            college.GetGroup(group_id).PrintGroup();
            Console.WriteLine("Enter the name of student to add (first name last name): ");
            Console.WriteLine("0 - done");

            while (true)
                if (!college.GetGroup(group_id).AddStudent()) { break; }

            college.GetGroup(group_id).PrintGroup();
            Console.WriteLine("Done!");
        }
        public void UpdateStudent(College college)
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
                    PrintListOfGroups(college);

                    from_group_id = ChooseGroupId();
                    college.GetGroup(from_group_id).PrintGroup();

                    Console.WriteLine("Enter Id of student to update: ");
                    int student_id = int.Parse(Console.ReadLine());
                    string firstName, lastName;
                    firstName = college.GetGroup(from_group_id).GetStudent(student_id).FirstName;
                    lastName = college.GetGroup(from_group_id).GetStudent(student_id).LastName;
                    Console.WriteLine($"Enter first name of student to update ({firstName}): ");
                    firstName = Console.ReadLine();
                    Console.WriteLine($"Enter last name of student to update ({lastName}): ");
                    lastName = Console.ReadLine();

                    college.GetGroup(from_group_id).GetStudent(student_id).FirstName = firstName;
                    college.GetGroup(from_group_id).GetStudent(student_id).LastName = lastName;

                    college.GetGroup(from_group_id).SortStudentsByLastname();
                    college.GetGroup(from_group_id).PrintGroup();

                    break;
                case "2":
                    PrintListOfGroups(college);
                    Console.WriteLine("What group to transfer from?");
                    from_group_id = ChooseGroupId();
                    college.GetGroup(from_group_id).PrintGroup();

                    Console.WriteLine("Choose ID of student: ");
                    student_id = int.Parse(Console.ReadLine());

                    Console.WriteLine(" Id     Student");
                    Console.WriteLine("----------------------");

                    college.GetGroup(from_group_id).GetStudent(student_id).PrintStudent();
                    Student temp_student = college.GetGroup(from_group_id).GetStudent(student_id);

                    Console.WriteLine("What group to transfer to?");
                    to_group_id = ChooseGroupId();
                    college.GetGroup(to_group_id).PrintGroup();

                    Console.WriteLine("Are you sure? (Y/N)");
                    string sure = Console.ReadLine();
                    if (sure == "Y" || sure == "y") {
                        Console.WriteLine("Transfer");
                        college.GetGroup(from_group_id).RemoveStudent(student_id);
                        college.GetGroup(to_group_id).AddStudent(temp_student);
                    }
                    break;
                default:
                    break;
            }
            Console.WriteLine("Done!");
        }
        public void RemoveStudent(College college)
        {
            int student_id;

            Console.WriteLine("Removing of a student");
            Console.WriteLine("---------------------");

            PrintAllStudents(college);
            Console.WriteLine("Enter Id of student to remove: ");
            student_id = int.Parse(Console.ReadLine());

            Console.WriteLine("Are you sure? (Y/N)");
            string sure = Console.ReadLine();

            if (sure == "Y" || sure == "y")
                foreach (Group g in college.groups)
                {
                    g.RemoveStudent(student_id);
                    break;
                }
            Console.WriteLine("Done!");
        }
        public void PrintAllStudents(College college)
        {
            Console.WriteLine($"  College {college.Name}");
            int numberOfStudent = 0;
            
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("   N   Id         Student                   Group  Group_ID       Speciality");
            Console.WriteLine("------------------------------------------------------------------------------");

            List <Student> allStudents = new List<Student>();
            foreach (var g in college.groups)
                foreach (var s in g.students)
                {
                    var student_id = s.Id;
                    var last_name = s.LastName;
                    var first_name = s.FirstName;
                    var group_id = g.Id;
                    var group_name = g.Name;
                    var speciality = g.Speciality;
                    Student student = new Student(student_id, first_name, last_name, group_id, group_name, speciality);
                    allStudents.Add(student);
                }
            var sortedStudents = (from s in allStudents orderby s.LastName select s).ToList();

            foreach (var s in sortedStudents) {
                    numberOfStudent++;
                    Console.WriteLine($" {numberOfStudent,3}  {s.Id,3}  " +
                        $"{s.LastName,-15} {s.FirstName,-10}  " +
                        $"{s.GroupName,10}   {s.GroupId,3}   {s.Speciality,20}");
                }
        }
        public void HelpFindStudentsId(College college)
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
                    PrintAllStudents(college);
                if (search == "2")
                {
                    PrintListOfGroups(college);
                    college.GetGroup(ChooseGroupId()).PrintGroup();
                }
            }
        }

        public void AddTeacher(College college)
        {
            Console.WriteLine("Adding of a teacher");
            Console.WriteLine("-------------------");
            Console.WriteLine("Enter the name of a new teacher to add (first name, last name): ");
            Console.WriteLine("0 - done");

            string teacher_name_ = Console.ReadLine();
            if (teacher_name_ == "0") { return; }

            string[] teacher_name = teacher_name_.Split(' ');
            Teacher new_teacher = new Teacher(teacher_name[0], teacher_name[1]);

            college.teachers.Add(new_teacher);
            college.SortTeachersByLastname();


            Console.WriteLine("Done!");
        }
        public void PrintAllTeachers(College college)
        {
            Console.WriteLine("There are teachers in the college:");
            Console.WriteLine(" ID |     Name    ");

            foreach (Teacher t in college.teachers)
                Console.WriteLine($"{t.Id}    {t.LastName} {t.FirstName}");
        }
        public void UpdateTeacher(College college)
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

                    HelpFindTeacherId(college);

                    Console.WriteLine("Enter Id of a teacher to update: ");
                    teacher_id = int.Parse(Console.ReadLine());
                    firstName = college.GetTeacher(teacher_id).FirstName;
                    Console.WriteLine($"Enter first name of a teacher to update ({firstName}): ");
                    firstName = Console.ReadLine();
                    lastName = college.GetTeacher(teacher_id).LastName;
                    Console.WriteLine($"Enter last name of a teacher to update ({lastName}): ");
                    lastName = Console.ReadLine();

                    college.GetTeacher(teacher_id).FirstName = firstName;
                    college.GetTeacher(teacher_id).LastName = lastName;

                    break;
                case "2":

                    break;
                default:
                    break;
            }
        }
        public void HelpFindTeacherId(College college)
        {
            Console.WriteLine("You need your teachers ID");
            Console.WriteLine("Do you need help to find them (Y/N):");
            string needHelp = Console.ReadLine();
            if (needHelp == "Y" || needHelp == "y")
                PrintAllTeachers(college);
        }

        public void AddMarkDialogue(College college)
        {
            HelpFindTeacherId(college);
            Console.WriteLine("Enter, please, your teachers ID:");
            int teacher_id = int.Parse(Console.ReadLine());
            Console.Write("Teacher ");
            college.GetTeacher(teacher_id).PrintTeacher();

            HelpFindStudentsId(college);

            Console.WriteLine("Enter, please, ID of a student:");
            int student_id = int.Parse(Console.ReadLine());
            Student student;
            while (true) {
                if (college.FindGroupByStudentId(student_id) != null) {
                    student = college.FindGroupByStudentId(student_id).GetStudent(student_id);
                    break;
                }
                Console.WriteLine($"There are no student with ID {student_id}");
                Console.WriteLine("Enter, please, ID of a student:");
                student_id = int.Parse(Console.ReadLine());
            }
            //student.AddMark(student_id, teacher_id);
            string firstname = college.FindGroupByStudentId(student_id).GetStudent(student_id).FirstName;
            string lastname = college.FindGroupByStudentId(student_id).GetStudent(student_id).LastName;

            Console.WriteLine($"Student {firstname} {lastname} is getting:");

            //datetime date = findgroupbystudentid(student_id).getstudent(student_id).marks.findlast().date;
            //console.writeline(" date    |       subjects name       | score |   teacher");
            //console.writeline($"{datetime.now}  {getsubject(subject_id)}    {mark.score}  ");
        }

        public int StartMenu(College college)
        {
            //Console.Clear(); 
            Console.WriteLine();
            Console.WriteLine($"College { college.Name }");
            Console.WriteLine();
            Console.WriteLine("Choose the option:");
            Console.WriteLine("Operations with groups   - 1");
            Console.WriteLine("Operations with teachers - 2");
            Console.WriteLine("Operations with students - 3");
            Console.WriteLine("Exit                     - 0");
            int choose = int.Parse(Console.ReadLine());
            return choose;
        }
        public void StartGroupsMenu(College college)
        {
            Console.WriteLine("View list of groups      - 1");
            Console.WriteLine("Create new group         - 2");
            Console.WriteLine("Delete group             - 3");
            Console.WriteLine("Return to start menu     - 0");
        }
        public void ViewGroupsMenu(Group group)
        {
            Console.WriteLine();
            Console.WriteLine("View list of students    - 1");
            Console.WriteLine("Return to previous menu  - 0");
        }
        public void ViewListOfStudents(Group group)
        {
            Console.WriteLine("\n");
            Console.WriteLine($"Group { group.Name }");
            Console.WriteLine();
            Console.WriteLine("Choose the option:");

            Console.WriteLine("View list of students    - 1");
            Console.WriteLine("Return to previous menu  - 0");
        }
        public void CreateNewGroupMenu()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Enter name of new group  - 1");
            Console.WriteLine("Return to previous menu  - 0");
        }
        public void DeleteGroupMenu(College college)
        {
            Console.WriteLine();
            PrintListOfGroups(college);
            Console.WriteLine();
            Console.WriteLine("Choose the group to delete");
            Console.WriteLine("Or return to previous menu - 0");
        }

        public void StudentsMenu(College college)
        {
            //Console.WriteLine("New student    - 1");
            //Console.WriteLine("Find student - 2");
            //Console.WriteLine("Delete student - 3");
        }
        public void TeachersMenu(College college)
        {
            //Console.WriteLine("New teacher    - 1");
            //Console.WriteLine("Find teacher - 2");
            //Console.WriteLine("Delete teacher - 3");
        }
    }
}
