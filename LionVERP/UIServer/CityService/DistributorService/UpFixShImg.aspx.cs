using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvBll.BusiOrderInfo;
using LionvModel.BusiOrderInfo;

namespace LionVERP.UIServer.CityService.DistributorService
{
    public partial class UpFixShImg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            B_FixGetGoodsImgBll bmib = new B_FixGetGoodsImgBll();
            if (iv.f)
            {
                HttpFileCollection files = Request.Files;
                string sid = Request.QueryString["sid"];
                string newname = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                UpFile uf = new UpFile();
                ArrayList efile = new ArrayList();
                B_FixGetGoodsImg spi = new B_FixGetGoodsImg();
                string url = "/UpFile/ImageFixed/";
                string ur = uf.UpImage(files[0], newname, url, 1024000);
                if (ur.Length > 1)
                {
                    spi.sid = sid;
                    spi.maker = iv.u.ename;
                    spi.fixer = iv.u.ename;
                    spi.gdate = DateTime.Now.ToString();
                    spi.ps = "";
                    spi.domain = "p";
                    spi.url = url + ur;
                    spi.cdate = DateTime.Now.ToString();
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