using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonLearning
{
    public class Ship
    {
        private static Ship instance = new Ship();
        public string ShipName { get; private set; }

        private Ship()
        {
            ShipName = "Titanic";
        }

        public static Ship GetInstance()
        {
            return instance;
        }

        public void Sail()
        {
            Console.WriteLine($"{ShipName} is sailing...");
        }
    }
}
