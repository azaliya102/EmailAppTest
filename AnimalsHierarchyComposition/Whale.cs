using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsHierarchyComposition
{
    public class Whale
    {
        public MammalAttributes Attributes { get; }
        public Whale(string firstName, string middleName)
        {
            Attributes = new MammalAttributes(firstName, middleName);
        }
        public void Speak()
        {
            Console.WriteLine($"{Attributes.FirstName} {Attributes.MiddleName} says: whoooooooooooooooooo!!!");
        }
    }
}
