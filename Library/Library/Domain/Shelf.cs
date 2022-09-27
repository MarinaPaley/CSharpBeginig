// <copyright file="Shelf.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>

namespace Domain
{
    /// <summary>
    /// Класс Полка.
    /// </summary>
    public class Shelf
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Shelf"/>.
        /// </summary>
        /// <param name="name"> Номер полки. </param>
        public Shelf(int name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Номер полки.
        /// </summary>
        public int Name { get; set; }

        /// <summary>
        /// Книги.
        /// </summary>
        public ISet<Book> Books { get; set; } = new HashSet<Book>();

        /// <summary>
        /// Положить книгу на полку.
        /// </summary>
        /// <param name="book"> Книга. </param>
        public void PutBook(Book book)
        {
            this.Books.Add(book);
            book.Shelf = this;
        }

        /// <inheritdoc/>
        public override string ToString() =>
            $"{"Полка"} {this.Name}{":"} {string.Join(", ", this.Books)}";
    }
}
