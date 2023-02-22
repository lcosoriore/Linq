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
void PrintValues(IEnumerable<Book> ListBook)
{
    Console.WriteLine("{0,-60} {1,15} {2,15}\n","Title", "PageCount", "PublishedDate");
	foreach (var item in ListBook)
	{
		Console.WriteLine("{0,-60} {1,15} {2,15}\n", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}