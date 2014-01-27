using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Xacml.Schemas;


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
            return MapContext(httpContext);
        }

        protected virtual IList<AttributesType> MapContext(IHttpContext httpContext)
        {
            var attributeList = new List<AttributesType>() 
            {
                new AttributesType(
                    Constants.AttributeCategories.Resource,
                    new AttributeType(
                        Constants.Resource.ResourceId,
                        Constants.DataTypes.String, 
                        httpContext.Request.Url.AbsolutePath)),
                new AttributesType(
                    Constants.SubjectCategory.AccessSubject,
                    new AttributeType(
                        Constants.Subject.SubjectId,
                        Constants.DataTypes.Rfc822Name,
                        httpContext.User.Identity.Name)),
                new AttributesType(
                    Constants.AttributeCategories.Action,
                    new AttributeType(
                        Constants.Action.ActionId,
                        Constants.DataTypes.String,
                        httpContext.Request.HttpMethod))
            };
            return attributeList;
        }
    }
}
