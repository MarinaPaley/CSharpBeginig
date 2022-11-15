// <copyright file="Shelf.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>

namespace Domain
{
    /// <summary>
    /// Класс Полка.
    /// </summary>
    public class Shelf : IEquatable<Shelf>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Shelf"/>.
        /// </summary>
        /// <param name="name"> Номер полки. </param>
        public Shelf(int name)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Shelf"/>.
        /// </summary>
        [Obsolete("ORM only")]
        protected Shelf()
        {
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public virtual Guid Id { get; }

        /// <summary>
        /// Номер полки.
        /// </summary>
        public virtual int Name { get; set; }

        /// <summary>
        /// Книги.
        /// </summary>
        public virtual ISet<Book> Books { get; set; } = new HashSet<Book>();

        /// <summary>
        /// Положить книгу на полку.
        /// </summary>
        /// <param name="book"> Книга. </param>
        public virtual void PutBook(Book book)
        {
            this.Books.Add(book);
            book.Shelf = this;
        }

        /// <inheritdoc/>
        public override string ToString() =>
            $"{"Полка"} {this.Name}{":"} {string.Join(", ", this.Books)}";

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return this.Equals(obj as Shelf);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        /// <summary>
        /// Метод сравнения полок.
        /// </summary>
        /// <param name="other">Друга яполка.</param>
        /// <returns><see langword="true"/>, если равны, иначе – <see langword="false"/>. </returns>
        public virtual bool Equals(Shelf? other)
        {
            return Equals(this.Id, other?.Id);
        }
    }
}
