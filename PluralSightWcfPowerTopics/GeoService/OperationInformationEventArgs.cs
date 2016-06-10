using System;

namespace GeoService
{
    public class OperationInformationEventArgs : EventArgs
    {
        public string ServiceName { get; set; }
        public string OperationName { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}