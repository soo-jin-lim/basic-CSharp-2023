using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs22_collection
{
    class MyList
    {
        int[] array;

        public MyList()
        {
            array = new int[3]; // 최초크기 3
        }

        public int Length
        {
            get { return array.Length; }
        }

        // 엔덱서 
        public int this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                if (index >= array.Length) // 3보다 커지면  
                {
                    Array.Resize<int>(ref array, index + 1);
                    Console.WriteLine("MyList Resized : {0}", array.Length);
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[5];
            array[0] = 1;
            array[1] = 2;
            array[2] = 3;
            array[3] = 4;
            array[4] = 5;   // 지정된 범위 내에서만 원소를 추가할 수 있습. 이이상 원소를 추가 할수없으므로 다른 코드가 더 필요함.

            // Console.WriteLine(array[5]);    // IndexOutOfRangeException

            char[] oldSring = new char[5];  // 조선시대방법   // 문자열의 길이를 지정해줘야함 // 주로 c에서만 사용함
            string curstring = "";  // 문자열길이 제한없습

            // ArrayList
            ArrayList list = new ArrayList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);    //위에있는 배열과 차이점. 한계가 없습 갯수추가 가능

            // 여러가지 메서드
            ArrayList list2 = new ArrayList();
            list2.Add(8);
            list2.Add(4);
            list2.Add(15);
            list2.Add(10);
            list2.Add(7);
            list2.Add(2);

            foreach (var item in list2)
            {
                Console.WriteLine(item);
            }
            // list에서 데이터 삭제
            Console.WriteLine("10 삭제 후 ");
            list2.Remove(10);
            Console.WriteLine("3번째 데이터 삭제");
            list2.RemoveAt(3);

            foreach (var item in list2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("0번째 위치에 7추가");
            list2.Insert(0, 7); // 0번째 위치에 7을 입력학셌다.
            foreach (var item in list2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("정렬");
            list.Sort();
            foreach (var item in list2)
            {
                Console.WriteLine(item);
            }

            //ArrayList . Add(), .Insert(x, val), .Remove(x), .Remove(val), .Soer(), .Reverse()

            // 새로만든  MyList
            MyList myList = new MyList();
            for (int i = 1; i <= 5; i++)
            {
                myList[i] = i * 5; // 5, 10, 15, 20, 25
                   
            }
            for(int i = 0; i < myList.Length; i++)
            {
                Console.WriteLine(myList[i]);   
            }
        }

    }
}