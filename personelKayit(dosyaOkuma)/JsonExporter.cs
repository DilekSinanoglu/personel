using Newtonsoft.Json;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace personelKayit_dosyaOkuma_
{
    class JsonExporter : IPersonExporter
    {
        string formatName = "JSON";
        string fileExtension = ".json";
        public string FormatName
        {
            get { return formatName; }
        }
        public string FileExtension
        {
            get { return fileExtension; }
        }


        public void SaveToFile(BindingList<Person> personList,string filePath)
        {
            string convert = JsonConvert.SerializeObject(personList);
            File.WriteAllText(filePath, convert);
        }

        public BindingList<Person> LoadFromFile(string filePath)
        {
            BindingList<Person> loadedList = JsonConvert.DeserializeObject<BindingList<Person>>(File.ReadAllText(filePath));
            return loadedList;
        }

    }
}
