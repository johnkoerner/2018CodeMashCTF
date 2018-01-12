using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CodeMashCTF_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int knownCount = 1;
            string known = "7";
            while (true)
            {
                bool found = false;
                foreach (var guess in GetGuesses(known))
                {
                    TcpClient client = new TcpClient("codemash.hacking-lab.com", 8357);
                    var s = client.GetStream();

                    ReadHeader(s);
                    Console.Write(guess + " - ");

                    s.Write(Encoding.ASCII.GetBytes(guess + "\r\n"), 0, 22);
                    byte[] result = new byte[3];
                    while (true)
                    {
                        var cnt = s.Read(result, 0, 3);
                        Console.WriteLine(Encoding.ASCII.GetString(result).Trim());
                        string number = Encoding.ASCII.GetString(result).Trim().TrimEnd(new[] {'>','<'});
                        
                        if (int.Parse(number) > knownCount)
                        {
                            known += guess[knownCount];
                            knownCount++;
                            found = true;
                        }
                        if (cnt <= 0) break;
                    }
                    if (found) break;
                }
            }
        }

        static string[] GetGuesses(string known)
        {
            var result = new List<string>();
            for (int i=0; i<10; i++)
            {
                var x = known + i.ToString();
                x=x.PadRight(20, '5');
                result.Add(x);
            }
            return result.ToArray();
        }

        static void ReadHeader(Stream s)
        {
            byte[] result = new byte[1];
            while (s.Read(result, 0, 1) >0)                
                if (result[0] == Encoding.ASCII.GetBytes("\n")[0])  break;
        }
    }
}
