using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMashCTF_8
{
    class Program
    {
        private static String key = "lockpickingisfun";
        private static String cipher = "?8hiyKT5fw*W^J~art3t.47i";

        public static void Main(String[] args)
        {
            String input = key; ;
            StringBuilder codeword = new StringBuilder();
            for (int i = 0; i < cipher.Length; i++)
            {
                codeword.Append((char)(key[(i % key.Length)] - cipher[i] + 54));
            }
            Console.WriteLine(codeword.ToString());
            Console.ReadLine();
        }
    }
}
