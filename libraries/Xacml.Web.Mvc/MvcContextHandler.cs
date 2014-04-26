using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xacml.Schemas;

namespace Xacml.Web.Mvc
{
    public class MvcContextHandler : HttpContextHandler
    {
        public MvcContextHandler(IHttpContext httpContext)
            : base(httpContext)
        { }
        
        protected override IList<AttributesType> MapContext(IHttpContext httpContext)
        {
            var baseContext = base.MapContext(httpContext);
            var routeContext = MapRouteContext(httpContext.Request.RequestContext.RouteData);
            return baseContext;
        }

        private IList<AttributesType> MapRouteContext(IRouteData routeData)
        {
            var controller = GetRouteValueAsString(routeData, "controller");
            var area = GetRouteValueAsString(routeData, "area");
            var action = GetRouteValueAsString(routeData, "action");

            var routeContextAttributes = new List<AttributesType>() 
            {
                new AttributesType(
                    Constants.AttributeCategories.Resource,
                    new AttributeType(
                        MvcConstants.Identifiers.Controller, 
                        Constants.DataTypes.String,
                        controller),
                    new AttributeType(
                        MvcConstants.Identifiers.Action, 
                        Constants.DataTypes.String,
                        action),
                    new AttributeType(
                        MvcConstants.Identifiers.Area, 
                        Constants.DataTypes.String,
                        area))
            };
            return routeContextAttributes;
        }

        private static string GetRouteValueAsString(IRouteData routeData, string key)
        {
            var routeValue = routeData.Values[key];
            if (routeValue == null)
                return null;
            return routeValue.ToString();
        }
    }
}
