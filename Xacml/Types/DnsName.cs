using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Xacml.Types
{
    public struct DnsName
    {
        public string HostName;
        public PortRange PortRange;

        public static DnsName Parse(string name)
        {
            DnsName dnsName = new DnsName();
            string hostName = name;
            if (name.Contains(":"))
            {
                var split = name.Split(':');
                hostName = split[0];
                var uri = new Uri(hostName);
                dnsName.HostName = uri.Host;
                dnsName.PortRange = PortRange.Parse(split[1]);
            }
            else 
            {
                dnsName.PortRange = default(PortRange);
            }

            return dnsName;
        }

        public override string ToString()
        {
            if (PortRange.Equals(default(PortRange)))
            {
                return HostName;
            }
            return string.Format("{0}:{1}", HostName, PortRange.ToString());
        }
    }
}
