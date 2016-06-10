using System.Runtime.Serialization;

namespace PunService.AJAX
{
    [DataContract]
    public class PunComplexCookieParameter
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Age { get; set; }

        [DataMember]
        public float Degree { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        public override string ToString()
        {
            return string.Format("Name: {0}, Age: {1}, Degree: {2}, IsActive: {3}", Name, Age, Degree, IsActive);
        }
    }

    [DataContract]
    public class PunComplexCookie
    {
        [DataMember]
        public string Cookie { get; set; }

        [DataMember]
        public string Evaluation { get; set; }

        public override string ToString()
        {
            return string.Format("Cookie: {0}, Evaluation: {1}", Cookie, Evaluation);
        }
    }
}