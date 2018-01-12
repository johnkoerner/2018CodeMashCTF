using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMashCTF_5
{
    public class Program
    {
        static void Main(string[] args)
        {
            var atxt = System.IO.File.ReadAllText(@"d:\temp\cm\a.txt").Replace("\r\n", "");
            var btxt = System.IO.File.ReadAllText(@"d:\temp\cm\b.txt").Replace("\r\n", "");
            var ctxt = System.IO.File.ReadAllText(@"d:\temp\cm\c.txt").Replace("\r\n", "");
            var dtxt = System.IO.File.ReadAllText(@"d:\temp\cm\d.txt").Replace("\r\n", "");

            var result = Not(atxt);
            result = And(result, btxt);
            result = Or(result, ctxt);
            result = XOr(result, dtxt);

            Console.WriteLine(Format((result)));
            Console.ReadLine();
        }

        public static string Format(string input)
        {
            var bmp = new System.Drawing.Bitmap(25, 25);
            var g = System.Drawing.Graphics.FromImage(bmp);
            var whitepen = new Pen(Brushes.White);
            var blackpen = new Pen(Brushes.Black);
            var row = 0;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (i % 25 == 0 && i != 0)
                {
                    row++;
                    sb.Append("\r\n");
                }
                sb.Append(input[i] == '1' ? "1" : "0");
                var pen = input[i] == '1' ? blackpen : whitepen;
                g.DrawRectangle(pen, i % 25, row, 1, 1);
            }
            bmp.Save("D:\\temp\\cm\\qr.bmp");
            g.Dispose();
            bmp.Dispose();
            return sb.ToString();
        }

        public static string Not(string input)
        {
            var result = new StringBuilder();
            foreach (var s in input)
            {
                Validate(s);
                if (s == '1')
                {
                    result.Append("0");
                }
                else if (s == '0')
                {
                    result.Append("1");
                }
                else
                {
                    throw new Exception();
                }
            }

            return result.ToString();
        }

        public static string And(string one, string two)
        {
            var result = new StringBuilder();
            for (int i = 0; i < one.Length; i++)
            {
                Validate(one[i]);
                Validate(two[i]);
                if ((one[i] == '0') || (two[i] == '0'))
                {
                    result.Append("0");
                }
                else
                {
                    result.Append("1");
                }
            }
            return result.ToString();
        }

        public static void Validate(char s)
        {
            if (s == '1' || s == '0')
                return;

            throw new Exception();
        }

        public static string Or(string one, string two)
        {
            var result = new StringBuilder();
            for (int i = 0; i < one.Length; i++)
            {
                Validate(one[i]);
                Validate(two[i]);
                if ((one[i] == '1') || (two[i] == '1'))
                {
                    result.Append("1");
                }
                else
                {
                    result.Append("0");
                }
            }
            return result.ToString();
        }

        public static string XOr(string one, string two)
        {
            var result = new StringBuilder();
            for (int i = 0; i < one.Length; i++)
            {
                Validate(one[i]);
                Validate(two[i]);
                if ((one[i] == '0') && (two[i] == '1'))
                {
                    result.Append("1");
                }
                else if ((two[i] == '0') && (one[i] == '1'))
                {
                    result.Append("1");
                }
                else
                {
                    result.Append("0");
                }
            }
            return result.ToString();
        }
    }
}
