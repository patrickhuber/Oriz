using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml.Web
{
    public interface IHttpResponse
    {
        void End();
        int StatusCode { get; set; }
    }
}
