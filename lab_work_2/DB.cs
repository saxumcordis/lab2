using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace lab_work_2
{
    public class DB
    {
        private static readonly DB instance = new DB();

        private readonly MySqlConnection db;
        private DB()
        {
            db = new MySqlConnection("Database=CLASSROOM;Data Source=localhost;User Id=root;Password=");
        }


        public static List<object[]> execute(string query)
        {
            var command = new MySqlCommand(query, instance.db);

            instance.db.Open();

            var result = new List<object[]>();




            for (var reader = command.ExecuteReader(); reader.Read();)
            {
                var arr = new object[reader.FieldCount];
                reader.GetValues(arr);
                result.Add(arr);
            }



            instance.db.Close();
            return result;
        }
        public void read(string query) { }
    }
}
