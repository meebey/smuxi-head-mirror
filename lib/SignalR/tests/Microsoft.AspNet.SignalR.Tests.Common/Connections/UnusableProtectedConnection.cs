﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.AspNet.SignalR.FunctionalTests
{
    public class UnusableProtectedConnection : PersistentConnection
    {
        protected override bool AuthorizeRequest(IRequest request)
        {
            return false;
        }
    }
}
