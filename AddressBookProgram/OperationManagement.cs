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
            //creating the object for the class address book 
            AddressBookCompute addressBook = new AddressBookCompute();
            bool CONTINUE = true;
            string name;

            //the loop continues until the user exit the site
            while (CONTINUE)
            {
                Console.WriteLine("Enter your choice:");
                Console.WriteLine("1.Add contacts");
                Console.WriteLine("2.Display");
                Console.WriteLine("3.Edit Details");
                Console.WriteLine("4.Delete the contact");
                Console.WriteLine("0.Exit");
                int choice = Convert.ToInt32(Console.ReadLine());

                //select which method has to be invoked
                switch (choice)
                {
                    case 1:
                        AddDetails(addressBook);
                        break;
                    case 2:
                        addressBook.DisplayContact();
                        break;

                    case 3:
                        //gets input from the user such as name and number that has to be changed
                        Console.WriteLine("Enter the first name of person to edit number:");
                        name = Console.ReadLine();
                        Console.Write("Enter the new number:");
                        long number = Convert.ToInt64(Console.ReadLine());

                        //calling edit contact method
                        addressBook.EditContact(name, number);
                        break;

                    case 4:
                        //Deleting the user contact with first name
                        Console.WriteLine("Enter the name to delete contact:");
                        name = Console.ReadLine();
                        addressBook.DeleteContact(name);
                        break;

                    case 0:
                        CONTINUE = false;
                        break;

                    default:
                        break;
                }
            }
        }

        //gets the user detail from the user
        public static void AddDetails(AddressBookCompute addressBookCompute)
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
            addressBookCompute.AddContactDetails(firstName, lastName, address, city, state, zipCode, phoneNumber);
        }
    }
}