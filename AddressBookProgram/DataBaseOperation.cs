using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace AddressBookProgram
{
    class DataBaseOperation
    {
        List<ContactDetails> detail = new List<ContactDetails>();
        public static string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=Address_Book_Service";
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        public List<ContactDetails> ReadFromDataBase()
        {
           
            Dictionary<string, List<ContactDetails>> contactDictionary = new Dictionary<string, List<ContactDetails>>();
            
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("RetriveAllDetail", sqlConnection);
                //passing command type as stored procedure
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                //if it has data
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ContactDetails contact = new ContactDetails();
                        contact.personId = Convert.ToInt32(reader["personId"]);
                        contact.firstName = reader.GetString(1);
                        contact.lastName = reader.GetString(2);
                        contact.address = reader.GetString(3);
                        contact.city = reader.GetString(4);
                        contact.state = reader.GetString(5);
                        contact.zipCode = reader.GetInt64(6).ToString();
                        contact.phoneNumber = reader.GetInt64(7).ToString();
                        contact.emailAddress = reader.GetString(8);
                        detail.Add(contact);
                    }
                }
                reader.Close();
                return detail;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

        }
        public int EditContactDetail(int id, string firstName, long phoneNumber)
        {
            using (sqlConnection)
                try
                {
                    //passing query in terms of stored procedure
                    SqlCommand sqlCommand = new SqlCommand("EditPhoneNumber", sqlConnection);
                    //passing command type as stored procedure
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlConnection.Open();
                    //adding the values to the stored procedure
                    sqlCommand.Parameters.AddWithValue("@firstName", firstName);
                    sqlCommand.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                    sqlCommand.Parameters.AddWithValue("@id", id);
                    int result = sqlCommand.ExecuteNonQuery();
                    //if result is greater than 0 then record is inserted
                    if (result > 0)
                        return 1;
                    else
                        return 0;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }
        }
        public List<ContactDetails> RetriveBasedOnStateOrCity(string state, string city)
        {
            using (sqlConnection)
                try
                {
                    //passing query in terms of stored procedure
                    SqlCommand sqlCommand = new SqlCommand("RetriveDataState", sqlConnection);
                    //passing command type as stored procedure
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlConnection.Open();
                    //adding the values to the stored procedure
                    sqlCommand.Parameters.AddWithValue("@state", state);
                    sqlCommand.Parameters.AddWithValue("@city", city);
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    //if it has data
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ContactDetails contact = new ContactDetails();
                            contact.personId = Convert.ToInt32(reader["personId"]);
                            contact.firstName = reader.GetString(1);
                            contact.lastName = reader.GetString(2);
                            contact.address = reader.GetString(3);
                            contact.city = reader.GetString(4);
                            contact.state = reader.GetString(5);
                            contact.zipCode = reader.GetInt64(6).ToString();
                            contact.phoneNumber = reader.GetInt64(7).ToString();
                            contact.emailAddress = reader.GetString(8);
                            detail.Add(contact);
                        }
                    }
                    reader.Close();
                    return detail;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }
        }
        public List<ContactDetails> RetriveBasedOnDate(DateTime startdate, DateTime endDate)
        {
            using (sqlConnection)
                try
                {
                    //passing query in terms of stored procedure
                    SqlCommand sqlCommand = new SqlCommand("RetriveBasedOnDate", sqlConnection);
                    //passing command type as stored procedure
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlConnection.Open();
                    //adding the values to the stored procedure
                    sqlCommand.Parameters.AddWithValue("@stateDate", startdate);
                    sqlCommand.Parameters.AddWithValue("@endDate", endDate);
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    //if it has data
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ContactDetails contact = new ContactDetails();
                            contact.personId = Convert.ToInt32(reader["personId"]);
                            contact.firstName = reader.GetString(1);
                            contact.lastName = reader.GetString(2);
                            contact.address = reader.GetString(3);
                            contact.city = reader.GetString(4);
                            contact.state = reader.GetString(5);
                            contact.zipCode = reader.GetInt64(6).ToString();
                            contact.phoneNumber = reader.GetInt64(7).ToString();
                            contact.emailAddress = reader.GetString(8);
                            detail.Add(contact);
                        }
                    }
                    reader.Close();
                    return detail;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }


        }
        public int WriteIntoDataBase(ContactDetails details)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                sqlConnection.Open();
                //creating object for transaction class and begin transaction
                SqlTransaction transaction = sqlConnection.BeginTransaction();
                try
                {
                    //executing the query
                    string AddressInsertion = "insert into AddressBook(firstName,lastName,phoneNumber,address,city,state,email,zipCode,date_added) values ('" + details.firstName + "','" + details.lastName + "'," + Convert.ToDouble(details.phoneNumber) + ",'" + details.address + "','" + details.city + "','" + details.state + "','" + details.emailAddress + "'," + Convert.ToDouble(details.zipCode) + ",'" + details.addedDate + "')";
                    string TypeInsertion = "insert into ContactAddress(personId,typeId) values(" + details.personId + "," + details.typeId + ")";
                   // string addressBookNameInsertion = "insert into AddressBookContact(personId,addressBookId) values (" + details.personId + "," + details.addressBookId + ")";
                    new SqlCommand(AddressInsertion, sqlConnection, transaction).ExecuteNonQuery();
                    new SqlCommand(TypeInsertion, sqlConnection, transaction).ExecuteNonQuery();
                   // new SqlCommand(addressBookNameInsertion, sqlConnection, transaction).ExecuteNonQuery();
                    //if all query is successfull commit
                    transaction.Commit();

                    return 1;
                }
                catch (Exception e)
                {
                    //else roll back
                    transaction.Rollback();
                    return 0;
                }
                finally
                {
                    sqlConnection.Close();
                }
                
            }
        }
        //UC-21 Adding multiple contact to list using thread
        public List<ContactDetails> AddingMultipleData(List<ContactDetails> contacts)
        {
            contacts.ForEach(contactDetail => {
                Task thread = new Task(() =>
                {
                    Console.WriteLine("Contact begin added" + contactDetail.firstName);
                    WriteIntoDataBase(contactDetail);
                    Console.WriteLine("Contact added:" + contactDetail.firstName);
                });
                thread.Start();
            });
            contacts = ReadFromDataBase();
            return contacts;
        }

    }



}

