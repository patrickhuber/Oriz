using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SimpleXacml.Web
{
    public class HttpRequestAdapter : IHttpRequest
    {
        private HttpRequestBase httpRequest;
        public HttpRequestAdapter(HttpRequestBase request)
        {
            this.httpRequest = request;
        }
        public Uri Url
        {
            get { return this.httpRequest.Url; }
        }
    }
}
