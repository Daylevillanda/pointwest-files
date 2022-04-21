using System;
using LabEx7.Model;
using LabEx7.Service;
using LabEx7.View;

namespace LabEx7
{
    class StudentRecordManager
    {
        UserInterface userInterface;
        public StudentRecordManager()
        {
            this.userInterface = new();
        }
        public void Start()
        {
            while(true)
            {
                string choice = userInterface.MainMenu();
                switch (choice)
                {
                    case "1":
                        userInterface.AddStudentUI();
                        break;
                    case "2":
                        userInterface.DisplayStudentUI();
                        Console.WriteLine("\nPress Any Key To Continue...");
                        Console.ReadLine();
                        break;
                    case "3":
                        userInterface.ModifyStudentUI();
                        break;
                    case "4":
                        userInterface.DeleteStudentUI();
                        break;
                    case "5":
                        userInterface.ExitUI();
                        break;
                    default:
                        break;

                }

            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            StudentRecordManager studentRecordManager = new StudentRecordManager();
            studentRecordManager.Start();
        }
    }
}
