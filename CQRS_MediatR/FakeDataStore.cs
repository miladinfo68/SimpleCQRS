using CQRS_MediatR.Cqrs.Commands;
using CQRS_MediatR.Models;
using System.Collections.Generic;
using System.Linq;

namespace CQRS_MediatR
{
    public class FakeDataStore
    {
        private static List<Person> people = new List<Person>()
        {
            { new Person(){Id=1 , Name="milad jalali" , Age=33 } } ,
            { new Person(){Id=2 , Name="mina ahmadi" , Age=25 } } ,
            { new Person(){Id=3 , Name="reza pishvayee" , Age=31 } }
        };
   
        public int AddPerson(AddPersonCommand person)
        {
            var index = people.ToList().OrderByDescending(x => x.Id).First().Id + 1;
            people.Add(new Person { Id = index, Name = person.Name, Age = person.Age });
            return index;
        }

        public IEnumerable<Person> GetAllPeople()
        {            
            return people;
        }

        public Person GetPersonById(int id)
        {
            return people.FirstOrDefault(x => x.Id == id);
        }

       
        public Person Update(UpdatePersonCommand person)
        {
            var item = people.FirstOrDefault(a => a.Id == person.Id);
            if (item !=null)
            {
                item.Name = person.Name;
                item.Age = person.Age;
            }
            return item;
        }


        public IEnumerable<Person> DeletPersonById(int id)
        {
            return people.Where(w => w.Id != id);
        }
    }
}
