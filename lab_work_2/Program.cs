﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace lab_work_2
{
    class Program
    {
        private static readonly Repository<Student> repository = new Repository<Student>();
        private static KeyValuePair<string, string>[] fieldsArr = {
                new KeyValuePair<string, string>("Name: ", "^.{1,32}$"),
                new KeyValuePair<string, string>("Birth: ", @"^\d{2}\.\d{2}\.\d{4}$"),
                new KeyValuePair<string, string>("University: ", "^.{1,256}$"),
                new KeyValuePair<string, string>("Class: ", "^.{1,32}$"),
                new KeyValuePair<string, string>("Level: ", "^\\d{1,11}$"),
                new KeyValuePair<string, string>("GPA: ", "^((100)|(\\d{1,2}([.|,]\\d)?))$")
};
        private static object getFieldFromConsole(KeyValuePair<string, string> fieldArr)
        {
            Console.WriteLine(fieldArr.Key);
            var temp = Console.ReadLine();
            if (Regex.IsMatch(temp, fieldArr.Value))
                return temp;
            Console.WriteLine("Wrong input");
            return getFieldFromConsole(fieldArr);
        }
        private static void add()
        {
            try
            {
                var arr = new object[7];
                arr[0] = 0;
                for (var i = 1; i < 7; ++i)
                    arr[i] = getFieldFromConsole(fieldsArr[i - 1]);

                repository.add((Student)new Student().fromRepository(arr));
            }
            catch (Exception e)
            {
                Console.WriteLine("Wrong input " + e);
            }
        }
        private static void update()
        { Console.WriteLine("Enter student's id");
            var id = Int32.Parse(Console.ReadLine());
            var student = repository.get(id);
            Console.WriteLine("Choose the field: \n1. Name \n2. Birth \n3. University \n4. Class \n5. Level \n6. GPA");
            int choice = Int32.Parse(Console.ReadLine());
            var value = getFieldFromConsole(fieldsArr[choice - 1]);
            switch (choice)
            {
                case 1:
                    student.name = (string)value;
                    break;
                case 2:
                    student.birth = (string)value;
                    break;
                case 3:
                    student.university = (string)value;
                    break;
                case 4:
                    student.@class = (string)value;
                    break;
                case 5:
                    student.level = Int32.Parse((string)value);
                    break;
                case 6:
                    student.gpa = float.Parse((string)value);
                    break;
                default:
                    throw new ArgumentException();
            }
            repository.update(student);
        }

        public static void delete()
        {
            Console.WriteLine("Enter the ID");
            repository.delete(Int32.Parse(Console.ReadLine()));
        }
        public static void getByName()
        {
            repository.getByName((string)getFieldFromConsole(fieldsArr[0]));
        }
        public static void getByBirth()
        {
            repository.getByName((string)getFieldFromConsole(fieldsArr[1]));
        }
        public static void sort()
        {
            Console.WriteLine("Choose the type of sort: \n1) Ascending \n2) Descending");
            var sortType = Int32.Parse(Console.ReadLine()) == 1 ? Order.ASC : Order.DESC;
            Console.WriteLine("Choose the field: \n1) name \n2) birth");
            var field = Int32.Parse(Console.ReadLine());
            switch (field) {
                case 1:                  
                    repository.all("name", sortType);
                    break;
                case 2:
                    repository.all("birth", sortType);
                    break;
            }                    
            }
        public static void getExtremeGPA()
        {
            repository.getMaxGPA();
            repository.getMaxGPA();
        }
        
    
        static void Main(string[] args)
        {
            Console.WriteLine("You are working with this DB:");
            
            while (true)
            {
                print(repository.all());
                while (true)
                {
                    Console.WriteLine("Select: \n1) add \n2) update \n3) delete \n4) sort \n5) findbyname \n6) findbybirth \n7) getExtremeGPA ");        
                    try
                    {
                        switch (Int32.Parse(Console.ReadLine()))
                        {
                            case 1:
                                add();
                                break;
                            case 2:
                                update();
                                break;
                            case 3:
                                delete();
                                break;
                            case 4:
                                sort();
                                break;
                            case 5:
                                getByName();
                                break;
                            case 6:
                                getByBirth();
                                break;
                            case 7:
                                getExtremeGPA();
                                break;
                            default:    
                                throw new ArgumentException();
                        }
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Wrong input");
                    }
                }
            }
        }
        private static void print(List<Student> students)
        {
            if (students.Count > 0)
            {
                var max = new[] { 2, 4, 10, 10, 5, 5, 3 };

                foreach (var student in students)
                {
                    if (student.id.ToString().Length > max[0])
                        max[0] = student.id.ToString().Length;
                    if (student.name.Length > max[1])
                        max[1] = student.name.Length;
                    if (student.university.Length > max[3])
                        max[3] = student.university.Length;
                    if (student.@class.Length > max[4])
                        max[4] = student.@class.Length;
                    if (student.level.ToString().Length > max[5])
                        max[5] = student.level.ToString().Length;
                    if (student.gpa.ToString().Length > max[6])
                        max[6] = student.gpa.ToString().Length;
                }

                Console.WriteLine("{0," + (-max[0]) + "} {1," + (-max[1])
                + "} {2," + (-max[2]) + "} {3," + (-max[3])
                + "} {4," + (-max[4]) + "} {5," + (-max[5])
                + "} {6," + (-max[6]) + "}",
                "id", "name", "birth", "university", "class", "level", "gpa");
                foreach (var student in students)
                    Console.WriteLine("{0," + (-max[0]) + "} {1," + (-max[1])
                + "} {2," + (-max[2]) + "} {3," + (-max[3])
                + "} {4," + (-max[4]) + "} {5," + (-max[5])
                + "} {6," + (-max[6]) + "}",
                    student.id, student.name, student.birth, student.university, student.@class,
                    student.level, student.gpa);
            }
            else
                Console.WriteLine("Table is empty");

        }

        }



    }

