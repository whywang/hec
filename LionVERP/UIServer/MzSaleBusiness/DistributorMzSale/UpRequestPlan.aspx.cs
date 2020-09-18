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
    public partial class UpRequestPlan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string r = "", sid = "", preqest = "", place = "", pdemo = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            B_MzRequstDesignBll brdpb = new B_MzRequstDesignBll();
            if (iv.f)
            {
                HttpFileCollection files = Request.Files;
                if (Request.QueryString["sid"] != null)
                {
                    sid = Request.QueryString["sid"];
                }
                if (Request.QueryString["preqest"] != null)
                {
                    preqest = Request.QueryString["preqest"];
                }
                if (Request.QueryString["pdemo"] != null)
                {
                    pdemo = Request.QueryString["pdemo"];
                }
                if (Request.QueryString["place"] != null)
                {
                    place = Request.QueryString["place"];
                }
                string newname = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                UpFile uf = new UpFile();
                ArrayList efile = new ArrayList();
                B_MzRequstDesign spi = new B_MzRequstDesign();
                HttpPostedFile file = files[0];
                string url = "/UpFile/DesignPlan/";
                string ur = uf.UpFiles(file, newname, url, 10240000);
                if (ur.Length > 1)
                {
                    spi.sid = sid;
                    spi.maker = iv.u.ename;
                    spi.pdemo = pdemo;
                    spi.place = place;
                    spi.pname = file.FileName;
                    spi.preqest = preqest;
                    spi.url = url + ur;
                    spi.cdate = DateTime.Now.ToString();
                    if (brdpb.Add(spi) > 0)
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