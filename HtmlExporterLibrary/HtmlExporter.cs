using personelKayit_dosyaOkuma_;
using PersonLibrary;
using System.ComponentModel;
using System.IO;
using System.Net;

namespace HtmlExporterLibrary
{
    public class HtmlExporter : IPersonExporter
    {
        string formatName = "HTML";
        string fileExtension = ".html";
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
            streamWriter.WriteLine("<html>");
            streamWriter.WriteLine("<body>");
            for (int i = 0; i < personList.Count; i++)
            {
                Person _person = personList[i];
                streamWriter.WriteLine("<p>");
                streamWriter.WriteLine("<b>Id:</b>" + _person.Id + "<br/>");
                streamWriter.WriteLine("<b>Name:</b>" + _person.Name + "<br/>");
                streamWriter.WriteLine("<b>Surname:</b>" + _person.SName + "<br/>");
                streamWriter.WriteLine("<b>Date:</b>" + _person.Date + "<br/>");
                streamWriter.WriteLine("</p>");
            }
            streamWriter.WriteLine("</body>");
            streamWriter.WriteLine("</html>");
        }

        public BindingList<Person> LoadFromFile(string filePath)
        {
            StreamReader streamReader = new StreamReader(filePath);
            string readLine;
            string[] unwantedArray = new string[] { "<html>","<body>","<p>", "</html>", "</body>", "</p>" };
            string[] array = null;
            BindingList<Person> loadedList = new BindingList<Person>();

            readLine = streamReader.ReadLine();
            while (readLine != null)
            {
                array = readLine.Split(' ');

                //    if (readLine == "<b>%")
                //    {
                //        Person person = new Person();
                //        person.Id = array[0];
                //        loadedList.Add(person);
                //    }

                //    //Person person = new Person();
                //    //person.Id = array[1];
                //    //loadedList.Add(person);
                readLine = streamReader.ReadLine();
                for (int i = 0; i < unwantedArray.Length; i++)
                {
                    if (array[0] != unwantedArray[i])
                    {
                        
                        Person person = new Person();
                        person.Id = array[0];
                        loadedList.Add(person);
                    }

                }
            }

            streamReader.Close();
            return loadedList;
        }
    }
}