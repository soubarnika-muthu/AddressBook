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
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipCode { get; set; }
        public string phoneNumber { get; set; }

        //constructor that gets user detail and store it in the current object
        public ContactDetails(string firstName, string lastName, string address, string city, string state, string zipCode, string phoneNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zipCode = zipCode;
            this.phoneNumber = phoneNumber;
        }

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