using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsHierarchyComposition
{
    public class MammalAttributes
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public MammalAttributes(string firstName, string middleName, string lastName = null)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }

    }
}
