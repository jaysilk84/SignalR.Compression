using System.Diagnostics.Contracts;
using System.Web.Routing;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Compression.Server;
using Microsoft.AspNet.SignalR.Compression.Server.SystemWeb;
using Owin;

namespace Microsoft.AspNet.SignalR.Compression.Server.SystemWeb
{
    public static class CompressionBaseExtensions
    {
        public static void CompressPayloads(this CompressionBase compressionBase, IAppBuilder builder, string path = "/compression/contracts")
        {
            //routes..Map<ContractEndpoint>("compression/contracts", "compression/contracts");
            //routes.MapConnection<ContractEndpoint>("", "");
            builder.MapSignalR<ContractEndpoint>(path);
            compressionBase.CompressPayloads();
            
            
        }
    }
}
