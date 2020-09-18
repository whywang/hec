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

namespace LionVERP.UIServer.SalesBusiness.DistributorOrder
{
    public partial class UpPayImg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            B_PayImgBll bmib = new B_PayImgBll();
            if (iv.f)
            {
                string ptype = "o";
                HttpFileCollection files = Request.Files;
                string sid = Request.QueryString["sid"];
                string imgms = Request.QueryString["imgms"];
                if( Request.QueryString["ptype"]!=null)
                {
                    ptype = Request.QueryString["ptype"].ToString();
                }
                string newname = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                UpFile uf = new UpFile();
                ArrayList efile = new ArrayList();
                B_PayImg spi = new B_PayImg();

                string url = "/UpFile/ImageMeasure/";
                string ur = uf.UpImage(files[0], newname, url, 10240000);
                if (ur.Length > 1)
                {
                    spi.sid = sid;
                    spi.maker = iv.u.ename;
                    spi.remark = imgms;
                    spi.url = url + ur;
                    spi.ptype = ptype;
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