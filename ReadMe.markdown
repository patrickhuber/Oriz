SimpleXacml
===========
Overview
--------
Implements a simle xacml architecture in .NET

Purpose
-------
Large enterprises have complex authorization needs which opens the door to look at standards compliant authorization standards, to achieve these needs they also have large budgets. 

There are no really 'easy' ways to achieve complex authorization in a simple .NET application without using a large vendor product. So, to fulfill the need and as a learning project, the SimpleXacml implementation was created. 

Getting Started
---------------

###Enforce Policy in an ASP.NET Web Forms Application
1. Add the Xacml.Web.PolicyEnforcementModule to the modules section of the web.config
	```xml
	<system.webServer>
		<modules runAllManagedModulesForAllRequests="true" >
			<add name="Xacml.Web.PolicyEnforcementModule, Xacml.Web, Version=1.0.0"/>
		</modules>
	</system.webServer>
	```
2. Set the configuration module for xacml in the config section of the web.config
	```xml
	<configuration>
	  <configSections>
		<section name="xacml" type="Xacml.ConfigurationSection, Xacml, Version=1.0.0.0"/>
	  </configSections>
	</configuration>
	```
3. Set the policy access point to the FileSystemPolicyAccessPoint
	```xml
	<xacml>
		<policyAccessPoint type="Xacml.Web.WebFileSystemPolicyAccessPoint, Xacml, Version=1.0.0.0">
			<data folder="~/App_Data/Policies"/>
		</policyAccessPoint>
	</xacml>
	```

###Enforce Policy in an ASP.NET Mvc Application
1. Add the Xacml.Web.Mvc.PolicyEnforcementAttribute to the global.asax.cs global filters
	```csharp
	GlobalFilters.Filters.Add(new Xacml.Web.Mvc.PolicyEnforcementAttribute());
	```
2. Set the configuration module for xacml in the config section of the web.config
	```xml
	<configuration>
	  <configSections>
		<section name="xacml" type="Xacml.ConfigurationSection, Xacml, Version=1.0.0.0"/>
	  </configSections>
	</configuration>
	```
3. Set the policy access point to the FileSystemPolicyAccessPoint
	```xml
	<xacml>
		<policyAccessPoint type="Xacml.Web.WebFileSystemPolicyAccessPoint, Xacml, Version=1.0.0.0">
			<data folder="~/App_Data/Policies"/>
		</policyAccessPoint>
	</xacml>
	```

###Enforce Policy in a WCF Service 

License
-------

Copyright (c) 2014, Patrick Huber
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:

* Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
* Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
* Neither the name of the SimpleXacml nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL PATRICK HUBER BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE. 