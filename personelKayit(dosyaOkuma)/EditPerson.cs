using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace personelKayit_dosyaOkuma_
{
    class EditPerson
    {
        Person person;

        public void editPerson(BindingList<Person> personList, DataGridView dataGrid)
        {
            
            if (dataGrid.SelectedRows.Count > 0)
            {
                person = personList[dataGrid.SelectedRows[0].Index];
                frmAdd frmAdd = new frmAdd(person);
                if (frmAdd.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("İnformation updated");
                }
                frmAdd.Dispose();
            }
            else
                MessageBox.Show("Select the person you want to edit");
        }
    }
}
