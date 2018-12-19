using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Autofac;
using Autofac.Features.ResolveAnything;
using PersonLibrary;

namespace personelKayit_dosyaOkuma_
{
    static class Program
    {
      
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            ContainerBuilder _builder = new ContainerBuilder();
            _builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());

            string[] _exporterDlls = Directory.GetFiles(Environment.CurrentDirectory+ "\\netstandard2.0", "*ExporterLibrary.dll");
            for(int i=0;i< _exporterDlls.Length;i++)
            {
                Assembly _asm = Assembly.LoadFile(_exporterDlls[i]);
                _builder.RegisterAssemblyTypes(_asm).As<IPersonExporter>();
            }

            _builder.
                RegisterType<PersonExporterFactory>().
                As<IPersonExporterFactory>();

            var _container = _builder.Build();

            Form1 _frm = _container.Resolve<Form1>();

            Application.Run(_frm);
        }
    }
}
