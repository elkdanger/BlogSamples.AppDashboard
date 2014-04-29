using Owin;
using Microsoft.Owin.Hosting;
using Microsoft.Owin.FileSystems;

namespace AppDashboard
{
    public class WebInterfaceOptions
    {
    }

    public static class AppBuilderExtensions
    {
        public static IAppBuilder UseDashboardInterface(this IAppBuilder app, WebInterfaceOptions options = null)
        {
            options = options ?? new WebInterfaceOptions();

            app.Use(async (context, next) =>
            {
                if (context.Request.Path.ToString() == "/")
                {
                    context.Response.ContentType = "text/html";
                    await context.Response.WriteAsync(WebResources.index_html);
                }

                if (context.Request.Path.ToString().Equals("/dashboard.js", System.StringComparison.OrdinalIgnoreCase))
                {
                    context.Response.ContentType = "text/javascript";
                    await context.Response.WriteAsync(WebResources.dashboard);
                }
                
                await next.Invoke();
            });

            return app;
        }
    }
}
