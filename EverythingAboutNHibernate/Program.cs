using EverythingAboutNHibernate;
using System;
using System.Linq;

namespace EverythingAboutNHibernate
{
    class Program
    {
        static void Main(string[] args)
        {
            AddBird("Jesse", "Sullivan");
            DeleteBird(1);
            BirdsCheckoutWithWhere();
            Console.ReadLine();
        }

        // for adding birds
        static void AddBird(string name, string lastName)
        {
            using (var session = NHibernateHelper.OpenSession())
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
            Console.WriteLine("Your bird has been successfully added !!!");
        }

        // for selecting info about birds
        static void BirdsCheckout()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var birdsList = session.Query<Birds>().ToList();

                Console.WriteLine("Your birds:");
                foreach (var bird in birdsList)
                {
                    Console.WriteLine($"ID: {bird.ID}, Name: {bird.Name}, LastName: {bird.LastName}");
                }
            }
        }
        // for selecting info with filter
        static void BirdsCheckoutWithWhere()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var query = session.CreateQuery("from Birds where ID < :id");
                query.SetParameter("id", 4);

                var birdsList = query.List<Birds>();

                Console.WriteLine("Birds with ID < 4:");
                foreach (var bird in birdsList)
                {
                    Console.WriteLine($"ID: {bird.ID}, Name: {bird.Name}, LastName: {bird.LastName}");
                }
            }
        } 

        // for deleting a bird
        static void DeleteBird(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var bird = session.Get<Birds>(id); 
                    if (bird != null)
                    {
                        session.Delete(bird);
                        transaction.Commit();
                        Console.WriteLine("bird's been deleted");
                    }
                    else
                    {
                        Console.WriteLine("check again for this bird's id");
                    }
                }
            }
        }
    }
}
    

