/* Copyright (C) 2004 - 2009  Versant Inc.  http://www.db4o.com */

using Db4objects.Db4o.Query;
using Db4objects.Db4o.Tests.Common.Soda.Util;

namespace Db4objects.Db4o.Tests.Common.Soda.Arrays.Typed
{
	public class STArrStringTTestCase : SodaBaseTestCase
	{
		public string[] strArr;

		public STArrStringTTestCase()
		{
		}

		public STArrStringTTestCase(string[] arr)
		{
			strArr = arr;
		}

		public override object[] CreateData()
		{
			return new object[] { new Db4objects.Db4o.Tests.Common.Soda.Arrays.Typed.STArrStringTTestCase
				(), new Db4objects.Db4o.Tests.Common.Soda.Arrays.Typed.STArrStringTTestCase(new 
				string[] { null }), new Db4objects.Db4o.Tests.Common.Soda.Arrays.Typed.STArrStringTTestCase
				(new string[] { null, null }), new Db4objects.Db4o.Tests.Common.Soda.Arrays.Typed.STArrStringTTestCase
				(new string[] { "foo", "bar", "fly" }), new Db4objects.Db4o.Tests.Common.Soda.Arrays.Typed.STArrStringTTestCase
				(new string[] { null, "bar", "wohay", "johy" }) };
		}

		public virtual void TestDefaultContainsOne()
		{
			IQuery q = NewQuery();
			q.Constrain(new Db4objects.Db4o.Tests.Common.Soda.Arrays.Typed.STArrStringTTestCase
				(new string[] { "bar" }));
			Expect(q, new int[] { 3, 4 });
		}

		public virtual void TestDefaultContainsTwo()
		{
			IQuery q = NewQuery();
			q.Constrain(new Db4objects.Db4o.Tests.Common.Soda.Arrays.Typed.STArrStringTTestCase
				(new string[] { "foo", "bar" }));
			Expect(q, new int[] { 3 });
		}

		public virtual void TestDescendOne()
		{
			IQuery q = NewQuery();
			q.Constrain(typeof(Db4objects.Db4o.Tests.Common.Soda.Arrays.Typed.STArrStringTTestCase
				));
			q.Descend("strArr").Constrain("bar");
			Expect(q, new int[] { 3, 4 });
		}

		public virtual void TestDescendTwo()
		{
			IQuery q = NewQuery();
			q.Constrain(typeof(Db4objects.Db4o.Tests.Common.Soda.Arrays.Typed.STArrStringTTestCase
				));
			IQuery qElements = q.Descend("strArr");
			qElements.Constrain("foo");
			qElements.Constrain("bar");
			Expect(q, new int[] { 3 });
		}

		public virtual void TestDescendOneNot()
		{
			IQuery q = NewQuery();
			q.Constrain(typeof(Db4objects.Db4o.Tests.Common.Soda.Arrays.Typed.STArrStringTTestCase
				));
			q.Descend("strArr").Constrain("bar").Not();
			Expect(q, new int[] { 0, 1, 2 });
		}

		public virtual void TestDescendTwoNot()
		{
			IQuery q = NewQuery();
			q.Constrain(typeof(Db4objects.Db4o.Tests.Common.Soda.Arrays.Typed.STArrStringTTestCase
				));
			IQuery qElements = q.Descend("strArr");
			qElements.Constrain("foo").Not();
			qElements.Constrain("bar").Not();
			Expect(q, new int[] { 0, 1, 2 });
		}
	}
}
