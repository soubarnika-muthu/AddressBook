using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
    class OperationManagement
    {
        public static void ReadInput()
        {
            Console.WriteLine("Enter the contact details");
            AddDetails();

        }

        //gets the user details from the user
        public static void AddDetails()
        {
            Console.WriteLine("Enter first Name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Address");
            string address = Console.ReadLine();
            Console.WriteLine("Enter City");
            string city = Console.ReadLine();
            Console.WriteLine("Enter State");
            string state = Console.ReadLine();
            Console.WriteLine("Enter Zipcode");
            long zipCode = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter Phone Number");
            long phoneNumber = Convert.ToInt64(Console.ReadLine());

            //create object for the class address compute and call the set contact detail method 
            AddressBookCompute addressBookCompute = new AddressBookCompute();
            addressBookCompute.AddContactDetails(firstName, lastName, address, city, state, zipCode, phoneNumber);
        }
    }
}