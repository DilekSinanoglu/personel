using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace personelKayit_dosyaOkuma_
{
    class LoadAndSave
    {
        public void loadSaveMethod(FileDialog fileDialog, string filter, Action<BindingList<Person>, FileDialog> saveLoadFile, BindingList<Person> personList)
        {
            fileDialog.Filter = filter;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                saveLoadFile(personList, fileDialog);
            }
           
        }
    }
}
