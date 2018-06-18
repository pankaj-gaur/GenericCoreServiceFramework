using System;
using System.ServiceModel;
using System.Xml;

namespace GenericCoreServiceFramework.Framework
{
    public class MaxedNetTcpBinding : NetTcpBinding
    {
        public MaxedNetTcpBinding(SecurityMode securityMode)
            : base(securityMode)
        {
            initializeMaxSettings();
        }

        public MaxedNetTcpBinding()
            : base()
        {
            initializeMaxSettings();   
        }

        private void initializeMaxSettings()
        {
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
