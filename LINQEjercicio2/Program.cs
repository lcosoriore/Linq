using LINQEjercicio2;

LinqQueries queries= new LinqQueries();

PrintValues(queries.AllCollection());
PrintValues(queries.BooksAfter2000());
PrintValues(queries.BooksAfter2000QueryExpression());
PrintValues(queries.BooksWithMore250PagesAndWordsInAction());
PrintValues(queries.BooksWithMore250PagesAndWordsInActionQueryExpression());
Console.WriteLine($" All books have status? -  {queries.AllBooksHaveStatus()}");
Console.WriteLine($" Any book Publish? -  {queries.AnyBookPublish2005()}");
PrintValues(queries.BooksPython());
PrintValues(queries.BooksJava());
PrintValues(queries.BooksJavaDescending());
PrintValues(queries.BooksTakeOperator());
PrintValues(queries.BooksSkipOperator());
PrintValues(queries.FirtsThreeBooks());
Console.WriteLine($" books that are between 200 and 500 pages using Count -  {queries.NumberBooksBetween200And500PagesCount()}");
Console.WriteLine($" books that are between 200 and 500 pages using LongCount -  {queries.NumberBooksBetween200And500PagesLongCount()}");
Console.WriteLine($" books with Min Publish Date -  {queries.DatePublishMin()}");
Console.WriteLine($" books with Max Pages Book -  {queries.MaxPagesBook()}");
var book = queries.BookWithLessNumberOfPages();
Console.WriteLine($" Book With Less Number Of Pages -  {book.Title} - {book.PageCount}");

var bookmostrecent = queries.BookWithMostRecentPublicationDate();
Console.WriteLine($" Return book with most recent publication date -  {bookmostrecent.Title} - {bookmostrecent.PageCount}");

Console.WriteLine($" Return average tittle -  {queries.AverageTittle}");

ImprimirGrupo(queries.BooksAfter2000GroupBy());
ImprimirDiccionario(queries.DicctionaryBooksForCharacter(), 'A');

PrintValues(queries.BooksAfter2005());
void PrintValues(IEnumerable<Book> ListBook)
{
    Console.WriteLine("{0,-60} {1,15} {2,15}\n","Title", "PageCount", "PublishedDate");
	foreach (var item in ListBook)
	{
		Console.WriteLine("{0,-60} {1,15} {2,15}\n", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}

void ImprimirGrupo(IEnumerable<IGrouping<int, Book>> ListadeLibros)
{
    foreach (var grupo in ListadeLibros)
    {
        Console.WriteLine("");
        Console.WriteLine($"Grupo: {grupo.Key}");
        Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
        foreach (var item in grupo)
        {
            Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.Date.ToShortDateString());
        }
    }
}

void ImprimirDiccionario(ILookup<char, Book> ListadeLibros, char letra)
{
    Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach (var item in ListadeLibros[letra])
    {
        Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.Date.ToShortDateString());
    }
}