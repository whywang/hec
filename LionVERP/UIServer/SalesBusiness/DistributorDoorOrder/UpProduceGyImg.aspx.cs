using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvBll.BusiOrderInfo;
using System.Collections;
using LionvModel.BusiOrderInfo;
using LionvCommonBll;

namespace LionVERP.UIServer.SalesBusiness.DistributorOrder
{
    public partial class UpProduceGyImg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            B_ProduceGyImgBll bmib = new B_ProduceGyImgBll();
            if (iv.f)
            {
                HttpFileCollection files = Request.Files;
                string sid = Request.QueryString["sid"];
                string gname = Request.QueryString["gname"];
                string newname = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                UpFile uf = new UpFile();
                ArrayList efile = new ArrayList();
                B_ProduceGyImg spi = new B_ProduceGyImg();
                string url = "/UpFile/ImageMeasure/";
                string ur = uf.UpImage(files[0], newname, url, 10240000);
                if (ur.Length > 1)
                {
                    spi.sid = sid;
                    spi.gsid = CommonBll.GetSid();
                    spi.maker = iv.u.ename;
                    spi.gname = gname;
                    spi.gurl = url + ur;
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