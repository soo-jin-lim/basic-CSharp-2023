using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace cs12_methods
{
    class Calc
    {
        public static int Plus(int a, int b)
        {
            return a + b;
        }
        public int Minus(int a, int b)
        {
            return a - b;
        }
    }

    internal class Program
    {
        /// <summary>
        /// 실행시 메모리에 최초 올라가야 하기때문에 static이 되어야 하고
        /// 메서드 이름이 Main이면 실행될때 알아서 제일 처음에 시작된다.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            #region < static 메서드 >

            int result = Calc.Plus(1, 2);   // static 덕분에 new 사용 안함!!!(메모리에 미리 올라가서 new로 힙에 올릴 필요x)
            // static은 최초실행 때 메모리에 바로 올라가기 때문에
            // 클래스의 객체를 만들 필요가 없음 like new Calc();

            // Calc.Minus(3, 2);   // Minus는 static이 아니기 때문에 접근 불가( 객체 생성 필요 )
            result = new Calc().Minus(3, 2);
            Console.WriteLine(result);
            #endregion

            #region < Call by reference vs Call by value 비교 >

            int x = 10; int y = 3;
            // ref가 없으면 Call by value
            Swap(ref x, ref y); // x, y가 가지고 있는 주소를 전달하라 Call by reference == pointer

            Console.WriteLine("x = {0}, y = {1}", x, y);

            Console.WriteLine(GetNumber());

            #endregion

            #region < out 매개변수 >

            int divid = 10;
            int divor = 3;

            int rem = 0;

            //result = Divide(divid, divor);
            //Console.WriteLine(result);

            //int rem = Reminder(divid, divor);
            //Console.WriteLine(rem);

            Divide(divid, divor, out result, out rem);  //ref와 out은 결과가 같으나 out 권장!!!
            // out이 컴파일러를 통해 결과를 할당하지 않는 버그 만들 가능성 제거
            Console.WriteLine("나누기 값 {0}, 나머지 {1}", result, rem);

            (result, rem) = Divide(20, 6);
            Console.WriteLine("나누기 값 {0}, 나머지 {1}", result, rem);

            (result, rem) = Divide(20, 6);
            Console.WriteLine("나누기 값 {0}, 나머지 {1}", result, rem);

            #endregion

            #region < 가변길이 매개변수 >

            Console.WriteLine(Sum(1, 3, 5, 7, 9));

            #endregion
        }

        //static int Divide(int x, int y)
        //{
        //    return x / y;
        //}

        //static int Reminder(int x, int y)
        //{
        //    return x % y;
        //}   // 메서드 두개 만들걸 아래처럼 하나로
        static void Divide(int x, int y, out int val, out int rem)
        {
            val = x / y;
            rem = x % y;
        }
        static (int result, int rem) Divide(int x, int y)
        {
            return (x / y, x % y);  // C# 7.0
        }
        static (float result, float rem) Divide(float x, float y)
        {
            return ((int)(x / y), (int)(x % y));
        }



        // Main 메서드와 같은 레벨에 있는 메서드들은 전부 static이 되어야 함( 무조건! )
        public static void Swap(ref int a, ref int b)
        {
            int temp = 0;
            temp = a;   // temp = 10
            a = b;      // a = 3
            b = temp;   // b= 10
        }

        static int val = 100;

        public static ref int GetNumber()
        {
            return ref val;     // static 메서드에 접근할 수 잇는 변수는 static밖에 없음
        }
        public static int Sum(params int[] args)    // Python 가변길이 매개변수랑 비교
        {
            int sum = 0;

            foreach (var item in args)
            {
                sum += item;
            }
            return sum;
        }

    }
}