using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entity
{
    public class NumberOfBooksPerPublisher
    {
        public int NoOfBooks { get; set; }
        public string PublisherName { get; set; }

        public void Print(NumberOfBooksPerPublisher item)
        {
            Console.WriteLine($"{item.NoOfBooks} books on {item.PublisherName}");
        }

    }
}
