using BizTalk.Tools.SSOApplicationConfiguration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSO.Application.Configuration.Web
{
    public partial class ImportApp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnimport_Click(object sender, EventArgs e)
        {
            var pass = Request.Form["pass"];
            var contactInfo = ConfigurationManager.AppSettings["contactInfo"];
            var appAdminAcct = ConfigurationManager.AppSettings["appAdminAcct"];
            var appUserAcct = ConfigurationManager.AppSettings["appUserAcct"];
            //string link;
            //link = "pdf/" + Path.GetFileName(FileUpload1.FileName);
            var path = Server.MapPath(FileUpload1.FileName);
            var appWext = Path.GetFileNameWithoutExtension(FileUpload1.FileName);
            var pathWFile = Path.GetDirectoryName(path);
            var defpath = pathWFile + "\\Apps\\" + FileUpload1.FileName;

            if (FileUpload1.HasFile && pass != "")
            {
                FileUpload1.SaveAs(defpath);
                if (Utils.ImportAppFromXML(defpath, pass, appAdminAcct, contactInfo, appUserAcct))
                {

                    Response.Redirect("ImportApp.aspx", true);
                }
                else
                {
                    Utils.OverwriteSSOApplication(appWext, pass, appAdminAcct, contactInfo, appUserAcct, defpath);
                }
            }
            else
            {
                Response.Write("<script language='javascript'>window.alert('Preencha todos os campos');window.location='Default.aspx';</script>");
            }
            Response.Redirect("ImportApp.aspx", true);
        }
    }
}