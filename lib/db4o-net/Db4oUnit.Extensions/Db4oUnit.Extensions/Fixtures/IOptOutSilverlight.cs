/* Copyright (C) 2004 - 2009  Versant Inc.  http://www.db4o.com */

using Db4oUnit.Extensions.Fixtures;

namespace Db4oUnit.Extensions.Fixtures
{
	/// <summary>
	/// Marker interface to denote that implementing test cases should be excluded
	/// from running in silverlight environment.
	/// </summary>
	/// <remarks>
	/// Marker interface to denote that implementing test cases should be excluded
	/// from running in silverlight environment.
	/// </remarks>
	public interface IOptOutSilverlight : IOptOutFromTestFixture
	{
	}
}
