/* Copyright (C) 2004 - 2009  Versant Inc.  http://www.db4o.com */

#if !SILVERLIGHT
using System;
using Db4oUnit.Fixtures;
using Db4objects.Db4o.Tests.Common.Events;

namespace Db4objects.Db4o.Tests.Common.Staging
{
	public class OwnCommitCallbackFlaggedEmbeddedTestSuite : FixtureBasedTestSuite
	{
		public class Item
		{
			public int _id;

			public Item(int id)
			{
				_id = id;
			}
		}

		public override IFixtureProvider[] FixtureProviders()
		{
			return new IFixtureProvider[] { new SimpleFixtureProvider(OwnCommittedCallbacksFixture
				.Factory, new OwnCommittedCallbacksFixture.IContainerFactory[] { new OwnCommittedCallbacksFixture.EmbeddedCSContainerFactory
				(), new OwnCommittedCallbacksFixture.EmbeddedSessionContainerFactory() }), new SimpleFixtureProvider
				(OwnCommittedCallbacksFixture.Action, new OwnCommittedCallbacksFixture.CommitAction
				[] { new OwnCommittedCallbacksFixture.ClientACommitAction(), new OwnCommittedCallbacksFixture.ClientBCommitAction
				() }) };
		}

		public override Type[] TestUnits()
		{
			return new Type[] { typeof(OwnCommittedCallbacksFixture.OwnCommitCallbackFlaggedTestUnit
				) };
		}
	}
}
#endif // !SILVERLIGHT
