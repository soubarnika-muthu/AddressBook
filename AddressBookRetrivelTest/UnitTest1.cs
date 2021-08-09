using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBookProgram;
using System.Collections.Generic;
using System;

namespace AddressBookRetrivelTest
{
    [TestClass]
    public class AddressBookTest
    {
        OperationManagement operation;
        [TestInitialize]
        public void TestSetUp()
        {
            operation = new OperationManagement();
        }
        //UC16-Retrive all data from database
        [TestMethod]
        public void RetrivingtheDataFromDataBaseTest()
        {
            int expected = 4;
            List<ContactDetails> list = operation.RetrivingDataFromDataBase();
            Assert.AreEqual(expected, list.Count);
        }

        //UC17-Update contact data from database
        [TestMethod]
        public void UpdateDataTest()
        {
            int expected = 1;
            int actual = operation.updateContact(2, "Shanthi", 9845625362);
            Assert.AreEqual(expected, actual);
        }
        //UC18-Retrival based on date range
        [TestMethod]
        public void DateRangeRetrivalTest()
        {
            int expected = 2;
            DateTime startDate = new DateTime(2017, 01, 01);
            DateTime enddate = new DateTime(2019, 01, 01);
            List<ContactDetails> actual = operation.RetrivingDataBasedOnDate(startDate, enddate);
            Assert.AreEqual(expected, actual.Count);
        }

        //UC19-Retrive the data based on city or state
        [TestMethod]
        public void StateCityRetrivalTest()
        {
            int expected = 4;
            List<ContactDetails> actual = operation.RetrivingDataBasedOnStateCity("Tamil Nadu", "chennai");
            Assert.AreEqual(expected, actual.Count);
        }

        //UC20-Adding data to the address book
        [TestMethod]
        public void InsertIntoAddressBookTest()
        {
            int expected = 0;
            ContactDetails contactDetails = new ContactDetails { personId = 10, firstName = "marcus", lastName = "josh", address = "mgm road", city = "madurai", state = "Tamil Nadu", zipCode = "856423", phoneNumber = "9856234561", emailAddress = "marcys@gmail.com", typeId = 2, addressBookId = 1, addedDate = "2020-06-30" };
            int actual = operation.AddDetailsToAddressBook(contactDetails);
            Assert.AreEqual(expected, actual);
        }
        //UC21-ADDing multiple records
        [TestMethod]
        public void AddingMultipleDataToAddressBook()
        {
            int expected = 0;
            List<ContactDetails> contactList = new List<ContactDetails> { new ContactDetails { personId = 14, firstName = "marcus1", lastName = "josh", address = "mgm road", city = "madurai", state = "Tamil Nadu", zipCode = "856423", phoneNumber = "9856234561", emailAddress = "marcys@gmail.com", typeId = 2, addressBookId = 1, addedDate = "2020-06-30" } ,
                                                                         new ContactDetails { personId =12, firstName = "marcus2", lastName = "josh", address = "mgm road", city = "madurai", state = "Tamil Nadu", zipCode = "856423", phoneNumber = "9856234561", emailAddress = "marcys@gmail.com", typeId = 2, addressBookId = 1, addedDate = "2020-06-30" },
                                                                         new ContactDetails { personId =13, firstName = "marcus3", lastName = "josh", address = "mgm road", city = "madurai", state = "Tamil Nadu", zipCode = "856423", phoneNumber = "9856234561", emailAddress = "marcys@gmail.com", typeId = 2, addressBookId = 1, addedDate = "2020-06-30" }};
            contactList = operation.AddMultiplecontactToDataBase(contactList);
            Assert.AreEqual(expected, contactList);
        }

        //UC22-retriving data from json server
        [TestMethod]
        public void OnCallingGetAPI_ReturnsContacts()
        {
            List<ContactDetails> actual = new AddressBookJsonServer().ReadFromServer();
            Assert.AreEqual(1, actual.Count);
        }

        //Adding data to json server
        [TestMethod]
        public void OnCallingPOSTAPI_AddMethodToServer()
        {
            List<ContactDetails> contactDetails = new List<ContactDetails> { new ContactDetails { personId = 12, firstName = "marcus", lastName = "josh", address = "mgm road", city = "madurai", state = "Tamil Nadu", zipCode = "856423", phoneNumber = "9856234561", emailAddress = "marcys@gmail.com", typeId = 2, addressBookId = 1, addedDate = "2020-06-30" } };
            new AddressBookJsonServer().AddingMultipleContactToServer(contactDetails);

        }

        //UC24-Updating the record in json server
        [TestMethod]
        public void OnCallingPutAPI_UpdatePhoneNumber()
        {
            int expected = 1;
            ContactDetails contact = new ContactDetails { personId = 2, firstName = "Jessi", lastName = "Arul", address = "K.K.Nagar", city = "Chennai", state = "Tamil Nadu", zipCode = "600007", phoneNumber = "8642536784", emailAddress = "jessiA@gmail.com", typeId = 2, addressBookId = 1, addedDate = "2020-06-30" };
            int actual = new AddressBookJsonServer().UpdateValueInJsonServer(contact);
            Assert.AreEqual(expected, actual);
        }
        //UC25- delete record from the json server
        [TestMethod]
        public void OnCallingDeleteAPI_DeletetheRecord()
        {
            bool expected = true;
            bool actual = new AddressBookJsonServer().DeleteData(2);
            Assert.AreEqual(expected, actual);
        }
    }
}
