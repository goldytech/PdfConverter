namespace PdfConverter.WebApi
{
    using System.Web.Http;

    using Contoso.PdfConverter.WebApi;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            UnityConfig.RegisterComponents();
        }
    }
}
