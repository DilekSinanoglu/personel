using System;
using System.Windows.Forms;
using PersonLibrary;

namespace personelKayit_dosyaOkuma_
{
    public partial class frmAdd : Form
    {
        Person person;
        public frmAdd(Person person)
        {
            InitializeComponent();
            this.person = person;
            txtId.Enabled = (this.person.Id == null);      
            loadPerson();        
        }
        private void loadPerson()
        {
            txtId.Text = person.Id;
            txtName.Text = person.Name;
            txtSName.Text = person.SName;
            dtDate.MinDate = person.Date;
        }
        private void updatePerson(Person person)
        {
            person.Id = txtId.Text;
            person.Name = txtName.Text;
            person.SName = txtSName.Text;
            person.Date = dtDate.Value;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            updatePerson(person);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}