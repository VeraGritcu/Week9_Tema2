using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Entity;

namespace SummaryBookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BookRepository bookRep = new BookRepository();
            //List<Book> books2010 = bookRep.GetBooksFromYear(2010);

            //Book newestBook = bookRep.GetNewestBook();           
            //bookRep.PrintBookExtendedView(newestBook);

            List<Book> top10Books = bookRep.GetTopBooks(10);
            foreach (var book in top10Books)
            {
                bookRep.PrintBookReducedView(book);
            }
        }
    }
}
