/* Copyright (C) 2004 - 2009  Versant Inc.  http://www.db4o.com */

using Db4objects.Db4o.Reflect.Generic;

namespace Db4objects.Db4o.Reflect.Generic
{
	/// <exclude></exclude>
	public interface IGenericConverter
	{
		string ToString(GenericObject obj);

		string ToString(GenericArray array);
	}
}
