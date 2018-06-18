using System;
using System.Net;
using System.ServiceModel.Channels;

namespace GenericCoreServiceFramework.Framework
{
    public class CoreServiceFrameworkNetTcpContext : CoreServiceFrameworkContext
    {
        public CoreServiceFrameworkNetTcpContext(Uri endpointUri, NetworkCredential windowsNetworkCredentials)
            : base(endpointUri, windowsNetworkCredentials)
        {
        }

        public override Binding GetBinding()
        {
            var endpointBinding = new MaxedNetTcpBinding();
            return endpointBinding;
        }
    }
}
