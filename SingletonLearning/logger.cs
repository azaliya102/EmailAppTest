using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonLearning
{
    public class Logger
    {
        private static Logger instance = new Logger();
        private Logger() { }
        public static Logger GetInstance()
        {
            return instance;
        }
    }
}
