using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs11_logiccondition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 20;
            if (a == 20) // 처리하려는 로직이 있음 무조건 {} 써야함.
            {
                Console.WriteLine("20 입니다.");
                Console.WriteLine("두번째 줄입니다.");
            }
            if (a == 20) return;//메서드를 완전히 빠져나가는 구문은 한줄도 ok
            //데이터 타입비교 switch문
            object obj = null;

            string inputs = Console.ReadLine();//콘솔에서 입력
            if(int.TryParse(inputs, out int iouput))//예외가 발생하면 0
                    {
                obj = iouput;//입력값이 정수라서 문자열을 정수 변환
            }
            else if(float.TryParse(inputs, out float foutput))
            {
                obj = foutput;//입력값이 실수라서 문자열을 실수 변환
            }
            else
            {
                obj = inputs;//이도 저도 아님
            }
            Console.WriteLine(obj);
            switch(obj)
            {
                case int i: //정수라면
                    Console.WriteLine("{0}는 int형식입니다");
                    break;
                case float f://실수라면
                    Console.WriteLine("{0}는 float형식입니다");
                    break;
                case string s://문자열이면
                    Console.WriteLine("{0}는 string형식입니다");
                    break;
                default:
                    Console.WriteLine("무슨 타입인지 모름");
                    break;
            }
            #region<2중 for구문>

            for(int x =2; x <=9; x++)
            {
                for(int y =1; y <=9; y++)
                {
                    Console.WriteLine("{0} x {1} = {2}", x, y, x * y);
                }
                #endregion
                #region <Foreach문>
                int[] ary = { 2, 4, 6, 8, 10 };
                foreach (int i in ary)
                {
                    Console.WriteLine("{0} x 2 = {i}", i, i * 2);
                }
                // 위 아래 결과 완전 동일
                for (int i = 0; i < ary.Length; i ++)
                {
                    Console.WriteLine("{0}*2={1}", ary[i], ary[i] * 2);
                }

            }
            #endregion

        }
    }
}
