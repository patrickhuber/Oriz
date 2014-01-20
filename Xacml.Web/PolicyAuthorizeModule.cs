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
            app.AuthorizeRequest += this.OnEnter;
        }

        private void OnEnter(object source, EventArgs e)
        {
            HttpContext context = ((HttpApplication)source).Context;
            if (context.SkipAuthorization)
            {
                if (context.User != null && context.User.Identity.IsAuthenticated)
                {
                    return;                    
                }
            }
            else 
            {
                var contextAdapter = new HttpContextAdapter(context);
                var contextHandler = new HttpContextHandler(contextAdapter);
            }
        }
    }
}
