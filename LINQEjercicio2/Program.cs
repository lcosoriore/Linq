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
void PrintValues(IEnumerable<Book> ListBook)
{
    Console.WriteLine("{0,-60} {1,15} {2,15}\n","Title", "PageCount", "PublishedDate");
	foreach (var item in ListBook)
	{
		Console.WriteLine("{0,-60} {1,15} {2,15}\n", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}