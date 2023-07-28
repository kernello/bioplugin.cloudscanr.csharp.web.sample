
using Bioplugin.Cloudscanr.Csharp.Web.Sample.BioPluginService;
using Bioplugin.Cloudscanr.Csharp.Web.Sample.Utilities;
using System;

namespace Bioplugin.Cloudscanr.Csharp.Web.Sample
{
    public partial class DeleteID : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }
        protected void btnDeleteID_Click(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = "Start Delete ID operation...";
                if (!string.IsNullOrEmpty(txtDeleteID.Text.Trim().ToString()))
                {
                    string deleteID = txtDeleteID.Text.Trim().ToString();

                    BioPluginServiceSoapClient bioPluginService = new BioPluginServiceSoapClient();

                    string serviceResponse = bioPluginService.DeleteID(deleteID, SessionManager.EngineName);
                    lblMessage.Text = ResponseHelper.ProcessServerResult(serviceResponse, ResponseHelper.BPOperationName.DeleteID);

                }
                else lblMessage.Text = "Please give Delete ID";
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