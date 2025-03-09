using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Model
{
    internal class Books
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int? Price { get; set; }
        public int? PublishedYear { get; set; }

        public override string ToString()
        {
            return $"BikeId={BookId}\tTitle={Title}\tPrice={Price}\tPublishedYear={PublishedYear}";
        }
    }
}
