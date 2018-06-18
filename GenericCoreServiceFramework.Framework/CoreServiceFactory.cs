using System;
using System.Net;

namespace GenericCoreServiceFramework.Framework
{
    public static class CoreServiceConnectionProtocol
    {
        public const String netTcp = "net.tcp";
        public const String wsHttp = "http";
        public const String undefined = "undefined";
    }

    public static class CoreServiceFactory
    {
        public static ICoreServiceFrameworkContext GetCoreServiceContext(Uri endpointUri, NetworkCredential networkCredentials)
        {
            switch (endpointUri.Scheme.ToLower())
            {
                case CoreServiceConnectionProtocol.wsHttp:
                    return GetWsHttpContext(endpointUri, networkCredentials);
                case CoreServiceConnectionProtocol.netTcp:
                    return GetNetTcpContext(endpointUri, networkCredentials);
                default:
                    throw new ArgumentException("The uri connection scheme specified [{0}] is not correct; a valid scheme (ie. http for WsHttp, or net.tcp for NetTcp must be specified).");
            }
        }

        public static ICoreServiceFrameworkContext GetWsHttpContext(Uri endpointUri, NetworkCredential windowsNetworkCredentials)
        {
            return new CoreServiceFrameworkWsHttpContext(endpointUri, windowsNetworkCredentials);
        }

        public static ICoreServiceFrameworkContext GetNetTcpContext(Uri endpointUri, NetworkCredential windowsNetworkCredentials)
        {
            return new CoreServiceFrameworkNetTcpContext(endpointUri, windowsNetworkCredentials);
        }
    }
}
