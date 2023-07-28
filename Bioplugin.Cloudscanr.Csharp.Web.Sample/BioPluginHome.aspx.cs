using Bioplugin.Cloudscanr.Csharp.Web.Sample.Utilities;
using System;

namespace Bioplugin.Cloudscanr.Csharp.Web.Sample
{
    public partial class BioPluginHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SessionManager.EngineName = EngineName();
                SessionManager.DeviceName = DeviceName();
                //
                lblStatus.Text = "Device: " + SessionManager.DeviceName + ", Engine: " + SessionManager.EngineName;

            }
        }


        #region Configuration

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string EngineName()
        {
            try
            {
                return Request.Cookies["BioPluginEngineName"].Value.ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string DeviceName()
        {
            try
            {
                return Request.Cookies["BioPluginDeviceName"].Value.ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion
        

        protected void lnkIsRegistered_Click(object sender, EventArgs e)
        {
            Response.Redirect("IsRegistered.aspx");
        }

        protected void lnkChangeID_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangeID.aspx");
        }

        protected void lnkDeleteID_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeleteID.aspx");
        }

        protected void lnkRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void lnkIdentify_Click(object sender, EventArgs e)
        {
            Response.Redirect("Identify.aspx");
        }

        protected void lnkVerify_Click(object sender, EventArgs e)
        {
            Response.Redirect("Verify.aspx");
        }
        protected void lnkUpdate_Click(object sender, EventArgs e)
        {
            Response.Redirect("Update.aspx");
        }
    }
}