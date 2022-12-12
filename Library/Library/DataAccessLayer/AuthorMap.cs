// <copyright file="AuthorMap.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>

namespace DataAccessLayer
{
    using Domain;
    using FluentNHibernate.Mapping;

    /// <summary>
    /// Класс отображения Автора.
    /// </summary>
    internal class AuthorMap : ClassMap<Author>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AuthorMap"/>.
        /// </summary>
        public AuthorMap()
        {
            this.Table("Authors");

            this.Id(x => x.Id);

            this.Map(x => x.FirstName)
                .Length(50)
                .Not.Nullable();

            this.Map(x => x.LastName)
                .Length(50)
                .Not
                .Nullable();

            this.Map(x => x.MiddleName)
                .Length(50)
                .Nullable();

            this.HasManyToMany(x => x.Books)
                .Not
                .Inverse();
        }
    }
}
