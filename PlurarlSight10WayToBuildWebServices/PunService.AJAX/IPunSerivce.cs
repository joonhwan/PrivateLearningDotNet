using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using WcfCors;

namespace PunService.AJAX
{
    [ServiceContract]
    public interface IPunSerivce
    {
        [OperationContract]
        [WebGet(UriTemplate = "cookie/{id}", ResponseFormat = WebMessageFormat.Json)]
        string GetCookie(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", 
            UriTemplate = "cookieComplex", // 만일 여기에 "cookieComplex/" 와 같이 하면, redirect 307 오류가 발생한다(redirect를 따라면 호출이 성공하는 것 같다.)
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json
            )]
        [CorsEnabled]
        PunComplexCookie GetCookieComplex(PunComplexCookieParameter parameter);
    }
}
