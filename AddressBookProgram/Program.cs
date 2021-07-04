using System;

namespace AddressBookProgram
{
    class Program
    {
        /// <summary>
        /// Welcome to Address Book Management System
        /// UC1-Creation of new contact
        //  UC2 Adding new contact
        /// </summary>
        /// <param name="args">The arguments.</param>
      
            static void Main(string[] args)
            {
                Console.WriteLine("Welcome to Address book");
                //calling operation management class that contains operation
                OperationManagement.ReadInput();
                Console.Read();
            }
        }
    }

