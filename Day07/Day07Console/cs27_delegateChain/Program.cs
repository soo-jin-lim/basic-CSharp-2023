using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace cs27_delegateChain
{
    delegate void ThereIsFire(string location); // 불났을 때 대신해주는 대리자 

    delegate int Calc(int a, int b);

    delegate string Concatenate(string[] args );

    class Sample
    {
        private int valueA;  // 멤버변수  - 외부에서 접근 불가 

        public int ValueA // 프로퍼티 
        {
            //get { return valueA; }
            //set { valueA = value; }
            // 위 아래는 같음 아래는 람다 
            get => valueA;
            set => valueA = value;
        }
    }

    internal class Program
    {
        #region  <축소>
        static void Call119(string location)
        {
            Console.WriteLine("소방서죠 {0}에 불났어요 ", location);
        }

        static void ShotOut(string location)
        {
            Console.WriteLine("{0}에 불났어요", location);
        }

        static void Escape(string location) 
        {
            Console.WriteLine("{0}에서 탈출합니다. " , location);
        }
        #endregion

        static string ProcConcate(string[] args)
        {
            string result = string.Empty;   // == " " ;

            foreach(string s in args)
            {
                result += s +" /" ;
            }
            return result;
        }

        static void Main(string[] args)
        {
            #region < 대리자 체인 영역 >
            //var loc = "우리집";
            //Call119(loc);
            //ShotOut(loc);
            //Escape(loc);

            //var otherloc = "경찰서";
            //ThereIsFire fire = new ThereIsFire(Call119);
            //fire += new ThereIsFire(ShotOut);
            //fire += new ThereIsFire(Escape); // 대리자 메서드 추가 

            //fire(otherloc);

            //fire -= new ThereIsFire(ShotOut);

            //fire("다른집");

            //// 익명함수 
            //Calc plus = delegate (int a, int b)
            //{
            //    return a + b;
            //};
            //Console.WriteLine(plus(6,7));

            //Calc minus = (a, b) => { return a - b;  };

            //Console.WriteLine(minus(67, 9));

            //Calc simpleMinus = (a, b) => a - b;
            //Console.WriteLine(simpleMinus(88, 7));

            #endregion

            Concatenate concat = new Concatenate(ProcConcate);
            var result = concat(args);

            Console.WriteLine(result);

            Concatenate concat2 = (arr) =>
            {
                string res = string.Empty;   // == " " ;

                foreach (string s in args)
                {
                    res += s + " /";
                }
                return res;
            };
        }
    }
}
