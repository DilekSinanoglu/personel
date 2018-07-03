using System.ComponentModel;
using PersonLibrary;

namespace personelKayit_dosyaOkuma_
{
    public interface IPersonExporter
    {
        string FileExtension { get; }
        string FormatName { get; }

        BindingList<Person> LoadFromFile(string filePath);
        void SaveToFile(BindingList<Person> personList, string filePath);
    }
}