using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GeoService
{
    [ServiceContract]
    public interface IGeoService
    {
        [OperationContract]
        GeoInfo GetGeoInfoByZipCode(int zipCode);
        [OperationContract]
        List<ZipCode> GetZipCodes();
    }
}
