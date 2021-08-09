using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBookProgram;
using System.Collections.Generic;

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
    }
}
