/* Copyright (C) 2004 - 2009  Versant Inc.  http://www.db4o.com */

using System;
using Db4oUnit.Extensions;
using Db4objects.Db4o.Tests.Common.Freespace;

namespace Db4objects.Db4o.Tests.Common.Freespace
{
	public class AllTests : ComposibleTestSuite
	{
		public static void Main(string[] args)
		{
			new Db4objects.Db4o.Tests.Common.Freespace.AllTests().RunSolo();
		}

		protected override Type[] TestCases()
		{
			return ComposeTests(new Type[] { typeof(FreespaceManagerDiscardLimitTestCase), typeof(
				FreespaceManagerReopenTestCase), typeof(FreespaceManagerTestCase), typeof(FreespaceManagerTypeChangeTestCase
				) });
		}

		#if !SILVERLIGHT
		protected override Type[] ComposeWith()
		{
			return new Type[] { typeof(BlockConfigurationFileSizeTestCase), typeof(FileSizeTestCase
				) };
		}
		#endif // !SILVERLIGHT
	}
}
