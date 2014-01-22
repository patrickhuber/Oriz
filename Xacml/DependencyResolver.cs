using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml
{
    public class DependencyResolver
    {
        private static IDependencyResolver dependencyResolver;
        
        public static void SetResolver(IDependencyResolver resolver)
        {
            lock (dependencyResolver)
            {
                dependencyResolver = resolver;
            }
        }

        public static IDependencyResolver Current
        {
            get { return dependencyResolver; }
        }
    }
}
