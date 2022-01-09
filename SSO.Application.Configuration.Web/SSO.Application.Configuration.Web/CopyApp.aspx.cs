using BizTalk.Tools.SSOApplicationConfiguration;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSO.Application.Configuration.Web
{
    public partial class CopyApp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string appToUse = Request.QueryString["AppName"].ToString();
            string randomString = Utils.copyAppName(appToUse);
            string appUserAcct, appAdminAcct, description, contactInfo;
            HybridDictionary props = SSOConfigManager.GetConfigProperties(appToUse, out description, out contactInfo, out appUserAcct, out appAdminAcct);
            Utils.CopySSOApp(randomString,appToUse, description, appAdminAcct, contactInfo, appUserAcct);
            Response.Redirect("Index.aspx", true);
        }
    }
}