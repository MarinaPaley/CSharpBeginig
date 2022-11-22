namespace DataAccessLayer.Tests
{
    using NHibernate;
    using NUnit.Framework;
    public class MapTests
    {
        protected ISession Session { get; private set; }

        [SetUp]
        public void Setup()
        {
            this.Session = ConfiguratorTests.BuildSessionForTest();
        }

        [TearDown]
        public void TearDown()
        {
            this.Session?.Dispose();
        }
    }
}