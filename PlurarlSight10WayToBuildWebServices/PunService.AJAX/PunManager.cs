using System;
using System.ServiceModel.Web;

namespace PunService.AJAX
{
    public class PunManager : IPunSerivce
    {
        public string GetCookie(string id)
        {
            Console.WriteLine("Cookie has been requested : id={0}", id);
            return string.Format("Cookie[{0}]", id);
        }

        public PunComplexCookie GetCookieComplex(PunComplexCookieParameter parameter)
        {
            Console.WriteLine("Cookie has been requested : {0}", parameter);

            var cookie = new PunComplexCookie()
            {
                Cookie = string.Format("{0}-{1}-{2}-{3}", parameter.Name, parameter.Age, parameter.Degree, parameter.IsActive),
                Evaluation = parameter.Degree > 0.5 ? "GD" : "NG"
            };
            return cookie;
        }
    }
}