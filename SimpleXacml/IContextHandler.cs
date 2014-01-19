using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleXacml
{
    public interface IContextHandler
    {
        IDictionary<string, string> GetContext();
    }
}
