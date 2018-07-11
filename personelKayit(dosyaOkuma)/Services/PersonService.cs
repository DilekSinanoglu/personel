using System.Collections.Generic;
using personelKayit_dosyaOkuma_.Database;
using PersonLibrary;

namespace personelKayit_dosyaOkuma_.Services
{
    class PersonService: IPersonService
    {
        IPersonRepository personRepository = new PersonRepository();

        public Person Add(Person person)
        {
            return personRepository.Add(person);
        }

        public Person Update(Person person)
        {   
            return personRepository.Update(person); ;
        }

        public string Delete(string personId)
        {
            return personRepository.Delete(personId);
        }

        public IList<Person> GetAll()
        {    
            return personRepository.GetAll();
        }

        public IList<Person> Search(string searchedPerson)
        {
            return personRepository.Search(searchedPerson);
        }
        public IList<string> GetNameSearch(string searchedPerson)
        {
            return personRepository.GetNameSearch(searchedPerson);
        }


    }
}
