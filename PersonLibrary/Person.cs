using System;
using System.ComponentModel;

namespace PersonLibrary
{
    public class Person : INotifyPropertyChanged
    {
        string id;
        string name;
        string sName;
        DateTime date;
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