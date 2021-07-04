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
        public void EditContact(string name, long number)
        {
            //checks for every object whether the name is equal the given name
            foreach (ContactDetails contact in this.contactList)
            {
                if (contact.firstName.Equals(name))
                {
                    //calls the setdetail method
                    contact.SetDetail(number);
                }
            }
        }
        //Delete the particular object
        public void DeleteContact(string name)
        {
            foreach (ContactDetails contact in this.contactList)
            {
                if (contact.firstName.Equals(name))
                {
                    this.contactList.Remove(contact);
                    break;
                }
            }
        }


    }
}
