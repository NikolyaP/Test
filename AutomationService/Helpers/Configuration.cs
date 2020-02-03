using System.Web.Configuration;

namespace AutomationService.Helpers
{
    public class Configuration
    {
        public static string ServiceUrl => WebConfigurationManager.AppSettings["baseUrl"];
    }
}
