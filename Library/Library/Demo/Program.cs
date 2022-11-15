// See https://aka.ms/new-console-template for more information
using Domain;
using DataAccessLayer;

var author = new Author("Васильева", "Марина", "Алексеевна");
var book = new Book("C", author);
var shelf = new Shelf(1);
shelf.PutBook(book);

Console.WriteLine(book);
Console.WriteLine(author);

Settings settings = new Settings();
settings.AddDabaseServer("DESKTOP-FEV6RUE");
settings.AddDatabase("Library");

using var sessionFactory = Configurator.GetSessionFactory
    (settings, showSql: true);

using (var session = sessionFactory.OpenSession())
{
    session.Save(shelf);
    session.Flush();
}