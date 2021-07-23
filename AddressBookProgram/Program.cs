using System;

namespace AddressBookProgram
{
    class Program
    {
        /// <summary>
        /// Welcome to Address Book Management System
        /// UC1 - Gets the contact detail
        /// UC2- Get and stores multiple contacts
        /// UC3- Edit the contacts
        /// UC4-Deleting the particular contact detail
        /// UC5 -Add multiple person to address book one by one from user
        /// UC6- Adding Multiple Address Book
        /// UC7-Ensure no duplicate enteries in address book
        /// UC8-Search person by city or state
        /// UC9-View person by city or state
        /// UC10-Number of contact persons bycity or state
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address book");
            //calling operation management class that contains operation
            OperationManagement operationManagement = new OperationManagement();

            //non-static method 
            operationManagement.ReadInput();
            Console.Read();
        }
    }
}
