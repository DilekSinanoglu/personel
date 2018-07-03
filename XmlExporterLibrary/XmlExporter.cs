using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;
using PersonLibrary;

namespace personelKayit_dosyaOkuma_
{
    public class XmlExporter : IPersonExporter
    {
        string formatName = "XML";
        string fileExtension = ".xml";
        public string FormatName
        {
            get { return formatName; }
        }
        public string FileExtension
        {
            get { return fileExtension; }
        }
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(BindingList<Person>));

        public void SaveToFile(BindingList<Person> personList, string filePath)
        {
            StreamWriter streamWriter = new StreamWriter(filePath);
            xmlSerializer.Serialize(streamWriter, personList);
            streamWriter.Flush();
            streamWriter.Close();
        }
        public BindingList<Person> LoadFromFile(string filePath)
        {
            StreamReader streamReader = new StreamReader(filePath);
            BindingList<Person> loadedList = (BindingList<Person>)xmlSerializer.Deserialize(streamReader);
            streamReader.Close();
            return loadedList;
        }
    }
}
