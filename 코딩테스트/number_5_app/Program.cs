using number_5_app;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace number_5_app
{
    public interface IAnimal
    {
        int Age
        {
            get; set;
        }
        string Name
        {
            get; set;
        }
        void Eat();
        void Sleep();
        void Sound();
    }
    public class Dog : IAnimal
    {
        public string Name
        {
            get; set;
        }
        public int Age
        {
            get; set;
        }
        public void Eat()
        {
            Console.WriteLine($"Pet {this.Name}가 먹습니다");
        }
        public void Sleep()
        {
            Console.WriteLine($"Pet {this.Name}가 잡니다");
        }
        public void Sound()
        {
            Console.WriteLine($"Pet {this.Name}가 멍멍 짖습니다");
        }
    }
    public class Cat : IAnimal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public void Eat()
        {
            Console.WriteLine($"{this.Name}가 먹습니다");
        }
        public void Sleep()
        {
            Console.WriteLine($"{this.Name}가 잡니다");
        }
        public void Sound()
        {
            Console.WriteLine($"{this.Name}가 야옹 웁니다 ");
        }
    }
    public class Horse : IAnimal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public void Eat()
        {
            Console.WriteLine($"{this.Name}이 먹습니다");
        }
        public void Sleep()
        {
            Console.WriteLine($"{this.Name}이 잡니다");
        }
        public void Sound()
        {
            Console.WriteLine($"{this.Name}이 소리를 냅니다.");
        }
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("강아지");
        Dog dog = new Dog { Name = "강아지", Age = 1 };
        dog.Sleep();
        dog.Eat();
        dog.Sound();

        Console.WriteLine("\n고양이");
        Cat cat = new Cat { Name = "고양이", Age = 2 };
        cat.Sleep();
        cat.Eat();
        cat.Sound();

        Console.WriteLine("\n말");
        Horse horse = new Horse { Name = "말", Age = 3 };
        horse.Sleep();
        horse.Eat();
        horse.Sound();
    }
}