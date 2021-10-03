using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            person person = new person();
            person.initMenu();
        }
    }



    class book
    {
        private string bookid;
        private string bookname;

        private List<book> bookList = new List<book>();

        public void ShowBookList()
        {
            Console.WriteLine("Book List");
            Console.WriteLine("----------------------------------------");
            foreach (var book in bookList)
            {
                Console.WriteLine("Book ID:" + book.bookid);
                Console.WriteLine("Book name:" + book.bookname);
            }
        }

    }

    class person
    {
        private List<person> personList = new List<person>();
        public string name;
        public string password;
        public string usertype;
        public string id;

        public void initMenu()
        {
            clearscreen();

            string selectMenu;

            Console.WriteLine("Welcome to Digital Library");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("1.Login");
            Console.WriteLine("2.Register");
            Console.Write("Select Menu:");

            selectMenu = Console.ReadLine();

            if (selectMenu == "1")
            {
                Login();
            }
            else
            {
                Register();
            }
        }

        public void Register()
        {
            clearscreen();
            Console.WriteLine("Register new Person");
            Console.WriteLine("-------------------");

            Console.WriteLine("Input name:");
            name = Console.ReadLine();
            Console.WriteLine("Input Password:");
            password = Console.ReadLine();
            Console.WriteLine("Input User Type 1 = Student, 2 = Employee:");
            usertype = Console.ReadLine();
            if (usertype == "1")
            {
                Console.WriteLine("Student ID:");
            }
            else
            {
                Console.WriteLine("Employee ID:");
            }

            id = Console.ReadLine();

            personList.Add(new person() { name = name, password = password, usertype = usertype, id = id });

            initMenu();
        }

        public void Login()
        {
            clearscreen();

            Console.WriteLine("Login Screen");
            Console.WriteLine("------------");
            Console.WriteLine("Input name:");
            name = Console.ReadLine();
            Console.WriteLine("Input Password:");
            password = Console.ReadLine();

            var person = personList.Where(a => a.name == name && a.password == password).FirstOrDefault();

            if (person != null)
            {
                if (person.usertype == "1")
                {
                    displayStudentMenu(person.name, person.id);
                }
                else
                {
                    displayEmployeeMenu(person.name, person.id);
                }
            }
            else
            {
                initMenu();
            }
        }

        public void displayStudentMenu(string name, string id)
        {
            string selectMenu;
            clearscreen();
            Console.WriteLine("Student Management");
            Console.WriteLine("-------------------");
            Console.WriteLine("Name:" + name);
            Console.WriteLine("Student ID:" + id);
            Console.WriteLine("-------------------");
            Console.WriteLine("1.Borrow Books");
            Console.WriteLine("Input Menu:");

            selectMenu = Console.ReadLine();

            if (selectMenu == "1")
            {
                book book = new book();
                book.ShowBookList();
            }

        }

        public void displayEmployeeMenu(string name, string id)
        {
            string selectMenu;
            clearscreen();
            Console.WriteLine("Employee Management");
            Console.WriteLine("-------------------");
            Console.WriteLine("Name:" + name);
            Console.WriteLine("Employee ID:" + id);
            Console.WriteLine("-------------------");
            Console.WriteLine("1.Get List Books");
            Console.WriteLine("Input Menu:");

            selectMenu = Console.ReadLine();

            if (selectMenu == "1")
            {
                book book = new book();
                book.ShowBookList();
            }

        }

        public void borrowBook()
        {
            string bookid;
            clearscreen();

            book book = new book();
            book.ShowBookList();

            Console.WriteLine("Input Book Id:");

            bookid = Console.ReadLine();

            if (bookid != "exit")
            {
                borrowBook();
            }
            else
            {
                initMenu();
            }


        }

        static void clearscreen()
        {
            Console.Clear();
        }
    }

}
