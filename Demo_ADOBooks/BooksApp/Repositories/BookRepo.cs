using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksApp.Model;

namespace BooksApp.Repositories
{
    internal class BookRepo : IBookRepo
    {
        SqlConnection con = null;
        SqlCommand command = null;

        public List<Books> GetAllBooks()
        {
            List<Books> books = new List<Books>();
            con = new SqlConnection("Server=DESKTOP-03V0C0B;Database=BookStoreDB;Trusted_Connection=true");
            command.CommandText = "select * from Books";
            command.Connection= con;
            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) 
            { 
                
                Books obj=new Books();
                obj.BookId = (int)reader["BookId"];
                obj.Title= (string)reader["Title"];
                obj.Price = (int)reader["Price"];
                obj.PublishedYear = (int)reader["PublishedYear"];
                books.Add(obj);
                
            }
            con.Close();
            return books;
        }
    }
}
