using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksApp.Model;

namespace BooksApp.Repositories
{
    internal interface IBookRepo
    {
        List<Books> GetAllBooks();

    }
}
