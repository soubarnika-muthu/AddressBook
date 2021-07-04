using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
    class ContactDetails
    {
        public string firstName;
        public string lastName;
        public string address;
        public string city;
        public string state;
        public long zipCode;
        public long phoneNumber;

        //constructor that gets user detail and store it in the current object
        public ContactDetails(string firstName, string lastName, string address, string city, string state, long zipCode, long phoneNumber)
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

    }
}