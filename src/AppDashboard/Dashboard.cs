using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Logging;

namespace AppDashboard
{
    public class Dashboard : IDashboard
    {
        private ILogger _logger;

        public Dashboard(ILogger logger)
        {
            this._logger = logger;
        }

        public Task LogMessageAsync(string message, bool error = false)
        {
            return new TaskFactory().StartNew(() =>
            {
                if (!error)
                {
                    this._logger.WriteInformation(message);
                }
                else
                {
                    this._logger.WriteError(message);
                }
            });
        }
    }
}
