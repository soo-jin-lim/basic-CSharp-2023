using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace cs16_inheritance
{
    class Base // 기반 또는 부모클래스
        //자식클래스에서 상속받으려면 private는 안써야함.
    {
        protected string Name;
        private string Color;// 만약에 상속을 할거면 private를 protect로 굥
        public int Age;

        public Base(string Name, string Color, int Age)
        {
            this.Name = Name;
            this.Color = Color;
            this.Age = Age;
            Console.WriteLine("{0}.Base()",Name);
        }
        public void BaseMethod()
        {
            Console.WriteLine("{0}.BaseMethod()",Name);
        }

        public void GetColor()
        {
            Console.WriteLine("{0}.BaseMethod()", Name);
        }
    }

    class Child : Base //상속받은 이후 Base의 Name,Color,Age를 새로 만들거나 하지않음
    {
        public Child(string Name, string Color, int Age) : base(Name, Color, Age)
        {
            Console.WriteLine("{0}.Child()", Name);
        }
        public void ChildMethod()
        {
            Console.WriteLine("{0}.ChildMethod()", Name);
        }
        //public
    
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Base b = new Base("NameB", "White", 1);
            b.BaseMethod();
            b.BaseMethod();

            Child c = new Child("NameC", "Black", 2);
            c.BaseMethod();
            c.ChildMethod();
            c.GetColor();//Base.GetColor Black ... c에서 color에 접근 불가

        }
    }
}