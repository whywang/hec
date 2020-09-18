using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvAopModel;
using LionvBll.SysInfo;
using System.Collections;
using LionvBll.BusiOrderInfo;
using LionvModel.BusiOrderInfo;

namespace LionVERP.UIServer.AfterSaleServiceBusiness.DistributorAfterSale
{
    public partial class UpFeedBackImg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            B_FeedBackImgBll bmib = new B_FeedBackImgBll();
            if (iv.f)
            {
                HttpFileCollection files = Request.Files;
                string csid = Request.QueryString["sid"];
                string fname = Request.QueryString["fname"];
                string fremark = Request.QueryString["fremark"];
                string newname = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                UpFile uf = new UpFile();
                ArrayList efile = new ArrayList();
                B_FeedBackImg spi = new B_FeedBackImg();

                string url = "/UpFile/ImageMeasure/";
                string ur = uf.UpImage(files[0], newname, url, 1024000);
                if (ur.Length > 1)
                {
                    spi.sid = csid;
                    spi.maker = iv.u.ename;
                    spi.iname = fname;
                    spi.remark = fremark;
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