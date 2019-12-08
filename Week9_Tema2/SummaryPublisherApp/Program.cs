using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Entity;

namespace SummaryPublisherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PublisherRepository publisherRep = new PublisherRepository();
            //var no = publisherRep.GetNumberOfPublishers();
            //Console.WriteLine($"Number of rows from Publisher table is {no}");

            //publisherRep.ReadPublisherList(publisherRep.GetTopPublisher(10));

            //publisherRep.BooksPerPublisher();

            //publisherRep.PriceOfBooksPerPublisher();

            List<NumberOfBooksPerPublisher> list =  publisherRep.GetBooksPerPublisher();
            foreach (var item in list)
            {
                item.Print(item);
            }
        }
    }
}
