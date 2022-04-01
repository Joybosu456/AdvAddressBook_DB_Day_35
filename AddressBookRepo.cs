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

        public void personBelongingCityOrState()
        {
            try
            {
                AddressBookModel addressBookModel = new AddressBookModel();
                using (this.connection)
                {
                    string query = @"select * from AddressBook_Table where city='mumbai' Or state='andhra';";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            addressBookModel.FirstName = sqlDataReader.GetString(0); ;
                            addressBookModel.LastName = sqlDataReader.GetString(1);
                            addressBookModel.Address = sqlDataReader.GetString(2);
                            addressBookModel.City = sqlDataReader.GetString(3);
                            addressBookModel.State = sqlDataReader.GetString(4);
                            addressBookModel.Zip = sqlDataReader.GetInt64(5);
                            addressBookModel.PhoneNumber = sqlDataReader.GetInt64(6);
                            addressBookModel.Email = sqlDataReader.GetString(7);
                            addressBookModel.AddressBookName = sqlDataReader.GetString(8);
                            addressBookModel.AddressBookType = sqlDataReader.GetString(9);
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", addressBookModel.FirstName, addressBookModel.LastName, addressBookModel.Address, addressBookModel.City, addressBookModel.State, addressBookModel.Zip, addressBookModel.PhoneNumber, addressBookModel.Email, addressBookModel.AddressBookName, addressBookModel.AddressBookType);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    sqlDataReader.Close();
                    this.connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }


    }
}