using System;
using System.ComponentModel;
using System.Threading;

namespace AppDashboard.Host
{
    class Program
    {
        static bool _isRunning = true;

        static void Main(string[] args)
        {
            var dashboardHost = new AppDashboard.DashboardHost();
            var url = "http://localhost:9999";

            using(dashboardHost)
            {
                var dashboard = dashboardHost.Start(url);

                Console.WriteLine("Dashboard started at " + url);
                Console.WriteLine("Enter a log message or type 'quit' to exit");

                while(_isRunning)
                {
                    HandleInput(dashboard);    
                }
            }

            Console.ReadKey();
        }

        private static async void HandleInput(IDashboard dashboard)
        {
            Console.Write(": ");
            string cmd = Console.ReadLine().Trim();

            if (cmd.Equals("quit", StringComparison.CurrentCultureIgnoreCase))
            {
                _isRunning = false;
            }
            else
            {
                await dashboard.LogMessageAsync(cmd);
            }

            Console.WriteLine();
        }
    }
}
