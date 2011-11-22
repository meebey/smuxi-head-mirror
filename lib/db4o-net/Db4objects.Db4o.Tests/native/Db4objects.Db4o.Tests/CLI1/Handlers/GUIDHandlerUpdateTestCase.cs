/* Copyright (C) 2009  Versant Inc.  http://www.db4o.com */
using System;

namespace Db4objects.Db4o.Tests.CLI1.Handlers
{
    internal class GUIDHandlerUpdateTestCase : ValueTypeHandlerUpdateTestCaseBase<Guid>
    {
    	protected override Guid[] GetData()
    	{
    		return Data;
    	}

        protected override bool DefragmentInReadWriteMode()
        {
            return true;
        }
		
		private static readonly Guid[] Data = new Guid[] {
            Guid.Empty,
            new Guid("a17b9ce4-e7f7-464c-a7d8-598a229f6a0c"),
            new Guid("c2e5944a-b630-4cad-b49e-8e261a08c14c"),
            new Guid("7e255e48-5320-4b1f-86da-2d680aaed914"),
            new Guid("9d33da58-44ae-44c3-b719-4c006be0cb44"),
        };
	}
}
