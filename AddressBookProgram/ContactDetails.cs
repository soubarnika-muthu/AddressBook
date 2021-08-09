using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{

    /// <summary>
    /// This class store the address details 
    /// </summary>
    public class ContactDetails
    {
        public int personId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipCode { get; set; }
        public string phoneNumber { get; set; }
        public string emailAddress { get; set; }
        public string addedDate { get; set; }
        public int typeId { get; set; }
        public int addressBookId { get; set; }
        //for json server
        public int id { get; set; }

        //it displays the details of the address book
        public void Display()
        {
            Console.WriteLine("Name : {0} {1}", this.firstName, this.lastName);
            Console.WriteLine("Address:{0}", this.address);
            Console.WriteLine("City: {0}", this.city);
            Console.WriteLine("State:{0}", this.state);
            Console.WriteLine("Zipcode:{0}", this.zipCode);
            Console.WriteLine("phone number:{0}", this.phoneNumber);

        }

        //method sets the value 
        public void SetDetail(string number)
        {
            this.phoneNumber = number;
        }

    }
}