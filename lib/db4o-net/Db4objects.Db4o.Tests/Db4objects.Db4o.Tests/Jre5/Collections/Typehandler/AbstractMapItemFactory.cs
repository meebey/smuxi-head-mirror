/* Copyright (C) 2004 - 2009  Versant Inc.  http://www.db4o.com */

using Db4objects.Db4o.Tests.Jre5.Collections.Typehandler;

namespace Db4objects.Db4o.Tests.Jre5.Collections.Typehandler
{
	public abstract class AbstractMapItemFactory : AbstractItemFactory
	{
		public override string FieldName()
		{
			return AbstractItemFactory.MapFieldName;
		}
	}
}
