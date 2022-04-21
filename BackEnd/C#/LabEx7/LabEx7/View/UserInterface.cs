using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabEx7.Model;
using LabEx7.Service;
using LabEx7.Helper;

namespace LabEx7.View
{
    class UserInterface
    {
        StudentService studentService;
        HashSet<Student> students;

        public UserInterface()
        {
            this.studentService = new();
            this.students = studentService.GetStudents();
        }
        public string MainMenu()
        {
            Console.Clear();
            Console.WriteLine("[1] - Add     Records");
            Console.WriteLine("[2] - List    Records");
            Console.WriteLine("[3] - Modify  Records");
            Console.WriteLine("[4] - Delete  Records");
            Console.WriteLine("[5] - Exit    Program");
            Console.Write("\nSelect your choice: ");
            string choice = Console.ReadLine();

            return choice;
        }
        public void AddStudentUI()
        {
            Console.Clear();
            Console.WriteLine("========== ADD STUDENT RECORD =========");
            Console.Write("Enter Student ID: ");
            int ID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Student Fist Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Student Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter Student Grade Level (1 = ONE, 2 = TWO, 3 = THREE, 4 = FOUR, 5 = FIVE, 6 = SIX): ");
            string gradeLevel = Console.ReadLine();
            GradeLevel gradeList = (GradeLevel)Enum.Parse(typeof(GradeLevel), gradeLevel, true);
            Console.Write("Enter Student Section (1 = A, 2 = B, 3 = C, 4 = D, 5 = E): ");
            string section = Console.ReadLine();
            Section sect = (Section)Enum.Parse(typeof(Section), section, true);

            var student = new Student()
            {
                ID = ID,
                FirstName = firstName,
                LastName = lastName,
                GradeLevel = gradeList,
                Section = sect,
            };
            if (studentService.AddStudent(student))
            {
                Console.WriteLine("\nStudent Added Successfully");
            }
            else
            {
                Console.WriteLine("\nStudent Already Exist");
            }

            Console.WriteLine("\nPress Any Key To Continue...");
            Console.ReadLine();
        }
        public void DeleteStudentUI()
        {
            Console.Clear();
            this.DisplayStudentUI();
            Console.Write("\nEnter Student ID To Delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
            if (studentService.DeleteStudent(id))
            {
                Console.WriteLine("\nStudent Deleted Successfully");
            }
            else
            {
                Console.WriteLine("\nStudent Not Found");
            }
            Console.WriteLine("\nPress Any Key To Continue...");
            Console.ReadLine();
        }
        public void ModifyStudentUI()
        {
            Console.Clear();
            this.DisplayStudentUI();
            Console.Write("\nEnter Student ID To Modify: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Modified Fist Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Modified Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter Modified Grade Level (1 = ONE, 2 = TWO, 3 = THREE, 4 = FOUR, 5 = FIVE, 6 = SIX): ");
            string gradeLevel = Console.ReadLine();
            GradeLevel gradeList = (GradeLevel)Enum.Parse(typeof(GradeLevel), gradeLevel, true);
            Console.Write("Enter Modified Section (1 = A, 2 = B, 3 = C, 4 = D, 5 = E): ");
            string section = Console.ReadLine();
            Section sect = (Section)Enum.Parse(typeof(Section), section, true);
            if(studentService.ModifyStudent(id, firstName, lastName, gradeList, sect))
            {
                Console.WriteLine("\nStudent Modified Successfully");
            }
            else
            {
                Console.WriteLine("\nModification Failed");
            }
            Console.WriteLine("\nPress Any Key To Continue...");
            Console.ReadLine();
        }
        public void DisplayStudentUI()
        {
            if (this.students.Count == 0)
            {
                Console.WriteLine("The Student Record is Empty\n");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\t\t\t========== STUDENT RECORD LIST =========");
                foreach (Student student in this.students)
                {
                    Console.WriteLine(student.ToString());
                }
            }
        }
        public void ExitUI()
        {
            Console.WriteLine("\nSaving Changes...");
            Console.WriteLine("\nPress Any Key To Continue...");
            Console.ReadLine();
            FileManager.SaveToFile(students);
        }
    }
}