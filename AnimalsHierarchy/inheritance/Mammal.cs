using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsHierarchy.inheritance
{
    public abstract class Mammal
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        protected Mammal(string firstName, string middleName, string lastName = null)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }
        public abstract void Speak();
    }
}
