using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonLearning
{
    public class TextString
    {
        private static TextString instance = new TextString();
        
        private string s; 
        private TextString()
        {
            s = "hello i'm a string part of singleton class";
        }
        public static TextString getInstance()
        {
            return instance;
        }

        public string GetText()
        {
            return s;
        }
    }
}
