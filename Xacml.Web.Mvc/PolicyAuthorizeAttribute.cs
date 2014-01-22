using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Xacml.Web.Mvc
{
    public class PolicyAuthorizeAttribute : AuthorizeAttribute
    {
        private IPolicyEnforcementPoint PolicyEnforcementPoint { get; set; }

        public PolicyAuthorizeAttribute()
            : this(DependencyResolver.Current.GetService<IPolicyEnforcementPoint>())
        { }

        public PolicyAuthorizeAttribute(IPolicyEnforcementPoint policyEnforcementPoint)
        {
            PolicyEnforcementPoint = policyEnforcementPoint;
        }

        protected override bool AuthorizeCore(HttpContextBase authorizeContext)
        {
            IHttpContext httpContext = new HttpContextAdapter(authorizeContext);
            return AuthorizeCore(httpContext);
        }

        public bool AuthorizeCore(IHttpContext httpContext)
        {
            if (httpContext.SkipAuthorization)
            {
                if (httpContext.User != null && httpContext.User.Identity.IsAuthenticated)
                    return true;
            }
            var accessResponse = PolicyEnforcementPoint.RequestAccess(new MvcContextHandler(httpContext));
            return accessResponse.IsAuthorized;        
        }
    }
}
