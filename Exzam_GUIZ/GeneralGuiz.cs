using System;
using System.Collections.Generic;

namespace Exam_Project
{
    public class GeneralGuiz : Guiz
    {
       public GeneralGuiz(string Patchkey, string Patchvalue, string Patchansv):base(Patchkey, Patchvalue, Patchansv)
       {
            patchkey = "Generalkey.txt";
            patchvalue = "Generalvalue.txt";
            patchanswer = "Generalanswer.txt";
       }
        public List<int> RandIndex()
        {
            Random rand = new Random();
            int c = 0;
            List<int> index = new List<int>();
            for (int i = 0; i < 19;)
            {
                if (index.Count == 0)
                {
                    index.Add(rand.Next(1, 40));
                    Console.Write($"{index[i]} ");
                }
                else
                {
                    int r = rand.Next(1, 40);
                    for (int j = 0; j < index.Count; j++) if (index[j] == r) c++;
                    if (c == 0) { i++; index.Add(r); Console.Write($"{index[i]} "); }
                    else c = 0; continue;
                }
            }
            Console.WriteLine();
            Console.WriteLine(index.Count);
            return index;
        }

        public override void Print()
        {
            Console.WriteLine("GeneralGuiz");
        }       
    }
}
