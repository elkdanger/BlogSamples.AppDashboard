using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Logging;

namespace AppDashboard
{
    public class CustomLogFactory : ILoggerFactory
    {
        public ILogger Create(string name)
        {
            return new CustomLogger(name);
        }
    }
}
