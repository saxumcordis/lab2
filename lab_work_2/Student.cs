using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work_2
{
    public class Student
    {
        public int id { get; set; }
        public string name { get; set; }
        public string birth { get; set; }
        public string university { get; set; }
        public string classString { get; set; }
        public int level { get; set; }
        public int gpa { get; set; }

        public Student() { }

        public Student(int id, string name, string birth, string university,
            string classString, int level, int gpa) {
            this.id = id;
            this.name = name;
            this.birth = birth;
            this.university = university;
            this.classString = classString;
            this.level = level;
            this.gpa = gpa;
            }

    }

}
    