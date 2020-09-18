using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvAopModel;
using LionvBll.BusiOrderInfo;
using LionvCommonBll;
using LionvBll.BusiMgOrderInfo;
using LionvBll.SysInfo;

namespace LionVERP.UIServer.CommonFile
{
    public partial class UpProductionImg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            B_GroupProductionBll bmib = new B_GroupProductionBll();
            BusiInvTempBll bitb = new BusiInvTempBll();
            VProductionsBll vpb = new VProductionsBll();
            if (iv.f)
            {
                HttpFileCollection files = Request.Files;
                string sid = Request.QueryString["sid"];
                string gnum = Request.QueryString["gnum"];
                string ptype = Request.QueryString["ptype"];
                string gurl = "";
                string newname = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                UpFile uf = new UpFile();
                string url = "/UpFile/ImageRemark/";
                string ur = uf.UpImage(files[0], newname, url, 10240000);
                if (ur.Length > 1)
                {
                    gurl = url + ur;

                    if (bmib.UpRemarkImg(sid, Convert.ToInt32(gnum), gurl, ptype))
                    {
                        //VProductions vps = new VProductions();
                        //vps.htmtext = bitb.MgItemProductionHtml(sid, Convert.ToInt32(gnum), "0006");
                        //vps.gnum = Convert.ToInt32(gnum);
                        //vps.vtype = "s";
                        //vps.sid = sid;
                        //vps.id = sid + gnum + "s";
                        //vpb.Add(vps);
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