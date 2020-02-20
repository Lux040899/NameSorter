using Microsoft.VisualStudio.TestTools.UnitTesting;
using NameSorter;
using System.Globalization;
using System;

namespace NameTest
{
    [TestClass]
    public class PersonTest
    {
        Person person = new Person("Lakshya Mittal 04-08-99");
        [TestMethod]
        public void Last_Name_check()
        {
            string expected = "Mittal";
            string actual = person.LastName; 

            Assert.AreEqual(expected, actual, "Name not reversed corretcly");
        }

        [TestMethod]
        public void Given_Name_check()
        {
            string expected = "Lakshya";
            string actual = person.GivenNames;

            Assert.AreEqual(expected, actual, "Name not stored correctly");
        }

        [TestMethod]
        public void DOB_check()
        {
            DateTime date;
            DateTime.TryParseExact("04-08-99", "dd-MM-yy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                out date);

            Assert.AreEqual(person._dateOfBirth, date, "Not compared correctly");
        }
    }
}
