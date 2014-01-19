using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;


namespace SimpleXacml.Web
{
    public class HttpContextHandler : IContextHandler
    {
        private IHttpContext httpContext;
        
        public HttpContextHandler(IHttpContext httpContext)
        {
            this.httpContext = httpContext;
        }

        public IEnumerable<AttributeType> GetContext()
        {
            var attributeList = new List<AttributeType>() 
            {
                new AttributeType(
                    Constants.Identifiers.Resource.ResourceId,
                    Constants.DataTypes.AnyUri, 
                    httpContext.Request.Url.AbsolutePath)
            };
            return attributeList;
        }
    }
}
