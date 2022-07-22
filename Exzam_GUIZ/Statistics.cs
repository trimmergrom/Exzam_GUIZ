using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Exam_Project
{    
    public class Statistics : Person, ICloneable
    {
        public string patchstat = "Statistic.txt";
        public string patchTOP = "TOP20.txt";
        public int index { get; set; }
        public int rating { get; set; }
        int generalcount;
        
        public int GeneralCount
        { get => generalcount;
            set { generalcount += rigthcount; }
        }
        private int rigthcount;
        public int RigthCount
        {
            get => rigthcount;
            set
            {
                if (value >= 0 && value <= 20) rigthcount = value;
                if (value > 20) rigthcount = 20;
            }
        }
        public Statistics() { }
        public new object Clone()
        {
            return new Statistics(Login, name, surname, generalcount);
        }
        public Statistics(string Login) : base(Login)
        {

        }
        public Statistics(string Login, string Name, string Surname, int GeneralCount) : base(Login, Name, Surname)
        {
            generalcount = GeneralCount;
        }
        public static int CompareByRating(Statistics stat1, Statistics stat2)
        {
            return stat1.generalcount.CompareTo(stat2.generalcount);
        }
        public void ChangDateLK(List<Person> people, List<Statistics> stat, int Value)
        {
            Console.WriteLine("Enter DOB:");
            people[Value].dob = Console.ReadLine();
            Console.WriteLine("Enter Login:");
            people[Value].Login = Console.ReadLine();

            StringBuilder stringperson = new StringBuilder();

            foreach (var person in people)
            {
                stringperson.Append($"{person.name} {person.surname} {person.dob} {person.Login} {person.Password}\n");
            }
            StringBuilder stringstat = new StringBuilder();
            stat[Value].Login = people[Value].Login;
            foreach (var statistics in stat)
            {
                stringstat.Append($"{statistics.Login} {statistics.name} {statistics.surname} {statistics.generalcount}\n");
            }
            Console.WriteLine(stringperson);
            Console.WriteLine(stringstat);
            File.WriteAllText(patchperson, stringperson.ToString());
            File.WriteAllText(patchstat, stringstat.ToString());
        }
        public List<Statistics> UnloadingStatistic()
        {
            List<Statistics> stat = new List<Statistics>();
            if (!File.Exists(patchstat)) return null;
            else
            {
                string[] Lines = File.ReadAllLines(patchstat);
                foreach (var line in Lines)
                {
                    string[] str = line.Split(' ');
                    Statistics statArr = new Statistics
                    
                    {
                        Login = str[0],
                        name = str[1],
                        surname = str[2],
                        generalcount = int.Parse(str[3])
                    };
                    stat.Add(statArr);
                }                             
            }
            return stat;
        }
        public void TOP20(List<Statistics> stat)
        {
            Statistics[] statistics = new Statistics[stat.Count];           
            for (int i = 0; i < stat.Count; i++) statistics[i] = stat[i];

            Array.Sort(statistics, Statistics.CompareByRating);
            for(int i = statistics.Length-1; i >=0; i--)
            {
                Console.WriteLine($"{statistics[i].Login} {statistics[i].name} {statistics[i].surname} {statistics[i].generalcount}\n");
                if (i > 19) break;
            }
        }        
        public void UpdateStatistic(List<Statistics> stat, int index, int RigthCount)
        {
            stat[index].generalcount += RigthCount;
            StringBuilder str = new StringBuilder();
            foreach (var statistics in stat)
            {
                str.Append($"{statistics.Login} {statistics.name} {statistics.surname} {statistics.generalcount}\n");
            }            
            File.WriteAllText(patchstat, str.ToString());
        }
    }

}