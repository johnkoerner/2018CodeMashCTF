using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMashCTF_6
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "363336643331333832643438363537373432326436383530333137323264346337393738333932643635373035343465";
            Console.WriteLine(HexToString(input));
            Console.WriteLine(HexToString(HexToString(input)));
            Console.ReadLine();
        }

        static string HexToString(string source)
        {
            StringBuilder sb = new StringBuilder();
            for(int i=0; i<source.Length; i+=2)
            {
                 sb.Append(Convert.ToChar(int.Parse( source.Substring(i, 2), System.Globalization.NumberStyles.HexNumber)));
            }           return sb.ToString();
        }
    }
}
