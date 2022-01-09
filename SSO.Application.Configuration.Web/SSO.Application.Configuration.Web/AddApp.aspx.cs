using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTalk.Tools.SSOApplicationConfiguration;

namespace SSO.Application.Configuration.Web
{
    public partial class AddApp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void btnChange_Click(object sender, EventArgs e)
        {
            var appname = Request.Form["addAppNametxt"];
            var contactInfo = ConfigurationManager.AppSettings["contactInfo"];
            var appAdminAcct = ConfigurationManager.AppSettings["appAdminAcct"];
            var appUserAcct = ConfigurationManager.AppSettings["appUserAcct"];

            if (appname != "")
            {
                if (Utils.CreateAPP(appname, appAdminAcct, contactInfo, appUserAcct))
                {

                    Response.Redirect("AddApp.aspx", true);
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Erro');window.location='Default.aspx';</script>");
                }
            }
            else
            {
                Response.Write("<script language='javascript'>window.alert('Preencha todos os campos');window.location='Default.aspx';</script>");
            }
           // string v2 = "False";
            Response.Redirect("AddApp.aspx", true);
        }
    }
}