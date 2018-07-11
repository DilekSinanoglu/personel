using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using personelKayit_dosyaOkuma_.Services;
using PersonLibrary;

namespace personelKayit_dosyaOkuma_
{
    public partial class Form1 : Form
    {
        IPersonExporterFactory exporterFactory;
        BindingList<Person> personList = new BindingList<Person>();
        IPersonService service = new PersonService();

        public Form1(IPersonExporterFactory exporterFactory)
        {
            InitializeComponent();
            dgwListe.AutoGenerateColumns = false;
            SetAllDataGrid();
            this.exporterFactory = exporterFactory;
            fillComboboxItems();
        }

        private void SetAllDataGrid()
        {
            IList<Person> people = service.GetAll();
            for (int i = 0; i < people.Count; i++)
            {
                personList.Add(people[i]);
            }       
            dgwListe.DataSource = personList;
        }

        private void fillComboboxItems()
        {
            cmbType.Items.AddRange(exporterFactory.GetAvailableTypes());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Person person = new Person();

            frmAdd frmAdd = new frmAdd(person);
            if (frmAdd.ShowDialog(this) == DialogResult.OK)
            {
                personList.Add(person);
                service.Add(person);
                MessageBox.Show("New person addedd.");
            }
            frmAdd.Dispose();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            Person person;
            if (dgwListe.SelectedRows.Count > 0)
            {
                person = personList[dgwListe.SelectedRows[0].Index];
                frmAdd frmAdd = new frmAdd(person);
                if (frmAdd.ShowDialog(this) == DialogResult.OK)
                {
                    service.Update(person);
                    MessageBox.Show("İnformation updated");
                }
                frmAdd.Dispose();
            }
            else
                MessageBox.Show("Select the person you want to edit!");


        }

        private void btnRmv_Click(object sender, EventArgs e)
        {
            Person person;
            if (dgwListe.SelectedRows.Count > 0)
            {
                DialogResult option = MessageBox.Show("Do you want remove?", " Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (option == DialogResult.Yes)
                {
                    person = personList[dgwListe.SelectedRows[0].Index];
                    personList.Remove(person);
                    service.Delete(person.Id);
                    MessageBox.Show("Person removed.");
                }
            }
            else
                MessageBox.Show("Please select the person to be removed.");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbType.Text != null)
            {
                IPersonExporter personExporter = exporterFactory.CreateExporter(cmbType.Text);
                string filePath = loadSaveMethod(sfdSave, personExporter);

                if (filePath != null)
                {
                    personExporter.SaveToFile(personList, filePath);
                    MessageBox.Show("Save Successful");
                }
            }
            else
                MessageBox.Show("Select type");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (cmbType.Text != null)
            {
                IPersonExporter personExporter = exporterFactory.CreateExporter(cmbType.Text);
                string filePath = loadSaveMethod(ofdLoad, personExporter);
                if (filePath != null)
                {
                    personList.Clear();
                    BindingList<Person> loadedList = personExporter.LoadFromFile(filePath);
                    for (int i = 0; i < loadedList.Count; i++)
                    {
                        personList.Add(loadedList[i]);
                    }
                    MessageBox.Show("Successful");
                }
            }
            else
                MessageBox.Show("Select type");
        }

        private string loadSaveMethod(FileDialog fileDialog, IPersonExporter personExporter)
        {
            string filter = personExporter.FormatName + "|*" + personExporter.FileExtension;
            fileDialog.Filter = filter;
            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return fileDialog.FileName;
            }
            return null;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            personList.Clear();        
            IList<Person> searchList = service.Search(txtSearch.Text);
            for (int i = 0; i < searchList.Count; i++)
            {
                Person person = new Person();
                person = searchList[i];
                personList.Add(person);
            }
        }
    }
}