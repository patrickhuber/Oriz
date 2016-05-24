using System.Collections.Generic;

namespace Oriz
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