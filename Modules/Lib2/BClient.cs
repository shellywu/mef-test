using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib2
{
    [Export("B",typeof(IClient))]
    [ExportMetadata("Order", 1)]
    public class BClient : IClient
    {
        private IMessager _messager;
        [ImportingConstructor]
        public BClient([Import]IMessager messager)
        {
            _messager = messager;
        }
        public void Fetch()
        {
            _messager.DoSomething("B Fetch");
        }
    }
    [Export(typeof(IClient))]
    [ExportMetadata("Order", 1)]
    public class B1Client : IClient
    {
        private IMessager _messager;
        [ImportingConstructor]
        public B1Client([Import]IMessager messager)
        {
            _messager = messager;
        }
        public void Fetch()
        {
            _messager.DoSomething("B1 Fetch");
        }
    }
}
