using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace personelKayit_dosyaOkuma_
{
    class RemovePerson
    {
        Person person;
        DialogResult option;

        public void PersonRemove(DataGridView dataGridView, BindingList<Person> personList)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                option = MessageBox.Show("Do you want remove?", " Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (option == DialogResult.Yes)
                {
                    person = personList[dataGridView.SelectedRows[0].Index];
                    personList.Remove(person);
                    MessageBox.Show("Person removed.");
                }
            }
            else
                MessageBox.Show("Please select the person to be removed.");
        }
    }
}
