using Domain;
using DataAccessLayer;

var author = new Author("Васильева", "Марина", "Алексеевна");
var book = new Book("C", author);
var shelf = new Shelf(1);
author.Books.Add(book);
shelf.PutBook(book);

Console.WriteLine(book);
Console.WriteLine(author);
Console.WriteLine(shelf);

var settings = new Settings();
settings.AddDabaseServer("DESKTOP-FEV6RUE");
settings.AddDatabase("Library");

using var sessionFactory = Configurator.GetSessionFactory(settings, showSql: true);

using (var session = sessionFactory.OpenSession())
{
    // @NOTE: Порядок важен!
    session.Save(shelf);
    session.Save(author);
    session.Save(book);

    session.Flush();
}
