using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace personelKayit_dosyaOkuma_
{
    class AddPerson
    {
        Person person;
        frmAdd frmAdd;

        public void addPerson(BindingList<Person> personList)
        {
            person = new Person();
            frmAdd = new frmAdd(person);
            if (frmAdd.ShowDialog() == DialogResult.OK)
            {
                personList.Add(person);
                MessageBox.Show("New person addedd.");
            }
            frmAdd.Dispose();
        }
    }
}
