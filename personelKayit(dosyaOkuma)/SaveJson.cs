using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace personelKayit_dosyaOkuma_
{
    class SaveJson
    { 
        string convert;

        public void saveFileJson(BindingList<Person> personList, FileDialog saveFileDialog)
        {
            convert = JsonConvert.SerializeObject(personList);
            File.WriteAllText(saveFileDialog.FileName, convert);
        }
    }
}
