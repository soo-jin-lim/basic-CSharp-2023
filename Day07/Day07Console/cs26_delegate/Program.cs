using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs26_delegate
{
    // 대리자 사용하겠다는 선언
    delegate int CalcDelegate(int a, int b);

    delegate int Compare(int a, int b);  // a랑 b 중 뭐가 더 큰지 (작은지) 비교 대리자 

    #region  <대리자 기본>
    class Calc
    {
        public int Plus(int a, int b) 
        {
            return a + b;
        }

        // static 이 붙으면 무조건 실행될때 최초 메모리에 올라감 
        // 프로그램 실행 중에는 언제든지 접근 가능 
        public static int Minus(int a, int b) 
        {
            return a - b;
        }
        #endregion
    }
    internal class Program
    {
        // 오름차순 예제
        static int AscendCompare(int a, int b)
        {
            if (a > b) return 1;
            else if (a == b) return 0;
            else  return -1;
        }
        
        static int DescendCompare(int a, int b) 
        {
            if (a < b) return 1;
            else if (a == b) return 0;
            else return -1;
        }

        // 오름차순, 내림차순이 하나의 메소드에서 다 정렬 
        static void BubbleSort(int[] DataSet, Compare compare)
        {
            int i = 0, j=0, temp = 0;

            for (i = 0; i < DataSet.Length ; i++)
            {
                for (j=0; j<DataSet.Length-(i+1) ; j++) 
                {
                    if (compare(DataSet[j], DataSet[j+1]) > 0)  // 대리자를 사용 
                    {
                        temp = DataSet[j+1];
                        DataSet[j+1]= DataSet[j];
                        DataSet[j] = temp;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            #region  < 대리자 기본 예>
            // 일반적으로  클래스 사용 방식 - 직접 호출
            Calc normalCalc = new Calc();
            int x = 10, y = 15;
            int res = normalCalc.Plus(x, y);
         //   Console.WriteLine(res);

           // Console.WriteLine(normalCalc.Plus(x,y));

            res = Calc.Minus(x, y);

            // 대리자를 사용하는 방식 - 대리자 대신 실행
            x = 30;  y = 20;
            Calc delCalc= new Calc();
            CalcDelegate Callback;

            Callback = new CalcDelegate(delCalc.Plus);
            int res2 = Callback(x, y);   // Calc.plus() 대신 호출 
         //   Console.WriteLine(res2);

            Callback = new CalcDelegate(Calc.Minus);
            res2= Callback(x, y);
         //   Console.WriteLine(res2);
            #endregion

            int[] origin = { 4, 7, 8, 2, 9, 1 };

            Console.WriteLine("오름차순 정렬");
            BubbleSort(origin, new Compare(AscendCompare));

            foreach (var item in origin)
            {
                Console.WriteLine("{0} ",item);
            }

            Console.WriteLine("내림차순 정렬");
            BubbleSort(origin, new Compare(DescendCompare));

            foreach (var item in origin)
            {
                Console.WriteLine("{0} ", item);
            }
        }
    }
}
