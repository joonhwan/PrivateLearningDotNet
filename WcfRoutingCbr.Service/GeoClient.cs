using System.CodeDom;
using System.ServiceModel;

namespace WcfRoutingCbr.Service
{
    public class GeoClient : ClientBase<IGeoService>, IGeoService
    {
        public GeoClient(string endpointName=null)
            : base(endpointName ?? "GeoService")
        {
            
        }

        public string GetStateNameByZipCode(int zipCode)
        {
            return Channel.GetStateNameByZipCode(zipCode);
        }

        public void Broadcast(string message)
        {
            Channel.Broadcast(message);
        }
    }
}