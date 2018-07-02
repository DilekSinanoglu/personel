﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personelKayit_dosyaOkuma_
{
    static class PersonExporterFactory
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
            for (int i=0;i<exporterList.Count;i++)
            {
                exporterType[i] = exporterList[i].FormatName;
            }
            return exporterType;
        }

        public static IPersonExporter CreateExporter(string name)
        {
          
            for (int i = 0; i < exporterList.Count; i++)
            {         
                if (exporterList[i].FormatName==name)
                {
                   return exporterList[i];

                }
            }      
            return null;
        }
    }
}