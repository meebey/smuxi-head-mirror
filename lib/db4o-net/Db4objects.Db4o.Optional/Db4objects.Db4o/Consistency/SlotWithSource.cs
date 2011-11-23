/* Copyright (C) 2004 - 2011  Versant Inc.  http://www.db4o.com */

using Db4objects.Db4o.Consistency;
using Db4objects.Db4o.Internal.Slots;

namespace Db4objects.Db4o.Consistency
{
	internal class SlotWithSource
	{
		public readonly Slot _slot;

		public readonly SlotSource _source;

		public SlotWithSource(Slot slot, SlotSource source)
		{
			this._slot = slot;
			this._source = source;
		}

		public override string ToString()
		{
			return _slot + "(" + _source + ")";
		}
	}
}
