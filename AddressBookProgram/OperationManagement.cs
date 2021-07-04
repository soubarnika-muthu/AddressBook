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
            addressBookCompute.AddContactDetails("Jeba", "Kani", "Jeba cottage,bommi nagar", "madurai", "Tamil Nadu", 625107, 8680018236);
            addressBookCompute.AddContactDetails("jasmine", "Rita", "K.K.Nagar", "chennai", "Tamil Nadu", 600008, 9487812639);
            addressBookCompute.DisplayContact();
        }
    }
}