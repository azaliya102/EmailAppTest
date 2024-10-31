using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using EverythingAboutFluentNHibernate;

class Program
{
    private static ILogger<Program> _logger;

    static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);

        var serviceProvider = serviceCollection.BuildServiceProvider();
        _logger = serviceProvider.GetRequiredService<ILogger<Program>>();

        _logger.LogInformation("Application started.");

        BirdsCheckout();
        //AddNewBirdie("Robert", "Oppenheimer");

        _logger.LogInformation("Application finished.");
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddLogging(configure =>
        {
            configure.AddConsole();
            configure.SetMinimumLevel(LogLevel.Debug); 
        });
    }

    static void BirdsCheckout()
    {
        _logger.LogDebug("Starting BirdsCheckout.");

        using (var session = FluentNHibernateHelper.OpenSession())
        {
            var birdsList = session.Query<Birds>().ToList();

            if (birdsList.Any())
            {
                _logger.LogInformation("Fetched bird list from database.");
            }
            else
            {
                _logger.LogWarning("No birds found in database.");
            }

            Console.WriteLine("Your birds:");
            foreach (var bird in birdsList)
            {
                Console.WriteLine($"ID: {bird.ID}, Name: {bird.Name}, LastName: {bird.LastName}");
            }
        }

        _logger.LogDebug("Completed BirdsCheckout.");
    }

    static void AddNewBirdie(string name, string lastName)
    {
        _logger.LogDebug("Starting AddNewBirdie.");

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
                _logger.LogInformation($"New bird added with name: {name}, last name: {lastName}");
            }
        }

        Console.WriteLine("Your bird's been added");
    }

    static void UpdateBirdie(int id, string newName, string newLastName)
    {
        _logger.LogDebug("Starting UpdateBirdie.");

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
                    _logger.LogInformation($"Bird with ID {id} updated to new name: {newName}, last name: {newLastName}");
                }
                else
                {
                    _logger.LogWarning($"Bird with ID {id} not found for update.");
                }
            }
        }

        _logger.LogDebug("Completed UpdateBirdie.");
    }
}
