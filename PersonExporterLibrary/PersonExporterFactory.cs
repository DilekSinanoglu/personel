using System.Collections.Generic;
using PersonLibrary;

namespace personelKayit_dosyaOkuma_
{
    public class PersonExporterFactory : IPersonExporterFactory
    {
        List<IPersonExporter> exporterList;

        public PersonExporterFactory(IPersonExporter[] exporters)
        {
            exporterList = new List<IPersonExporter>(exporters);
        }

        public string[] GetAvailableTypes()
        {
            string[] exporterType = new string[exporterList.Count];
            for (int i = 0; i < exporterList.Count; i++)
            {
                exporterType[i] = exporterList[i].FormatName;
            }
            return exporterType;
        }

        public IPersonExporter CreateExporter(string name)
        {

            for (int i = 0; i < exporterList.Count; i++)
            {
                if (exporterList[i].FormatName == name)
                {
                    return exporterList[i];

                }
            }
            return null;
        }
    }
}
