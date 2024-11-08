using System;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

public class FluentNHibernateHelper
{
    private static ISessionFactory _sessionFactory;

    private static ISessionFactory SessionFactory
    {
        get
        {
            if (_sessionFactory == null)
            {
                _sessionFactory = CreateSessionFactory();
            }
            return _sessionFactory;
        }
    }

    private static ISessionFactory CreateSessionFactory()
    {
        return Fluently.Configure()
    .Database(MsSqlConfiguration.MsSql2012
        .ConnectionString(@"Server=DESKTOP-S258JJS;Initial Catalog=my_db;Integrated Security=True;TrustServerCertificate=True")
        .ShowSql())
    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<FluentNHibernateHelper>())
    .BuildSessionFactory();
    }

    public static ISession OpenSession()
    {
        return SessionFactory.OpenSession();
    }
}