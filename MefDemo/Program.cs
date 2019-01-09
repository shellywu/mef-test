using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MefDemo
{
    public class Demo
    {
        [ImportMany(typeof(IClient))]
        public IEnumerable<Lazy<IClient,IClientData>> Clients { get; set; }
        public void Go()
        {
            Clients.FirstOrDefault(c=>c.Metadata.Order==2)?.Value.Fetch();
            Clients.FirstOrDefault(c => c.Metadata.Order == 1)?.Value.Fetch();
            Clients.OrderBy(c => c.Metadata.Order).Select(c => c.Value).ToList().ForEach(c =>
            {
                c.Fetch();
            });
        }
    }

    public class Demo2
    {
        [Import("B",AllowDefault =true)]
        public IClient ClientB { get; set; }
        [Import("A",AllowDefault =true)]
        public IClient ClientA { get; set; }
        public void Go()
        {
            ClientA?.Fetch();
            ClientB?.Fetch();
        }
    }
    public static class Program
    {
        static CompositionContainer _container;
        public static void Main(string[] args)
        {
            LoadModules();

            var bclient = _container.GetExportedValueOrDefault<IClient>("B");
            var aclient = _container.GetExportedValueOrDefault<IClient>("A");
            bclient?.Fetch();
            aclient?.Fetch();

            var demo = new Demo();
            _container.ComposeParts(demo);
            demo.Go();

            var demo2 = new Demo2();
            _container.ComposeParts(demo2);
            demo2.Go();

            Console.ReadLine();
        }

        private static void LoadModules()
        {
            var ac = new AggregateCatalog();

            Directory.GetDirectories("Modules").ToList().ForEach(p =>
            {
                var dc = new DirectoryCatalog(p);

                ac.Catalogs.Add(dc);
            });
            _container = new CompositionContainer(ac);
        }
    }
}
