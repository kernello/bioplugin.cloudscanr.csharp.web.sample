using Bioplugin.Cloudscanr.Csharp.Web.Sample.BioPluginService;
using Bioplugin.Cloudscanr.Csharp.Web.Sample.Utilities;
using System;

namespace Bioplugin.Cloudscanr.Csharp.Web.Sample
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                serverResult.Text = "Start regiteration...";
                string template = templateXML.Text.ToString();
                string regID = txtRegID.Text.ToString();

                if (!string.IsNullOrEmpty(template) && !string.IsNullOrEmpty(regID))
                {
                    BioPluginServiceSoapClient bioPluginService = new BioPluginServiceSoapClient();
                    string leftTemplate = "";
                    string rightTemplate = "";
                    (leftTemplate, rightTemplate) = XMLParsing.CapturedDataParse(template);

                    string serviceResponse = "";
                    if (!string.IsNullOrEmpty(leftTemplate)
                        && !string.IsNullOrEmpty(rightTemplate))
                    {
                        serviceResponse = bioPluginService.Register(leftTemplate, 1, rightTemplate, 1, regID, 1);
                    }
                    else serviceResponse = bioPluginService.RegisterSingle(leftTemplate, 1, regID, 1);
                    serverResult.Text = ResponseHelper.ProcessServerResult(serviceResponse, ResponseHelper.BPOperationName.Register);

                }
                else if (string.IsNullOrEmpty(regID))
                {
                    serverResult.Text = "Please put registration id first";
                }
                else
                    serverResult.Text = "Please biometric capture first";
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