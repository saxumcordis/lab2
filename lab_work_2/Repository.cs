using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work_2
{
    public  class Repository<T> where T : Entity, new() 
    {
        public void delete(int id)
        {
            if (id > 0)
                DB.execute(
            "DELETE FROM " + typeof(T).Name.ToLowerInvariant() + "s WHERE id = " + id
            );

        }
        private static string studentToString(T entity)
        {
            var result = "";
            foreach (var property in typeof(T).GetProperties())
            {
                var value = property.GetValue(entity);
                if (property.Name != "id")
                    result += property.Name.ToLower() + " = " + (value is string ? "'" : "")
                    + (value is float ? value.ToString().Replace(',', '.') : value)
                    + (value is string ? "'" : "") + ", ";
            }
            return result.Substring(0, result.Length - 2);


        }
        public void update(T entity)
        {
            if (entity.id > 0)
                DB.execute(
                "UPDATE " + typeof(T).Name.ToLower() + "s SET " + studentToString(entity) + " WHERE id = " + entity.id);
        }
        public void add(T entity)
        {
            DB.execute(
            "INSERT INTO " + typeof(T).Name.ToLower() + "s SET " + studentToString(entity));
        }
        public T get(int id)
        {
            if (id > 0)
            {
                var list = DB.execute(
                 "SELECT * FROM " + typeof(T).Name.ToLower() + "s WHERE id =" + id);
                if (list.Count > 0)
                    return (T)new T().fromRepository(list[0]);
                else
                    return null;
            }
            else
                return null;
        }
        public List<T> all(string orderBy = "id", Order order = Order.ASC)
        {
            var result = new List<T>();
            foreach (var entity in DB.execute("SELECT * FROM " + typeof(T).Name.ToLower()
            + "s ORDER BY " + orderBy + " " + order))
                result.Add((T)new T().fromRepository(entity));
            return result;
        }
        public List<T> getByName(string name)
        {      
            var list = DB.execute(
"SELECT * FROM " + typeof(T).Name.ToLower() + "s WHERE name =" + name +"");
                if (list.Count > 0)
                {
                var result = new List<T>();
                foreach (var student in list)
                    result.Add((T)new T().fromRepository(student));
                return result;
            }
                else
                    return null;
            
        }
            
            public List<T> getByBirth(string birth) {
            var list = DB.execute(
"SELECT * FROM " + typeof(T).Name.ToLower() + "s WHERE birth =" + birth + "");
            if (list.Count > 0)
            {
                var result = new List<T>();
                foreach (var student in list)
                    result.Add((T)new T().fromRepository(student));
                return result;
            }
            else
                return null;
        }
        public List<T> getMaxGPA()
        {
            var list = DB.execute("SELECT MAX(gpa) FROM students");
            if (list.Count > 0)
            {
                var result = new List<T>();
                foreach (var student in list)
                    result.Add((T)new T().fromRepository(student));
                return result;
            }
            else
                return null;
        }
        public List<T> getMinGPA()
        {
            var list = DB.execute("SELECT MIN(gpa) FROM students");
            if (list.Count > 0)
            {
                var result = new List<T>();
                foreach (var student in list)
                    result.Add((T)new T().fromRepository(student));
                return result;
            }
            else
                return null;
        }
    }
}

    