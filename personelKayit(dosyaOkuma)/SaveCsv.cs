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
    class SaveCsv
    {
        public void SaveFileCsv(BindingList<Person> personList, FileDialog fileDialog)
        {
            StreamWriter streamWriter = new StreamWriter(fileDialog.FileName);
            for (int i = 0; i < personList.Count; i++)
            {
                Person _person = personList[i];
                string personKnowledge = _person.Id + ";" + _person.Name + ";" + _person.SName + ";" + _person.Date;
                streamWriter.WriteLine(personKnowledge);
            }
            streamWriter.Flush();
            streamWriter.Close();
        }
    }
}
