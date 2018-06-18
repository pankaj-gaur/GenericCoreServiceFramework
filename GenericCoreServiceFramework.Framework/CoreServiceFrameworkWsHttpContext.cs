using System;
using System.Net;
using System.ServiceModel.Channels;

namespace GenericCoreServiceFramework.Framework
{
    public class CoreServiceFrameworkWsHttpContext : CoreServiceFrameworkContext
    {
        public CoreServiceFrameworkWsHttpContext(Uri endpointUri, NetworkCredential windowsNetworkCredentials)
            : base(endpointUri, windowsNetworkCredentials)
        {
            
        }

        public override Binding GetBinding()
        {
            var endpointBinding = new MaxedWsHttpBinding();
            return endpointBinding;
        }
    }
}
