using System.ComponentModel;

namespace personelKayit_dosyaOkuma_
{
    interface IPersonExporter
    {
        string FileExtension { get; }
        string FormatName { get; }

        BindingList<Person> LoadFromFile(string filePath);
        void SaveToFile(BindingList<Person> personList, string filePath);
    }
}