using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace cs24_genenic
{
    #region <일반화시키기>
    class MyArray<T> where T : class // 일반화 클래스 // where T : class 사용할 타입은 무조건 클래스타입이어야 한다
    {
        T[] array;
    }

    #endregion
    internal class Program
    {
        static void CopyArray<T>(T[] source, T[] target)
        {
            for (var i = 0; i < source.Length; i++)
            {
                target[i] = source[i];
            }
        }

        static void Main(string[] args)
        {
            #region <일반화시키기>
            int[] source = { 2, 4, 6, 8, 10 };
            int[] target = new int[source.Length];

            CopyArray<int>(source, target);      // CopyArray<int>(source, target) 와 동일
            foreach (var item in target)
            {
                Console.WriteLine(item);
            }
            long[] source2 = { 2100000, 2300000, 3300000, 5600000, 78000000 };
            long[] target2 = new long[source2.Length];

            CopyArray<long>(source2, target2);
            foreach (var item in target2)
            {
                Console.WriteLine(item);
            }
            float[] source3 = { 3.14f, 3.15f, 3.16f, 3.17f, 3.19f };
            float[] target3 = new float[source3.Length];

            CopyArray<float>(source3, target3);
            foreach (var item in target3)
            {
                Console.WriteLine(item);
            }
            #endregion
            // 일반화 컬렉션
            List<int> list = new List<int>();
            for (var i = 9; i > 0; i--)
            {
                list.Add(i);
            }
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            list.Remove(3); // 7삭ㄱ제

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            list.Sort();

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            // 아래와 같은 일반화 컬렉션 자주 볼 수 있음
            List<MyArray<string>> myStingArray = new List<MyArray<string>>();

            // 일반화 스택
            Stack<float> stFloats = new Stack<float>();
            stFloats.Push(3.15f);
            stFloats.Push(4.28f);
            stFloats.Push(7.24f);

            while (stFloats.Count > 0)
            {
                Console.WriteLine(stFloats.Pop());
            }

            // 일반화 Queue
            Queue<string> qStrings = new Queue<string>();
            qStrings.Enqueue("Hello");
            qStrings.Enqueue("World");
            qStrings.Enqueue("My");
            qStrings.Enqueue("C#");

            while (qStrings.Count > 0)
            {
                Console.WriteLine(qStrings.Dequeue());
            }
            //일반화 딕셔너리
            Dictionary<string, int> dicNumbers = new Dictionary<string, int>();
            disNumbers["하나"] = 1;
        }
    }
}