using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTalk.Tools.SSOApplicationConfiguration;

namespace SSO.Application.Configuration.Web
{
    public partial class RenameKey : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            chgKName.Text = Request.QueryString["KeyName"].ToString();
            chgKValue.Text = Request.QueryString["KeyValue"].ToString();
        }
        protected void btnChange_Click(object sender, EventArgs e)
        {
            string keyToD = Request.QueryString["KeyName"].ToString(); 
            string app = Request.QueryString["application"].ToString();
            Utils.RemoveKeyValueFromSSOApp(keyToD, app);

            string newKeyN = Request.Form["chgKName"];
            string newKeyV = Request.Form["chgKValue"];
            Utils.UpdateSSOApplication(app, newKeyN, newKeyV);
            Response.Redirect("Keys?application=" + app);
        }
    }
}