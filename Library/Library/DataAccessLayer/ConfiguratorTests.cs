namespace DataAccessLayer
{
    using System.Reflection;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using NHibernate;
    using NHibernate.Cfg;
    using NHibernate.Tool.hbm2ddl;

    public class ConfiguratorTests
    {
        private static Configuration? configuration;

        public static ISessionFactory GetSessionFactory(
            Assembly? assembly = null,
            bool showSql = false)
        {
            var databaseConfiguration =
                    SQLiteConfiguration.Standard.InMemory();

            if (showSql)
            {
                databaseConfiguration = databaseConfiguration
                    .ShowSql()
                    .FormatSql();
            }

            return Fluently.Configure()
                .Database(databaseConfiguration)
                .Mappings(m => m.FluentMappings.AddFromAssembly(assembly ??
                Assembly.GetExecutingAssembly()))
                .ExposeConfiguration(c => configuration = c)
                .BuildSessionFactory();
        }

        public static ISession BuildSessionForTest(bool showSql = true)
        {
            var session = GetSessionFactory(showSql: showSql).OpenSession();

            new SchemaExport(configuration)
                .Execute(true, true, false, session.Connection, null);

            return session;
        }
    }
}