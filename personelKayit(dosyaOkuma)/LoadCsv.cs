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
    class LoadCsv
    {
        StreamReader streamReader;


        public void loadFileCsv(BindingList<Person> personList, FileDialog fileDialog)
        {
            streamReader = new StreamReader(fileDialog.FileName);
            string readLine;
            readLine = streamReader.ReadLine();
            while (readLine != null)
            {
                string[] array = readLine.Split(';');
                Person person = new Person();
                person.Id = array[0];
                person.Name = array[1];
                person.SName = array[2];
                person.Date = DateTime.Parse(array[3]);
                personList.Add(person);
                readLine = streamReader.ReadLine();
            }
            streamReader.Close();
        }
       
    }
}
