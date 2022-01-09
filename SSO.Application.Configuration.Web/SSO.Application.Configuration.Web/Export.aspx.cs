using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Configuration;
using BizTalk.Tools.SSOApplicationConfiguration;
using System.Collections.Specialized;
using System.Threading;

namespace SSO.Application.Configuration.Web
{
    public partial class Export : System.Web.UI.Page
    {
        public string folderName;
        protected void Page_Load(object sender, EventArgs e)
        {
   
        }
        protected void btnChange_Click(object sender, EventArgs e)
        {
            /*
            Thread t = new Thread((ThreadStart)(() => {
                var folderBrowserDialog1 = new FolderBrowserDialog();
                // Show the FolderBrowserDialog.
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    folderName = folderBrowserDialog1.SelectedPath;
                }
            }));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
            */
            folderName = ConfigurationManager.AppSettings["pathToExport"]; 
            bool ok;
            string password_aux = Request.Form["chgAppNamepwd"]; 
            string appToUse = Request.QueryString["AppName"].ToString();
            string appToUseWithE = appToUse + ".sso";
            //Utils.getPassword(out ok, out password_aux);
            string path = folderName + "\\" + appToUse;
            
            Utils.ExportEncryptedAppToXML(path, appToUse, password_aux);
            Response.Redirect("Index.aspx", true);
        }
    }
}