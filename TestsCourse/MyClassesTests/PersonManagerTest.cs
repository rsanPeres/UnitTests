using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses.PersonClasses;

namespace MyClassesTests
{
    [TestClass]
    public class PersonManagerTest
    {
        [TestMethod]
        [Owner("Rafaela")]
        public void CreatePerson_OfTypeEmployee()
        {
            PersonManager mgr= new PersonManager();
            PersonClass per = mgr.CreatePersonClass("Rafaela", "Peres", false);

            Assert.IsInstanceOfType(per, typeof(Employee));
        }

        [TestMethod]
        [Owner("Rafaela")]
        public void DoEmployeeExist()
        {
            Supervisor sup= new ();

            sup.Employees = new List<Employee>();
            sup.Employees.Add(new Employee()
            {
                FirstName = "Rafaela",
                LastName = "Peres"
            });

            Assert.IsTrue(sup.Employees.Count > 0);
        }
    }
}
