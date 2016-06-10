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
        [FaultContract(typeof(ArgumentException))]
        GeoInfo GetGeoInfoByZipCode(int zipCode);
        [OperationContract]
        List<ZipCode> GetZipCodes();
    }
}
