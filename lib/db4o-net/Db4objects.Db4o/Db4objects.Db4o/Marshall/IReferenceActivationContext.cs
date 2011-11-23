/* Copyright (C) 2004 - 2009  Versant Inc.  http://www.db4o.com */

using Db4objects.Db4o.Marshall;

namespace Db4objects.Db4o.Marshall
{
	/// <summary>this interface is passed to reference type handlers.</summary>
	/// <remarks>this interface is passed to reference type handlers.</remarks>
	public interface IReferenceActivationContext : IReadContext
	{
		object PersistentObject();
	}
}
