using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses.PersonClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassesTests
{
    [TestClass]
    public class CollectionAssert
    {
        [TestMethod]
        public void AreCollectionEqualFailsBecauseNoComparerTest()
        {
            PersonManager manager= new PersonManager();
            List<PersonClass> peoplExpected= new List<PersonClass>();
            List<PersonClass> peoplActual= new List<PersonClass>();

            peoplExpected.Add(new PersonClass() { FirstName = "Rafaela" });
            peoplExpected.Add(new PersonClass() { FirstName = "Isabela" });
            peoplExpected.Add(new PersonClass() { FirstName = "Eva" });

            peoplActual = manager.GetPeople();

            CollectionAssert.Equals(peoplExpected, peoplActual, Comparer<PersonClass>.Create((x, y) =>
            x.FirstName == y.FirstName ? 0 : 1));

        }

        [TestMethod]
        public void AreCollectionAreEquivalentTest()
        {
            PersonManager manager = new PersonManager();
            List<PersonClass> peoplExpected = new List<PersonClass>();
            List<PersonClass> peoplActual = new List<PersonClass>();

            peoplActual = manager.GetPeople();

            peoplExpected.Add(peoplActual[1]);
            peoplExpected.Add(peoplActual[2]);
            peoplExpected.Add(peoplActual[0]);


            CollectionAssert.AreEquivalent(peoplExpected, peoplActual, Comparer<PersonClass>.Create((x, y) =>
            x.FirstName == y.FirstName ? 0 : 1));

        }

        [TestMethod]
        public void isCollectionOFTypeTest()
        {
            PersonManager manager = new PersonManager();
            List<PersonClass> peoplExpected = new List<PersonClass>();
            List<PersonClass> peoplActual = new List<PersonClass>();

            peoplActual = manager.GetSupervisors();

            CollectionAssert.AllItemsAreInstancesOfType(peoplActual, typeof(Supervisor));

        }
    }
}
