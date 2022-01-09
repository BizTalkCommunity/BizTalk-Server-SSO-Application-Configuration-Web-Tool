using BizTalk.Tools.SSOApplicationConfiguration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace SSO.Application.Configuration.Web
{
    public partial class delApp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Page.IsPostBack)
            {
                string confirmValue = this.hidField.Value;
                hfposted.Value = "1";
                if (confirmValue == "Yes")
                {
                    string app = Request.QueryString["application"].ToString();
                    app = app + ".sso";
                    var pathWFile = @"C:\inetpub\wwwroot\SSOWebApp\Apps";
                    File.Delete(Path.Combine(pathWFile, app));
                    Utils.DeleteSSOApp(app);
                    Response.Redirect("Index");
                }
                else
                {
                    Response.Redirect("Index");
                }
            }
        }
    }
}