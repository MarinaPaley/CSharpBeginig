namespace DataAccessLayer
{
    using Domain;
    using FluentNHibernate.Mapping;

    /// <summary>
    /// Класс отображения полки.
    /// </summary>
    internal class ShelfMap : ClassMap<Shelf>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ShelfMap"/>.
        /// </summary>
        public ShelfMap()
        {
            this.Table("Shelves");

            this.Id(x => x.Id);

            this.Map(x => x.Name)
                .Not.Nullable()
                .Unique();

            this.HasMany(x => x.Books)
                .Not.Inverse();

        }
    }
}
