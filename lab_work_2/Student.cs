using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work_2
{
    public class Student : Entity
    {

        public string name { get; set; }
        public string birth { get; set; }
        public string university { get; set; }
        public string @class { get; set; }
        public int level { get; set; }
        public float gpa { get; set; }

        public Student() { }

        public Student(int id, string name, string birth, string university,
            string @class, int level, float gpa)
        {
            this.id = id;
            this.name = name;
            this.birth = birth;
            this.university = university;
            this.@class = @class;
            this.level = level;
            this.gpa = gpa;
        }
        public override Entity fromRepository(object[] arr)
        {
            Int32.Parse(arr[0].ToString());
            arr[1].ToString();
            arr[2].ToString();
            arr[3].ToString();
            arr[4].ToString();
            Int32.Parse(arr[5].ToString());
            float.Parse(arr[6].ToString());
            return this;
        }
        public bool Equals(Student other)
        {
            return string.Equals(name, other.name) && string.Equals(university, other.university)
            && string.Equals(@class, other.@class) && level == other.level
            && gpa.Equals(other.gpa);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Student)obj);
        }
    }
}