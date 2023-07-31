using Bioplugin.Cloudscanr.Csharp.Web.Sample.BioPluginService;
using Bioplugin.Cloudscanr.Csharp.Web.Sample.Utilities;
using System;

namespace Bioplugin.Cloudscanr.Csharp.Web.Sample
{
    public partial class Update : System.Web.UI.Page
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


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                serverResult.Text = "Start updating...";
                string template = templateXML.Text.ToString();
                string updateID = txtUpdateID.Text.ToString();

                if (!string.IsNullOrEmpty(template) && !string.IsNullOrEmpty(updateID))
                {
                    BioPluginServiceSoapClient bioPluginService = new BioPluginServiceSoapClient();

                    string leftTemplate = "";
                    string rightTemplate = "";
                    (leftTemplate, rightTemplate) = XMLParsing.CapturedDataParse(template);

                    string serviceResponse = "";
                    if (!string.IsNullOrEmpty(leftTemplate)
                        && !string.IsNullOrEmpty(rightTemplate))
                    {
                        serviceResponse = bioPluginService.Update(leftTemplate, 1, rightTemplate, 1, updateID, 1);
                    }
                    else serviceResponse = bioPluginService.UpdateSingle(leftTemplate, 1, updateID, 1);

                    serverResult.Text = ResponseHelper.ProcessServerResult(serviceResponse, ResponseHelper.BPOperationName.Update);

                }
                else if (string.IsNullOrEmpty(updateID))
                {
                    serverResult.Text = "Please put update id first";
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