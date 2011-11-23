/* Copyright (C) 2007   Versant Inc.   http://www.db4o.com */
namespace Db4objects.Db4o.Tests.CLI2.Assorted
{
	public class AllTests : Db4oUnit.Extensions.Db4oTestSuite
	{
		protected override System.Type[] TestCases()
		{
			return new System.Type[]
			{
				typeof(AssemblyInfoTestCase),
				typeof(DelegateFieldTestCase),
                typeof(ListOfNullableItemTestCase),
				typeof(NullableDateTimeTestCase),
                typeof(NullableTypes),
				typeof(NullableArraysElementsTestCase),
				typeof(SimpleGenericTypeTestCase),
				typeof(UntypedDelegateArrayTestCase),
			};
		}
	}
}
