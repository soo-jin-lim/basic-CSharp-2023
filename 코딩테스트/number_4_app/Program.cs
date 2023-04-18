using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace number_4_app
{
    internal class Reinbow
    {

        static void Main(string[] args)
        {
            Dictionary<string, string> colors = new Dictionary<string, string>()
            {
                {"Red", "빨간색"},
                {"Orange", "주황색"},
                {"Yellow", "노란색"},
                {"Green", "초록색"},
                {"Blue", "파란색"},
                {"Navy", "남색"},
                {"Purple", "보라색"}
            };
            
            Console.Write("무지개 색은 ");
            foreach (var v in colors.Values)
            {
                Console.Write(v + ", ");
            }
            Console.WriteLine(" 입니다.");
         

            Console.WriteLine("\nKey와 Value 확인");
            string key = "Purple";
            string value = colors[key];
            Console.WriteLine($"{key}은 {value} 입니다.");
        }

    }
}

