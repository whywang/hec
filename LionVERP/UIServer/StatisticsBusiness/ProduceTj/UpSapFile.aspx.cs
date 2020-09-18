using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvAopModel;
using LionvBll.SysInfo;
using System.Collections;
using System.Data;
using LionvBll.BusiOrderInfo;

namespace LionVERP.UIServer.StatisticsBusiness.ProduceTj
{
    public partial class UpSapFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string r = "";
            B_ProductionItemBll bpib=new B_ProductionItemBll ();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                HttpFileCollection files = Request.Files;
                ExcleHelper eh = new ExcleHelper();
                string newname = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                UpFile uf = new UpFile();
                ArrayList efile = new ArrayList();
                string url = "/UpFile/ImageMeasure/";
                string ur = uf.UpXls(files[0], newname, url, 10240000);
                if (ur.Length > 1)
                {
                     string furl=url + ur;
                     string msg = "";
                     DataTable dt = eh.GetExcelTableByOleDB(furl, "SAP生产统计", true,ref msg);
                     if (msg == "")
                     {
                         if (bpib.UpdateWorkLine(dt) > 0)
                         {
                             r = "S";
                         }
                         else
                         {
                             r = "F";
                         }
                     }
                     else
                     {
                         r = "F";
                     }
                }
                else
                {
                    r = ur;
                }
            }
            else
            {
                r = iv.badstr;
            }
            Response.Write("{  msg:'" + r + "'}");
            Response.End();

        }
    }
}