using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
    interface IFileOperationWrite
    {
        void WriteData(Dictionary<string, List<ContactDetails>> addressDictionary, string fileName);
    }
    interface IFileOperationRead
    {
        void ReadData(string filePath);
    }
    interface IReadOperation
    {
        Dictionary<string, List<ContactDetails>> ReadData(string fileName);
    }
    interface DatabaseReadWrite
    {
        int WriteIntoDataBase(ContactDetails details);
        List<ContactDetails> ReadFromDataBase();
    }

    class TextFileOperation : IFileOperationWrite, IFileOperationRead
    {

        //method to write the data into the file
        public void WriteData(Dictionary<string, List<ContactDetails>> addressDictionary, string filePath)
        {
            if (File.Exists(filePath))
            {
                //using streamWriter write the data into the file 
                StreamWriter writer = new StreamWriter(filePath);
                foreach (var l in addressDictionary)
                {
                    //write line method append next dat in the next line
                    writer.WriteLine("AddressBook Name:" + l.Key);
                    foreach (var list in l.Value)
                    {
                        string s = "Name:" + list.firstName + " " + list.lastName + " Address:" + list.address + " City:" + list.city + " State:" + list.state + " Zipcode:" + list.zipCode + " Ph.No:" + list.phoneNumber;
                        writer.WriteLine(s);
                    }
                    writer.WriteLine();
                }
                //close the stream
                writer.Close();
                ReadData(filePath);
            }
            else
            {
                Console.WriteLine("File not exists");
            }

        }
        //method to read the data from the file 
        public void ReadData(string filePath)
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