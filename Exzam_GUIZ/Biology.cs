using System;

namespace Exam_Project
{
    public class Biology : Guiz
    {
        public Biology(string Patchkey, string Patchvalue, string Patchansv):base(Patchkey, Patchvalue, Patchansv)
        {
            patchkey = "Biologykey.txt";
            patchvalue = "Biologyvalue.txt";
            patchanswer = "Biologyanswer.txt";
        }
        public override void Print()
        {
            Console.WriteLine("Biology");
        }       
    }
}
