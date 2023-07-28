using Bioplugin.Cloudscanr.Csharp.Web.Sample.BioPluginService;
using Bioplugin.Cloudscanr.Csharp.Web.Sample.Utilities;
using System;

namespace Bioplugin.Cloudscanr.Csharp.Web.Sample
{
    public partial class IsRegistered : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
            }
        }

        protected void btnIsRegistered_Click(object sender, EventArgs e)
        {

            try
            {
                lblMessage.Text = "Start IsRegister operation...";
                if (!string.IsNullOrEmpty(txtRegisterID.Text.Trim().ToString()))
                {

                    string regID = txtRegisterID.Text.Trim().ToString();

                    BioPluginServiceSoapClient bioPluginService = new BioPluginServiceSoapClient();

                    string serviceResponse = bioPluginService.IsRegistered(regID, SessionManager.EngineName);
                    lblMessage.Text = ResponseHelper.ProcessServerResult(serviceResponse, ResponseHelper.BPOperationName.IsRegister);

                }
                else lblMessage.Text = "Please give an ID";
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("BioPluginHome.aspx");
        }
    }
}