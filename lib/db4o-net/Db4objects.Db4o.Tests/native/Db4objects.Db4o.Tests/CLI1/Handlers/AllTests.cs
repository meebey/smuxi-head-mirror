/* Copyright (C) 2004 - 2007  Versant Inc.  http://www.db4o.com */

using System;

namespace Db4objects.Db4o.Tests.CLI1.Handlers
{
    public class AllTests : Db4oUnit.Extensions.Db4oTestSuite
	{
        public static void Main(string[] args)
        {
            new AllTests().RunSolo();
        }

        protected override Type[] TestCases()
        {
            return new System.Type[]
		    {
                typeof(DateTimeHandlerTestCase),
                typeof(DecimalHandlerTestCase),
                typeof(EnumInUntypedVariableTestCase),
                typeof(EnumTypeHandlerTestCase),
				typeof(GuidTypeHandlerTestCase),
                typeof(SByteHandlerTestCase),
                typeof(UIntHandlerTestCase),
                typeof(ULongHandlerTestCase),
                typeof(UShortHandlerTestCase),
            };
        }
    }
}
