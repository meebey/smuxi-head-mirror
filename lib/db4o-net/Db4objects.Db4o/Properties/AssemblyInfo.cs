/* Copyright (C) 2009 Versant Inc.   http://www.db4o.com */
using System;
using System.Reflection;
using System.Security;

[assembly: AssemblyTitle("db4o - database for objects")]
[assembly: AssemblyCompany("Versant Corp., Redwood City, CA, USA")]
[assembly: AssemblyProduct("db4o - database for objects")]
[assembly: AssemblyCopyright("Versant Corp. 2000 - 2011")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyDelaySign(false)]
[assembly: AssemblyKeyName("")]

// attributes are automatically set by the build
[assembly: AssemblyVersion("8.0.183.14430")]
[assembly: AssemblyKeyFile("")]
[assembly: AssemblyConfiguration(".NET")]
[assembly: AssemblyDescription("Db4objects.Db4o 8.0.183.14430 (.NET)")]

#if !CF && !SILVERLIGHT
[assembly: AllowPartiallyTrustedCallers]
#endif

#if NET_4_0
[assembly: SecurityRules(SecurityRuleSet.Level1)]
#endif

[assembly: CLSCompliant(true)]