using Domain;
using FluentNHibernate.Testing;

namespace DataAccessLayer.Tests
{
    [TestFixture]
    public class ShelfMapTests : MapTests
    {
        [Test]
        public void PersistenceSpecification_ValidData_Success()
        {
            var shelf = new Shelf(1);
            new PersistenceSpecification<Shelf>(this.Session)
                .VerifyTheMappings(shelf);
        }
    }
}
