using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//메서드(method) 또는 멤버 함수(member function)는 객체 지향 프로그래밍에서 객체과 관련된 서브 루틴 (또는 함수)이며 데이터와 멤버 변수에 대한 접근 권한을 갖는다.
namespace cs17_inheritance
{
    // 상속해줄 부모 클래스
    class Parent
    {
        protected string Name;     // 상속할때는 private를 사용해서는 안된다.

        public Parent(string Name)
        {
            this.Name = Name;
            Console.WriteLine("{0} from Parent 생성자", Name);
        }

        public void ParentMethod()
        {
            Console.WriteLine("{0} from Parent 메서드", Name);
        }
    }
    // 상속받을 자식 클래스

    class Child : Parent
    {
        public Child(string Name) : base(Name)  // 부모생성자를 먼저 실행한뒤 자신 생성자를 실행
        {
            Console.WriteLine("{0} from Child 생성자", Name);
        }
        public void ChildMethod()
        {
            Console.WriteLine("{0} from Child 메서드", Name);
        }
    }
    // 클래스간 형변환 DB처리, DI
    class Mammal // 포유류
    {
        public void Nurse() // 기르다
        {
            Console.WriteLine("포유류 기르다");
        }
    }

    class Dogs : Mammal
    {
        public void Bark()
        {
            Console.WriteLine("멍멍!!!");

        }
    }
    class Cats : Mammal
    {
        public void Meow()
        {
            Console.WriteLine("야옹!!!");

        }
    }
    class Elephant : Mammal
    {
        public void Poo()
        {
            Console.WriteLine("뿌우우~");
        }
    }
    class ZooKeeper
    {
        public void Wash(Mammal mammal)
        {
            if (mammal is Elephant)
            {
                var animal = mammal as Elephant;
                Console.WriteLine("코끼리를 씻깁니다.");
                animal.Poo();
            }
            else if (mammal is Dogs)
            {
                var animal = mammal as Dogs;
                Console.WriteLine("강아지를 씻깁니다.");
                animal.Bark();
            }
            else if (mammal is Cats)
            {
                var animal = mammal as Cats;
                Console.WriteLine("고양이를 씻깁니다.");
                animal.Meow();
                animal.Meow();
                animal.Meow();
                animal.Meow();
                animal.Meow();
            }
        }
        internal class Program
        {
            static void Main(string[] args)
            {
                #region <기본상속 개념>
                Parent p = new Parent("p");
                p.ParentMethod();

                Console.WriteLine("자식클래스 생성");
                Child c = new Child("c");
                c.ParentMethod(); // 자식클래스는 부모클래스의 속성, 기능을 모두 쓸 수 있다.
                c.ChildMethod();
                #endregion
                #region < 클래스간 형식변환>    

                // Mammal mammal = new Mammal(); // 기본
                Mammal mammal = new Dogs();
                if (mammal is Dogs)
                {
                    Dogs midDog = mammal as Dogs;
                    midDog.Bark();
                }
                //Dogs dogs = new Mammal(); // 부모클래스가 자식클래스로 변환은 불가
                Dogs dog2 = new Dogs();
                Cats cat2 = new Cats();
                Elephant el2 = new Elephant();

                ZooKeeper Keeper = new ZooKeeper();
                Keeper.Wash(dog2);
                Keeper.Wash(cat2);
                Keeper.Wash(el2);

                #endregion

            }
        }
    }
}