using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Xacml.Types;

namespace Xacml.Functions
{
    public class FunctionRegistryFactory : IFunctionRegistryFactory
    {
        public virtual IFunctionRegistry CreateFunctionRegistry()
        {
            IFunctionRegistry functionRegistry = new FunctionRegistry();
            RegisterStringFunctions(functionRegistry);
            RegisterIntegerFunctions(functionRegistry);
            return functionRegistry;
        }

        private void RegisterStringFunctions(IFunctionRegistry functionRegistry)
        {     
            functionRegistry.RegisterFunction(Constants.Functions.String.Equal, new Func<string, string, bool>((x,y)=>x.Equals(y)));
            functionRegistry.RegisterFunction(Constants.Functions.String.EqualIgnoreCase, new Func<string, string, bool>((x, y) => x.Equals(y, StringComparison.CurrentCultureIgnoreCase)));
            functionRegistry.RegisterFunction(Constants.Functions.String.Concatenate, new Func<string[], string>((strArray)=>string.Concat(strArray)));
            functionRegistry.RegisterFunction(Constants.Functions.String.FromAnyUri, new Func<Uri, string>(uri => uri.ToString()));
            functionRegistry.RegisterFunction(Constants.Functions.String.FromBoolean, new Func<bool, string>(b => b.ToString()));
            functionRegistry.RegisterFunction(Constants.Functions.String.FromDate, new Func<DateTime, string>(dt => dt.ToShortDateString()));
            functionRegistry.RegisterFunction(Constants.Functions.String.FromDateTime, new Func<DateTime, string>(dt=>dt.ToString()));            
            functionRegistry.RegisterFunction(Constants.Functions.String.FromDayTimeDuration, new Func<YearMonthDuration, string>(ts => ts.ToString()));
            functionRegistry.RegisterFunction(Constants.Functions.String.FromDnsName, new Func<DnsName, string>(dns => dns.ToString()));
            functionRegistry.RegisterFunction(Constants.Functions.String.FromDouble, new Func<double, string>(d => d.ToString()));
            functionRegistry.RegisterFunction(Constants.Functions.String.FromInteger, new Func<int, string>(i => i.ToString()));            
            functionRegistry.RegisterFunction(Constants.Functions.String.FromTime, new Func<DateTime, string>(dt => dt.ToShortTimeString()));            
            functionRegistry.RegisterFunction(Constants.Functions.String.FromRfc822Name, new Func<MailAddress, string>(name=>name.ToString()));
            functionRegistry.RegisterFunction(Constants.Functions.String.FromX500Name, new Func<X500DistinguishedName, string>(name=>name.ToString()));
            
        }

        public void RegisterIntegerFunctions(IFunctionRegistry functionRegistry)
        { 

        }
    }
}
