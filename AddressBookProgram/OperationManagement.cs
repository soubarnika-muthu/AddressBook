using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
    class OperationManagement
    {
        Dictionary<string, AddressBookCompute> addressDictionary;
        public Dictionary<string, List<ContactDetails>> stateDic;
        public Dictionary<string, List<ContactDetails>> cityDic;

        //constructor that create the object for address book and store in dictionary
        public OperationManagement()
        {
            addressDictionary = new Dictionary<string, AddressBookCompute>();
            stateDic = new Dictionary<string, List<ContactDetails>>();
            cityDic = new Dictionary<string, List<ContactDetails>>();
        }

        //read input from user
        public void ReadInput()
        {
            OperationManagement operation = new OperationManagement();
            //creating the object for the class address book 
            bool CONTINUE = true;
            string name;
            AddressBookCompute book;

            //the loop continues until the user exit the site
            while (CONTINUE)
            {
                //selecting the choice
                Console.WriteLine("Enter your choice:");
                Console.WriteLine("1.Add new address book");
                Console.WriteLine("2.Add contacts");
                Console.WriteLine("3.Display");
                Console.WriteLine("4.Edit Details");
                Console.WriteLine("5.Delete the contact");
                Console.WriteLine("6.Delete the address book");
                Console.WriteLine("7.Display the person by city or state");
                Console.WriteLine("8.Grouping the persons based on city or state");
                Console.WriteLine("0.Exit");
                int choice = Convert.ToInt32(Console.ReadLine());

                //select which method has to be invoked
                switch (choice)
                {
                    case 1:
                        //creating the dictionary
                        Console.WriteLine("Enter address book name:");
                        string addBookName = Console.ReadLine();
                        //create the object for the address book
                        AddressBookCompute addressBook1 = new AddressBookCompute();
                        //pass address book object and name to the dictionary
                        this.addressDictionary.Add(addBookName, addressBook1);
                        break;


                    case 2:
                        try
                        {
                            //calling the AddDetails method by passing the address of the Address book compute
                            AddDetails(operation.BookName(addressDictionary), stateDic, cityDic);
                        }
                        catch (ArgumentNullException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case 3:
                        //display the details in particular dictionary
                        book = operation.BookName(addressDictionary);
                        if (book != null)
                        {
                            book.DisplayContact();
                        }
                        else
                        {
                            Console.WriteLine("No Address book of given name available");
                        }
                        break;

                    case 4:
                        try
                        {
                            book = operation.BookName(addressDictionary);
                            //gets input from the user such as name and number that has to be changed
                            Console.WriteLine("Enter the first name of person to edit number:");
                            name = Console.ReadLine();
                            Console.Write("Enter the new number:");
                            long number = Convert.ToInt64(Console.ReadLine());
                            //calling edit contact method
                            book.EditContact(name, number);
                        }
                        catch (NullReferenceException e)
                        {
                            Console.WriteLine("No dictionary available");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Enter valid input");
                        }
                        break;

                    case 5:
                        try
                        {
                            book = operation.BookName(addressDictionary);
                            //Deleting the user contact with first name
                            Console.WriteLine("Enter the name to delete contact:");
                            name = Console.ReadLine();
                            book.DeleteContact(name);
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine("Address book is not available");
                        }
                        break;

                    case 6:
                        //deleting the entire adress book
                        Console.WriteLine("Enter address book name to delete:");
                        string Name = Console.ReadLine();
                        addressDictionary.Remove(Name);
                        break;
                    case 7:
                        AddressBookCompute.FindPerson(addressDictionary);
                        break;
                    //case to group the persons in all address book based on state and city
                    case 8:
                        Console.WriteLine("Grouping based on city ");
                        AddressBookCompute.PrintList(cityDic);
                        Console.WriteLine("Grouping based on States ");
                        AddressBookCompute.PrintList(stateDic);
                        break;

                    case 0:
                        CONTINUE = false;
                        break;

                    default:
                        break;
                }
            }
        }

        //gets the user detail from the user by passing the address book object also state and city dicionary object to group based on dictionary value
        public static void AddDetails(AddressBookCompute addressBookCompute, Dictionary<string, List<ContactDetails>> stateRecord, Dictionary<string, List<ContactDetails>> cityRecord)
        {
            try
            {
                if (addressBookCompute == null)
                {
                    Console.WriteLine("Address book ot available");
                }
                else
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
                    //passing the details to add contact detail method
                    addressBookCompute.AddContactDetails(firstName, lastName, address, city, state, zipCode, phoneNumber, stateRecord, cityRecord);
                }
            }
            //catches when the user input the invalid data
            catch (FormatException e)
            {
                Console.WriteLine("Detail entered is not in correct format");
            }
        }

        //method to find the address of particular address book 
        public AddressBookCompute BookName(Dictionary<string, AddressBookCompute> adBook)
        {
            //enter the name of address ook
            Console.WriteLine("Enter address book name:");
            AddressBookCompute address;
            string Name = Console.ReadLine();
            //checks whether the adress book contains the record
            try
            {
                address = adBook[Name];
                //return the address of particular address book
                return address;

            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine(e.Message);
                return default;
            }
        }
    }
}