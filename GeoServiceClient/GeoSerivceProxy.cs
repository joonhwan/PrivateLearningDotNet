using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using GeoService;

namespace GeoServiceClient
{
    public class GeoSerivceProxy : ClientBase<IGeoService>, IGeoService
    {
        public GeoSerivceProxy()
        {
        }

        public GeoSerivceProxy(string endpointName)
            : base(endpointName)
        {
        }

        public GeoSerivceProxy(Binding binding, EndpointAddress address)
            : base(binding, address)
        {
        }

        public GeoInfo GetGeoInfoByZipCode(int zipCode)
        {
            return Channel.GetGeoInfoByZipCode(zipCode);
        }

        public List<ZipCode> GetZipCodes()
        {
            return Channel.GetZipCodes();
        }
    }
}