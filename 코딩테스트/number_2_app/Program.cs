using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace number_2_app
{
    internal class Boiler
    {
        public string Brand
        {
            get; set;
        }
        private byte voltage;

        public byte Voltage
        {
            get { return this. voltage; }
            set
            {
                // 110과 220v 만 저장 할 수 있도록 처리
               if(value == 110 || value == 220) 
                {
                    voltage = value;
                }
               else
                {
                    Console.WriteLine("Voltage 값은 110과 220으로만 저장");
                }
            }
        }
        private int temperature;
        public int Temperature
        {
            get { return this.temperature; }
            set
            {
                //물 온도는 5도 이하면 5도로 , 70도 이상이면 70도로 제한.
                if(value <= 5)
                {
                    this.temperature=5;
                }
                else if(value >= 70)
                {
                    temperature = 70; 
                }
                else
                {
                    this.temperature = value;
                }
            }
        }
        public void PrintAll()
        {
            Console.WriteLine($" Brand : {Brand}\n Voltage : {Voltage} \n Temperature : {Temperature}");
        }
        static void Main(string[] args)
        {
            Boiler Kitturami = new Boiler { Brand = "귀뚜라미", Voltage = 220, Temperature = 480 };
            Kitturami.PrintAll();

        
        }
    }
}
