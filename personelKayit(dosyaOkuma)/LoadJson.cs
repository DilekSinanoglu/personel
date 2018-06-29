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
    class LoadJson
    {
        BindingList<Person> loadedList;
        public void LoadFileJson(BindingList<Person> personList, FileDialog fileDialog)
        {
            loadedList = JsonConvert.DeserializeObject<BindingList<Person>>(File.ReadAllText(fileDialog.FileName));
            for (int i = 0; i < loadedList.Count; i++)
            {
                personList.Add(loadedList[i]);
            }
        }

    }
}

