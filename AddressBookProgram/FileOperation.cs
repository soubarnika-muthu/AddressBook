using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AddressBookProgram
{
    class FileOperation
    {
        string filepath = @"C:\Users\hp\source\repos\AddressBookProgram\AddressBookProgram\AddressBook.txt";
       

        //method to write the data into the file
        public void WriteIntoFile(Dictionary<string, List<ContactDetails>> addressDictionary)
        {
            if (File.Exists(filepath))
            {
                //using streamWriter write the data into the file 
                StreamWriter writer = new StreamWriter(filepath);
                foreach (var dickey in addressDictionary)
                {
                    //write line method append next dat in the next line
                    writer.WriteLine("AddressBook Name:" + dickey.Key);
                    foreach (var list in dickey.Value)
                    {
                        string s = "Name:" + list.firstName + " " + list.lastName + " Address:" + list.address + " City:" + list.city + " State:" + list.state + " Zipcode:" + list.zipCode + " Ph.No:" + list.phoneNumber;
                        writer.WriteLine(s);
                    }
                    writer.WriteLine();
                }
                //close the stream
                writer.Close();
                ReadFromFile(filepath);
            }
            else
            {
                Console.WriteLine("File not exists");
            }

        }
        //method to read the data from the file 
        public void ReadFromFile(string filePath)
        {
            //check if the file exists
            if (File.Exists(filePath))
            {
                //get all the data in single text and print the data
                string text = File.ReadAllText(filePath);
                Console.WriteLine(text);
            }
            else
            {
                Console.WriteLine("File not exist");
            }
        }
    }
}
