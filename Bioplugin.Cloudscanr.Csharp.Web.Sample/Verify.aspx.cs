using Bioplugin.Cloudscanr.Csharp.Web.Sample.BioPluginService;
using Bioplugin.Cloudscanr.Csharp.Web.Sample.Utilities;
using System;

namespace Bioplugin.Cloudscanr.Csharp.Web.Sample
{
    public partial class Verify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    lblCurrentDeviceName.Text = Request.Cookies["BioPluginDeviceName"].Value.ToString();
                }
                catch (Exception)
                {

                }
            }
        }
        protected void btnVerify_Click(object sender, EventArgs e)
        {
            try
            {
                serverResult.Text = "Start verify...";
                string template = templateXML.Text.ToString();
                string verifyID = txtVerifyID.Text.ToString();
               

                if (!string.IsNullOrEmpty(template) && !string.IsNullOrEmpty(verifyID))
                {
                    BioPluginServiceSoapClient bioPluginService = new BioPluginServiceSoapClient();
                    string leftTemplate = "";
                    string rightTemplate = "";
                    (leftTemplate, rightTemplate) = XMLParsing.CapturedDataParse(template);

                    string serviceResponse = "";
                    if (!string.IsNullOrEmpty(leftTemplate)
                        && !string.IsNullOrEmpty(rightTemplate))
                    {
                        serviceResponse = bioPluginService.Verify(leftTemplate, rightTemplate, verifyID, 1);
                    }
                    else serviceResponse = bioPluginService.VerifySingle(leftTemplate, verifyID, 1);

                    serverResult.Text = ResponseHelper.ProcessServerResult(serviceResponse, ResponseHelper.BPOperationName.Verify);

                }
                else if (string.IsNullOrEmpty(verifyID))
                {
                    serverResult.Text = "Please put verify id first";
                }
                else
                    serverResult.Text = "Please capture the biometric data first";
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