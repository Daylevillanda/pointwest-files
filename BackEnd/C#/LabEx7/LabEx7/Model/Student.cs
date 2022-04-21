using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabEx7.Model
{
    public enum GradeLevel
    {
        ONE = 1, TWO, THREE, FOUR, FIVE, SIX
    }
    public enum Section
    {
        A = 1, B, C, D, E
    }
    class Student : IEquatable<Student>
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GradeLevel GradeLevel { get; set; }
        public Section Section { get; set; }

        public bool Equals(Student other)
        {
            return this.ID == other.ID;
        }
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public override string ToString()
        {
            return $"Student ID: {ID} | First Name: {FirstName} | Last Name: {LastName} | Grade Level: {GradeLevel} | Section: {Section} ";
        }
    }
}
