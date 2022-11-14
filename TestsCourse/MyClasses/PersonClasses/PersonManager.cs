using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClasses.PersonClasses
{
    public class PersonManager
    {
        public PersonClass CreatePersonClass(string first, string last, bool isSupervisor)
        {
            PersonClass ret = null;
            if(first != null)
            {
                if (isSupervisor)
                {
                    ret = new Supervisor();
                }
                else
                {
                    ret = new Employee();
                }
                ret.FirstName = first;
                ret.LastName = last;
            }
            return ret;
        }

        public List<PersonClass> GetPeople()
        {
            List<PersonClass> people = new List<PersonClass>();

            people.Add(new PersonClass() { FirstName = "Rafaela" });
            people.Add(new PersonClass() { FirstName = "Isabela" });
            people.Add(new PersonClass() { FirstName = "Eva" });

            return people;
        }

        public List<PersonClass> GetSupervisors()
        {
            List<PersonClass> people = new List<PersonClass>();

            people.Add(CreatePersonClass( "Rafaela", "Peres", true));
            people.Add(CreatePersonClass( "Isabela", "Peres", true));

            return people;
        }
    }
}
