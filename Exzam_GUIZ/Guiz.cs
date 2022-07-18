using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Exam_Project
{
    public abstract class Guiz
    {
        public string patchkey;
        public string patchvalue;
        public string patchanswer;        
        public Guiz() { }
        public Guiz(string Patchkey, string Patchvalue, string Patchanswer)
        {
            patchkey = Patchkey;
            patchvalue = Patchvalue;
            patchanswer = Patchanswer;            
        }
        public  void AddingGuiz()
        {
            Console.WriteLine("Введите вопрос: ");
            string strkey = Console.ReadLine();
            StringBuilder key = new StringBuilder();
            key.Append($"{strkey}\n");
            Console.WriteLine("Введите ответ: ");
            string strvalue = Console.ReadLine();
            StringBuilder value = new StringBuilder();
            value.Append($"{strvalue}\n");
            Console.WriteLine("Введите варианты ответа через пробел: ");
            string stransw = Console.ReadLine();
            StringBuilder answ = new StringBuilder();
            answ.Append($"{stransw}\n");            
            File.AppendAllText(patchkey, key.ToString());
            File.AppendAllText(patchvalue, value.ToString());
            File.AppendAllText(patchanswer, answ.ToString());
        }        
        public virtual List<List<string>> UnloadingGuiz()
        {
            List<List<string>> Guiz = new List<List<string>>();
            List<string> key = new List<string>();
            string[] keys = File.ReadAllLines(patchkey);
            foreach (var line in keys) key.Add(line.ToString());
            Guiz.Add(key);
            List<string> value = new List<string>();
            string[] values = File.ReadAllLines(patchvalue);
            foreach (var line in values) value.Add(line.ToString());
            Guiz.Add(value);
            List<string> answer = new List<string>();
            string[] answers = File.ReadAllLines(patchanswer);
            foreach (var line in answers) answer.Add(line.ToString());
            Guiz.Add(answer);
            return Guiz;
        }
        public virtual int PassingTheGuiz(List<List<string>> Guiz, int index)
        {
            Statistics rigth = new Statistics();
            Person p = new Person();
            int c = 0;
            for (int i = 0; i < Guiz[0].Count; i++)
            {
                Console.WriteLine($"{i + 1} {Guiz[0][i]}");
                Console.WriteLine(Guiz[2][i]);
                Console.WriteLine("Введите порядковый номер Вашего варианта ответа в строке, в случае нескольких правильных вариантов ответов, номера ввести через пробел: ");
                string[] ans = Guiz[2][i].Split(' ');
                string[] val = Guiz[1][i].Split(' ');
                string user = Console.ReadLine();
                string[] usArr = user.Split(' ');

                for (int s = 0; s < usArr.Length; s++)
                {
                    if (int.Parse(usArr[s]) > ans.Length || int.Parse(usArr[s]) < 1)
                    {
                        Console.WriteLine("Введено не правильное число < 1 или > 4, повторите ввод");
                        user = Console.ReadLine(); usArr = user.Split(' ');
                    }
                        if (int.Parse(usArr[s]) > ans.Length || int.Parse(usArr[s])< 1 )
                    { Console.WriteLine("Вы уволены!"); break; }                    
                }

                List<string> Ans = new List<string>();
                for (int j = 0; j < usArr.Length; j++) Ans.Add(ans[int.Parse(usArr[j]) - 1]);
                if (val.Length == Ans.Count)
                {
                    for (int k = 0; k < val.Length; k++) if (val[k].Equals(Ans[k])) c++;
                    if (c == val.Length) { rigth.RigthCount++; c = 0; Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Ok "); Console.ResetColor(); }
                    else { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Ответ не верный."); Console.ResetColor(); }
                }
                else { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Ответ не верный."); Console.ResetColor(); }
                Console.WriteLine();
            }
                rigth.UpdateStatistic(rigth.UnloadingStatistic(), rigth.UnloadingIndex(), rigth.RigthCount);
                Console.WriteLine($"Rigth answers: Balls: {rigth.RigthCount} Raing: {rigth.GeneralCount}");
                return rigth.RigthCount;        
        }
        public  abstract void Print();
    }
}
