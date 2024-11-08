using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonLearning
{
    public class Moon
    {
        private static Moon instance = new Moon();
        private Moon() { }
        public static Moon GetInstance()
        {
            return instance;
        }
    }
}
