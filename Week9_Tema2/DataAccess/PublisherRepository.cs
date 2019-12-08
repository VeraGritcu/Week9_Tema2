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
    public class PublisherRepository
    {
        public List<Publisher> GetAllPublishers()
        {
            List<Publisher> publishers = new List<Publisher>();

            var query = $"Select * from publisher";
            var connection = DBConnection.GetConnection();
            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    Publisher thisP = new Publisher();
                    thisP.PublisherID = (int)rdr["PublisherID"];
                    thisP.Name = rdr["Name"].ToString();

                    publishers.Add(thisP);
                }
                rdr.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return publishers;
        }
        public int GetNumberOfPublishers()
        {
            int id = -1;
            SqlConnection conn = DBConnection.GetConnection();
            try
            {
                string query = "select count(*) from publisher";
                SqlCommand command = new SqlCommand(query, conn);
                 id = (int)command.ExecuteScalar();
            }
            catch(SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return id;
        }

        public List<Publisher> GetTopPublisher(int topNr)
        {
            List<Publisher> publishers = new List<Publisher>();

            var query = $"Select top {topNr} * from publisher";
            var connection = DBConnection.GetConnection();
            try
            {

                SqlCommand command = new SqlCommand(query, connection);


                SqlDataReader rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    Publisher thisP = new Publisher();
                    thisP.PublisherID = (int)rdr["PublisherID"];
                    thisP.Name = rdr["Name"].ToString();
                   
                    publishers.Add(thisP);
                }
                rdr.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return publishers;
        }

        public void ReadPublisherList(List<Publisher> publishers)
        {
            foreach (var publisher in publishers)
            {
                Console.WriteLine($"PublisherID {publisher.PublisherID} Name {publisher.Name}");
            }
        }

        public void BooksPerPublisher()
        {
            SqlConnection conn = DBConnection.GetConnection();
           try
            {
                string query = " select Name, count(bookid) as NoOfBooks from publisher p  inner join book b on b.publisherid = p.publisherid group by p.name";


                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    string name = rdr["Name"].ToString();
                    int books = (int)rdr["NoOfBooks"];
                    Console.WriteLine($"Publisher name: {name} has {books} book(s)");
                }
                rdr.Close();

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void PriceOfBooksPerPublisher()
        {
            SqlConnection conn = DBConnection.GetConnection();
            try
            {
                string query = " select Name, sum(b.price) BooksPrice from publisher p  inner join book b on b.publisherid = p.publisherid group by p.name";


                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    string name = rdr["Name"].ToString();
                    decimal price = (decimal)rdr["BooksPrice"];
                    Console.WriteLine($"Publisher name: {name} has books with a total amount of {price}");
                }
                rdr.Close();

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public List<NumberOfBooksPerPublisher> GetBooksPerPublisher()
        {
            List<NumberOfBooksPerPublisher> list = new List<NumberOfBooksPerPublisher>();

              SqlConnection conn = DBConnection.GetConnection();
            try
            {
                string query = "select count(b.bookid) NoOfBooks, name " +
                    " from publisher p inner join book b on b.publisherid = p.publisherid group by p.name";
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    var pair = new NumberOfBooksPerPublisher();

                    pair.NoOfBooks = rdr["NoOfBooks"] as int? ?? default(int);
                    pair.PublisherName = rdr["name"].ToString();
                    list.Add(pair);

                }
                rdr.Close();

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return list;
        }
    }
}
