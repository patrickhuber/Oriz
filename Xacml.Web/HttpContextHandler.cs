using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;


namespace Xacml.Web
{
    public class HttpContextHandler : IContextHandler
    {
        private IHttpContext httpContext;
        
        public HttpContextHandler(IHttpContext httpContext)
        {
            this.httpContext = httpContext;
        }

        public IEnumerable<AttributesType> GetContext()
        {
            var attributeList = new List<AttributesType>() 
            {
                new AttributesType(
                    Constants.AttributeCategories.Resource,
                    new AttributeType(
                            Constants.Identifiers.Resource.ResourceId,
                            Constants.DataTypes.String, 
                            httpContext.Request.Url.AbsolutePath))                
            };
            return attributeList;
        }
    }
}
