namespace Domain
{
    public class Book
    {
        public Book(string title, ISet<Author> authors)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException("name");
            }

            this.Title = title;
            this.Authors = authors;
        }

        public Book(string title, params Author[] authors)
            : this(title, new HashSet<Author>(authors))
        {
        }

        public Guid Id { get; }

        public string Title { get; }

        public ISet<Author> Authors { get; } = new HashSet<Author>();

        public override string ToString()
        {
            return $"{this.Title} {string.Join(", ", this.Authors)}";
        }
    }
}
