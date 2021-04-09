using System;

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

            college.AddGroup();

            college.AddStudentDialogue();

            if (college.groups.Count > 1)
            {
                college.AddStudentDialogue();
                Console.WriteLine();
            }

            college.PrintAllStudents();
            Console.WriteLine();

            Console.WriteLine("Test: Removing of student");
            college.RemoveStudentDialogue();
            college.PrintAllStudents();
            Console.WriteLine();

            Console.WriteLine("Test: updating of student");
            college.UpdateStudentDialogue();
            college.PrintAllStudents();
            Console.WriteLine();
            //StartGroupsMenu(college);
            //ViewGroupsMenu(group1);
            //CreateNewGroupMenu();
            //DeleteGroupMenu(college);
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
            college.PrintListOfGroups();
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
