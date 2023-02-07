using System;
using System.Xml.Linq;

namespace SchoolManagementSystem
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Console School Management System");
            Console.WriteLine();

           

            Teacher teachers= new Teacher();
            Students students = new Students();
            Course course = new Course();
            
            //course added by teacher instance
            teachers.AddAvailableCourse(new Course("Mathematics 101", "This course introduce you to basic syntax of mathematical operation like addition and others",CourseLevel.Beginner,"Mr dolapo"));
            teachers.AddAvailableCourse(new Course("English 101", "This course introduce you to lexics and structure in english and the basic rules of concord", CourseLevel.Expert, "Dr. Dayo"));

            //students added to the database of add student by teacher
            teachers.AddStudent(new Students("Babatunde Saheed", 22,Gender.Male));
            teachers.AddStudent(new Students("Babatunde Sheriff", 32,Gender.Male));
            teachers.AddStudent(new Students("Babatunde Assisat", 18, Gender.Female));
            
            Console.Write("Please Sign in as a teacher or students? 1. Teacher  2. Student  \n Your Answer: ");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Sign In as Teacher Sucessfully");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Please in full details as a teacher");
                    teachers.registerOneTeacher();
                    while (true)

                    {
                        Console.WriteLine();
                        Console.Write(
                        "Welcome to Teacher Dashboard \n \nPlease Select from the menu below using their index" +
                        "\n   1. Goto Students Portal to Manage Student." +
                        "\n   2. Manage  Course." +
                        "\n   3. Use Calculator " + " \n   4. Play Game " + " \n   5. Read Novel  \n   6. Sign Out" +
                        "\n Your option: ");
                        int options = int.Parse(Console.ReadLine());
                        switch (options)
                        {
                            case 1:
                                teachers.studentImplement(true);
                                break;
                            case 2:
                                teachers.courseImplement();
                                break;
                            case 3:
                                Console.WriteLine("Use Calculaor incoming");
                                break;
                            case 4:
                                Console.WriteLine("Play Game");
                                break;
                            case 5:
                                Console.WriteLine("Read Novel incoming");
                                break;
                        }
                        if(options ==6)
                        {
                            Console.WriteLine( "Sign out as teacher successfully");
                            break;
                        }
                    }
                    break;

                case "2":
                    Console.WriteLine();
                    Console.WriteLine("Fill in your details");
                    Console.WriteLine();
                    Console.Write("Please enter your name: ");
                    string name = Console.ReadLine();
                    Console.Write("Please enter your age: ");
                    int age = int.Parse(Console.ReadLine());
                    Console.Write("Please select your gender: 1. Male 2. Female \n Your Option: ");
                    int genderSelect = int.Parse(Console.ReadLine());
                    teachers.AddStudent(new Students(name, age, genderSelect == 1 ? Gender.Male : Gender.Female));
                    Console.WriteLine("Your student info has been saved successfully");
                    Console.WriteLine();
                    while (true)
                    {
                        Console.WriteLine();
                        Console.Write(
                        "Welcome to Student Dashboard \n \nPlease Select from the menu below using their index" +
                        "\n   1. Goto your Profile." +
                        " \n   2.  My Course Management." +
                        " \n   3. Use Calculator " + " \n   4. Play Game " + " \n   5. Read Novel  \n   6. Sign Out" +
                        "\n Your option: ");
                        int options = int.Parse(Console.ReadLine());
                        switch (options)
                        {
                            case 1:
                                teachers.studentImplement(false);
                                break;
                            case 2:
                                while (true)
                                {
                                    Console.Write("Welcome to the Student Course menu \n \n Please Select from the course menu below using their index" +
                        "\n   1. Add new course to my registered courses list." +
                        " \n   2. Views all my registered course." +
                        " \n   3. Delete course from my registered course list from the list " +
                        "\n Your option: ");
                                    int studentSelect = int.Parse(Console.ReadLine());
                                    switch (studentSelect)
                                    {
                                        case 1:
                                            Console.WriteLine();
                                            Console.WriteLine("Please use index of the courses below to add to your own course");
                                            teachers.showCourseIndexForStudent();
                                            Console.Write("How many course do u want to add: ");
                                            int numCourse = int.Parse(Console.ReadLine());
                                            while (numCourse > 0)
                                            {
                                                Console.Write("Please Input the index of the course to add: ");
                                                int indexCourse = int.Parse(Console.ReadLine());
                                                teachers.RegisterForCourse(indexCourse);
                                                numCourse--;
                                            }
                                            teachers.ViewAllStudentRegisteredCourse();
                                            break;
                                        case 2:
                                            Console.WriteLine();
                                            teachers.ViewAllStudentRegisteredCourseHistory();
                                            break;
                                        case 3:
                                            teachers.showCourseRegIndex();
                                            Console.Write("Please input the index of the course you want to remove: ");
                                            int removeRegCourse = int.Parse(Console.ReadLine());
                                            teachers.RemoveRegisteredCourse(removeRegCourse);
                                            break; 
                                        default:
                                            break;
                                    }
                                    Console.Write("Do you want to leave course menu ? yes or no __ ");
                                    string continueLoop = Console.ReadLine();
                                    if (continueLoop.ToLower() != "yes")
                                    {
                                        break;
                                    }
                                } 
                                break;
                            case 3:
                                Console.WriteLine("Use Calculaor incoming");
                                break;
                            case 4:
                                Console.WriteLine("Play Game");
                                break;
                            case 5:
                                Console.WriteLine("Read Novel incoming");
                                break;
                        }
                        if (options == 6)
                        {
                            Console.WriteLine("Sign out as teacher successfully");
                            break;
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Thanks for using my school management system console");
                    break;

            }
            
        }
    }
}
