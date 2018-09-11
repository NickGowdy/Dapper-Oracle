using System.Configuration;

namespace Dapper.Oracle.Configurations
{
    public class UrlConfigurations
    {
        public static string GetFoo { get; } = ConfigurationManager.AppSettings["Your_Stored_Procedure/View_Name"];
        public static string GetFoos { get; } = ConfigurationManager.AppSettings["Your_Stored_Procedure/View_Name"];
    }
}
