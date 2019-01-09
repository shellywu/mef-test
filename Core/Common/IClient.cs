using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IClient
    {
        void Fetch();
    }

    public interface IClientData
    {
        int Order { get; }
    }
}
