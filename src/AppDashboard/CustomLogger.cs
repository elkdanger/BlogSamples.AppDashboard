using System;
using System.Diagnostics;
using Microsoft.Owin.Logging;

namespace AppDashboard
{
    public class CustomLogger : ILogger
    {
        public CustomLogger(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public bool WriteCore(TraceEventType eventType, int eventId, object state, Exception exception, Func<object, Exception, string> formatter)
        {
            if (state != null)
            {
                string message = string.Format("{0:f}\t{1}", DateTime.Now, formatter(state, exception));

                Console.WriteLine(message);

                // Write to our dashboard hub
                DashboardHub.Instance.LogMessage(new Message(formatter(state, exception)), eventType == TraceEventType.Error);
            }

            return true;
        }
    }
}
