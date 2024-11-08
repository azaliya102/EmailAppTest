using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonLearning
{
    public class DatabaseConnection
    {
        private static DatabaseConnection instance = new DatabaseConnection();
        public string ConnectionString { get; private set; }

        private DatabaseConnection()
        {
            ConnectionString = "Server=myServer;Database=myDB;User Id=myUser;Password=myPass;";
        }

        public static DatabaseConnection GetInstance()
        {
            return instance;
        }
    }
}

