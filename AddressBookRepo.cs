using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AdvAddressBook_ADO.NET
{
    public class AddressBookRepo
    {
        //Give path for Database Connection
        public static string connectionString = @"Data Source=(Localdb)\MSSQLLocalDB;Initial Catalog=AddressBook_Service;Integrated Security=True";
        //Represents a connection to Sql Server Database
        SqlConnection connection = new SqlConnection(connectionString);

        // Checks the connection.
        public void DataBaseConnection()
        {
            try
            {
                this.connection.Open();
                Console.WriteLine("connection established");
                this.connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }


    }
}