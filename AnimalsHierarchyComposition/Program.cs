using AnimalsHierarchyComposition;
using System;

public class Program
{
    static void Main(string[] args)
    {
        Monkey monkey1 = new Monkey("Banjo", "Bubbles", "McNutty");
        monkey1.Speak();
        Whale whale1 = new Whale("Waldo", "Blubberton");
        whale1.Speak();
    }
}
