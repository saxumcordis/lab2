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
            Console.WriteLine(new Repository<Student>().get(3).name);
            Console.ReadKey();
        }


        

    }
}
