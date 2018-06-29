using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace personelKayit_dosyaOkuma_
{
    public partial class Form1 : Form
    {
        BindingList<Person> personList = new BindingList<Person>();
        const string csvExtension = "Csv File|*.csv";
        const string xmlExtension = "XML files|*.xml";
        const string jsonExtension = "Json files|*.json";
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
            AddPerson add = new AddPerson();
            add.Addperson(personList);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditPerson edit = new EditPerson();
            edit.Editperson(personList,dgwListe);
        }

        private void btnRmv_Click(object sender, EventArgs e)
        {
            RemovePerson remove = new RemovePerson();
            remove.PersonRemove(dgwListe, personList);     
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            LoadAndSave loadAndSave = new LoadAndSave();
            if (cmbType.Text == FileType.Csv.ToString())         
            {
                SaveCsv saveCsv = new SaveCsv();
                loadAndSave.LoadSaveMethod(sfdSave, csvExtension, saveCsv.SaveFileCsv, personList);
            }
            else if (cmbType.Text == FileType.Xml.ToString())
            {
                SaveXml saveXml = new SaveXml();
                loadAndSave.LoadSaveMethod(sfdSave, xmlExtension, saveXml.SaveFileXml, personList);
            }
            else if (cmbType.Text==FileType.Json.ToString())
            {
                SaveJson saveJson = new SaveJson();
                loadAndSave.LoadSaveMethod(sfdSave, jsonExtension, saveJson.SaveFileJson, personList);
            }
            else
                MessageBox.Show("Select type");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            personList.Clear();
            LoadAndSave loadAndSave = new LoadAndSave();

            if (cmbType.Text == FileType.Csv.ToString())
            {
                LoadCsv loadCsv = new LoadCsv();
                loadAndSave.LoadSaveMethod(ofdLoad, csvExtension, loadCsv.LoadFileCsv, personList);
            }
            else if (cmbType.Text == FileType.Xml.ToString())
            {
                LoadXml loadXml = new LoadXml();
                loadAndSave.LoadSaveMethod(ofdLoad, xmlExtension, loadXml.LoadFileXml, personList);
            }
            else if (cmbType.Text == FileType.Json.ToString())
            {
                LoadJson loadJson = new LoadJson();
                loadAndSave.LoadSaveMethod(ofdLoad,jsonExtension ,loadJson.LoadFileJson, personList);
            }
            else
                MessageBox.Show("Select type");
        }

    }
}
 