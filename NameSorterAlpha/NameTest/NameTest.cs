using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NameSorter;

namespace NameTest
{
    [TestClass]
    public class NameTest
    {
        AlternateName name = new AlternateName("Lakshya Mittal");
        [TestMethod]
        public void Reversed_name_check()
        {
            string expected = "Mittal Lakshya";
            string actual = name.getReversedName();

            Assert.AreEqual(expected, actual, "Name not reversed corretcly");
        }
    }
}
