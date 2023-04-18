using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace number_1_app
{
    internal class Boiler
    {
        public string Brand;
        public int Voltage;
        public int Temperature;

        public void PrintAll()
        {
            Console.WriteLine($" Brand : {Brand}\n Voltage : {Voltage} \n Temperature : {Temperature}");
        }
        static void Main(string[] args)
        {
            Boiler Kitturami = new Boiler{ Brand = "귀뚜라미", Voltage = 220, Temperature = 45 };
            Kitturami.PrintAll();
        }
    }
}