using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace personelKayit_dosyaOkuma_
{
    class LoadXml
    {
        XmlSerializer xmlSerializer;
        StreamReader streamReader;
        BindingList<Person> loadedList;

        public void LoadFileXml(BindingList<Person> personList, FileDialog fileDialog)
        {
            xmlSerializer = new XmlSerializer(typeof(BindingList<Person>));
            streamReader = new StreamReader(fileDialog.FileName);
            loadedList = (BindingList<Person>)xmlSerializer.Deserialize(streamReader);
            for (int i = 0; i < loadedList.Count; i++)
            {
                personList.Add(loadedList[i]);

            }
            streamReader.Close();
        }
    }
}
