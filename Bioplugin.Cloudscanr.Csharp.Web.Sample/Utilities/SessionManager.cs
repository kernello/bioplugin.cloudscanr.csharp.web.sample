using System.Web;

namespace Bioplugin.Cloudscanr.Csharp.Web.Sample.Utilities
{
    public class SessionManager
    {
        public static string EngineName
        {
            get { return (string)HttpContext.Current.Session["BioPluginEngineName"]; }
            set { HttpContext.Current.Session["BioPluginEngineName"] = value; }
        }
        public static string DeviceName
        {
            get { return (string)HttpContext.Current.Session["BioPluginDeviceName"]; }
            set { HttpContext.Current.Session["BioPluginDeviceName"] = value; }
        }

    }

}