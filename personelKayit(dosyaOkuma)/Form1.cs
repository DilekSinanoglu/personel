using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace personelKayit_dosyaOkuma_
{
    public partial class Form1 : Form
    {
        BindingList<Person> personList = new BindingList<Person>();

        public Form1()
        {
            InitializeComponent();
            dgwListe.AutoGenerateColumns = false;
            dgwListe.DataSource = personList;
            fillComboboxItems();
        }

        private void fillComboboxItems()
        {
            cmbType.Items.AddRange(Enum.GetNames(typeof(FileType)));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Person person = new Person();
            frmAdd frmAdd = new frmAdd(person);
            if (frmAdd.ShowDialog(this) == DialogResult.OK)
            {
                personList.Add(person);
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
                    MessageBox.Show("İnformation updated");
                }
                frmAdd.Dispose();
            }
            else
                MessageBox.Show("Select the person you want to edit");
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
                    MessageBox.Show("Person removed.");
                }
            }
            else
                MessageBox.Show("Please select the person to be removed.");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((FileType)cmbType.SelectedIndex == FileType.Csv)
            {
                saveCsv();
            }
            else if ((FileType)cmbType.SelectedIndex == FileType.Xml)
            {
                saveXml();
            }
            else if ((FileType)cmbType.SelectedIndex == FileType.Json)
            {
                saveJson();           
            }
            else
                MessageBox.Show("Select type");
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            personList.Clear();

            if ((FileType)cmbType.SelectedIndex == FileType.Csv)
            {
                loadCsv();
            }
            else if ((FileType)cmbType.SelectedIndex == FileType.Xml)
            {
                loadXml();

            }
            else if ((FileType)cmbType.SelectedIndex == FileType.Json)
            {
                loadJson();
            }
            else
                MessageBox.Show("Select type");
        }

        private string loadSaveMethod(FileDialog fileType, string filter)
        {
            fileType.Filter = filter;
            if (fileType.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return fileType.FileName;
            }
            return null;
        }

        private void saveXml()
        {
            XmlExporter xmlExporter = new XmlExporter();
            string filter = xmlExporter.FormatName + "|*" + xmlExporter.FileExtension;
            string filePath = loadSaveMethod(sfdSave, filter);
            if (filePath != null)
            {
                xmlExporter.SaveToFile(personList, filePath);
            }
        }


        private void loadXml()
        {
            XmlExporter xmlExporter = new XmlExporter();
            string filter = xmlExporter.FormatName + "|*" + xmlExporter.FileExtension;
            string filePath = loadSaveMethod(ofdLoad, filter);
            if (filePath != null)
            {
                BindingList<Person> loadedList = xmlExporter.LoadFromFile(filePath);
                for (int i = 0; i < loadedList.Count; i++)
                {
                    personList.Add(loadedList[i]);
                }
            }
        }

        private void saveJson()
        {
            JsonExporter jsonExporter = new JsonExporter();
            string filter = jsonExporter.FormatName + "|*" + jsonExporter.FileExtension;
            string filePath = loadSaveMethod(sfdSave, filter);
            if (filePath != null)
            {
                jsonExporter.SaveToFile(personList, filePath);
            }
        }

        private void loadJson()
        {
            JsonExporter jsonExporter = new JsonExporter();
            string filter = jsonExporter.FormatName + "|*" + jsonExporter.FileExtension;
            string filePath = loadSaveMethod(ofdLoad, filter);
            if (filePath != null)
            {
                BindingList<Person> loadedList = jsonExporter.LoadFromFile(filePath);
                for (int i = 0; i < loadedList.Count; i++)
                {
                    personList.Add(loadedList[i]);
                }
            }
        }

        private void saveCsv()
        {
            CsvExporter csvExporter = new CsvExporter();
            string filter = csvExporter.FormatName + "|*" + csvExporter.FileExtension;
            string filePath = loadSaveMethod(sfdSave, filter);
            if (filePath != null)
            {
                csvExporter.SaveToFile(personList, filePath);
            }
        }

        private void loadCsv()
        {
            CsvExporter csvExporter = new CsvExporter();
            string filter = csvExporter.FormatName + "|*" + csvExporter.FileExtension;
            string filePath = loadSaveMethod(ofdLoad, filter);
            if (filePath != null)
            {
                BindingList<Person> loadedList = csvExporter.LoadFromFile(filePath);
                for (int i = 0; i < loadedList.Count; i++)
                {
                    personList.Add(loadedList[i]);
                }
            }
        }
    }
}