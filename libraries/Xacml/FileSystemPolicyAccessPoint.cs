using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Xacml.Schemas;

namespace Xacml
{
    public class FileSystemPolicyAccessPoint : IPolicyAccessPoint
    {
        private string path;
        private string pattern;

        public FileSystemPolicyAccessPoint(string path)
            : this(path, "*.*")
        { }

        public FileSystemPolicyAccessPoint(string path, string pattern)
        {
            this.path = path;
            this.pattern = pattern;
        }

        public IEnumerable<PolicyType> GetTargetedPolicies(IEnumerable<AttributesType> attributes)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            var files = directoryInfo.GetFiles(pattern);
            var policies = new List<PolicyType>();

            foreach (var file in files)
            {
                var policy = GetPolicyFromFile(file);
                if(PolicyApplies(policy, attributes))
                    policies.Add(policy);
            }
            return policies;
        }

        private bool PolicyApplies(PolicyType policy, IEnumerable<AttributesType> attributes)
        {
            var target = policy.Target;
            var targetExpression = new TargetExpression(target);
            return targetExpression.Evaluate(attributes);
        }

        private PolicyType GetPolicyFromFile(FileInfo fileInfo)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PolicyType));
            using(var fileStream = fileInfo.OpenRead())
            {
                var policy = serializer.Deserialize(fileStream) as PolicyType;
                return policy;
            }
        }
    }
}
