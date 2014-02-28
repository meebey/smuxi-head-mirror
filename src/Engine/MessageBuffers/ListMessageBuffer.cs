// Smuxi - Smart MUltipleXed Irc
//
// Copyright (c) 2010-2011 Mirco Bauer <meebey@meebey.net>
//
// Full GPL License: <http://www.gnu.org/licenses/gpl.txt>
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307 USA

using System;
using System.Collections.Generic;

namespace Smuxi.Engine
{
    public class ListMessageBuffer : List<MessageModel>, IMessageBuffer
    {
        int f_MaxCapacity;

        public int MaxCapacity {
            get {
                return f_MaxCapacity;
            }
            set {
                f_MaxCapacity = value;
                Capacity = f_MaxCapacity;
            }
        }

        public ListMessageBuffer()
        {
        }

        public new void Add(MessageModel item)
        {
            if (MaxCapacity > 0 && Count >= MaxCapacity) {
                RemoveAt(0);
            }
            base.Add(item);
        }

        IList<MessageModel> IMessageBuffer.GetRange(int offset, int limit)
        {
            // clamp limit to count
            if (offset + limit > Count) {
                limit = Count - offset;
            }
            return base.GetRange(offset, limit);
        }

        public void Flush()
        {
            // NOOP
        }

        public void Dispose()
        {
            // NOOP
        }
    }
}
