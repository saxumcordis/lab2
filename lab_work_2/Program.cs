using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace lab_work_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // DB.execute("DELETE FROM students WHERE id = 1");
            DB.execute("UPDATE students SET name = 'имя2' WHERE id = 2");
            // DB.execute("INSERT INTO students (name, birth, university, class, level, gpa) VALUES('tolek plakat xochet', '1901', 'memos', 'sbv', 1, 1)");
            Console.ReadKey();
        }


        

    }
}
