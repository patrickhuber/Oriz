using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Xacml.ServiceModel
{
    public class PolicyAuthorizationManager : ServiceAuthorizationManager
    {
        IPolicyEnforcementPoint policyEnforcementPoint;

        public PolicyAuthorizationManager()
            : this(DependencyResolver.Current.GetService<IPolicyEnforcementPoint>())
        { }

        public PolicyAuthorizationManager(IPolicyEnforcementPoint policyEnforcementPoint)
        {
            this.policyEnforcementPoint = policyEnforcementPoint;
        }

        protected override bool CheckAccessCore(OperationContext operationContext)
        {
            var operationContextAdapter = new OperationContextAdapter(operationContext);
            return CheckAccessCore(operationContextAdapter);
        }

        public bool CheckAccessCore(IOperationContext operationContext)
        { 
            var operationContextHandler = new OperationContextHandler(operationContext);
            var accessResponse = policyEnforcementPoint.RequestAccess(operationContextHandler);
            return accessResponse.IsAuthorized;
        }
    }
}
