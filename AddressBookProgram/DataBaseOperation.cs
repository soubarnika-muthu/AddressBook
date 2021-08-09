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
        public static string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=AddressBookService";
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        public List<ContactDetails> ReadFromDataBase()
        {

            Dictionary<string, List<ContactDetails>> contactDictionary = new Dictionary<string, List<ContactDetails>>();
            List<ContactDetails> detail = new List<ContactDetails>();
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.RetriveAllDetails", sqlConnection);
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

        public void WriteIntoDataBase(ContactDetails details)
        {
            throw new NotImplementedException();
        }

    }
}
