using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Compression.Server;

namespace Microsoft.AspNet.SignalR.Compression.Tests.Common.Payloads
{
    [Payload]
    public class Event<T>
    {
        public T EventData { get; set; }
        public int EventId { get; set; }

    }
}
