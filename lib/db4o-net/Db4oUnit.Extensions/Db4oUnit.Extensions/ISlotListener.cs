/* Copyright (C) 2004 - 2009  Versant Inc.  http://www.db4o.com */

using Db4objects.Db4o.Internal.Slots;

namespace Db4oUnit.Extensions
{
	/// <exclude></exclude>
	public interface ISlotListener
	{
		void OnFree(Slot slot);
	}
}
