/* Copyright (C) 2004 - 2011  Versant Inc.  http://www.db4o.com */

using Db4objects.Db4o.CS.Internal;

namespace Db4objects.Db4o.CS.Internal
{
	public interface IBroadcastFilter
	{
		bool Accept(IServerMessageDispatcher dispatcher);
	}
}
