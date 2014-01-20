using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace Xacml.Web
{
    public interface IHttpContext
    {
        IHttpRequest Request { get; }
        bool SkipAuthorization { get; }
        IPrincipal User { get; }
    }
}
