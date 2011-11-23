/* Copyright (C) 2004 - 2009  Versant Inc.  http://www.db4o.com */

using System;
using Db4objects.Db4o.CS.Internal.Messages;
using Db4objects.Db4o.Internal;

namespace Db4objects.Db4o.CS.Internal.Messages
{
	public class MRequestExceptionWithResponse : MsgD, IMessageWithResponse
	{
		public virtual Msg ReplyFromServer()
		{
			Platform4.ThrowUncheckedException((Exception)ReadSingleObject());
			return null;
		}
	}
}
