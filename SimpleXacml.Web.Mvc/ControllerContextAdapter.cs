using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace SimpleXacml.Web.Mvc
{
    public class ControllerContextAdapter
    {
        private ControllerContext controllerContext;

        public ControllerContextAdapter(ControllerContext controllerContext)
        {   
            this.controllerContext = controllerContext;
        }

        public IRouteData RouteData        
        {
            get { return new RouteDataAdapter(controllerContext.RouteData); }
        }
    }
}
