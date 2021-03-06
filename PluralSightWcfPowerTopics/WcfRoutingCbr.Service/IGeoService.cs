﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfRoutingCbr.Service
{
    [ServiceContract]
    public interface IGeoService
    {
        [OperationContract]
        string GetStateNameByZipCode(int zipCode);

        [OperationContract(IsOneWay = true, Action = "http://anyurlyouwant/geoservice/broadcast")]
        void Broadcast(string message);
    }
}
