using System.Runtime.Serialization;

namespace GeoService
{
    [DataContract]
    public class GeoInfo
    {
        [DataMember]
        public string AreaName { get; set; }

        public override string ToString()
        {
            return string.Format("AreaName: {0}", AreaName);
        }
    }
}