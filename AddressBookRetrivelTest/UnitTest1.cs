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
    }
}
