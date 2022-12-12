namespace Domain.Tests
{

    using NUnit.Framework;
    using Domain;
    using System.Linq;

    /// <summary>
    /// Модульные тесты для <see cref="Shelf"/>.
    /// </summary>
    [TestFixture]
    public class ShelfTest
    {
        [Test]
        public void AddBook_ValidData_Success() 
        {
            // Arrange
            var author = new Author("Толстой", "Лев", "Николаевич");
            var book = new Book("Война и мир", author);
            var shelf = new Shelf(1);

            // Act
            shelf.PutBook(book);
            var count = shelf!.Books.Count;

            // Assert
            Assert.AreEqual(book.Shelf, shelf);
            Assert.IsTrue(count > 0);
        }

        [Test]
        public void ToString_Success()
        {
            // Arrange
            var author = new Author("Толстой", "Лев", "Николаевич");
            var book = new Book("Война и мир", author);
            var shelf = new Shelf(1);
            shelf.PutBook(book);
            var expected = "Полка 1: Война и мир Толстой Л.Н.";

            // Act
            var actual = shelf!.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToString_TwoBooksOnShelf_Success()
        {
            // Arrange
            var author = new Author("Толстой", "Лев", "Николаевич");
            var book1 = new Book("Война и мир", author);
            var book2 = new Book("Анна Каренина", author);
            var shelf = new Shelf(1);
            shelf.PutBook(book1);
            shelf.PutBook(book2);
            var expected = "Полка 1: Война и мир Толстой Л.Н., Анна Каренина Толстой Л.Н.";
            
            // Act
            var actual = shelf.ToString();
            
            // Assert
            Assert.AreEqual(expected,actual);
        }
    } 
}
