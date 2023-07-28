using Bioplugin.Cloudscanr.Csharp.Web.Sample.BioPluginService;
using Bioplugin.Cloudscanr.Csharp.Web.Sample.Utilities;
using System;

namespace Bioplugin.Cloudscanr.Csharp.Web.Sample
{
    public partial class Identify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        protected void btnIdentify_Click(object sender, EventArgs e)
        {

            try
            {
                serverResult.Text = "Start Identify...";
                string template = templateXML.Text.ToString();

                if (!string.IsNullOrEmpty(template))
                {
                    BioPluginServiceSoapClient bioPluginService = new BioPluginServiceSoapClient();
                    string leftTemplate = "";
                    string rightTemplate = "";
                    (leftTemplate, rightTemplate) = XMLParsing.CapturedDataParse(template);

                    string serviceResponse = "";
                    if (!string.IsNullOrEmpty(leftTemplate)
                        && !string.IsNullOrEmpty(rightTemplate))
                    {
                        serviceResponse = bioPluginService.Identify(leftTemplate, 1, 1, rightTemplate, 1, 1, 1);
                    }
                    else serviceResponse = bioPluginService.IdentifyQuick(leftTemplate, 1, 1, 1);

                    serverResult.Text = ResponseHelper.ProcessServerResult(serviceResponse, ResponseHelper.BPOperationName.Identify);

                }
                else
                {
                    serverResult.Text = "Please biometric capture first";
                }

            }
            catch (Exception ex)
            {
                serverResult.Visible = true;
                serverResult.Text = ex.Message;
            }
        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("BioPluginHome.aspx");
        }

    }
}