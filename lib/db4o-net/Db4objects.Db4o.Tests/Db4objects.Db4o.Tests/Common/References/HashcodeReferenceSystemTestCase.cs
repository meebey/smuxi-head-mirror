/* Copyright (C) 2004 - 2009  Versant Inc.  http://www.db4o.com */

using Db4objects.Db4o.Internal.References;
using Db4objects.Db4o.Tests.Common.References;

namespace Db4objects.Db4o.Tests.Common.References
{
	public class HashcodeReferenceSystemTestCase : ReferenceSystemTestCaseBase
	{
		protected override IReferenceSystem CreateReferenceSystem()
		{
			return new HashcodeReferenceSystem();
		}
	}
}
