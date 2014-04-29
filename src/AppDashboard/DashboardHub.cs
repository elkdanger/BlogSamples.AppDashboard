using System;
using Microsoft.AspNet.SignalR;

namespace AppDashboard
{
    /// <summary>
    /// http://www.asp.net/signalr/overview/signalr-20/hubs-api/hubs-api-guide-server#callfromoutsidehub
    /// </summary>
    public class DashboardHub : Hub
    {
        private readonly static Lazy<DashboardHub> _instance = new Lazy<DashboardHub>(
            () => new DashboardHub(GlobalHost.ConnectionManager.GetHubContext<DashboardHub>()));

        private IHubContext _context;

        private DashboardHub(IHubContext context)
        {
            this._context = context;
        }

        public static DashboardHub Instance
        {
            get { return _instance.Value; }
        }

        public void LogMessage(Message message, bool isError = false)
        {
            this._context.Clients.All.logMessage(message, isError);
        }
    }
}
