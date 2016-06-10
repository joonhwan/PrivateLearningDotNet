using System;
using System.Configuration;
using System.ServiceModel.Configuration;

namespace GeoService
{
    public class OperationReportServiceBehaviorExtension : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(OperationReportServiceBehaviorAttribute); }
        }

        [ConfigurationProperty("enabled")]
        public bool Enabled
        {
            get { return (bool)base["enabled"];  }
            set { base["enabled"] = value; }
        }

        protected override object CreateBehavior()
        {
            return new OperationReportServiceBehaviorAttribute(Enabled);
        }
    }
}