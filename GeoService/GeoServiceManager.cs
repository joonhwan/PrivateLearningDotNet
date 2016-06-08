using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace GeoService
{
    [ServiceBehavior()]
    public class GeoServiceManager : IGeoService
    {
        public GeoServiceManager()
        {
        }

        public GeoInfo GetGeoInfoByZipCode(int zipCode)
        {
            return new GeoInfo()
            {
                AreaName = string.Format("Area of {0}", zipCode),
            };
        }

        public List<ZipCode> GetZipCodes()
        {
            return new List<ZipCode>
            {
                new ZipCode{ Code = 1, State = "Yongin" },
                new ZipCode{ Code = 2, State = "Suwon" },
                new ZipCode{ Code = 3, State = "Seoul" },
                new ZipCode{ Code = 4, State = "Bundang" },
                new ZipCode{ Code = 5, State = "Daejoen" },
                new ZipCode{ Code = 6, State = "Busan" },
            };
        }

    }
}