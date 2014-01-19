using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleXacml.Web
{
    public class HttpContextHandler : IContextHandler
    {
        private IHttpContext httpContext;
        
        public HttpContextHandler(IHttpContext httpContext)
        {
            this.httpContext = httpContext;
        }

        public IDictionary<string, string> GetContext()
        {
            Dictionary<string, string> context = new Dictionary<string, string>();
            
            
            return context;
        }
    }
}
