using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Xacml.Web
{
    public class HttpApplicationAdapter : IHttpApplication
    {
        private HttpApplication httpApplication;

        public HttpApplicationAdapter(HttpApplication httpApplication)
        {
            this.httpApplication = httpApplication;
        }

        public void CompleteRequest()
        {
            httpApplication.CompleteRequest();
        }

        public IHttpContext Context
        {
            get 
            { 
                return new HttpContextAdapter(httpApplication.Context); 
            }
        }
    }
}
