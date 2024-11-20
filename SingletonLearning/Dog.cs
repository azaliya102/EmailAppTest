using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonLearning
{
    public class Dog
    {
        private static Dog instance = new Dog();
        public string Name { get; private set; }

        private Dog()
        {
            Name = "Buddy";
        }

        public static Dog GetInstance()
        {
            return instance;
        }

        public void Bark()
        {
            Console.WriteLine($"{Name} says: Woof!");
        }
    }

}
