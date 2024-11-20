using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonLearning
{
    public class Car
    {
        private static Car instance = new Car();
        public string Model { get; private set; }

        private Car()
        {
            Model = "Tesla Model S";
        }

        public static Car GetInstance()
        {
            return instance;
        }

        public void Drive()
        {
            Console.WriteLine($"{Model} is driving...");
        }
    }
}
