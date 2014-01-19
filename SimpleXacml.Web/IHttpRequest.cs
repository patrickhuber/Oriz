using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleXacml.Web
{
    public interface IHttpRequest
    {
        Uri Url { get; }
    }
}
