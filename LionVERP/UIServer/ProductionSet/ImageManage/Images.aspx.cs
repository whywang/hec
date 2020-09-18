using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvAopModel;
using LionvBll.SysInfo;
using System.Collections;
using LionvBll.ProductionInfo;
using LionvModel.ProductionInfo;
using LionvCommonBll;

namespace LionVERP.UIServer.ProductionSet.ImageManage
{
    public partial class Images : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            Sys_ProduceImgBll spib = new Sys_ProduceImgBll();
            if (iv.f)
            {
                HttpFileCollection files = Request.Files;
                string icode = Request.QueryString["icode"];
                string iname = Request.QueryString["iname"];
                string fx = Request.QueryString["fx"];
                string newname = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                UpFile uf = new UpFile();
                ArrayList efile = new ArrayList();
                Sys_ProduceImg spi=new Sys_ProduceImg ();

                string url="/UpFile/ImageFile/";
                string ur = uf.UpImage(files[0],newname,url,1024000);
                CommonBll.PhotoChangeSize(System.Web.HttpContext.Current.Server.MapPath(url + ur), 60, 100);
                if (ur.Length>1)
                {
                    spi.iname = iname;
                    spi.icode = icode;
                    spi.dcode =iv.u.dcode==""?"00010001": iv.u.dcode.Substring(0,8);
                    if (fx == "z")
                    {
                        spi.iurl = url + ur;
                    }
                    if (fx == "f")
                    {
                        spi.ifurl = url + ur;
                    }
                    if (spib.Exists(" and icode='" + icode + "'"))
                    {
                        if (spib.Update(spi))
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
                        if (spib.Add(spi) > 0)
                        {
                            r = "S";
                        }
                        else
                        {
                            r = "F";
                        }
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