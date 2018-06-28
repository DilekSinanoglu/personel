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

        public Form1()
        {
            InitializeComponent();
            dgwListe.AutoGenerateColumns = false;
            dgwListe.DataSource = personList;
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
            if (cmbType.SelectedIndex == 0)
            {
                loadSaveMethod(sfdSave, "Csv File|*.csv", saveCvs);
            }
            else if (cmbType.SelectedIndex == 1)
            {
                loadSaveMethod(sfdSave, "XML files|*.xml", saveXml);
            }
            else if (cmbType.SelectedIndex == 2)
            {
                loadSaveMethod(sfdSave, "Json files|*.json", saveJson);
            }
            else
                MessageBox.Show("Select type");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            personList.Clear();

            if (cmbType.SelectedIndex == 0)
            {
                loadSaveMethod(ofdLoad,"Csv File|*.csv",loadCvs);
            }
            else if (cmbType.SelectedIndex == 1)
            {
                loadSaveMethod(ofdLoad,"Xml File|*.xml",loadXml);
            }
            else if (cmbType.SelectedIndex == 2)
            {
                loadSaveMethod(ofdLoad,"Json files|*.json",loadJson);
            }
            else
                MessageBox.Show("Select type");
        }

        private void loadSaveMethod(FileDialog fileDialog, string filter, Action incomingMethod)
        {
            fileDialog.Filter = filter;

            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                incomingMethod();
            }
        }

        private void saveJson()
        {
            string convert = JsonConvert.SerializeObject(personList);
            File.WriteAllText(sfdSave.FileName, convert);
        }

        private void saveXml()
        {
            StreamWriter streamWriter = new StreamWriter(sfdSave.FileName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BindingList<Person>));
            xmlSerializer.Serialize(streamWriter, personList);
            streamWriter.Flush();
            streamWriter.Close();
        }

        private void saveCvs()
        {
            StreamWriter streamWriter = new StreamWriter(sfdSave.FileName);
            for (int i = 0; i < personList.Count; i++)
            {
                Person _person = personList[i];
                string personKnowledge = _person.Id + ";" + _person.Name + ";" + _person.SName + ";" + _person.Date;
                streamWriter.WriteLine(personKnowledge);
            }
            streamWriter.Flush();
            streamWriter.Close();
        }

        private void loadJson()
        {
            BindingList<Person> loadedList = JsonConvert.DeserializeObject<BindingList<Person>>(File.ReadAllText(ofdLoad.FileName));
            for (int i = 0; i < loadedList.Count; i++)
            {
                personList.Add(loadedList[i]);
            }
        }

        private void loadXml()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BindingList<Person>));
            StreamReader streamReader = new StreamReader(ofdLoad.FileName);
            BindingList<Person> loadedList = (BindingList<Person>)xmlSerializer.Deserialize(streamReader);
            for (int i = 0; i < loadedList.Count; i++)
            {
                personList.Add(loadedList[i]);

            }
            streamReader.Close();
        }

        private void loadCvs()
        {
            StreamReader streamReader = new StreamReader(ofdLoad.FileName);
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
 