using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
    class OperationManagement
    {
        public static void ReadInput()
        {

            AddressBookCompute addressBookCompute = new AddressBookCompute();
            ////create object for the class address compute and call the set contact detail method
            addressBookCompute.AddContactDetails("sou", "muthu", "Anna nagar", "madurai", "Tamil Nadu", 625107, 9964747576);
            addressBookCompute.AddContactDetails("gemini", "muthu", "K.K.Nagar", "chennai", "Tamil Nadu", 600008, 9487812639);
            addressBookCompute.DisplayContact();
        }
    }
}