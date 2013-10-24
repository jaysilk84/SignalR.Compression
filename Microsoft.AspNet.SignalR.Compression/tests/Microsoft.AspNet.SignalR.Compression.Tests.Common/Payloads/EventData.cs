using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Compression.Server;

namespace Microsoft.AspNet.SignalR.Compression.Tests.Common.Payloads
{
    [Payload]
    public class EventData<T>
    {
        public T Property { get; set; }
    }
}
