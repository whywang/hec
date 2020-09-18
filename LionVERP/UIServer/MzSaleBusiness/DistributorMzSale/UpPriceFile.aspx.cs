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

namespace LionVERP.UIServer.MzSaleBusiness.DistributorMzSale
{
    public partial class UpPriceFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string r = "", sid = "", fname = "", oprice = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            B_MzPriceFileBll bmpfb = new B_MzPriceFileBll();
            B_QbqqSaleOrderBll bmsob = new B_QbqqSaleOrderBll();

            if (iv.f)
            {
                HttpFileCollection files = Request.Files;
                if (Request.QueryString["sid"] != null)
                {
                    sid = Request.QueryString["sid"];
                }
                if (Request.QueryString["fname"] != null)
                {
                    fname = Request.QueryString["fname"];
                }
                if (Request.QueryString["oprice"] != null)
                {
                    oprice = Request.QueryString["oprice"];
                }
 
                string newname = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                UpFile uf = new UpFile();
                ArrayList efile = new ArrayList();
                B_MzPriceFile spi = new B_MzPriceFile();

                string url = "/UpFile/PriceFIle/";
                string ur = uf.UpXls(files[0], newname, url, 10240000);
                if (ur.Length > 1)
                {
                    string xname = new UpFile().GetFileExName(files[0]);
                    spi.sid = sid;
                    spi.maker = iv.u.ename;
                    spi.fname = fname+xname;
                    spi.furl = url + ur;
                    spi.fmoney = Convert.ToDecimal(oprice);
                    spi.cdate = DateTime.Now.ToString();
                    bmpfb.Delete(" and sid='" + sid + "'");
                    if (bmpfb.Add(spi))
                    {
                        bmsob.SetOrderMoney(sid, oprice);
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