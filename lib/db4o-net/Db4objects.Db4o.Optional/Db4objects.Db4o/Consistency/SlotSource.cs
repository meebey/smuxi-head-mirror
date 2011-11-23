/* Copyright (C) 2004 - 2011  Versant Inc.  http://www.db4o.com */

namespace Db4objects.Db4o.Consistency
{
	internal class SlotSource
	{
		public static readonly Db4objects.Db4o.Consistency.SlotSource IdSystem = new Db4objects.Db4o.Consistency.SlotSource
			("IdSystem");

		public static readonly Db4objects.Db4o.Consistency.SlotSource Freespace = new Db4objects.Db4o.Consistency.SlotSource
			("Freespace");

		private readonly string _name;

		private SlotSource(string name)
		{
			_name = name;
		}

		public override string ToString()
		{
			return _name;
		}
	}
}
