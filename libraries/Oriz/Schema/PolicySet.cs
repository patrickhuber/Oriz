using System;
using System.Collections.Generic;

namespace Oriz.Schema
{
    public class PolicySet
    {
        public Target Target { get; set; }

        public ICollection<PolicySet> PolicySets { get; set; }

        public ICollection<Policy> Policies { get; set; }
        
        public string CombingingAlgorithmId { get; set; }
    }
}