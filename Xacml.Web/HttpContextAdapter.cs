using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Web;

namespace Xacml.Web
{
    public class HttpContextAdapter : IHttpContext
    {
        private HttpContextBase httpContext;

        public HttpContextAdapter(HttpContext httpContext)
            : this(new HttpContextWrapper(httpContext))
        { 
        }

        public HttpContextAdapter(HttpContextBase httpContext)
        {
            this.httpContext = httpContext;
        }

        public IHttpRequest Request
        {
            get 
            {
                if(httpContext.Request != null)
                    return new HttpRequestAdapter(httpContext.Request);
                return null;
            }
        }

        public IHttpResponse Response
        {
            get 
            {
                if (httpContext.Response != null)
                    return new HttpResponseAdapter(httpContext.Response);
                return null;
            }
        }

        public bool SkipAuthorization
        {
            get { return httpContext.SkipAuthorization; }
        }

        public IPrincipal User
        {
            get { return httpContext.User; }
        }

        public IHttpApplication ApplicationInstance
        {
            get 
            {
                if (httpContext.ApplicationInstance == null)
                    return null;
                return new HttpApplicationAdapter(httpContext.ApplicationInstance);
            }
        }
    }
}
