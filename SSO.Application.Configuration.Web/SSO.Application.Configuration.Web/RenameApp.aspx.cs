using BizTalk.Tools.SSOApplicationConfiguration;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSO.Application.Configuration.Web
{
    public partial class RenameApp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            chgAppNametxt.Text = Request.QueryString["AppName"].ToString();
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            string appToUse = Request.QueryString["AppName"].ToString();
            string appUserAcct, appAdminAcct, description, contactInfo;
            string newApp = Request.Form["chgAppNametxt"];
            HybridDictionary props = SSOConfigManager.GetConfigProperties(appToUse, out description, out contactInfo, out appUserAcct, out appAdminAcct);
          
            Utils.UpdateSSOApp(appToUse,newApp,description,appAdminAcct,contactInfo,appUserAcct);

            Response.Redirect("Index.aspx", true);
        }
    }
}