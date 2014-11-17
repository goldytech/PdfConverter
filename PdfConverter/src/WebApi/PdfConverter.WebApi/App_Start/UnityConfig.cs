using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace Contoso.PdfConverter.WebApi
{
    using Contoso.PdfConverter.DataAccess;
    using Contoso.PdfConverter.DataAccess.Contracts;
    using Contoso.PdfConverter.Library;
    using Contoso.PdfConverter.Library.Contracts;

    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<IAppUnitOfWork, AppUnitOfWork>(new TransientLifetimeManager());

            container.RegisterType<IPdfConversionService, PdfConversionService>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}