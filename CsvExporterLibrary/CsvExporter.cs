using System;
using System.ComponentModel;
using System.IO;
using PersonLibrary;


namespace personelKayit_dosyaOkuma_
{
    public class CsvExporter : IPersonExporter
    {
        string formatName = "CSV";
        string fileExtension = ".csv";
        public string FormatName
        {
            get { return formatName; }
        }
        public string FileExtension
        {
            get { return fileExtension; }
        }

        public void SaveToFile(BindingList<Person> personList, string filePath)
        {
            StreamWriter streamWriter = new StreamWriter(filePath);
            for (int i = 0; i < personList.Count; i++)
            {
                Person _person = personList[i];
                string personKnowledge = _person.Id + ";" + _person.Name + ";" + _person.SName + ";" + _person.Date;
                streamWriter.WriteLine(personKnowledge);
            }
            streamWriter.Flush();
            streamWriter.Close();
        }

        public BindingList<Person> LoadFromFile(string filePath)
        {
            StreamReader streamReader = new StreamReader(filePath);
            string readLine;
            BindingList<Person> loadedList = new BindingList<Person>();
            readLine = streamReader.ReadLine();
            while (readLine != null)
            {
                string[] array = readLine.Split(';');
                Person person = new Person();
                person.Id = array[0];
                person.Name = array[1];
                person.SName = array[2];
                person.Date = DateTime.Parse(array[3]);
                loadedList.Add(person);
                readLine = streamReader.ReadLine();
            }
            streamReader.Close();
            return loadedList;
        }
    }
}