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
            string expected = "MittalLakshya";
            string actual = name.getReversedName();

            Assert.AreEqual(expected, actual, "Name not reversed corretcly");
        }

        [TestMethod]
        public void Name_check()
        {
            string expected = "Lakshya Mittal";
            string actual = name.getName();

            Assert.AreEqual(expected, actual, "Name not stored correctly");
        }

        [TestMethod]
        public void compare_to_check()
        {
            AlternateName name2 = new AlternateName("Anil Aggarwal");
            int expected = 1;
            int actual = name.CompareTo(name2);

            Assert.AreEqual(expected, actual, "Not compared correctly");
        }
    }
}
