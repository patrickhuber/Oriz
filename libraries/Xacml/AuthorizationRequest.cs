using System.Collections.Generic;

namespace Xacml
{
    public class AuthorizationRequest
    {
        public AuthorizationContext AuthorizationContext { get; set; }

        public AuthorizationRequest(AuthorizationContext authorizationContext)
        {
            AuthorizationContext = authorizationContext;
        }

        public AuthorizationRequest()
        { }
    }
}