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
    public partial class UpMeasureFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string r = "", sid = "", mname = "" ;
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            B_MzMeasureFileBll bmpfb = new B_MzMeasureFileBll();

            if (iv.f)
            {
                HttpFileCollection files = Request.Files;
                if (Request.QueryString["sid"] != null)
                {
                    sid = Request.QueryString["sid"];
                }
                if (Request.QueryString["fname"] != null)
                {
                    mname = Request.QueryString["fname"];
                }
                string newname = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                UpFile uf = new UpFile();
                ArrayList efile = new ArrayList();
                B_MzMeasureFile spi = new B_MzMeasureFile();

                string url = "/UpFile/MeasureFile/";
                string ur = uf.UpFiles(files[0], newname, url, 10240000);
                if (ur.Length > 1)
                {
                    string xname = new UpFile().GetFileExName(files[0]);
                    spi.sid = sid;
                    spi.maker = iv.u.ename;
                    spi.mname = mname + xname;
                    spi.murl = url + ur;
                    spi.cdate = DateTime.Now.ToString();
                    bmpfb.Delete(" and sid='" + sid + "'");
                    if (bmpfb.Add(spi)>0)
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