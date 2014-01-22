using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Xacml.Web
{
    public sealed class PolicyAuthorizeModule : IHttpModule
    {
        IPolicyEnforcementPoint policyEnforcementPoint;

        public PolicyAuthorizeModule()
            : this(DependencyResolver.Current.GetService<IPolicyEnforcementPoint>())
        { }
        
        public PolicyAuthorizeModule(IPolicyEnforcementPoint policyEnforcementPoint)
        {
            this.policyEnforcementPoint = policyEnforcementPoint;
        }

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
            if (SkipAuthorization(httpContext))
                return;
            else if (AccessIsDenied(httpContext))
                SetUnAuthorizedResponse(httpContext);
        }

        private bool SkipAuthorization(IHttpContext httpContext)
        {
            if (httpContext.SkipAuthorization)
            {
                if (httpContext.User != null && httpContext.User.Identity.IsAuthenticated)
                {
                    return true;
                }
            }
            return false;
        }

        private bool AccessIsDenied(IHttpContext httpContext)
        { 
            var contextHandler = new HttpContextHandler(httpContext);
            var accessResponse = policyEnforcementPoint.RequestAccess(contextHandler);
            return !accessResponse.IsAuthorized;
        }

        private void SetUnAuthorizedResponse(IHttpContext httpContext)
        {
            httpContext.Response.StatusCode = 401;
            httpContext.Response.End();
            httpContext.ApplicationInstance.CompleteRequest();
        }
    }
}
