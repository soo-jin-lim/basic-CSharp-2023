using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs10_operator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //비트연산자 <<== *2 / >> == /2
            int firstval = 15; //15(8.4.2.1)
            int secondval = firstval << 1;//11110 16 + 8 + 4 + 2 = 30
            Console.WriteLine(secondval);

            // 1111 & 1111 => 1101 15 & 13 => 13
            // 1010 | 0101 => 1111
            firstval = 15;
            secondval = 13;
            Console.WriteLine(firstval & secondval);
            Console.WriteLine(~secondval);//보수

            //Null 병합 연산자
            int? checkval = null;
            Console.WriteLine(checkval == null? 0: checkval);//3항 연산자

            Console.WriteLine(checkval ?? 0);// null은 3항 연산자를 더 축소

            checkval = 25;
            Console.WriteLine(checkval.HasValue ? checkval.Value : 0);
            Console.WriteLine(~checkval);  
                }
    }
}
