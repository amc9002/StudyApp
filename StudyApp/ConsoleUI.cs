using System;

namespace StudyApp
{
    class ConsoleUI
    {
        public void Run(College college)
        {
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

            Group group = new Group("101717");
            Student student1 = new Student("Andrej", "Cieraszkou");
            Student student2 = new Student("Ales'", "Baczkarou");
            Student student3 = new Student("Piatro", "Sabierau");

            college.AddGroup(group);

            college.AddStudentToGroup(1, student1);
            college.AddStudentToGroup(1, student2);
            college.AddStudentToGroup(1, student3);

            group = new Group("101727");
            college.groups.Add(group);
            Student student = new Student("Maksim", "Baczkarou");
            college.AddStudentToGroup(2, student);
            student = new Student("Mscislau", "Cieraszkou");
            college.AddStudentToGroup(2, student);
            student = new Student("Alaksandar", "Lukaszenka");
            college.AddStudentToGroup(2, student);

            college.PrintGroups();
            Console.WriteLine();
            
            college.PrintGroupById(1);
            Console.WriteLine();
            college.PrintGroupById(2);
            Console.WriteLine();

            college.PrintAllStudents();
            Console.WriteLine();

            Console.WriteLine($"Test: Removing student with Id = 2");
            college.RemoveStudentById(2);
            college.PrintAllStudents();
            Console.WriteLine();

            Console.WriteLine("Test: updating of student with ID = 4");
            college.UpdateStudentById(4, "Taciana", "Sakalova");
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
            college.PrintGroups();
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
