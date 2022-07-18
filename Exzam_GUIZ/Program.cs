using Exam_Project;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Exzam_GUIZ
{
    class Program
    {
        static void Start()
        {
            Console.WriteLine("Hello! Welkom to Guiz!");
            Console.WriteLine("Зарегистрированный пользователь - ввести 1");
            Console.WriteLine("Для регистрации ввести 2");
            Console.WriteLine("Для выхода из программы ввести 3");
        }
        static void StartLK()
        {
            Console.WriteLine("Hello! Welkom to LK!");
            Console.WriteLine("Для изменения регистрационных данных - ввести 1");
            Console.WriteLine("Викторина по географии - ввести 2");
            Console.WriteLine("Викторина по биологии - ввести 3");
            Console.WriteLine("Викторина по разным областям знаний - ввести 4");
            Console.WriteLine("Посмотреть рейтинги и статистику - ввести 5");
            Console.WriteLine("Для выхода из раздела - ввести 0");
        }
        static void StartAdmin()
        {
            Console.WriteLine("Hello Admin!");
            Console.WriteLine("AddingGuiz, click 1");
            Console.WriteLine("Testing , click 2");
            Console.WriteLine("Creat Geneal Guiz, click 3");
            Console.WriteLine("If you are EXIT, click 4");
        }
        static void AddingGuizAdmin()
        {
            Console.WriteLine("Adding Guiz");
            Console.WriteLine("Input geography Guiz, click 1");
            Console.WriteLine("Input biology Guiz, click 2");
            Console.WriteLine("For Exit, click 3");
        }
        static void TestingGuiz()
        {
            Console.WriteLine("Testing GUIZ");
            Console.WriteLine("Anloading geography Guiz, click 1");
            Console.WriteLine("Anloading biology Guiz, click 2");
            Console.WriteLine("Random Guiz, click 3");
            Console.WriteLine("Statistic, click 4");
            Console.WriteLine("For Exit, click 5");
        }
        public static List<List<string>> UnloadGeneralGuiz(List<int> index)
        {
            Guiz geoG = new Geography("", "", "");
            Guiz bioG = new Biology("", "", "");
            Guiz Gen = new GeneralGuiz("", "", "");
            List<List<string>> Guiz = new List<List<string>>();

            List<string> keyG = new List<string>();
            string[] keys1 = File.ReadAllLines(geoG.patchkey);
            string[] keys2 = File.ReadAllLines(bioG.patchkey);
            foreach (var line in keys1) keyG.Add(line.ToString());
            foreach (var line in keys2) keyG.Add(line.ToString());
            var kyG = from line in keyG select line;
            File.WriteAllLines(Gen.patchkey, kyG);

            List<string> valueG = new List<string>();
            string[] values1 = File.ReadAllLines(geoG.patchvalue);
            string[] values2 = File.ReadAllLines(bioG.patchvalue);
            foreach (var line in values1) valueG.Add(line.ToString());
            foreach (var line in values2) valueG.Add(line.ToString());
            var valG = from line in valueG select line;
            File.WriteAllLines(Gen.patchvalue, valG);

            List<string> answerG = new List<string>();
            string[] answers1 = File.ReadAllLines(geoG.patchanswer);
            string[] answers2 = File.ReadAllLines(bioG.patchanswer);
            foreach (var line in answers1) answerG.Add(line.ToString());
            foreach (var line in answers2) answerG.Add(line.ToString());
            var ansG = from line in answerG select line;
            File.WriteAllLines(Gen.patchanswer, ansG);
            List<string> keyrand = new List<string>();
            List<string> valrand = new List<string>();
            List<string> answerrand = new List<string>();
            for (int i = 0; i < index.Count; i++)
            {
                keyrand.Add(keyG[index[i]]);
                valrand.Add(valueG[index[i]]);
                answerrand.Add(answerG[index[i]]);                               
            }
            Guiz.Add(keyrand);
            Guiz.Add(valrand);
            Guiz.Add(answerrand);
            return Guiz;
        }
        private static void OptionAdmin()
        {
            Person p = new Person();
            Statistics onguiz = new Statistics();
            string b;
            do
            {
                StartAdmin();
                b = Console.ReadLine().ToLower();
                switch (b)
                {
                    case "1":
                        AddingGuizAdmin();
                        b = Console.ReadLine().ToLower();
                        switch (b)
                        {
                            case "1":
                                Guiz geography = new Geography("", "", "");
                                geography.AddingGuiz();
                                break;
                            case "2":
                                Guiz biology = new Biology("", "", "");
                                biology.AddingGuiz();
                                break;
                            case "3":

                                break;
                            case "4":
                                break;
                        }
                        break;
                    case "2":
                        TestingGuiz();
                        b = Console.ReadLine().ToLower();

                        switch (b)
                        {
                            case "1":
                                Guiz geo = new Geography("", "", "");
                                geo.PassingTheGuiz(geo.UnloadingGuiz(), p.UnloadingIndex());
                                break;
                            case "2":
                                Guiz bio = new Biology("", "", "");
                                bio.PassingTheGuiz(bio.UnloadingGuiz(), p.UnloadingIndex());
                                break;
                            case "3":
                                GeneralGuiz randguiz1 = new GeneralGuiz("", "", "");
                                randguiz1.PassingTheGuiz(UnloadGeneralGuiz(randguiz1.RandIndex()), p.UnloadingIndex());
                                break;
                            case "4":
                                onguiz.TOP20(onguiz.UnloadingStatistic());
                                break;
                            case "5":
                                break;
                        }
                        break;
                }
                Console.WriteLine("For leter, click any key. For EXIT - Print \"0\"");
                b = Console.ReadLine().ToLower();
            } while (b != "0");
        }
        private static void Registr(List<Person> people)
        {
            Person person = new Person();
            Statistics stat = new Statistics();
            person.Input();            
            StringBuilder logpass = new StringBuilder();
            logpass.Append($"{person.name} {person.surname} {person.dob} {person.Login} {person.Password}\n");            
            if (people == null) File.AppendAllText(person.patchperson, logpass.ToString());
            else
            {
                List<string> str1 = new List<string>();
                int c = 0;
                for (int i = 0; i < people.Count; i++)
                {
                    str1.Add(people[i].Login);
                    if (!str1[i].Equals(person.Login)) c++;                   
                }
                if (c == people.Count)
                {
                    File.AppendAllText(person.patchperson, logpass.ToString());
                    stat.Login = person.Login; stat.name = person.name; stat.surname = person.surname;
                    StringBuilder statrigth = new StringBuilder();
                    statrigth.Append($"{stat.Login} {stat.name} {stat.surname} {stat.RigthCount}\n");
                    File.AppendAllText(stat.patchstat, statrigth.ToString());
                    Console.WriteLine($"{person.name} {person.surname} {person.dob} Login: {person.Login} Password: {person.Password}");
                    Console.WriteLine("Сохраните логин и пароль для дальнейшей работы в программе.");                    
                    Console.WriteLine("Yor registration yes");
                }
                else
                {
                    Console.WriteLine("Регистрация не состоялась, повторите процедуру.");
                    return;
                }
            }
        }
        private static void LK(int index, List<Person> people)
        {
            Statistics onguiz = new Statistics();
            Person person = new Person();
            string a;
            if (index > -1)
            {
                    Console.WriteLine("Вход выполнен\n");
                do
                {
                    StartLK();
                    a = Console.ReadLine();
                    switch (a)
                    {
                        case "1":
                            Console.WriteLine("Редактирование личных данных:");
                            onguiz.ChangDateLK(person.UnloadingPersons(), onguiz.UnloadingStatistic(), person.UnloadingIndex());
                            break;
                        case "2":
                            Guiz geo = new Geography("", "", "");
                            geo.PassingTheGuiz(geo.UnloadingGuiz(), person.UnloadingIndex());
                            break;
                        case "3":
                            Guiz bio = new Biology("", "", "");
                            bio.PassingTheGuiz(bio.UnloadingGuiz(), person.UnloadingIndex());
                            break;
                        case "4":
                            GeneralGuiz randguiz1 = new GeneralGuiz("", "", "");
                            randguiz1.PassingTheGuiz(UnloadGeneralGuiz(randguiz1.RandIndex()), person.UnloadingIndex());
                            break;
                        case "5":
                            onguiz.TOP20(onguiz.UnloadingStatistic());
                            break;
                        case "6":
                            break;
                    }
                    Console.WriteLine("Для продолжения работы, введите \"1\", для выхода введите \"0\"");
                    a = Console.ReadLine();
                } while (a != "0");
            }
            else { Console.WriteLine("Логин или пароль введены не верно, повторите процедуру."); return; }
        }
        static void Main(string[] args)
        {
            Person person = new Person();            
            string b;
            do
            {
                Start();
                b = Console.ReadLine().ToLower();
                switch (b)
                {
                    case "1":
                        LK(person.Authentication(person.UnloadingPersons()), person.UnloadingPersons());
                        break;
                    case "2":
                        Registr(person.UnloadingPersons());
                        break;
                    case "3":

                        break;
                    case "admin":
                        OptionAdmin();
                        break;
                }
                Console.WriteLine("Для продолжения работы нажмите любую клавишу, для выхода из программы введите \"0\"");
                b = Console.ReadLine().ToLower();
            } while (b != "0");
        }
    }
}


