using System;
using Owin;
using Microsoft.Owin.Hosting;
using Microsoft.Owin.Logging;

namespace AppDashboard
{
    public class DashboardHost : IDisposable
    {
        private IDisposable _webApp;

        public IDashboard Start(string url)
        {
            IDashboard dashboard = null;

            this._webApp = WebApp.Start(url, app =>
            {
                app.SetLoggerFactory(new CustomLogFactory());

                var logger = app.CreateLogger("App Dashboard");

                dashboard = new Dashboard(logger);

                app.MapSignalR();
                app.UseDashboardInterface();
            });

            return dashboard;
        }

        public void Dispose()
        {
            if (this._webApp != null)
            {
                this._webApp.Dispose();
                this._webApp = null;
            }
        }
    }
}
