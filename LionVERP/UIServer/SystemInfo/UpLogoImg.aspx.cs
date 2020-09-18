using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvAopModel;
using LionvBll.SysInfo;
using System.Collections;
using LionvModel.SysInfo;

namespace LionVERP.UIServer.SystemInfo
{
    public partial class UpLogoImg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            Sys_SystemImgBll bmib = new Sys_SystemImgBll();
            if (iv.f)
            {
                HttpFileCollection files = Request.Files;
                string mt = Request.QueryString["mtype"];
                string newname = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                UpFile uf = new UpFile();
                ArrayList efile = new ArrayList();
                Sys_SystemImg spi = new Sys_SystemImg();

                string url = "/UpFile/ImageMeasure/";
                string ur = uf.UpImage(files[0], newname, url, 10240000);
                if (ur.Length > 1)
                {
                    spi.murl = url + ur;
                    spi.mtype = Convert.ToInt32(mt);
                    bmib.Delete(" and mtype=" + mt + "");
                    if (bmib.Add(spi) > 0)
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