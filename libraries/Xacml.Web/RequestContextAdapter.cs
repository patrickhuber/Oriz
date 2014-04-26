using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;

namespace Xacml.Web
{
    public class RequestContextAdapter : IRequestContext
    {
        private RequestContext requestContext;

        public RequestContextAdapter(RequestContext requestContext)
        {
            this.requestContext = requestContext;
        }

        public IRouteData RouteData
        {
            get { return new RouteDataAdapter(requestContext.RouteData); }
        }
    }
}
