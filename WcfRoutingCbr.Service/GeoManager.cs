using System.ServiceModel;

namespace WcfRoutingCbr.Service
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class GeoManager : IGeoService
    {
        public string GetStateNameByZipCode(int zipCode)
        {
            return string.Format("STATE{0}", zipCode);
        }
    }
}