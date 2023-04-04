using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs04_enums
{
    internal class Program
    {
        enum HomeTown
        {
            seoul=1,
            Daejeon=2,
            Deagu,
            Busan,
            Jeju=9
        };

       
        static void Main(string[] args)
        {
            HomeTown myHomeTown;

            myHomeTown = HomeTown.Busan;
            if (myHomeTown == HomeTown.seoul)
            {
                Console.WriteLine("서울 출신");
            }else if (myHomeTown==HomeTown.Daejeon)
            {
                Console.WriteLine("충청도");
            }else if(myHomeTown== HomeTown.Deagu)
            {
                Console.WriteLine("대구입니다");
            }else if(myHomeTown!=HomeTown.Busan)
            {
                Console.WriteLine("부산이라예");
            }
       
        }
    }
}
