using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
