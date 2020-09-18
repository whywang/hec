using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvBll.SysInfo;
using LionvAopModel;
using LionvBll.ProductionInfo;
using System.Collections;
using LionvModel.ProductionInfo;

namespace LionVERP.UIServer.ProductionSet.ProductionManage
{
    public partial class UpLogoFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string r = "", ltype = "", lt="";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            Sys_ProductionOrderLogoBll smcb = new Sys_ProductionOrderLogoBll();
            if (iv.f)
            {
                HttpFileCollection files = Request.Files;
                if (Request.QueryString["ltype"] != null)
                {
                    ltype = Request.QueryString["ltype"];
                }
                if (Request.QueryString["lt"] != null)
                {
                    lt = Request.QueryString["lt"];
                }
                string newname = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                UpFile uf = new UpFile();
                ArrayList efile = new ArrayList();
                Sys_ProductionOrderLogo spi = new Sys_ProductionOrderLogo();

                string url = "/UpFile/LogoFile/";
                string ur = uf.UpImage(files[0], newname, url, 10240000);
                if (ur.Length > 1)
                {
                    spi.dcode = iv.u.dcode.Substring(0, 8);
                    spi.maker = iv.u.ename;
                  
                    spi.cdate = DateTime.Now.ToString();
                    if (ltype == "xq")
                    {
                        spi.xqt = lt;
                        spi.xqurl = url + ur;
                    }
                    if (ltype == "pg")
                    {
                        spi.pgt = lt;
                        spi.pgurl = url + ur;
                    }
                    if (ltype == "sp")
                    {
                        spi.spt = lt;
                        spi.spurl = url + ur;
                    }
                    if (ltype == "gp")
                    {
                        spi.gpt = lt;
                        spi.gpurl = url + ur;
                    }
                    if (ltype == "bp")
                    {
                        spi.bpt = lt;
                        spi.bpurl = url + ur;
                    }
                    if (smcb.UpdateLogo(spi,ltype))
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