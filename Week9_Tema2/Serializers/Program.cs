using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using DataAccess;
using Entity;
using Newtonsoft.Json;

namespace Serializers
{
    class Program
    {
        static void Main(string[] args)
        {
            //string output = JsonSerializer();
            //Console.WriteLine(output);

            //XMLSerializer();

        }

        private static void XMLSerializer()
        {
            BookRepository bookRepository = new BookRepository();

            List<Book> books = bookRepository.GetAllBooks();

            XmlSerializer xsSubmit = new XmlSerializer(typeof(List<Book>));

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, books);
                    string xml = sww.ToString();

                }
            }
        }

        private static string JsonSerializer()
        {
            BookRepository bookRepository = new BookRepository();
            List<Book> bookList = bookRepository.GetAllBooks();


            string output = JsonConvert.SerializeObject(bookList);

            File.WriteAllText("books.json", output);
            return output;
        }
    }
}
