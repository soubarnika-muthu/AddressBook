using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AddressBookProgram
{

    class CSVFileOperation : IFileOperationWrite, IReadOperation
    {
        public void WriteData(Dictionary<string, List<ContactDetails>> contactList, string fileName)
        {
            //create stream writer stream and pass the csv file path
            using (StreamWriter writer = new StreamWriter(fileName))
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
        public Dictionary<string, List<ContactDetails>> ReadData(string fileName)
        {
            //read all the file from the list
            string[] record = File.ReadAllLines(fileName);
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
                    list.Add(new ContactDetails { firstName = fields[1], lastName = fields[2], address = fields[3], city = fields[4], state = fields[5], zipCode = fields[6], phoneNumber = fields[7] });
                }
                //else store in the existing list
                else
                {
                    list = new List<ContactDetails>();
                    list.Add(new ContactDetails { firstName = fields[1], lastName = fields[2], address = fields[3], city = fields[4], state = fields[5], zipCode = fields[6], phoneNumber = fields[7] });
                    contactList.Add(fields[0], list);
                }
            }
            return contactList;
        }
    }
}
