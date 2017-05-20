using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;

[assembly: OwinStartup(typeof(AI.Learning.API.Startup))]
namespace AI.Learning.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
            app.UseNinjectMiddleware(CreateKernel);
            app.UseNinjectWebApi(WebApiConfiguration());
        }

        #region WebApi Configurations
        private HttpConfiguration WebApiConfiguration()
        {
            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            return config;
        }
        #endregion

        #region Ninject Configurations
        private StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            RegisterServices(kernel);
            return kernel;
        }
        private void RegisterServices(KernelBase kernel)
        {
            // TODO - put in registrations here...
        }
        #endregion
    }
}
