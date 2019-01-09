using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Impl
{
    [Export(typeof(IMessager))]
    public class MyBase : IMessager
    {
        public void DoSomething(string message)
        {
            Console.WriteLine($"mybase dosomething say:{message}");
        }
    }
}
