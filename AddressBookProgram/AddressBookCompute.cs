using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
    class AddressBookCompute
    {

        private LinkedList<ContactDetails> contactList;

        public AddressBookCompute()
        {
            this.contactList = new LinkedList<ContactDetails>();
        }

        //this method add details to the address book
        public void AddContactDetails(string firstName, string lastName, string address, string city, string state, long zipCode, long phoneNumber)
        {
            ContactDetails contactDetails = new ContactDetails(firstName, lastName, address, city, state, zipCode, phoneNumber);
            this.contactList.AddLast(contactDetails);
        }

        public void DisplayContact()
        {
            foreach (ContactDetails contact in this.contactList)
            {
                contact.Display();
            }
        }

    }
}
