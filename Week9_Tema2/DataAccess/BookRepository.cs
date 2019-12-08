using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Connection;
using Entity;
using System.Data.SqlClient;

namespace DataAccess
{
    public class BookRepository
    {

        public List<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();

            var query = "Select * from book";
            var connection = DBConnection.GetConnection();
            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    Book thisBook = new Book();
                    thisBook.BookId = (int)rdr["BookID"];
                    thisBook.Title = rdr["Title"].ToString();
                    thisBook.PublisherID = rdr["PublisherID"] as int? ?? default(int);
                    thisBook.Year = rdr["Year"] as int? ?? default(int);
                    thisBook.Price = rdr["Price"] as decimal? ?? default(decimal);

                    books.Add(thisBook);
                }
                rdr.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return books;
        }
        
        public List<Book> GetBooksFromYear(int year)
        {
            List<Book> books = new List<Book>();

            var query = "Select * from book where year = @year";
            var connection = DBConnection.GetConnection();
            try
            {
                SqlParameter yearParam = new SqlParameter ("@year", year);
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(yearParam);
                
                SqlDataReader rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    Book thisBook = new Book();
                    thisBook.BookId = (int)rdr["BookID"];
                    thisBook.Title = rdr["Title"].ToString();
                    thisBook.PublisherID = rdr["PublisherID"] as int? ?? default(int);
                    thisBook.Year = rdr["Year"] as int? ?? default(int);
                    thisBook.Price = rdr["Price"] as decimal? ?? default(decimal);

                    books.Add(thisBook);
                }
                rdr.Close();
            }
            catch(SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return books;
        }

        public Book GetNewestBook()
        {
            Book book = new Book();
            SqlConnection conn = DBConnection.GetConnection();
            string query = " select b.* from book b inner join book b2 on b.bookid = b2.bookid" +
                " where b.year = (select max(year) from book )";
            try
            {
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    
                    book.BookId = (int)rdr["BookID"];
                    book.Title = rdr["Title"].ToString();
                    book.PublisherID = rdr["PublisherID"] as int? ?? default(int);
                    book.Year = rdr["Year"] as int? ?? default(int);
                    book.Price = rdr["Price"] as decimal? ?? default(decimal);
                }
                rdr.Close();
            }
            catch(SqlException e)
            {
                Console.WriteLine(e.Message);
            }
           
            return book;
        }

        public void PrintBookExtendedView(Book b)
        {
            Console.WriteLine($"BookID - [{b.BookId}] Title [{b.Title}] PublisherID [{b.PublisherID}] Year [{b.Year}] Price [{b.Price}]");
        }

        public List<Book> GetTopBooks(int topNr)
        {
            List<Book> books = new List<Book>();

            var query =$"Select top {topNr} * from book";
            var connection = DBConnection.GetConnection();
            try
            {
                
                SqlCommand command = new SqlCommand(query, connection);
                

                SqlDataReader rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    Book thisBook = new Book();
                    thisBook.BookId = (int)rdr["BookID"];
                    thisBook.Title = rdr["Title"].ToString();
                    thisBook.PublisherID = rdr["PublisherID"] as int? ?? default(int);
                    thisBook.Year = rdr["Year"] as int? ?? default(int);
                    thisBook.Price = rdr["Price"] as decimal? ?? default(decimal);

                    books.Add(thisBook);
                }
                rdr.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return books;
        }
        public void PrintBookReducedView(Book b)
        {
            Console.WriteLine($"Title [{b.Title}] Year [{b.Year}] Price [{b.Price}]");
        }

    }
}
