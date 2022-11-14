using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace MyClassesTests
{
    [TestClass]
    public class StringAssertClassTest
    {
        [TestMethod]
        public void ContainsTest()
        {
            string str1 = "RafaelaPeres";
            string str2 = "Peres";

            StringAssert.Contains(str1, str2);
        }

        [TestMethod]
        public void StartsWithTest()
        {
            string str1 = "Todos Caixa Alta";
            string str2 = "Todos";

            StringAssert.StartsWith(str1, str2);
        }

        [TestMethod]
        public void IsAllLowerCase()
        {
            Regex reg = new Regex(@"^([^A-Z])+$");

            StringAssert.Matches("todos caixa", reg);
        }

        [TestMethod]
        public void IsNotAllLowerCase()
        {
            Regex reg = new Regex(@"^([^A-Z])+$");

            StringAssert.DoesNotMatch("Todos caixa", reg);
        }
    }
}
