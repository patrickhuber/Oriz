using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Xacml.Web
{
    public sealed class PolicyAuthorizeModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication app)
        {
            app.AuthorizeRequest += this.OnAuthorizeRequest;
        }

        private void OnAuthorizeRequest(object source, EventArgs e)
        {
            HttpContext context = ((HttpApplication)source).Context;
            OnAuthorizeRequest(new HttpContextAdapter(context));
        }

        public void OnAuthorizeRequest(IHttpContext httpContext)
        {
            if (httpContext.SkipAuthorization)
            {
                if (httpContext.User != null && httpContext.User.Identity.IsAuthenticated)
                {
                    return;
                }
            }
            else
            {
                var contextHandler = new HttpContextHandler(httpContext);
                var polcyEnforcementPoint = new PolicyEnforcementPoint();
                var accessResponse = polcyEnforcementPoint.RequestAccess(contextHandler);
                if (!accessResponse.IsAuthorized)
                {
                    httpContext.Response.StatusCode = 401;
                    httpContext.Response.End();
                }
            }
        }
    }
}
