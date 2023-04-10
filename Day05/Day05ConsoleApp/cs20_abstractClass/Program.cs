using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs20_abstractClass
{
    abstract class AbstractParent // 추상 메서드는 추상 클래스에 넣는다. 즉 추상 메서드를 사용하고 싶으면 추상 클래스를 쓰면 된다. 기능은 인터페이스와 동일
    {
        protected void MethodA()
        {
            Console.WriteLine("AbstractParent.MethodA()");
        }

        public void MethodB()   // 클래스랑 동일
        {
            Console.WriteLine("AbstractParent.MethodA()");
        }

        public abstract void MethodC(); // 인터페이스= 추상메서드     //구현 없음 밑에서 재정의함
    }

    class Child : AbstractParent        
    {
        public override void MethodC()      //인터페이스와의 차이를 위해서 override를 사용?  재정의(사실은 구현!)
        {
            Console.WriteLine("Child.MethodA() - 추상클래스 구현!");
            MethodA();
        }
    }

    abstract class Mammal // 포유류 최상위(부모) 클래스
    {
        public abstract void Sound();
    }

    class Dogs : Mammal     // Dogs는 추상클래스 구현 해줘야 함(alt + enter 눌러서 거기 목록차에있습)
    {
        public override void Sound()
        {
            Console.WriteLine("멍멍!!");
        }
    }
    class Cats : Mammal     // Dogs는 추상클래스 구현 해주어야 한다(alt + enter 눌러서 거기 목록차에있습) // Cat class는 자동 추상클래스
    {
        public override void Sound()
        {
            Console.WriteLine("냥냥!!");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            AbstractParent parent = new Child();    //자식클레스를 부모에 할당. (ex 메머드를 포유류 클레스에 다 집어넣다.)
            parent.MethodC();
            parent.MethodB();       // MethodA는 protected이기 때문에 쓸수없지만 위 자식 클래스에서는 쓸수 있다.
            //parent.MethodA(); // protected는 자기 자신과 자식클래스 내에서만 사용가능
        }
    }
}