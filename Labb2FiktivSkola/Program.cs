using Labb2FiktivSkola.Models;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Security.Cryptography.X509Certificates;

namespace Labb2FiktivSkola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SchoolDbContext context = new SchoolDbContext();
            ProgramStart(context);
        }

        public static void ProgramStart(SchoolDbContext context)
        {
            Console.Clear();
            Console.Write("\n\tVad vill du göra?" +
                "\n\t[1]Visa alla elever" +
                "\n\t[2]Visa alla elever i en klass" +
                "\n\t[3]Lägg till ny personal" +
                "\n\t: ");
            int.TryParse(Console.ReadLine(), out int choice);
            switch (choice)
            {
                case 1:
                    ShowAllStudents(context);
                    break;

                case 2:
                    ShowSpecificClassStudents(context);
                    break;

                case 3:
                    AddEmployee(context);
                    break;

                default:
                    Console.Write("!!!ERROR!!!");
                    Console.ReadLine();
                    ProgramStart(context);
                    break;
            }
        }

        public static void ShowAllStudents(SchoolDbContext context)
        {
            bool nameSort = SortByFirstOrLastName();
            bool sortOrder = SortAccendingOrDecending();

            if (nameSort == true && sortOrder == true)
            {
                var students = context.ConnectionTbls
                    .Where(x => x.StudentId != null)
                    .Select(x => x.Person.FullName)
                    .Distinct();

                foreach (var item in students)
                {
                    Console.Write($"\n\t{item}");
                }
            }

            if (nameSort == true && sortOrder == false)
            {
                string oldItem = "";

                var students = context.ConnectionTbls
                    .Where(x => x.StudentId != null)
                    .OrderByDescending(x => x.Person.FullName)
                    .Select(x => x.Person.FullName);

                foreach (var item in students)
                {
                    if (item == oldItem)
                    {
                        continue;
                    }
                    Console.Write($"\n\t{item}");
                    oldItem = item;
                }
            }

            if (nameSort == false && sortOrder == true)
            {
                var students = context.ConnectionTbls
                    .Where(x => x.StudentId != null)
                    .Select(x => x.Person.FullName) //här hade man användt sig av "LastName" istället t.ex.
                    .Distinct();

                foreach (var item in students)
                {
                    Console.Write($"\n\t{item}");
                }
            }

            if (nameSort == false && sortOrder == false)
            {
                string oldItem = "";

                var students = context.ConnectionTbls
                    .Where(x => x.StudentId != null)
                    .OrderByDescending(x => x.Person.FullName) //här hade man användt sig av "LastName" istället t.ex.
                    .Select(x => x.Person.FullName);

                foreach (var item in students)
                {
                    if (item == oldItem)
                    {
                        continue;
                    }
                    Console.Write($"\n\t{item}");
                    oldItem = item;
                }
            }
            Console.ReadLine();
            ProgramStart(context);
        }

        public static bool SortByFirstOrLastName()
        {
            Console.Clear();
            Console.Write("\n\tVill du sortera efter förnamn eller efternamn?" +
                "\n\t[1]Förnamn" +
                "\n\t[2]Efternamn" +
                "\n\t: ");
            int.TryParse(Console.ReadLine(), out int choice);
            switch (choice)
            {
                case 1:
                    return true;

                case 2:
                    return false;

                default:
                    return true;
            }
        }

        public static bool SortAccendingOrDecending()
        {
            Console.Clear();
            Console.Write("\n\tVill du sortersa A till Ö eller Ö till A?" +
                "\n\t[1]A till Ö" +
                "\n\t[2]Ö till A" +
                "\n\t: ");
            int.TryParse(Console.ReadLine(), out int choice);
            switch (choice)
            {
                case 1:
                    return true;

                case 2:
                    return false;

                default:
                    return true;
            }
        }

        public static void ShowSpecificClassStudents(SchoolDbContext context)
        {
            string classNumber = GetClassNumber(context);
            bool nameSort = SortByFirstOrLastName();
            bool sortOrder = SortAccendingOrDecending();

            if (nameSort == true && sortOrder == true)
            {
                var students = context.ConnectionTbls
                    .Where(x => x.StudentId == classNumber)
                    .Select(x => x.Person.FullName)
                    .Distinct();

                foreach (var item in students)
                {
                    Console.Write($"\n\t{item}");
                }
            }

            if (nameSort == true && sortOrder == false)
            {
                string oldItem = "";

                var students = context.ConnectionTbls
                    .Where(x => x.StudentId == classNumber)
                    .OrderByDescending(x => x.Person.FullName)
                    .Select(x => x.Person.FullName);

                foreach (var item in students)
                {
                    if (item == oldItem)
                    {
                        continue;
                    }
                    Console.Write($"\n\t{item}");
                    oldItem = item;
                }
            }

            if (nameSort == false && sortOrder == true)
            {
                var students = context.ConnectionTbls
                    .Where(x => x.StudentId == classNumber)
                    .Select(x => x.Person.FullName) //här hade man användt sig av "LastName" istället t.ex.
                    .Distinct();

                foreach (var item in students)
                {
                    Console.Write($"\n\t{item}");
                }
            }

            if (nameSort == false && sortOrder == false)
            {
                string oldItem = "";

                var students = context.ConnectionTbls
                    .Where(x => x.StudentId == classNumber)
                    .OrderByDescending(x => x.Person.FullName) //här hade man användt sig av "LastName" istället t.ex.
                    .Select(x => x.Person.FullName);

                foreach (var item in students)
                {
                    if (item == oldItem)
                    {
                        continue;
                    }
                    Console.Write($"\n\t{item}");
                    oldItem = item;
                }
            }
            Console.ReadLine();
            ProgramStart(context);
        }

        public static string GetClassNumber(SchoolDbContext context)
        {
            int choiceNumber = 1;

            Console.Clear();
            Console.Write("\n\tVilken klass vill du kolla på?");
            var classes = context.StudentTbls
                .Select(x => x.ClassYear);

            foreach (var item in classes)
            {
                Console.Write($"\n\t[{choiceNumber}]{item}");
                choiceNumber++;
            }

            Console.Write("\n\t: ");
            int.TryParse(Console.ReadLine(), out int choice);

            if (choice < 1 || choice > 9)
            {
                return "1";
            }
            else
            {
                return choice.ToString();
            }
        }

        public static void AddEmployee(SchoolDbContext context)
        {
            Console.Clear();
            Console.Write("\n\tAnge förnamn och efternamn: ");
            string fullName = Console.ReadLine();
            Console.Write("\n\tAnge telefonummer: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("\n\tAnge personnummer: ");
            string personNumber = Console.ReadLine();
            Console.Write("\n\tAnge ålder: ");
            int.TryParse(Console.ReadLine(), out int age);

            int newID = context.PersonTbls.Count();
            PersonTbl person = new PersonTbl()
            {
                Id = newID.ToString(),
                FullName = fullName,
                PhoneNumber = phoneNumber,
                PersonNumber = personNumber,
                Age = age
            };
            context.PersonTbls.Add(person);

            Console.Write("\n\tAnge vilke typ av lärare" +
                "\n\t[1]Mattelärare" +
                "\n\t[2]Programmeringslärare" +
                "\n\t[3]Engelskalärare" +
                ": ");
            int.TryParse(Console.ReadLine(), out int choice);

            int personCount = context.PersonTbls.Count();
            int employeeID = choice + 3;

            ConnectionTbl connection = new ConnectionTbl()
            {
                PersonId = personCount.ToString(),
                EmployeeId = employeeID.ToString(),
                CourseId = choice.ToString()
            };
            context.ConnectionTbls.Add(connection);
            context.SaveChanges();
            ProgramStart(context);
        }
    }
}