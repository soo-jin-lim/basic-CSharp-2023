using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs07_CTS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Int32 a = 12345; //CTS
            int b = 12345;

            Console.WriteLine(a.GetType());
            Console.WriteLine(a);
            Console.WriteLine(b.GetType());
            Console.WriteLine(b);

            System.String d = "abcdf";//CTS는 비추천
            string e = "abcdef";
            Console.WriteLine(d.GetType());
            Console.WriteLine(e.GetType());

        }
    }
}
