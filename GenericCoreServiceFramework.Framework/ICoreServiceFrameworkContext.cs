using System;
using System.ServiceModel.Channels;
using Tridion.ContentManager.CoreService.Client;


namespace GenericCoreServiceFramework.Framework
{
    public interface ICoreServiceFrameworkContext : IDisposable
    {
        Uri EndpointUri { get; }
        ISessionAwareCoreService Client { get; }
        Binding GetBinding();
    }
}
