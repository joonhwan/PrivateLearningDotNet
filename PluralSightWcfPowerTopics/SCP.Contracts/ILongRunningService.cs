﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SCP.Contracts
{
    [ServiceContract(CallbackContract = typeof(ILongRunningCallback))]
    public interface ILongRunningService
    {
        [OperationContract]
        void Connect();

        [OperationContract]
        void Disconnect();

        [OperationContract(IsOneWay = true)]
        void StartProcess();
    }
}
