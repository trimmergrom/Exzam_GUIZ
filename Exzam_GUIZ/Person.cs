using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Exam_Project
{
    public interface ICloneable
    {
        object Clone();        
    }
    public  class Person : ICloneable 
    {
        public string patchperson = "person.txt";
        public string patchindex = "index.txt";
        public string name { get; set; }
        public string surname { get; set; }
        public string dob { get; set; }
        string login;
        string password;
        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public Person() { }
        public object Clone()
        {
            return new Person(Login, name, surname);
        }
        public Person(string Login)
        {
            login = Login;
        }
        public Person(string Login, string Name, string Surname)
        {
            login = Login;
            name = Name;
            surname = Surname;
        }
        public Person(string Name, string Surname, string dob, string Login, string Password)
        {
            name = Name;
            surname = Surname;
            this.dob = dob;
            login = Login;
            password = Password;
        }

        //public Person(string name, string surname)
        //{
        //    this.name = name;
        //    this.surname = surname;
        //}

        public void Input()
        {
            Console.WriteLine("Enter your name: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter your surname: ");
            surname = Console.ReadLine();
            Console.WriteLine("Enter your Date of birth: ");
            dob = Console.ReadLine();

            string symbols1 = name + surname + dob;
            StringBuilder log = new StringBuilder();
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                int index = random.Next(0, symbols1.Length - 1);
                log.Append(symbols1[index]);
            }
            login = surname + "_" + log.ToString();
            string symbols = "qwert1234567890yasdfghjkl;\\/mnbvcxz!№%?*_+@#$^&-=QWERTYUIOPLKJHGFDSAZXCVBNM";            
            StringBuilder pass = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                int index = random.Next(0, symbols.Length - 1);
                pass.Append(symbols[index]);
            }
            password = pass.ToString();            
        }
        public  List<Person> UnloadingPersons()
        {
            List<Person> people = new List<Person>();
            if (!File.Exists(patchperson)) return null;                       
            else
            {
                string[] lines = File.ReadAllLines(patchperson);
                foreach (var line in lines)
                {
                    string[] str = line.Split(' ');
                    Person person = new Person
                    {
                        name = str[0],
                        surname = str[1],
                        dob = str[2],
                        Login = str[3],
                        Password = str[4]
                    };
                    people.Add(person);
                }
            }
            return people;
        }
        public int Authentication(List<Person> people)
        {
            Console.WriteLine("Введите логин и пароль:");
            string Log = Console.ReadLine();
            string Pass = Console.ReadLine();
            int index = -1;
            for (int i = 0; i < people.Count; i++)
            {
                if (people[i].Login.Equals(Log) && people[i].Password.Equals(Pass)) index = i;
            }
            File.WriteAllText(patchindex, index.ToString());
            return index;
        }
        public int UnloadingIndex()
        {
            string str = File.ReadAllText(patchindex);
            int index = int.Parse(str);
            return index;
        }
    }
}
