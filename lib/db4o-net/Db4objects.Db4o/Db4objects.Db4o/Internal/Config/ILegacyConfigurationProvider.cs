/* Copyright (C) 2004 - 2011  Versant Inc.  http://www.db4o.com */

using Db4objects.Db4o.Internal;

namespace Db4objects.Db4o.Internal.Config
{
	public interface ILegacyConfigurationProvider
	{
		Config4Impl Legacy();
	}
}
