using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
   public class AddressBookJsonServer
    {

        RestClient client;
        public AddressBookJsonServer()
        {
            client = new RestClient("http://localhost:3000");
        }
        public IRestResponse GetAllEmployee()
        {
            RestRequest request = new RestRequest("/Contacts");
            IRestResponse response = client.Execute(request);
            return response;
        }
        public List<ContactDetails> ReadFromServer()
        {
            IRestResponse response = GetAllEmployee();
            var res = JsonConvert.DeserializeObject<List<ContactDetails>>(response.Content);
            return res;
        }
        public void WriteIntoJsonServer(ContactDetails contact)
        {
            RestRequest request = new RestRequest("/Contacts", Method.POST);
            JsonObject json = new JsonObject();
            json.Add("id", contact.personId);
            json.Add("firstName", contact.firstName);
            json.Add("lastName", contact.lastName);
            json.Add("address", contact.address);
            json.Add("city", contact.city);
            json.Add("state", contact.state);
            json.Add("zipCode", contact.zipCode);
            json.Add("phoneNumber", contact.phoneNumber);
            json.Add("emailAddress", contact.emailAddress);
            json.Add("addedDate", contact.addedDate);
            json.Add("typeId", contact.typeId);
            json.Add("addressBookId", contact.addressBookId);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var res = JsonConvert.DeserializeObject<ContactDetails>(response.Content);
            res.personId = res.id;
            Console.WriteLine("" + res.personId);
        }
        //Adding multiple data to the server
        public void AddingMultipleContactToServer(List<ContactDetails> contactList)
        {
            foreach (var contact in contactList)
            {
                WriteIntoJsonServer(contact);
                new DataBaseOperation().WriteIntoDataBase(contact);
            }
        }

        public int UpdateValueInJsonServer(ContactDetails contact)
        {
            int result = 0;
            RestRequest request = new RestRequest("/Contacts/" + contact.personId, Method.PUT);
            JsonObject json = new JsonObject();
            json.Add("id", contact.personId);
            json.Add("firstName", contact.firstName);
            json.Add("lastName", contact.lastName);
            json.Add("address", contact.address);
            json.Add("city", contact.city);
            json.Add("state", contact.state);
            json.Add("zipCode", contact.zipCode);
            json.Add("phoneNumber", contact.phoneNumber);
            json.Add("emailAddress", contact.emailAddress);
            json.Add("addedDate", contact.addedDate);
            json.Add("typeId", contact.typeId);
            json.Add("addressBookId", contact.addressBookId);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var res = JsonConvert.DeserializeObject<ContactDetails>(response.Content);
            if (response.IsSuccessful)
            {
                result = new DataBaseOperation().EditContactDetail(contact.personId, contact.firstName, Convert.ToInt64(contact.phoneNumber));
            }
            return result;
        }

        //delete the record from the server
        public bool DeleteData(int id)
        {
            RestRequest request = new RestRequest("/Contacts/" + id, Method.DELETE);
            IRestResponse response = client.Execute(request);
            return (response.IsSuccessful);
        }

    }
}
