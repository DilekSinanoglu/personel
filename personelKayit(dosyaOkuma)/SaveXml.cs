using Newtonsoft.Json;
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
    class SaveXml
    {
        StreamWriter streamWriter;
        XmlSerializer xmlSerializer;
      

        public void saveFileXml(BindingList<Person> personList, FileDialog saveFileDialog)
        {
            xmlSerializer= new XmlSerializer(typeof(BindingList<Person>));
            streamWriter= new StreamWriter(saveFileDialog.FileName);
            xmlSerializer.Serialize(streamWriter, personList);
            streamWriter.Flush();
            streamWriter.Close();
        }
    }
}
