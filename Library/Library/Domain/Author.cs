// <copyright file="Author.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>

namespace Domain
{
    /// <summary>
    /// Автор.
    /// </summary>
    public class Author
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Author"/>.
        /// </summary>
        /// <param name="lastName"> Фамилия. </param>
        /// <param name="firstName"> Имя. </param>
        /// <param name="middleName">Отчество. </param>
        public Author(
            string lastName,
            string firstName,
            string? middleName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentNullException(nameof(firstName));
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentNullException(nameof(lastName));
            }

            if ((middleName?.Trim())?.Length == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(middleName));
            }

            this.Id = Guid.NewGuid();
            this.FirstName = firstName;
            this.LastName = lastName;
            this.MiddleName = middleName;
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string LastName { get; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string? MiddleName { get; }

        /// <summary>
        /// Книги.
        /// </summary>
        public ISet<Book> Books { get; } = new HashSet<Book>();

        /// <summary>
        /// Добавить автору книгу.
        /// </summary>
        /// <param name="book">Книгу.</param>
        public void GetBook(Book book)
        {
            this.Books.Add(book);
            book.Authors.Add(this);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var fullName = $"{this.LastName} {this.FirstName[0]}{"."}";
            if (this.MiddleName is not null)
            {
                fullName = $"{fullName}{this.MiddleName[0]}{"."}";
            }

            return fullName;
        }
    }
}