using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EverythingAboutFluentNHibernate;
using FluentNHibernate.Mapping;

class Program
{
    static void Main(string[] args)
    {
        BirdsCheckout();
        //AddNewBirdie("Robert", "Oppenheimer");
        
    }

    static void BirdsCheckout()
    {
        using (var session = FluentNHibernateHelper.OpenSession())
        {
            var birdsList = session.Query<Birds>().ToList();

            Console.WriteLine("Your birds:");
            foreach (var bird in birdsList)
            {
                Console.WriteLine($"ID: {bird.ID}, Name: {bird.Name}, LastName: {bird.LastName}");
            }
        }
    }

    static void AddNewBirdie(string name, string lastName)
    {
        using (var session = FluentNHibernateHelper.OpenSession())
        {
            using (var transaction = session.BeginTransaction())
            {
                var bird = new Birds
                {
                    Name = name,
                    LastName = lastName
                };
                session.Save(bird);
                transaction.Commit();
            }
        }
        Console.WriteLine("Your bird's been added");
    }

    static void UpdateBirdie(int id, string newName, string newLastName)
    {
        using (var session = FluentNHibernateHelper.OpenSession())
        {
            using (var transaction = session.BeginTransaction())
            {
                var bird = session.Get<Birds>(id);
                if (bird != null)
                {
                    bird.Name = newName;
                    bird.LastName = newLastName;
                    session.Update(bird);
                    transaction.Commit();
                    Console.WriteLine("Bird information updated successfully");
                }
                else
                {
                    Console.WriteLine("Bird not found((");
                }
            }
        }
    }

}