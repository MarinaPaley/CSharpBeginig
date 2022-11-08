﻿// See https://aka.ms/new-console-template for more information
using Domain;
using DataAccessLayer;

var author = new Author("Васильева", "Марина", "Алексеевна");
var book = new Book("C", author);
Console.WriteLine(book);
Console.WriteLine(author);

Settings settings = new Settings();
settings.AddDabaseServer("DESKTOP-FEV6RUE");
settings.AddDatabase("Library");