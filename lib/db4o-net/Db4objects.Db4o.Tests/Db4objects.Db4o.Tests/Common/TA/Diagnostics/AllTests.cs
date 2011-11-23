/* Copyright (C) 2004 - 2009  Versant Inc.  http://www.db4o.com */

using System;
using Db4oUnit.Extensions;
using Db4objects.Db4o.Tests.Common.TA.Diagnostics;

namespace Db4objects.Db4o.Tests.Common.TA.Diagnostics
{
	public class AllTests : Db4oTestSuite
	{
		protected override Type[] TestCases()
		{
			return new Type[] { typeof(TransparentActivationDiagnosticsTestCase) };
		}

		public static void Main(string[] args)
		{
			new Db4objects.Db4o.Tests.Common.TA.Diagnostics.AllTests().RunAll();
		}
	}
}
