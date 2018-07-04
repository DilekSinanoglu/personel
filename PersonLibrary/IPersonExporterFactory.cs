using personelKayit_dosyaOkuma_;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonLibrary
{
    public interface IPersonExporterFactory
    {
        string[] GetAvailableTypes();
        IPersonExporter CreateExporter(string name);
    }
}
