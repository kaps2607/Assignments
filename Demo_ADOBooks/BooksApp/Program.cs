using BooksApp.Repositories;

namespace BooksApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IBookRepo bookRepo = new BookRepo();
            bookRepo.GetAllBooks();
        }
    }
}
