using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonLearning
{
    public class Sun
    {
        private static Sun instance = new Sun();
        private Sun()
        {
        }

        public static Sun getInstance()
        {
            return instance;
        }
    }
}
