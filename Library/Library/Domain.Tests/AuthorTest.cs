namespace Domain.Tests
{

using NUnit.Framework;
using Domain;
using System;

/// <summary>
/// Модульные тесты для <see cref="Author"/>.
/// </summary>
    [TestFixture]
    public class AuthorTest
    {
        /// <summary>
        /// Проверка конструктора.
        /// </summary>
        [Test]
        [TestCase("Николаевич")]
        [TestCase(null)]
        public void Ctor_ValidData_Success(string? middleName)
        {
            // Arrange
            // Act
            // Assert
            Assert.DoesNotThrow(() => _ = new Author("Толстой", "Лев", middleName));
        }

        /// <summary>
        /// Проверка конструктора. Неправильное отчество.
        /// </summary>
        [Test]
        [TestCase("")]
        [TestCase("   ")]
        public void Ctor_WrongMiddleName_ThrowException(string? middleName)
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Author("Толстой", "Лев", middleName));
        }

        /// <summary>
        /// Проверка конструктора. Неправильное имя.
        /// </summary>
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void Ctor_WrongFirstName_ThrowException(string firstName)
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => _ = new Author("Толстой", firstName, null));
        }

        /// <summary>
        /// Проверка конструктора. Неправильная фамилия.
        /// </summary>
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void Ctor_WrongLastName_ThrowException(string lastName)
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => _ = new Author(lastName, "Лев", null));
        }

        [Test]
        public void ToString_AuthorHasMiddleName_Success()
        {
            // Arrange
            var author = new Author("Толстой", "Лев", "Николаевич");
            var expected = "Толстой Л.Н.";
            // Act && Assert
            Assert.AreEqual(expected, author.ToString());
        }

        [Test]
        public void ToString_AuthorHasNotMiddleName_Success()
        {
            // Arrange
            var author = new Author("Толстой", "Лев", null);
            var expected = "Толстой Л.";
            // Act
            var actual = author.ToString();
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetBook_ValidData_Success()
        {
            // Arrange
            var author = new Author("Толстой", "Лев", "Николаевич");
            var book1 = new Book("Война и мир", author);
            var book2 = new Book("Анна Каренина", author);

            // Act
            author.Books.Add(book1);
            author.Books.Add(book2);
            var count = author.Books.Count;

            // Assert
            Assert.AreEqual(count, 2);
            Assert.IsTrue(author.Books.Contains(book1));
            Assert.AreEqual(author.Books.Contains(book2), true);
            Assert.AreEqual(book2.Authors.Contains(author), true);

        }
    }
}