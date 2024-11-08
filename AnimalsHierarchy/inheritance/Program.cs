using System;

namespace AnimalsHierarchy.inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Mammal monkey = new Monkey("Georgie", "The Greatest", "Apeman");
            monkey.Speak();

            Mammal whale = new Whale("Whalie", "Whaler");
            whale.Speak();
        }
    }
}