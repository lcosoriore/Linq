using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LINQEjercicio2
{
    public class LinqQueries
    {
        private List<Book> booksCollection = new List<Book>();
        public LinqQueries() 
        {
            using (StreamReader reader = new StreamReader("books.json"))
            {
                string json = reader.ReadToEnd();
                this.booksCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive= true});
            }
        }
        public IEnumerable<Book> AllCollection() 
        {
            return booksCollection;
        }

        public IEnumerable<Book> BooksAfter2000()
        {
            return booksCollection.Where(p=>p.PublishedDate.Year>2000);
        }
        public IEnumerable<Book> BooksAfter2000QueryExpression()
        {
            return from b in booksCollection  where b.PublishedDate.Year>2000 select b;
        }

        public IEnumerable<Book> BooksWithMore250PagesAndWordsInAction()
        {
            return booksCollection.Where(p => p.PageCount > 250 && p.Title.Contains("in Action"));
        }

        public IEnumerable<Book> BooksWithMore250PagesAndWordsInActionQueryExpression()
        {
            return from b in booksCollection where b.PageCount > 250 && b.Title.Contains("in Action") select b;
        }

        public bool AllBooksHaveStatus()
        {
            return booksCollection.All(p => p.Status != string.Empty);
        }
        public bool AnyBookPublish2005()
        {
            return booksCollection.Any(p => p.PublishedDate.Year ==2005);
        }

        public IEnumerable<Book> BooksPython()
        {
            return booksCollection.Where(p => p.Categories.Contains("Python"));
        }
        public IEnumerable<Book> BooksJava()
        {
            return booksCollection.Where(p => p.Categories.Contains("Java")).OrderBy(p => p.Title);
        }

        public IEnumerable<Book> BooksJavaDescending()
        {
            return booksCollection.Where(p => p.PageCount>=450).OrderByDescending(p => p.PageCount);
        }

        public IEnumerable<Book> BooksTakeOperator()
        {
            return booksCollection.Where(p => p.Categories.Contains("Java")).OrderByDescending(p => p.PublishedDate).Take(3);
        }
        public IEnumerable<Book> BooksSkipOperator()
        {
            return booksCollection.Where(p => p.PageCount>400).Take(4).Skip(2);
        }

        public IEnumerable<Book> FirtsThreeBooks()
        {
            return booksCollection.Take(3)
                 .Select(p => new Book() { Title=p.Title, PageCount= p.PageCount });
        }
       // Using the count operator, returns the number of books that are between 200 and 500 pages.
       public int NumberBooksBetween200And500PagesCount()
        {
            return booksCollection.Count(p=>p.PageCount >200 && p.PageCount<500);
        }
        public long NumberBooksBetween200And500PagesLongCount()
        {
            return booksCollection.Where(p => p.PageCount > 200 && p.PageCount < 500).LongCount();
        }

        //Using the min operator, returns the shortest publication date of the collection.
        public DateTime DatePublishMin()
        {
            return booksCollection.Min(p => p.PublishedDate);
        }

        public int MaxPagesBook()
        {
            return booksCollection.Max(p => p.PageCount);
        }

        //Return the book with the least number of pages greater than zero.
        public Book BookWithLessNumberOfPages()
        {
            return booksCollection.Where(p => p.PageCount > 0).MinBy(p => p.PageCount);
        }

        //Return book with most recent publication date
        public Book BookWithMostRecentPublicationDate()
        {
            return booksCollection.MaxBy(p => p.PublishedDate );
        }
        public double AverageTittle()
        {
            return Convert.ToDouble(booksCollection.Average(p => p.Title.Length));
        }
    }
}
