using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xacml
{
    public class AuthorizationResponse
    {
        public ICollection<Result> Results { get; set; }
    }
}
