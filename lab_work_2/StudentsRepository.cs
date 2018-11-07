using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work_2
{
    public class StudentsRepository
    {
        public static void save(Student student)
        {
            DB.execute("INSERT INTO students(name, birth, university, class, level, gpa) VALUES(" + studentToString(student) + ")");
        }
       
        


        private static string studentToString(Student student)
        {
            return "'" + student.name + "', '" + student.birth + "', '" + student.university + "', '"
+ student.@class + "', " + student.level + ", " + student.gpa;
        }
        public static void update(Student student)
        {
            if (student.id != null && student.id > 0)
            {
                DB.execute("UPDATE students SET name = '" + student.name + "', birth = '" + student.birth
+ "', university = '" + student.university + "', class = '" + student.@class
+ "', level = " + student.level + ", gpa = " + student.gpa + " WHERE id = " + student.id);
            }
        }
        public static void delete(int id)
        {
            if (id > 0)
                DB.execute("DELETE FROM students WHERE id = " + id);
        }
        public static Student get(int id)
        {
            if (id > 0)
            {
                var list = DB.execute("SELECT * FROM students WHERE id = " + id);
                if (list.Count > 0)
                    return new Student(
                            int.Parse(list[0][0].ToString()), (string)list[0][1], (string)list[0][2],
                                    (string)list[0][3], (string)list[0][4], int.Parse(list[0][5].ToString()),
                                            int.Parse(list[0][6].ToString()));
                return null;
            }

            return null;
        }
    }
}
