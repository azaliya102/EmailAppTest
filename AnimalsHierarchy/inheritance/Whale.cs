using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsHierarchy.inheritance
{
    public class Whale : Mammal
    {
        public Whale(string firstName, string middleName) : base(firstName, middleName)
        {

        }
        public override void Speak()
        {
            Console.WriteLine($"{FirstName} {MiddleName} says: whooooooooo!!!");
        }
    }
}
