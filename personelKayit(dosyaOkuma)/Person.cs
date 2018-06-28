using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personelKayit_dosyaOkuma_
{
    public class Person : INotifyPropertyChanged
    {
        string id;

        string name;
        string sName;
        DateTime date;

        // [XmlIgnore]
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        //[XmlText]
        public string SName
        {
            get
            {
                return sName;
            }
            set
            {
                sName = value;
                OnPropertyChanged("SName");
            }
        }
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
                OnPropertyChanged(DateTime.Now);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(object propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName.ToString()));
            }
        }
    }
}
