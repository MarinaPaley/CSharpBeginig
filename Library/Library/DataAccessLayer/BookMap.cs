// <copyright file="BookMap.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>

namespace DataAccessLayer
{
    using Domain;
    using FluentNHibernate.Mapping;

    /// <summary>
    /// Класс отображения Книги.
    /// </summary>
    internal class BookMap : ClassMap<Book>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="BookMap"/>.
        /// </summary>
        public BookMap()
        {
            this.Table("Books");

            this.Id(x => x.Id);

            this.Map(x => x.Title)
                .Length(50)
                .Not.Nullable();

            this.References(x => x.Shelf);

            this.HasManyToMany(x => x.Authors)
                .Inverse();
        }
    }
}
