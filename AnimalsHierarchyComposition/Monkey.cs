using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsHierarchyComposition
{
    public class Monkey
    {
        public MammalAttributes Attributes { get; }
        public Monkey(string firstName, string middleName, string lastName)
        {
            Attributes = new MammalAttributes(firstName, middleName, lastName);

        }
        public void Speak()
        {
            Console.WriteLine($"{Attributes.FirstName} {Attributes.MiddleName} {Attributes.LastName} says: ooh ooh aah aah!!!");
        }
    }
}

