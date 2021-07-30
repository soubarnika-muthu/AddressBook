using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CsvHelper;
using System.Globalization;
using Newtonsoft.Json;

namespace AddressBookProgram
{
    class FileOperation
    {
        
        string filepath = @"C:\Users\hp\source\repos\AddressBookProgram\AddressBookProgram\AddressBook.txt";
        string csvFile = @"C:\Users\hp\source\repos\AddressBookProgram\AddressBookProgram\ContactDetails.csv";
        string jsonFile = @"C:\Users\hp\source\repos\AddressBookProgram\AddressBookProgram\addressbook.json";

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
        public Dictionary<string, List<ContactDetails>> ReadFromJsonFile()
        {
            Dictionary<string, List<ContactDetails>> details = JsonConvert.DeserializeObject<Dictionary<string, List<ContactDetails>>>(File.ReadAllText(jsonFile));
            return details;
        }

        public void WriteIntoJsonFile(Dictionary<string, List<ContactDetails>> contactList)
        {
            File.WriteAllText(jsonFile, JsonConvert.SerializeObject(contactList));
            WriteIntoCSVFile(contactList);
        }

        public void WriteIntoCSVFile(Dictionary<string, List<ContactDetails>> contactList)
        {
            //create stream writer stream and pass the csv file path
            using (StreamWriter writer = new StreamWriter(csvFile))
            {
                //creating the csv writer path
                using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    //create teh feild as dictionary name
                    csvWriter.WriteField("DictionaryName");
                    //create the header that are the properties of the contact list
                    csvWriter.WriteHeader<ContactDetails>();
                    csvWriter.NextRecord();

                    foreach (var l in contactList)
                    {
                        string dic = l.Key;
                        foreach (var list in l.Value)
                        {
                            //write the list as record in the file
                            csvWriter.WriteField(dic);
                            csvWriter.WriteRecord(list);
                            csvWriter.NextRecord();
                        }
                    }
                }
            }
        }
        public Dictionary<string, List<ContactDetails>> ReadFromCSVFile()
        {
            //read all the file from the list
            string[] record = File.ReadAllLines(csvFile);
            Dictionary<string, List<ContactDetails>> contactList = new Dictionary<string, List<ContactDetails>>();
            List<ContactDetails> list;
            //to store in the dictioary skip the header
            foreach (string data in record.Skip(1))
            {
                string[] fields = data.Split(",");
                //create new list if list is not available
                if (contactList.ContainsKey(fields[0]))
                {
                    list = contactList[fields[0]];
                    list.Add(new ContactDetails(fields[1], fields[2], fields[3], fields[4], fields[5], fields[6], fields[7]));
                }
                //else store in the existing list
                else
                {
                    list = new List<ContactDetails>();
                    list.Add(new ContactDetails(fields[1], fields[2], fields[3], fields[4], fields[5], fields[6], fields[7]));
                    contactList.Add(fields[0], list);
                }
            }
            return contactList;
        }

    }
}