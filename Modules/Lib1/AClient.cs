using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Lib1
{
    [Export("A",typeof(IClient))]
    public class AClient : IClient
    {
        private IMessager _messager;
        [ImportingConstructor]
        public AClient([Import]IMessager messager)
        {
            _messager = messager;
        }
        public void Fetch()
        {
            _messager.DoSomething("A Fetch");
        }
    }
    [Export(typeof(IClient))]
    [ExportMetadata("Order", 2)]
    public class A1Client : IClient
    {
        private IMessager _messager;
        [ImportingConstructor]
        public A1Client([Import]IMessager messager)
        {
            _messager = messager;
        }
        public void Fetch()
        {
            _messager.DoSomething("A1 Fetch");
        }
    }
}
