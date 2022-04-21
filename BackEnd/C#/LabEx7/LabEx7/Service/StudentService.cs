using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabEx7.Model;

namespace LabEx7.Service
{
    class StudentService
    {
        HashSet<Student> students = new()
        {
            new Student() { ID = 1, FirstName = "John", LastName = "Doe", GradeLevel = GradeLevel.TWO, Section = Section.B },
            new Student() { ID = 2, FirstName = "Ward", LastName = "Doe", GradeLevel = GradeLevel.ONE, Section = Section.C },
            new Student() { ID = 3, FirstName = "Cris", LastName = "Doe", GradeLevel = GradeLevel.THREE, Section = Section.A },
        };

        public Student GetStudent(int id)
        {
            foreach (Student student in students)
            {
                if (student.ID == id)
                {
                    return student;
                }
            }
            return null;
        }
        public HashSet<Student> GetStudents()
        {
            return students;
        }
        public bool AddStudent(Student student)
        {
            return students.Add(student);
        }
        public bool DeleteStudent(int id)
        {
            Student student = GetStudent(id);
            return students.Remove(student);
        }
        public bool ModifyStudent(int id, string firstName, string lastName, GradeLevel gradeLevel, Section section)
        {
            Student originalStudent = GetStudent(id);
            originalStudent.FirstName = firstName;
            originalStudent.LastName = lastName;
            originalStudent.GradeLevel = gradeLevel;
            originalStudent.Section = section;
            return true;
        }
    }
}

