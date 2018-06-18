using System;
using System.ServiceModel;
using System.Xml;

namespace GenericCoreServiceFramework.Framework
{
    public class MaxedWsHttpBinding : WSHttpBinding
    {
        public MaxedWsHttpBinding(SecurityMode securityMode)
            : base(securityMode)
        {
            initializeMaxSettings();
        }

        public MaxedWsHttpBinding()
            : base()
        {
            initializeMaxSettings();
        }

        private void initializeMaxSettings()
        {
            this.CloseTimeout = new TimeSpan(0, 5, 0);
            this.OpenTimeout = new TimeSpan(0, 5, 0);
            this.ReceiveTimeout = new TimeSpan(0, 5, 0);
            this.SendTimeout = new TimeSpan(0, 5, 0);
            this.MaxReceivedMessageSize = Int32.MaxValue;

            this.MaxBufferPoolSize = Int32.MaxValue;
            this.MaxReceivedMessageSize = Int32.MaxValue;
            this.ReaderQuotas = new XmlDictionaryReaderQuotas
            {
                MaxDepth = Int32.MaxValue,
                MaxStringContentLength = Int32.MaxValue,
                MaxArrayLength = Int32.MaxValue
            };
        }

    }

}

