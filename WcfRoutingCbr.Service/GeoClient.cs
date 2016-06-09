using System.ServiceModel;

namespace WcfRoutingCbr.Service
{
    public class GeoClient : ClientBase<IGeoService>, IGeoService
    {
        public string GetStateNameByZipCode(int zipCode)
        {
            return Channel.GetStateNameByZipCode(zipCode);
        }
    }
}