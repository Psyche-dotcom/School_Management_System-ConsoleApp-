using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem
{
    enum CourseLevel
    {
        Beginner,
        Medium,
        Expert
    }
    class Course
    {
        private static int NextIdCourse = 1;
        public int CourseId { get; set; }
        internal string CourseName { get; set; }
        internal string CourseDescription { get; set; }
        public string CourseAuthor { get; set; }
        
        internal CourseLevel CourseLevels { get; set; } = CourseLevel.Beginner;
        protected List<Course> availableCourses = new List<Course>();
     
        public Course()
        {
            CourseId = NextIdCourse++;
        }
        public Course(string courseName, string courseDescription, CourseLevel courseLevel, string CourseAuthor)
        {
            CourseId = NextIdCourse++;
            CourseName = courseName;
            CourseDescription = courseDescription;
            CourseLevels = courseLevel;
            this.CourseAuthor = CourseAuthor;
        }
        protected void AddCourse(Course course)
        {
            availableCourses.Add(course);
        }
        protected void RemoveCourse(int course)
        {
            availableCourses.RemoveAt(course);
        }
        public void showAllCourse (){
            foreach (Course item in availableCourses)
            {
                
                Console.WriteLine();
                Console.WriteLine($"The Course Info are below \n Id: {item.CourseId} \n Course Name: {item.CourseName} \n Course Descriptions: {item.CourseDescription} \n Author by: {item.CourseAuthor}");

            }
        
        }
        public void showCourseIndexForStudent()
        {
            int num = 1;
            
            Console.WriteLine("The Course info with there index available for addition to your course are below");
            foreach (Course item in availableCourses )
            {
                Console.WriteLine();
                Console.WriteLine($"index: {num} \n Course Name: {item.CourseName} \n Course Descriptions: {item.CourseDescription} \n Course Author: {item.CourseAuthor}");
                num++;
            }
            Console.WriteLine();
        }
        public void showOneCourse(int index)
        {

            Console.WriteLine();
            Console.WriteLine($"The student Info are below \n Id: {availableCourses[index].CourseId} \n Course Name or Course Title: {availableCourses[index].CourseName} \n Course Level: {availableCourses[index].CourseLevels} \n Course Description: {availableCourses[index].CourseDescription}");

        }
        public void showCourseIndex()
        {
            int num = 1;
            Console.WriteLine();
            Console.WriteLine($"The course index available for deletion with their course name are index");
            foreach (Course item in availableCourses)
            {
                Console.WriteLine();
                Console.WriteLine($"index: {num}  Name: {item.CourseName}");
                num++;
            }
            Console.WriteLine();
        }
        public void TotalCourseCount()
        {
            Console.WriteLine($"The total number of registered course are {availableCourses.Count}");
        }

        public void courseImplement()
        {
            
                while (true)
                {
                    Console.Write("Welcome to the Course menu \n \nPlease Select from the course menu below using their index" +
                        "\n   1. Add new course to the list." +
                        " \n   2. Views all registered course full details." +
                        " \n   3. Delete course from the list " +
                        "\n Your option: ");
                    string teachersOption = Console.ReadLine();
                    Console.WriteLine();
                    switch (int.Parse(teachersOption))
                    {
                        case 1:
                            Console.WriteLine();
                            Console.Write("Please enter the total number of course you want to create: ");
                            int createNoCourse = int.Parse(Console.ReadLine());
                            int counter = 0;
                            while (createNoCourse > 0)
                            {
                                Console.WriteLine();
                                Console.Write("Please enter the Course Name or Course Title: ");
                                string name = Console.ReadLine();
                                Console.Write("Please enter the Course Description: ");
                                string courseDes = Console.ReadLine();
                                Console.Write("Please enter the course Author: ");
                                string courseAuth = Console.ReadLine();
                                Console.Write("Please select the Course Level: \n 1. Beginner 2. Medium 3. Expert  \n Your Option: ");
                                int CourseLevelSelect = int.Parse(Console.ReadLine());
                                AddCourse(new Course(name,courseDes,CourseLevelSelect == 1 ? CourseLevel.Beginner:CourseLevelSelect == 2 ? CourseLevel.Medium : CourseLevel.Expert,courseAuth));
                                Console.WriteLine();
                                showOneCourse(counter);
                                counter++;
                                createNoCourse--;
                                Console.WriteLine();
                            }
                            Console.WriteLine();
                            TotalCourseCount();
                            Console.WriteLine();
                            break;
                        case 2:
                            Console.WriteLine();
                            Console.WriteLine("The full details of registered courses are below.");
                            showAllCourse();
                            TotalCourseCount();
                            break;
                        case 3:
                            Console.WriteLine();
                            showCourseIndex();
                            Console.WriteLine();
                            Console.WriteLine("Please input the student id of the student you want to remove? ");
                            int removeStudent = int.Parse(Console.ReadLine()) - 1;
                            RemoveCourse(removeStudent);
                            Console.WriteLine($"Remove studdent at id of {removeStudent + 1}");
                            Console.WriteLine();
                            Console.WriteLine("The remaining students on the list are listed below after removal");
                            showAllCourse();
                            break;

                    }
                    Console.Write("Do you want to perform another Course operation on course menu ? yes or no __ ");
                    string continueLoop = Console.ReadLine();
                    if (continueLoop.ToLower() != "yes")
                    {
                        break;
                    }

                }
            
            

        }


    }
}
