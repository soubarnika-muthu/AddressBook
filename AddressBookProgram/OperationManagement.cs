using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
   public class OperationManagement
    {

        Dictionary<string, List<ContactDetails>> addressDictionary;
        public Dictionary<string, List<ContactDetails>> stateDic;
        public Dictionary<string, List<ContactDetails>> cityDic;
        public AddressBookCompute addressBook = new AddressBookCompute();
        //constructor that create the object for address book and store in dictionary
        public OperationManagement()
        {
            addressDictionary = new Dictionary<string, List<ContactDetails>>();
            stateDic = new Dictionary<string, List<ContactDetails>>();
            cityDic = new Dictionary<string, List<ContactDetails>>();
        }

        //read input from user
        public void ReadInput()
        {
            OperationManagement operation = new OperationManagement();
            JSONFileOperation jSONFile = new JSONFileOperation();
            string jsonFile = @"C:\Users\hp\source\repos\AddressBookProgram\AddressBookProgram\addressbook.json";
            //creating the object for the class address book 
            bool CONTINUE = true;
            string name;
            List<ContactDetails> contactList;

            //the loop continues until the user exit the site
            while (CONTINUE)
            {
                //selecting the choice
                Console.WriteLine("Enter your choice:");
                Console.WriteLine("1.Reading the data from JSON");
                Console.WriteLine("2.Reading from CSV file");
                Console.WriteLine("3.Add new address book");
                Console.WriteLine("4.Add contacts");
                Console.WriteLine("5.Display");
                Console.WriteLine("6.Edit Details");
                Console.WriteLine("7.Delete the contact");
                Console.WriteLine("8.Delete the address book");
                Console.WriteLine("9.Display the person by city or state");
                Console.WriteLine("10.Grouping the persons based on city or state");
                Console.WriteLine("11.Total count of person in each city and state");
                Console.WriteLine("12.Sort the address book by key");
                Console.WriteLine("13.Sorting data based on City state or zipcode");
                Console.WriteLine("14.REading and writing the data into the file");
                Console.WriteLine("0.Exit");
                int choice = Convert.ToInt32(Console.ReadLine());

                //select which method has to be invoked
                switch (choice)
                {
                    case 1:
                        addressDictionary = jSONFile.ReadData(jsonFile);
                        break;
                    case 2:
                        string csvFile = @"C:\Users\hp\source\repos\AddressBookProgram\AddressBookProgram\ContactDetails.csv";
                        addressDictionary = new CSVFileOperation().ReadData(csvFile);
                        break;
                    case 3:
                        //creating the dictionary
                        Console.WriteLine("Enter address book name:");
                        string addBookName = Console.ReadLine();
                        List<ContactDetails> list = new List<ContactDetails>();
                        //create the object for the address book
                        //pass address book object and name to the dictionary
                        addressDictionary.Add(addBookName, list);
                        jSONFile.WriteData(addressDictionary, jsonFile);
                        break;


                    case 4:
                        try
                        {
                            //calling the AddDetails method by passing the address of the Address book compute
                            AddDetails(operation.BookName(addressDictionary), stateDic, cityDic);
                        }
                        catch (ArgumentNullException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        jSONFile.WriteData(addressDictionary, jsonFile);
                        break;

                    case 5:
                        //display the details in particular dictionary
                        contactList = operation.BookName(addressDictionary);
                        if (contactList != null)
                        {
                            AddressBookCompute.DisplayContact(contactList);
                        }
                        else
                        {
                            Console.WriteLine("No Address book of given name available");
                        }
                        break;

                    case 6:
                        try
                        {
                            contactList = operation.BookName(addressDictionary);
                            //gets input from the user such as name and number that has to be changed
                            Console.WriteLine("Enter the first name of person to edit number:");
                            name = Console.ReadLine();
                            Console.Write("Enter the new number:");
                            string number = Console.ReadLine();
                            //calling edit contact method
                            addressBook.EditContact(name, number, contactList);
                        }
                        catch (NullReferenceException e)
                        {
                            Console.WriteLine("No dictionary available");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Enter valid input");
                        }
                        jSONFile.WriteData(addressDictionary, jsonFile);
                        break;

                    case 7:
                        try
                        {
                            contactList = operation.BookName(addressDictionary);
                            //Deleting the user contact with first name
                            Console.WriteLine("Enter the name to delete contact:");
                            name = Console.ReadLine();
                            addressBook.DeleteContact(name, contactList);
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine("Address book is not available");
                        }
                        jSONFile.WriteData(addressDictionary, jsonFile);
                        break;

                    case 8:
                        //deleting the entire adress book
                        Console.WriteLine("Enter address book name to delete:");
                        string Name = Console.ReadLine();
                        addressDictionary.Remove(Name);
                        jSONFile.WriteData(addressDictionary, jsonFile);
                        break;
                    case 9:
                        AddressBookCompute.FindPerson(addressDictionary);
                        break;
                    //case to group the persons in all address book based on state and city
                    case 10:
                        Console.WriteLine("Grouping based on city ");
                        foreach (var l in cityDic.Values)
                        {
                            AddressBookCompute.DisplayContact(l);
                        }
                        Console.WriteLine("Grouping based on States ");
                        foreach (var l in stateDic.Values)
                        {
                            AddressBookCompute.DisplayContact(l);
                        }
                        break;
                    //to find the count of the person in particular city or state
                    case 11:
                        AddressBookCompute.CountOfPersons(cityDic);
                        AddressBookCompute.CountOfPersons(stateDic);
                        break;

                    case 12:
                        //displaying the sorted address book based on the key value ie.name of address book
                        Console.WriteLine("AddressBook after sorting");
                        foreach (var i in addressDictionary.OrderBy(x => x.Key))
                        {
                            Console.WriteLine("{0}", i.Key);
                        }
                        break;
                    case 13:
                        //displaying the sorted records based on city,state,zipcode
                        AddressBookCompute.SortData(cityDic);
                        break;
                    case 14:
                        //writing and reading  the data into the file
                        string filepath = @"C:\Users\hp\source\repos\AddressBookProgram\AddressBookProgram\AddressBook.txt";
                        new TextFileOperation().WriteData(addressDictionary, filepath);
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
        public void AddDetails(List<ContactDetails> list, Dictionary<string, List<ContactDetails>> stateRecord, Dictionary<string, List<ContactDetails>> cityRecord)
        {
            try
            {
                if (list == null)
                {
                    Console.WriteLine("Address book not available");
                }
                else
                {
                    ContactDetails contactDetails = new ContactDetails();
                    Console.WriteLine("Enter first Name");
                    contactDetails.firstName = Console.ReadLine();
                    Console.WriteLine("Enter Last Name");
                    contactDetails.lastName = Console.ReadLine();
                    Console.WriteLine("Enter Address");
                    contactDetails.address = Console.ReadLine();
                    Console.WriteLine("Enter City");
                    contactDetails.city = Console.ReadLine();
                    Console.WriteLine("Enter State");
                    contactDetails.state = Console.ReadLine();
                    Console.WriteLine("Enter Zipcode");
                    contactDetails.zipCode = Console.ReadLine();
                    Console.WriteLine("Enter Phone Number");
                    contactDetails.phoneNumber = Console.ReadLine();
                    //passing the details to add contact detail method
                    addressBook.AddContactDetails(stateRecord, cityRecord, list, contactDetails, contactDetails.firstName, contactDetails.state, contactDetails.city);
                }
            }
            //catches when the user input the invalid data
            catch (FormatException e)
            {
                Console.WriteLine("Detail entered is not in correct format");
            }
        }

        //method to find the address of particular address book 
        public List<ContactDetails> BookName(Dictionary<string, List<ContactDetails>> adBook)
        {
            //enter the name of address ook
            Console.WriteLine("Enter address book name:");
            List<ContactDetails> address;
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

        public List<ContactDetails> RetrivingDataFromDataBase()
        {
            DataBaseOperation operation = new DataBaseOperation();
            List<ContactDetails> detail = operation.ReadFromDataBase();
            return detail;
        }

        public int updateContact(int id, string firstName, long phoneNumber)
        {
            int res = new DataBaseOperation().EditContactDetail(id, firstName, phoneNumber);
            return res;
        }
        public List<ContactDetails> RetrivingDataBasedOnDate(DateTime startDate, DateTime endDate)
        {
            DataBaseOperation operation = new DataBaseOperation();
            List<ContactDetails> detail = operation.RetriveBasedOnDate(startDate, endDate);
            return detail;
        }

        public List<ContactDetails> RetrivingDataBasedOnStateCity(string state, string city)
        {
            DataBaseOperation operation = new DataBaseOperation();
            List<ContactDetails> detail = operation.RetriveBasedOnStateOrCity(state, city);
            return detail;
        }

        public int AddDetailsToAddressBook(ContactDetails details)
        {
            int res = new DataBaseOperation().WriteIntoDataBase(details);
            return res;
        }

        public List<ContactDetails> AddMultiplecontactToDataBase(List<ContactDetails> list)
        {
            list = new DataBaseOperation().AddingMultipleData(list);
            return list;
        }


    }
}