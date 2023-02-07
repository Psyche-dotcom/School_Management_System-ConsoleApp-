using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SchoolManagementSystem
{
    enum Gender
    {
        Male,
        Female
    }
    class Students : Course
    {
        private int Id { get; set; }
        private static int NextId = 1;
        private string name { get; set; }
        private int age { get; set; }
        private Gender gender { get; set; }
      
        
        public Students()
        {
            Id = NextId++;   
        }
        public Students( string name, int age, Gender gender)
        {
            Id = NextId++;
            this.name = name;
            this.age = age;
            this.gender = gender;
            
        }
        protected List<Students> students = new List<Students>();
        public void AddStudent(Students addstudent)
        {
            students.Add(addstudent);
        }
        protected void RemoveStudent(int index)
        {
            students.RemoveAt(index);
        }
        public void showStudent()
        {
            foreach (Students item in students)
            {
                Console.WriteLine();
                Console.WriteLine($"The student Info are below \n Id: {item.Id} \n Name: {item.name} \n Gender: {item.gender} \n Age: {item.age}");
            }
        }
        public void showMYStudent()
        {
                Console.WriteLine();
                Console.WriteLine($"My full student Info are below \n Id: {students[3].Id} \n Name: {students[3].name} \n Gender: {students[3].gender} \n Age: {students[3].age}");
        }
        public void showStudentIndex()
        {
            int num = 1;
            Console.WriteLine();
            Console.WriteLine($"The student index available for deletion with their info are index");
            foreach (Students item in students)
            {
                Console.WriteLine();
                Console.WriteLine($"index: {num}  Name: {item.name}");
                num++;
            }
            Console.WriteLine();
        }

        public void showOneStudent(int index)
        {
            Console.WriteLine();
            Console.WriteLine($"The student Info are below \n Id: {students[index].Id} \n Name: {students[index].name} \n Gender: {students[index].gender} \n Age: {students[index].age}");   
        }
        public void TotalStudentCount()
        {
            Console.WriteLine($"The total number of register student are {students.Count}"); 
        }

        List<Course> registeredCourses = new List<Course>();

        public void RegisterForCourse( int index)
        {
            Course course = availableCourses[index-1];
            if (availableCourses.Contains(course))
            {
                registeredCourses.Add(course);
            }
        }
        public void RemoveRegisteredCourse(int course)
        {
            registeredCourses.RemoveAt(course);
        }
        public void showCourseRegIndex()
        {
            int num = 1;
            Console.WriteLine();
            Console.WriteLine($"The course index available for deletion with their course name are index");
            foreach (Course item in registeredCourses)
            {
                Console.WriteLine();
                Console.WriteLine($"index: {num}  Name: {item.CourseName}");
                num++;
            }
            Console.WriteLine();
        }
        public void ViewAllStudentRegisteredCourseHistory()

        {
            Console.WriteLine("The full courses details registered by the student are below");
            foreach (Course item in registeredCourses)
            {
                Console.WriteLine();
                Console.WriteLine($"The Course Info are below \n Id: {item.CourseId} \n Course Name: {item.CourseName} \n Course Descriptions: {item.CourseDescription} \n Author by: {item.CourseAuthor}");

            }
        }
        public void ViewAllStudentRegisteredCourse()

        {
            Console.WriteLine("The course register for by the student are below");
            foreach (Course item in registeredCourses)
            {
                Console.WriteLine();
                Console.WriteLine($"The Course Info are below \n Id: {item.CourseId} \n Course Name: {item.CourseName} \n Course Descriptions: {item.CourseDescription} \n Author by: {item.CourseAuthor}");

            }
        }
     
        public void studentImplement(bool value)
        {
            if (value)
            {
                while (true)
                {
                    Console.Write("Welcome to the Students menu \n \nPlease Select from the student menu below using their index" +
                        "\n   1. Add new student to the list." +
                        " \n   2. Views all registered student full details." +
                        " \n   3. Delete student from the list " +
                        "\n Your option: ");
                    string teachersOption = Console.ReadLine();
                    Console.WriteLine();
                    switch (int.Parse(teachersOption))
                    {
                        case 1:
                            Console.WriteLine();
                            Console.Write("Please enter the total number of students you want to create: ");
                            int createNoStudent = int.Parse(Console.ReadLine());
                            int counter = 0;
                            while (createNoStudent > 0)
                            {
                                Console.WriteLine();
                                Console.Write("Please enter the students name: ");
                                string name = Console.ReadLine();
                                Console.Write("Please enter the students age: ");
                                int age = int.Parse(Console.ReadLine());
                                Console.Write("Please select the student gender: 1. Male 2. Female \n Your Option: ");
                                int genderSelect = int.Parse(Console.ReadLine());
                                AddStudent(new Students(name, age, genderSelect == 1 ? Gender.Male : Gender.Female));
                                Console.WriteLine();
                                showOneStudent(counter);
                                counter++;
                                createNoStudent--;
                                Console.WriteLine();
                            }
                            Console.WriteLine();
                            TotalStudentCount();
                            Console.WriteLine();
                            break;
                        case 2:
                            Console.WriteLine();
                            Console.WriteLine("The full details of students registered are below.");
                            showStudent();
                            TotalStudentCount();
                            break;
                        case 3:
                            Console.WriteLine();
                            showStudentIndex();
                            Console.WriteLine();
                            Console.WriteLine("Please input the student id of the student you want to remove? ");
                            int removeStudent = int.Parse(Console.ReadLine()) - 1;
                            RemoveStudent(removeStudent);
                            Console.WriteLine($"Remove studdent at id of {removeStudent + 1}");
                            Console.WriteLine();
                            Console.WriteLine("The remaining students on the list are listed below after removal");
                            showStudent();
                            break;

                    }
                    Console.Write("Do you want to perform another students operation on student menu ? yes or no __ ");
                    string continueLoop = Console.ReadLine();
                    if (continueLoop.ToLower() != "yes")
                    {
                        break;
                    }

                }
            }
            else
            {
                while (true)
                {
                    Console.Write($"Please Select from the student menu below using their index" +
                         "\n   1. View your full info" +
                         " \n   2. Views all registered students full info. " +
                         "\n Your option: ");
                    string studentsOption = Console.ReadLine();
                    Console.WriteLine();
                    switch (int.Parse(studentsOption))
                    {
                        case 1:
                            Console.WriteLine();
                            showMYStudent();
                            Console.WriteLine();
                            break;
                        case 2:
                            Console.WriteLine();
                            Console.WriteLine("The full details of students registered are below.");
                            showStudent();
                            Console.WriteLine($"There are {students.Count} number of registered student");
                            break;
                        default:
                            Console.WriteLine("Wrong Input of operation value");
                            break;
                    }
                    Console.Write("Do you want to perform another students operation on student menu ? yes or no __ ");
                    string continueLoop = Console.ReadLine();
                    if (continueLoop.ToLower() != "yes")
                    {
                        break;
                    }

                }

            }



        }


    }
 
}
