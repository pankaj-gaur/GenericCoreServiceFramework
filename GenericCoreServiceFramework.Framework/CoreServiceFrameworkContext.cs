using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Tridion.ContentManager.CoreService.Client;

namespace GenericCoreServiceFramework.Framework
{
    public abstract class CoreServiceFrameworkContext : ICoreServiceFrameworkContext
    {
        protected Uri _endpointUri = null;
        public Uri EndpointUri
        {
            get
            {
                return _endpointUri;
            }
        }

        protected SessionAwareCoreServiceClient _client = null;
        public ISessionAwareCoreService Client
        {
            get
            {
                return _client;
            }
        }

        protected CoreServiceFrameworkContext(Uri endpointUri, NetworkCredential windowsNetworkCredentials)
        {
            _endpointUri = endpointUri;
            var endpointBinding = this.GetBinding();

            var endpointAddress = new EndpointAddress(endpointUri);

            _client = new SessionAwareCoreServiceClient(endpointBinding, endpointAddress);

            if (windowsNetworkCredentials != null)
            {
                _client.ChannelFactory.Credentials.Windows.ClientCredential = windowsNetworkCredentials;
            }

            if (_client.State == CommunicationState.Created)
            {
                _client.Open();
            }

        }

        public abstract Binding GetBinding();

        public void Dispose()
        {
            if (_client != null)
            {
                switch (_client.State)
                {
                    case CommunicationState.Faulted:
                        _client.Abort();
                        break;
                    case CommunicationState.Opened:
                        _client.Close();
                        break;
                }
                var disposable = _client as IDisposable;
                if (disposable != null) disposable.Dispose();
            }

        }

    }
}
