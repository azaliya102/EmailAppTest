using SingletonLearning;
using System;

class Program
{
    static void Main(string[] args)
    {
        Sun sun1 = Sun.getInstance();
        Sun sun2 = Sun.getInstance();
        TextString textInstance = TextString.getInstance();


        if (sun1 == sun2)
        {
            Console.WriteLine("singleton works as it should, both variables contain the same instance");
        }
        else
        {
            Console.WriteLine("something's wrong");
        }

        Console.WriteLine(textInstance.GetText());
        var car = Car.GetInstance();
        Console.WriteLine($"Car model: {car.Model}");
        car.Drive();

        var dbConnection = DatabaseConnection.GetInstance();
        Console.WriteLine($"Database connection string is: {dbConnection.ConnectionString}");

        var dog = Dog.GetInstance();
        Console.WriteLine($"Dog name: {dog.Name}");
        dog.Bark();

        var moon = Moon.GetInstance();
        Console.WriteLine("Moon singleton instance accessed.");

        var ship = Ship.GetInstance();
        Console.WriteLine($"Ship name: {ship.ShipName}");
        ship.Sail();

    }
}