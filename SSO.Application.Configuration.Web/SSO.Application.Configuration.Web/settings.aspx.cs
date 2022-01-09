using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSO.Application.Configuration.Web
{
    public partial class settings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            contactInfotxt.Text = ConfigurationManager.AppSettings["contactInfo"];
            appAdminAccttxt.Text = ConfigurationManager.AppSettings["appAdminAcct"];
            appUserAccttxt.Text = ConfigurationManager.AppSettings["appUserAcct"];
            expPathtxt.Text = ConfigurationManager.AppSettings["pathToExport"];
        }
        protected void btnChange_Click(object sender, EventArgs e)
        {
            var contactInfo = Request.Form["contactInfotxt"];
            var appAdminAcct = Request.Form["appAdminAccttxt"];
            var appUserAcct = Request.Form["appUserAccttxt"];
            var expPath = Request.Form["expPathtxt"];

            ConfigurationManager.AppSettings["contactInfo"] = contactInfo;
            ConfigurationManager.AppSettings["appAdminAcct"] = appAdminAcct;
            ConfigurationManager.AppSettings["appUserAcct"] = appUserAcct;
            ConfigurationManager.AppSettings["pathToExport"] = expPath;

            //string v = "False";
            Response.Redirect("settings.aspx", true);
        }
    }
}