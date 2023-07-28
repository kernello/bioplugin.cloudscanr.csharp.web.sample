
using Bioplugin.Cloudscanr.Csharp.Web.Sample.BioPluginService;
using Bioplugin.Cloudscanr.Csharp.Web.Sample.Utilities;
using System;

namespace Bioplugin.Cloudscanr.Csharp.Web.Sample
{
    public partial class ChangeID : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
            }
        }

        protected void btnChangeID_Click(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = "Start Change ID operation...";
                if (!string.IsNullOrEmpty(txtOldID.Text.Trim().ToString()) && !string.IsNullOrEmpty(txtNewID.Text.Trim().ToString()))
                {
                    string newID = txtNewID.Text.Trim().ToString();
                    string oldID = txtOldID.Text.Trim().ToString();

                   BioPluginServiceSoapClient bioPluginService = new BioPluginServiceSoapClient();

                    string serviceResponse = bioPluginService.ChangeID(oldID, newID, SessionManager.EngineName);
                    lblMessage.Text = ResponseHelper.ProcessServerResult(serviceResponse, ResponseHelper.BPOperationName.ChangeID);

                }
                else if (string.IsNullOrEmpty(txtNewID.Text.Trim())) lblMessage.Text = "Please give New ID";
                else if (string.IsNullOrEmpty(txtOldID.Text.Trim())) lblMessage.Text = "Please give Old ID";
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