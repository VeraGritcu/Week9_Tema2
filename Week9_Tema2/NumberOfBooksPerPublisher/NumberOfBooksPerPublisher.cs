using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data.SqlClient;
using DataAccess.Connection;

namespace NumberOfBooksPerPublisher
{
    public class NumberOfBooksPerPublisher
    {
        private NumberOfBooksPerPublisher() { }
        private int NoOfBooks { get; set; }
        private string PublisherName { get; set; }



    }
}
