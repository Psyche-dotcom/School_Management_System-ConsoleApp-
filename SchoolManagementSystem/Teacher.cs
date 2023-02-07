using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem
{
    enum TeacherGender
    {
        Male,
        Female
    }
   
    class Teacher : Students
    {
        public int Id { get; set; }
        public static int NextId = 1;
        public string Name { get; set; }
        public int age { get; set; }
        public TeacherGender gender { get; set; }
       
        public Teacher()
        {
            Id = NextId++;
        }
        public Teacher(string name, int age, TeacherGender gender)
        {
            Id = NextId++;
            this.Name = name;
            this.age = age;
            this.gender = gender;
        }
        public void AddAvailableCourse(Course course)
        {
            AddCourse(course);
        }
        public void RemoveAvailableCourse(int course)
        {
            RemoveCourse(course);
        }
        protected List<Teacher> teacher = new List<Teacher>();
        protected void AddTeacher(Teacher addteacher)
        {
            teacher.Add(addteacher);
        }
        
        protected void RemoveTeacher(int index)
        {
            teacher.RemoveAt(index);
        }
        public void showTeacher()
        {
            foreach (Teacher item in teacher)
            {
                Console.WriteLine();
                Console.WriteLine($"The teacher Info are below \n Id: {item.Id} \n Name: {item.Name} \n Gender: {item.gender} \n Age: {item.age}");
            }
        }
        public void showOneTeacher(int index)
        {

            Console.WriteLine();
            Console.WriteLine($"The student Info are below \n Id: {teacher[index].Id} \n Name: {teacher[index].Name} \n Gender: {teacher[index].gender} \n Age: {teacher[index].age}");

        }
        public void TotalTeacherCount()
        {
            Console.WriteLine($"The total number of register student are {teacher.Count}");

        }
        public void registerOneTeacher()
        {
            Console.WriteLine();
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Please enter your age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Please select the student gender: 1. Male 2. Female \n Your Option: ");
            int genderSelect = int.Parse(Console.ReadLine());
            AddTeacher(new Teacher(name, age, genderSelect == 1 ? TeacherGender.Male : TeacherGender.Female));
            Console.WriteLine();
            Console.WriteLine("your Details is saved succefully");
        }

        public void methodB()
        {
            throw new NotImplementedException();
        }
    }
}
