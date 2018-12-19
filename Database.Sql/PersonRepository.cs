using System.Collections.Generic;
using System.Linq;
using PersonLibrary;
namespace personelKayit_dosyaOkuma_.Database
{
    public class PersonRepository : IPersonRepository
    {
        PersonContext context = new PersonContext();

        public Person Add(Person person)
        {
            context.Persons.Add(person);
            context.SaveChanges();
            return person;
        }

        public Person Update(Person person)
        {
            var personUpdate = context.Persons.Where(q => q.Id == person.Id).FirstOrDefault();
            context.SaveChanges();
            return person;
        }
        public string Delete(string personId)
        {
            var personDelete = context.Persons.Where(w => w.Id == personId).FirstOrDefault();
            context.Persons.Remove(personDelete);
            context.SaveChanges();
            return personId;
        }

       public IList<Person> GetAll()
        {
            return context.Persons.ToList();
        }

        public IList<Person> Search(string searchedPerson)
        {
            var _query2 = from p in context.Persons
                         where p.Id == ("33")
                         select new
                         { p.Id, p.Name };
            var _query = from p in context.Persons where p.Name.StartsWith(searchedPerson) select p;

            return _query.ToList();
            
        }
        public IList<string> GetNameSearch(string searchedPerson)
        {
            var _query = from p in context.Persons where p.Name.StartsWith(searchedPerson) select p.Name;

            return _query.ToList();
        }
        public List<Person> GetIdNameSearch(string searchedPerson)
        {
            var _query = from p in context.Persons
                         where p.Name.StartsWith(searchedPerson)
                         select new 
                         {
                             p.Id,
                             personName = p.Name
                         };

            var results = _query.ToList();

            return results.ConvertAll<Person>((a) => new Person() { Id = a.Id, Name = a.personName });
            
        }
    }
}
