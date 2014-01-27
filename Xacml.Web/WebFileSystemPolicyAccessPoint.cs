using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml.Web
{
    public class WebFileSystemPolicyAccessPoint : FileSystemPolicyAccessPoint
    {
        public WebFileSystemPolicyAccessPoint(string path) : base(path) { }
        public WebFileSystemPolicyAccessPoint(string path, string pattern) : base(path, pattern) { }
    }
}
