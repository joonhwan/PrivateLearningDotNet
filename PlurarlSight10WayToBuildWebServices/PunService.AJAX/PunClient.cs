using System.ServiceModel;

namespace PunService.AJAX
{
    public class PunClient : ClientBase<IPunSerivce>, IPunSerivce
    {
        public string GetCookie(string id)
        {
            return Channel.GetCookie(id);
        }

        public PunComplexCookie GetCookieComplex(PunComplexCookieParameter parameter)
        {
            return Channel.GetCookieComplex(parameter);
        }

        public void DoNotCallMe_CorsOption()
        {
            return;
        }
    }
}