using Bioplugin.Cloudscanr.Csharp.Web.Sample.Utilities;
using System;

namespace Bioplugin.Cloudscanr.Csharp.Web.Sample
{
    public partial class AppConfiguration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("BioPluginHome.aspx");
        }

    }
}