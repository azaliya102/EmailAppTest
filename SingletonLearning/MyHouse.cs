using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonLearning
{
    public class House
    {
        private static House instance = new House();
        public int Rooms { get; private set; }

        private House()
        {
            Rooms = 5;
        }

        public static House GetInstance()
        {
            return instance;
        }
    }
}
