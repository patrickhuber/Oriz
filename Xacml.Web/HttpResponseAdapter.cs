using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Xacml.Web
{
    public class HttpResponseAdapter : IHttpResponse
    {
        private HttpResponseBase httpResponse;
        public HttpResponseAdapter(HttpResponseBase httpResponse)
        {
            this.httpResponse = httpResponse;
        }

        public void End()
        {
            httpResponse.End();
        }

        public int StatusCode
        {
            get { return httpResponse.StatusCode; }
            set { httpResponse.StatusCode = value; }
        }
    }
}
