using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml
{
    public class FileSystemPolicyAccessPoint : IPolicyAccessPoint
    {
        private string path;
        private string pattern;

        public FileSystemPolicyAccessPoint(string path, string pattern)
        {
            this.path = path;
            this.pattern = pattern;
        }

        public IEnumerable<PolicyType> GetApplicablePolicies(IEnumerable<AttributesType> attributes)
        {
            throw new NotImplementedException();
        }
    }
}
