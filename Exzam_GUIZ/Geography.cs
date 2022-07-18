using System;

namespace Exam_Project
{
    public class Geography : Guiz
    {
        public Geography(string Patchkey, string Patchvalue, string Patchansv):base(Patchkey, Patchvalue, Patchansv)
        {
            patchkey = "geographykey.txt";
            patchvalue = "geographyvalue.txt";
            patchanswer = "geographyanswer.txt";            
        }
        public override void Print()
        {
            Console.WriteLine("Geography");
        }       
    }
}
