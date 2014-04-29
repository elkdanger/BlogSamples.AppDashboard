using System.Threading.Tasks;

namespace AppDashboard
{
    public interface IDashboard
    {
        Task LogMessageAsync(string message, bool error = false);
    }
}
