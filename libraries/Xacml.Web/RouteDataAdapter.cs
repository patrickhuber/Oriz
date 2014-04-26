using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;

namespace Xacml.Web
{
    public class RouteDataAdapter : IRouteData
    {
        private RouteData routeData;
        
        public RouteDataAdapter(RouteData routeData)
        {
            this.routeData = routeData;
        }

        public IDictionary<string, object> Values
        {
            get { return routeData.Values; }
        }
    }
}
