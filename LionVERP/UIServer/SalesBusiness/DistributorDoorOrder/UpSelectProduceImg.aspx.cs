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
    public partial class UpSelectProduceImg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            B_SelectProduceImgBll bspib = new B_SelectProduceImgBll();
            if (iv.f)
            {
                HttpFileCollection files = Request.Files;
                string sid = Request.QueryString["sid"];
                string spname = Request.QueryString["spname"];
                string newname = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                UpFile uf = new UpFile();
                ArrayList efile = new ArrayList();
                B_SelectProduceImg spi = new B_SelectProduceImg();

                string url = "/UpFile/ImageMeasure/";
                string ur = uf.UpImage(files[0], newname, url, 10240000);
                if (ur.Length > 1)
                {
                    spi.sid = sid;
                    spi.xsid = CommonBll.GetSid();
                    spi.maker = iv.u.ename;
                    spi.xpname = spname;
                    spi.xpurl = url + ur;
                    spi.cdate = DateTime.Now.ToString();
                    if (bspib.Add(spi) > 0)
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