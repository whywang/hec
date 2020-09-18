using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvBll.BusiOrderInfo;
using LionvModel.BusiOrderInfo;

namespace LionVERP.UIServer.CommonFile
{
    public partial class UpAfterProductionImg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            B_AfterProductionImgBll bitb = new B_AfterProductionImgBll();
            if (iv.f)
            {
                HttpFileCollection files = Request.Files;
                string sid = Request.QueryString["sid"];
                string gnum = Request.QueryString["gnum"];
                string gurl = "";
                string newname = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                UpFile uf = new UpFile();
                string url = "/UpFile/ImageAfter/";
                string ur = uf.UpImage(files[0], newname, url, 10240000);
                if (ur.Length > 1)
                {
                    gurl = url + ur;
                    B_AfterProductionImg bai = new B_AfterProductionImg();
                    bai.gnum = Convert.ToInt32(gnum);
                    bai.sid = sid;
                    bai.url = gurl;
                    bai.maker = iv.u.ename;
                    bai.cdate = DateTime.Now.ToString();
                    if (bitb.Add(bai)>0)
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