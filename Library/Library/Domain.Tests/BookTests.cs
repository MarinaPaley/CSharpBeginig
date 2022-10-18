namespace Domain.Tests
{
    using System;
    using System.Collections;
    using NUnit.Framework;
    using Domain;

    /// <summary>
    /// Модульные тесты для <see cref="Book"/>.
    /// </summary>
    [TestFixture]
    public sealed class BookTests
    {
        [Test]
        public void Ctor_ValidData_DoesNotThrowException()
        {
            // Arrange
            var author = new Author("Толстой", "Лев", "Николаевич");

            // Act & Assert
            Assert.DoesNotThrow(() => _ = new Book("Война и мир", author));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]

        public void Ctor_NoTitle_ThrowException(string title)
        {
            // Arrange
            var author = new Author("Толстой", "Лев", "Николаевич");

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _ = new Book(title, author));
        }

        [Test]
        public void Ctor_AuthorIsNull_NoException()
        {
            // Arrange
            Author? author = null;

            // Act & Assert
            Assert.DoesNotThrow(() => _ = new Book("Война и мир", author));
        }

        [Test]
        public void ToString_ValidData_Success()
        {
            // Arrange
            var book = new Book("12 Стульев", GetIlf(), GetPetrof());
            var expected = "12 Стульев Ильф И.А., Петров Е.П.";

            // Act
            var actual = book.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        //[Test]
        [TestCaseSource(nameof(RightBook))]
        public string ToString_ValidData_Success_1(Book book)
        {
            return book.ToString();
        }

        private static Author GetTolstoy() => new Author("Толстой", "Лев", "Николаевич");

        private static Author GetIlf() => new Author("Ильф", "Илья", "Арнольдович");

        private static Author GetPetrof() => new Author("Петров", "Евгений", "Петрович");

        public static IEnumerable RightBook()
        {
            yield return new TestCaseData(new Book("Война и мир", GetTolstoy())).Returns("Война и мир Толстой Л.Н.");
            //yield return new Book("Анна Каренина", GetTolstoy());
            //yield return new Book("12 Стульев", GetIlf(), GetPetrof());
        }
    }
}
