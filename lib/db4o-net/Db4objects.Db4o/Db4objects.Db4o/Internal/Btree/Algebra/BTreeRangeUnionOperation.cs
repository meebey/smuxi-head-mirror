/* Copyright (C) 2004 - 2011  Versant Inc.  http://www.db4o.com */

using Db4objects.Db4o.Internal.Btree;
using Db4objects.Db4o.Internal.Btree.Algebra;

namespace Db4objects.Db4o.Internal.Btree.Algebra
{
	/// <exclude></exclude>
	public abstract class BTreeRangeUnionOperation : BTreeRangeOperation
	{
		protected readonly BTreeRangeUnion _union;

		public BTreeRangeUnionOperation(BTreeRangeUnion union)
		{
			_union = union;
		}
	}
}
