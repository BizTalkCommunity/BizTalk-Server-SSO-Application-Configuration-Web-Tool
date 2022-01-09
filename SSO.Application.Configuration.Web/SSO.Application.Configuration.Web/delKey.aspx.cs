using BizTalk.Tools.SSOApplicationConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace SSO.Application.Configuration.Web
{
    public partial class delKey : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string app = Request.QueryString["application"].ToString();
            if (Page.IsPostBack)
            {
                string confirmValue = this.hidField.Value;
                hfposted.Value = "1";
                if (confirmValue == "Yes")
                {
                    string key = Request.QueryString["keyName"].ToString();
                    Utils.RemoveKeyValueFromSSOApp(key, app);
                    Response.Redirect("Keys?application=" + app);
                }
                else
                {
                    Response.Redirect("Keys?application=" + app);
                }
            }
        }
    }
}