using System;

namespace AddressBookProgram
{
    class Program
    {
        static string userStringEntry;
        static int userIntEntry;

        static Contact contact1 = new Contact();

        static void Main(string[] args)
        {
            Console.WriteLine("***Address Book.****");
            MainMenu();

            Console.ReadKey();
        }


        static void MainMenu()
        {
            Console.WriteLine("Choose the option ");
            Console.WriteLine("\n1 - Add Contact.");
            Console.WriteLine("2 - Remove Contact");
            Console.WriteLine("3 - List Contacts.");
            Console.WriteLine("4 - Quit.");

            userStringEntry = Console.ReadLine();
            userIntEntry = System.Int32.Parse(userStringEntry);

            switch (userIntEntry)
            {
                case 1:
                    AddContact();
                    break;

                case 2:
                    RemoveContact();
                    break;

                case 3:
                    ListContacts();
                    break;

                case 4:
                    Environment.Exit(0);
                    break;
                case 5:
                    Console.WriteLine("Enter the first name of person to edit number:");
                    string name = Console.ReadLine();
                    Console.Write("Enter the new number:");
                    long number = Convert.ToInt64(Console.ReadLine());

                default:
                    Console.WriteLine("Invalid choice. Please enter sufficient data.");
                    break;
            }
        }

        static void AddContact()
        {
            do
            {
                Console.WriteLine("\nEnter contacts first name.");
                contact1.FirstName = Console.ReadLine();

                Console.WriteLine("Enter contacts last name.");
                contact1.LastName = Console.ReadLine();

                Console.WriteLine("Enter contacts street address.");
                contact1.StreetAddress = Console.ReadLine();

                Console.WriteLine("Enter contacts town/city.");
                contact1.TownCity = Console.ReadLine();

                Console.WriteLine("Enter the contacts state.");
                contact1.State= Console.ReadLine();

                Console.WriteLine("Enter the contacts country.");
                contact1.Country = Console.ReadLine();

                Console.WriteLine("Enter the contacts phone number.");
                userStringEntry = Console.ReadLine();
                contact1.PhoneNumber = long.Parse(userStringEntry);


                Console.WriteLine("\nIs the following information correct?");

                Console.WriteLine("\nContacts first name: " + contact1.FirstName);
                Console.WriteLine("Contacts last name: " + contact1.LastName);
                Console.WriteLine("Contacts street address: " + contact1.StreetAddress);
                Console.WriteLine("Contacts town/city: " + contact1.TownCity);
                Console.WriteLine("Contacts state: " + contact1.State);
                Console.WriteLine("ZipCode:" + contact1.Zipcode);
                Console.WriteLine("Contacts country: " + contact1.Country);
                Console.WriteLine("Contacts phone number: " + contact1.PhoneNumber);



                Console.WriteLine("\n1 - Yes. 2 - Retry.");

                userStringEntry = Console.ReadLine();
                userIntEntry = System.Int32.Parse(userStringEntry);
            }
            while (userIntEntry == 2);

            if (userIntEntry == 1)
            {
                MainMenu();
            }
        }
        static void RemoveContact()
        {
            Console.WriteLine("\n1 - Remove all contacts. 2 - Main Menu.");
            userStringEntry = Console.ReadLine();
            userIntEntry = System.Int32.Parse(userStringEntry);

            if (userIntEntry == 1)
            {
                contact1.FirstName = "";
                contact1.LastName = "";
                contact1.StreetAddress = "";
                contact1.TownCity = "";
                contact1.State = "";
                contact1.Country = "";
                contact1.PhoneNumber = 0;

                Console.WriteLine("\nAll contacts have been removed.");

                Console.WriteLine("\n1 - Main Menu");

                userStringEntry = Console.ReadLine();
                userIntEntry = System.Int32.Parse(userStringEntry);

                switch (userIntEntry)
                {
                    case 1:
                        MainMenu();
                        break;

                    default:
                        Console.WriteLine("Please enter sufficient data.");
                        break;

                }

            }
        }

        static void ListContacts()
        {
            Console.WriteLine("\n\nContact 1.");

            Console.WriteLine("\n" + contact1.FirstName + "" + contact1.LastName);
            Console.WriteLine(contact1.StreetAddress + " ");
            Console.WriteLine(contact1.TownCity + " ");
            Console.WriteLine(contact1.State+" ");
            Console.WriteLine(contact1.Country + " ");
            Console.WriteLine(contact1.PhoneNumber + "");

            Console.WriteLine("\n1 - Main Menu");

            userStringEntry = Console.ReadLine();
            userIntEntry = System.Int32.Parse(userStringEntry);

            switch (userIntEntry)
            {
                case 1:
                    MainMenu();
                    break;

                default:
                    Console.WriteLine("Please enter sufficient data.");
                    break;
            }
        }

    }

}

