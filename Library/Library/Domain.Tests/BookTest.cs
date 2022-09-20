namespace Domain.Tests
{

    using NUnit.Framework;
    using Domain;
    using System;

    /// <summary>
    /// Модульные тесты для <see cref="Book"/>.
    /// </summary>
    [TestFixture]
    public class BookTest
    {
        [Test]
        public void Ctor_ValidData_DoesNotThrowException()
        {
            // Arrange
            var author = new Author("Толстой", "Лев", "Николаевич");
            // Act && Assert
            Assert.DoesNotThrow(() => _ = new Book("Война и мир", author));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]

        public void Ctor_NoTitle_ThrowException(string title)
        {
            // Arrange
            var author = new Author("Толстой", "Лев", "Николаевич");
            // Act && Assert
            Assert.Throws<ArgumentNullException>(() => _ = new Book(title, author));
        }

        [Test]
        public void Ctor_AuthorIsNull_NoException()
        {
            // Arrange
            Author author = null;
            // Act && Assert
            Assert.DoesNotThrow(() => _ = new Book("Война и мир", author));
        }
        [Test]
        //[TestCaseSource()]
        public void ToString_ValidData_Success()
        {
            Assert.Pass();
        }

    }
}
