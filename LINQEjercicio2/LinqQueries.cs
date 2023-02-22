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

    }
}
