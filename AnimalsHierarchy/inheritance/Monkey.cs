using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsHierarchy.inheritance
{
    public class Monkey : Mammal
    {
        public Monkey(string firstName, string middleName, string lastName)
            : base(firstName, middleName, lastName)
        {
        }

        public override void Speak()
        {
            Console.WriteLine($"{FirstName} {MiddleName} {LastName} says: ooh ooh aah aah  !");
        }

    }
}
