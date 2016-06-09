using System;
using System.ServiceModel;

namespace WcfRoutingCbr.Service
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class GeoManager : IGeoService
    {
        public string GetStateNameByZipCode(int zipCode)
        {
            Console.WriteLine("GeoManager1 : GetStateNameByZipCode({0}) : ", zipCode);
            return string.Format("STATE{0}", zipCode);
        }
    }

    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class GeoManager2 : IGeoService
    {
        public string GetStateNameByZipCode(int zipCode)
        {
            Console.WriteLine("GeoManager2 : GetStateNameByZipCode({0}) : ", zipCode);
            return string.Format("BIGSTATE{0}", zipCode);
        }
    }
}