/* Copyright (C) 2004 - 2011  Versant Inc.  http://www.db4o.com */

using Db4objects.Db4o.Consistency;
using Db4objects.Db4o.Foundation;
using Db4objects.Db4o.Internal;
using Db4objects.Db4o.Internal.Slots;
using Sharpen.Util;

namespace Db4objects.Db4o.Consistency
{
	internal class OverlapMap
	{
		private Sharpen.Util.ISet _dupes = new HashSet();

		private TreeIntObject _slots = null;

		private readonly IBlockConverter _blockConverter;

		public OverlapMap(IBlockConverter blockConverter)
		{
			_blockConverter = blockConverter;
		}

		public virtual void Add(Slot slot, SlotSource source)
		{
			Add(new SlotWithSource(slot, source));
		}

		public virtual void Add(SlotWithSource slot)
		{
			if (TreeIntObject.Find(_slots, new TreeIntObject(slot._slot.Address())) != null)
			{
				_dupes.Add(new Pair(ByAddress(slot._slot.Address()), slot));
			}
			_slots = (TreeIntObject)((TreeIntObject)TreeIntObject.Add(_slots, new TreeIntObject
				(slot._slot.Address(), slot)));
		}

		public virtual Sharpen.Util.ISet Overlaps()
		{
			Sharpen.Util.ISet overlaps = new HashSet();
			ByRef prevSlot = ByRef.NewInstance();
			TreeIntObject.Traverse(_slots, new _IVisitor4_33(this, prevSlot, overlaps));
			return overlaps;
		}

		private sealed class _IVisitor4_33 : IVisitor4
		{
			public _IVisitor4_33(OverlapMap _enclosing, ByRef prevSlot, Sharpen.Util.ISet overlaps
				)
			{
				this._enclosing = _enclosing;
				this.prevSlot = prevSlot;
				this.overlaps = overlaps;
			}

			public void Visit(object tree)
			{
				SlotWithSource curSlot = (SlotWithSource)((TreeIntObject)tree)._object;
				if (this.IsOverlap(((SlotWithSource)prevSlot.value), curSlot))
				{
					overlaps.Add(new Pair(((SlotWithSource)prevSlot.value), curSlot));
				}
				prevSlot.value = curSlot;
			}

			private bool IsOverlap(SlotWithSource prevSlot, SlotWithSource curSlot)
			{
				if (prevSlot == null)
				{
					return false;
				}
				return prevSlot._slot.Address() + this._enclosing._blockConverter.BytesToBlocks(prevSlot
					._slot.Length()) > curSlot._slot.Address();
			}

			private readonly OverlapMap _enclosing;

			private readonly ByRef prevSlot;

			private readonly Sharpen.Util.ISet overlaps;
		}

		public virtual Sharpen.Util.ISet Dupes()
		{
			return _dupes;
		}

		private SlotWithSource ByAddress(int address)
		{
			TreeIntObject tree = (TreeIntObject)TreeIntObject.Find(_slots, new TreeIntObject(
				address, null));
			return tree == null ? null : (SlotWithSource)tree._object;
		}
	}
}
