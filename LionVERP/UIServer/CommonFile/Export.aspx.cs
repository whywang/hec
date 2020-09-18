using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LionVERP.UIServer.CommonFile
{
    public partial class Export : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["content"]))
            {
                string itabstr = Request.Form["content"].ToString();
                string fname = Request.Form["fname"].ToString();

                string elxStr = "<table border='1' style='font-size:16px;'>";
                elxStr = elxStr + itabstr;
                elxStr = elxStr + "</table>";
                   
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Buffer = true;
                HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + System.Web.HttpUtility.UrlEncode(fname) + ".xls");
                HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
                HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
                HttpContext.Current.Response.Write(elxStr);
                Response.End();
            }
        }
    }
}