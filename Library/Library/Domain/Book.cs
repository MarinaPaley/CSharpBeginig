// <copyright file="Book.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>

namespace Domain
{
    /// <summary>
    /// Класс книга.
    /// </summary>
    public class Book
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
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Заголовок.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Авторы.
        /// </summary>
        public ISet<Author> Authors { get; } = new HashSet<Author>();

        /// <summary>
        /// Полка.
        /// </summary>
        public Shelf? Shelf { get; set; }

        /// <inheritdoc/>
        public override string ToString() => $"{this.Title} {string.Join(", ", this.Authors)}";
    }
}
