using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizTalk.Tools.SSOApplicationConfiguration;

namespace SSO.Application.Configuration.Web
{
    public partial class Keys : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string app = Request.QueryString["application"].ToString();
           
          TableRow tr = new TableRow();
          
            TableCell td = new TableCell();
            td.Text = "Name";
            TableCell td2 = new TableCell();
            td2.Text = "Value";
            TableCell td6 = new TableCell();
            td6.Text = "Option";

            tr.Cells.Add(td);
            tr.Cells.Add(td2);
            tr.Cells.Add(td6);

            Table1.Rows.Add(tr);


            string appUserAcct, appAdminAcct, description, contactInfo;
            HybridDictionary props = SSOConfigManager.GetConfigProperties(app, out description, out contactInfo,
             out appUserAcct, out appAdminAcct);
            foreach (DictionaryEntry appProp in props)
            {
                TableRow tr3 = new TableRow();

                TableCell td3 = new TableCell();
                td3.Text = appProp.Key.ToString();
                tr3.Cells.Add(td3);

                TableCell td4 = new TableCell();
                td4.Text = appProp.Value.ToString();
                tr3.Cells.Add(td4);
                TableCell td5 = new TableCell();
                td5.Text = "<a href='/SSOWebApp/RenameKey.aspx?application=" + app + "&KeyName=" + appProp.Key.ToString() + "&KeyValue="+ appProp.Value.ToString() +"'class='fa fa-edit' style='text-decoration:none;text-decoration-color:red'></a> | <a href='/SSOWebApp/delKey.aspx?application=" + app + "&keyName="+ appProp.Key.ToString() + "'class='fa fa-trash' style='text-decoration:none'></a>";
                tr3.Cells.Add(td5);

                Table1.Rows.Add(tr3);
            }

        }
        protected void btnaddkey_Click(object sender, EventArgs e)
        {
            string app = Request.QueryString["application"].ToString();
            var kname = Request.Form["keynametxt"];
            var kvalue = Request.Form["keyvaluetxt"];
            if (kname != "" & kvalue != "")
            {
                Utils.UpdateSSOApplication(app, kname, kvalue);
                Response.Redirect("Keys?application=" + app);
            }
            else
            {
                Response.Write("<script language='javascript'>window.alert('Preencha todos os campos');</script>");
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }

        }
    }
}