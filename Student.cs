using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRecords
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double GPA { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, GPA: {GPA}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Student other)
            {
                return Id == other.Id && Name == other.Name && GPA == other.GPA;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, GPA);
        }

    }
}
