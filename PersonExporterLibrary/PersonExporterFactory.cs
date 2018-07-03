using System.Collections.Generic;
using PersonLibrary;

namespace personelKayit_dosyaOkuma_
{
    public static class PersonExporterFactory
    {
        static List<IPersonExporter> exporterList;
        static PersonExporterFactory()
        {
            exporterList = new List<IPersonExporter>
            {
                new CsvExporter(),
                new XmlExporter(),
                new JsonExporter()
            };
        }

        public static string[] GetAvailableTypes()
        {
            string[] exporterType = new string[exporterList.Count];
            for (int i = 0; i < exporterList.Count; i++)
            {
                exporterType[i] = exporterList[i].FormatName;
            }
            return exporterType;
        }

        public static IPersonExporter CreateExporter(string name)
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
