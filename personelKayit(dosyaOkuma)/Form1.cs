using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

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
            add.addPerson(personList);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditPerson edit = new EditPerson();
            edit.editPerson(personList,dgwListe);
        }

        private void btnRmv_Click(object sender, EventArgs e)
        {
            Remove remove = new Remove();
            remove.personRemove(dgwListe, personList);     
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            LoadAndSave loadAndSave = new LoadAndSave();

            if (cmbType.Text == FileType.Csv.ToString())         
            {
                SaveCsv saveCsv = new SaveCsv();
                loadAndSave.loadSaveMethod(sfdSave, csvExtension, saveCsv.saveFileCsv, personList);
            }
            else if (cmbType.Text == FileType.Xml.ToString())
            {
                SaveXml saveXml = new SaveXml();
                loadAndSave.loadSaveMethod(sfdSave, xmlExtension, saveXml.saveFileXml, personList);
            }
            else if (cmbType.Text==FileType.Json.ToString())
            {
                SaveJson saveJson = new SaveJson();
                loadAndSave.loadSaveMethod(sfdSave, jsonExtension, saveJson.saveFileJson, personList);
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
                loadAndSave.loadSaveMethod(ofdLoad, csvExtension, loadCsv.loadFileCsv, personList);
            }
            else if (cmbType.Text == FileType.Xml.ToString())
            {
                LoadXml loadXml = new LoadXml();
                loadAndSave.loadSaveMethod(ofdLoad, xmlExtension, loadXml.loadFileXml, personList);
            }
            else if (cmbType.Text == FileType.Json.ToString())
            {
                LoadJson loadJson = new LoadJson();
                loadAndSave.loadSaveMethod(ofdLoad,jsonExtension ,loadJson.loadFileJson, personList);
            }
            else
                MessageBox.Show("Select type");
        }

    }
}
 