// <copyright file="Book.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>

namespace Domain
{
    /// <summary>
    /// Класс книга.
    /// </summary>
    public class Book : IEquatable<Book>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Book"/>.
        /// </summary>
        /// <param name="title">Заголовок. </param>
        /// <param name="authors">Список авторов. </param>
        public Book(string title, ISet<Author> authors)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException(nameof(title));
            }

            this.Id = Guid.NewGuid();
            this.Title = title;
            this.Authors = authors;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Book"/>.
        /// </summary>
        /// <param name="title">Заголовок. </param>
        /// <param name="authors">Список авторов.</param>
        public Book(string title, params Author[] authors)
            : this(title, new HashSet<Author>(authors))
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Book"/>.
        /// </summary>
        [Obsolete("FOR ORM only")]
        protected Book()
        {
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public virtual Guid Id { get; }

        /// <summary>
        /// Заголовок.
        /// </summary>
        public virtual string Title { get; }

        /// <summary>
        /// Авторы.
        /// </summary>
        public virtual ISet<Author> Authors { get; } = new HashSet<Author>();

        /// <summary>
        /// Полка.
        /// </summary>
        public virtual Shelf? Shelf { get; set; }

        /// <inheritdoc/>
        public virtual bool Equals(Book? other)
        {
            return Equals(this.Id, other?.Id);
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return this.Equals(obj as Book);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        /// <inheritdoc/>
        public override string ToString() => $"{this.Title} {string.Join(", ", this.Authors)}";
    }
}
