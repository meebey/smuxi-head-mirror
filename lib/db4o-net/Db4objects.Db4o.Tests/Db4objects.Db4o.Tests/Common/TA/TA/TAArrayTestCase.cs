/* Copyright (C) 2004 - 2011  Versant Inc.  http://www.db4o.com */

using Db4oUnit;
using Db4objects.Db4o.Tests.Common.TA;
using Db4objects.Db4o.Tests.Common.TA.TA;

namespace Db4objects.Db4o.Tests.Common.TA.TA
{
	/// <exclude></exclude>
	public class TAArrayTestCase : TAItemTestCaseBase
	{
		private static readonly int[] Ints1 = new int[] { 1, 2, 3 };

		private static readonly int[] Ints2 = new int[] { 4, 5, 6 };

		private static readonly LinkedList[] List1 = new LinkedList[] { LinkedList.NewList
			(5), LinkedList.NewList(5) };

		private static readonly LinkedList[] List2 = new LinkedList[] { LinkedList.NewList
			(5), LinkedList.NewList(5) };

		public static void Main(string[] args)
		{
			new TAArrayTestCase().RunAll();
		}

		/// <exception cref="System.Exception"></exception>
		protected override object CreateItem()
		{
			TAArrayItem item = new TAArrayItem();
			item.value = Ints1;
			item.obj = Ints2;
			item.lists = List1;
			item.listsObject = List2;
			return item;
		}

		/// <exception cref="System.Exception"></exception>
		protected override void AssertItemValue(object obj)
		{
			TAArrayItem item = (TAArrayItem)obj;
			ArrayAssert.AreEqual(Ints1, item.Value());
			ArrayAssert.AreEqual(Ints2, (int[])item.Object());
			ArrayAssert.AreEqual(List1, item.Lists());
			ArrayAssert.AreEqual(List2, (LinkedList[])item.ListsObject());
		}
	}
}
