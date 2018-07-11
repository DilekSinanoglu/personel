using System.Collections.Generic;
using PersonLibrary;

namespace personelKayit_dosyaOkuma_.Database
{
    public interface IPersonRepository
    {
        Person Add(Person person);
        Person Update(Person person);
        string Delete(string personId);
        IList<Person> GetAll();
        IList<Person> Search(string searchedPerson);
        IList<string> GetNameSearch(string searchedPerson);
    }
}