using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml.Web
{
    public interface IHttpRequest
    {
        Uri Url { get; }
        string HttpMethod { get; }
        IRequestContext RequestContext { get; }
    }
}
