using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using EverythingAboutFluentNHibernate;

class Program
{
    private static ILogger<Program> _logger;

    static void Main(string[] args)
    {
        var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder
                .AddConsole()
                .SetMinimumLevel(LogLevel.Debug);
        });

        _logger = loggerFactory.CreateLogger<Program>();

        _logger.LogInformation("Application started.");

        BirdsCheckout();
        // AddNewBirdie("Robert", "Oppenheimer");

        _logger.LogInformation("Application finished.");
    }

    static void BirdsCheckout()
    {
        _logger.LogDebug("Starting BirdsCheckout.");

        using (var session = FluentNHibernateHelper.OpenSession())
        {
            var birdsList = session.Query<Birds>().ToList();

            if (birdsList.Any())
            {
                _logger.LogInformation("Got bird list from my db.");
            }
            else
            {
                _logger.LogWarning("No birds found in database.");
            }

            _logger.LogInformation("These are your birds:");
            foreach (var bird in birdsList)
            {
                _logger.LogInformation($"ID: {bird.ID}, Name: {bird.Name}, LastName: {bird.LastName}");
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

        _logger.LogInformation("Your bird's been added");
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
