/* Copyright (C) 2004 - 2009  Versant Inc.  http://www.db4o.com */

using Db4objects.Db4o.Bench.Logging.Replay.Commands;
using Db4objects.Db4o.IO;

namespace Db4objects.Db4o.Bench.Logging.Replay.Commands
{
	public class ReadCommand : ReadWriteCommand, IIoCommand
	{
		public ReadCommand(int length) : base(length)
		{
		}

		public virtual void Replay(IoAdapter adapter)
		{
			adapter.Read(PrepareBuffer(), _length);
		}
	}
}
