using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
    class JSONFileOperation : IFileOperationWrite, IReadOperation
    {

        public Dictionary<string, List<ContactDetails>> ReadData(string fileName)
        {
            Dictionary<string, List<ContactDetails>> details = JsonConvert.DeserializeObject<Dictionary<string, List<ContactDetails>>>(File.ReadAllText(fileName));
            return details;
        }

        public void WriteData(Dictionary<string, List<ContactDetails>> contactList, string jsonFile)
        {
            File.WriteAllText(jsonFile, JsonConvert.SerializeObject(contactList));
        }
    }
}