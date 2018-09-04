using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Val_ADO.Net
{
    class Program
    {
       SqlCommand comand1 = null;
       static SqlConnection sql_connection = null;
        static SqlDataReader data_reader = null;
        static string connectionString;
        static void Main(string[] args)
        {
            connectionString = @"Data Source=COMP901\SQLEXPRESS;Initial Catalog=bookshops;Integrated Security=True;";
            
            selectCountOfBooks();
            sumAllBooksPrice();
            sumAllBooksPages();
            Console.ReadKey();
        }

        private static void sumAllBooksPages()
        {
            sql_connection = new SqlConnection(connectionString);
            string query_sum_price = "select sum(Pages) from Books;";
            try
            {
                sql_connection.Open();
                SqlCommand command3 = new SqlCommand(query_sum_price, sql_connection);
                int sum = Convert.ToInt32(command3.ExecuteScalar());
                Console.WriteLine($"Сумма страниц всех книг: {sum}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (sql_connection != null)
                {
                    sql_connection.Close();
                }
                data_reader?.Close();
            }
        }

        private static void sumAllBooksPrice()
        {
            sql_connection = new SqlConnection(connectionString);
            string query_sum_price = "select sum(Price) from Books;";
            try
            {
                sql_connection.Open();
                SqlCommand command2 = new SqlCommand(query_sum_price, sql_connection);
                int sum = Convert.ToInt32(command2.ExecuteScalar());
                Console.WriteLine($"Сумма цен всех книг: {sum}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (sql_connection != null)
                {
                    sql_connection.Close();
                }
                data_reader?.Close();
            }
        }

        private static void selectCountOfBooks()
        {
            sql_connection = new SqlConnection(connectionString);
            string query_books = "select count(*) from Books;";
           
            try
            {
                sql_connection.Open();
                SqlCommand comand1 = new SqlCommand(query_books, sql_connection);
                int count = Convert.ToInt32(comand1.ExecuteScalar());
              
                data_reader = comand1.ExecuteReader();
         
                Console.WriteLine($"К-тво книг: {count}");
              
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (sql_connection != null)
                {
                    sql_connection.Close();
                }
                data_reader?.Close();
            }
        }
    }
}
