using BizTalk.Tools.SSOApplicationConfiguration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace SSO.Application.Configuration.Web
{
    public partial class Index1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            TableRow tr = new TableRow();

            TableCell td = new TableCell();
            td.Text = "Name";
            TableCell td5 = new TableCell();
            td5.Text = "Options";

            tr.Cells.Add(td);
            tr.Cells.Add(td5);

            Table1.Rows.Add(tr);

            var contactInfo = ConfigurationManager.AppSettings["contactInfo"];
            foreach (var application in SSOConfigManager.GetApplications(contactInfo))
            {
              
                TableRow tr2 = new TableRow();
                TableCell td2 = new TableCell();
                td2.Text = application;

                tr2.Cells.Add(td2);
                TableCell td3 = new TableCell();
                td3.Text = "<a href='/SSOWebApp/Keys.aspx?application=" + application + "'class='fa fa-key' style='text-decoration:none;text-decoration-color:red'></a> | <a href='/SSOWebApp/delApp.aspx?application=" + application + "'class='fa fa-trash' style='text-decoration:none'></a> | <a href='/SSOWebApp/RenameApp.aspx?AppName=" + application + "' class='fa fa-edit' style='text-decoration:none'></a> | <a href='/SSOWebApp/CopyApp.aspx?AppName=" + application + "'class='fa fa-copy' style='text-decoration:none'></a> | <a href='/SSOWebApp/Export.aspx?AppName=" + application + "'class='fa fa-folder' style='text-decoration:none'></a>";

                tr2.Cells.Add(td3);

                Table1.Rows.Add(tr2);
            }
        }
        protected void btnimport_Click(object sender, EventArgs e)
        {
            /*
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
   
            if (FileUpload1.HasFile && pass!="")
            {
                FileUpload1.SaveAs(defpath);
                if (Utils.ImportAppFromXML(defpath, pass, appAdminAcct, contactInfo, appUserAcct))
                {
                    
                    Response.Redirect("Index.aspx", true);
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
            Response.Redirect("Index.aspx", true);
            */
            
        }
        protected void btnadd_Click(object sender, EventArgs e)
        {
           /*
            var appname = Request.Form["txtappaddname"];
            var contactInfo = ConfigurationManager.AppSettings["contactInfo"];
            var appAdminAcct = ConfigurationManager.AppSettings["appAdminAcct"];
            var appUserAcct = ConfigurationManager.AppSettings["appUserAcct"];
            //string link;
            //link = "pdf/" + Path.GetFileName(FileUpload1.FileName);
            var path = Server.MapPath(FileUpload1.FileName);
            var appWext = Path.GetFileNameWithoutExtension(FileUpload1.FileName);
            var pathWFile = Path.GetDirectoryName(path);
            var defpath = pathWFile + "\\Apps\\" + FileUpload1.FileName;

            if (appname!="")
            {
                if (Utils.CreateAPP(appname, appAdminAcct, contactInfo, appUserAcct))
                {

                    Response.Redirect("Index.aspx", true);
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
            Response.Redirect("Index.aspx", true);
           */
        }
        protected void ClsSet_Click(object sender, EventArgs e)
        {
           // Panl2.Visible = false;
        }
        protected void ClsAdd_Click(object sender, EventArgs e)
        {
         //   Panl1.Visible = false;
        }
        protected void ClsImportA_Click(object sender, EventArgs e)
        {
            //   Panl1.Visible = false;
        }
        protected void btnChange_Click(object sender, EventArgs e)
        {
            /*
            var contactInfo = Request.Form["contactInfotxt"];
            var appAdminAcct = Request.Form["appAdminAccttxt"];
            var appUserAcct = Request.Form["appUserAccttxt"];

            ConfigurationManager.AppSettings["contactInfo"] = contactInfo;
            ConfigurationManager.AppSettings["appAdminAcct"] = appAdminAcct;
            ConfigurationManager.AppSettings["appUserAcct"] = appUserAcct;

            Response.Redirect("Index.aspx", true);
            */
        }
    }
}