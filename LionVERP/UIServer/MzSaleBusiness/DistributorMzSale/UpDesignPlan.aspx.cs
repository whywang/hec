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
    public partial class UpDesignPlan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string r = "", sid = "",  place = "", pname = "",pnum="";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            B_MzDesignPlanBll bmdpb = new B_MzDesignPlanBll();
            if (iv.f)
            {
                HttpFileCollection files = Request.Files;
                if (Request.QueryString["sid"] != null)
                {
                    sid = Request.QueryString["sid"];
                }
                if (Request.QueryString["fplace"] != null)
                {
                    place = Request.QueryString["fplace"];
                }
                if (Request.QueryString["fname"] != null)
                {
                    pname = Request.QueryString["fname"];
                }
                if (Request.QueryString["pnum"] != null)
                {
                    pnum = Request.QueryString["pnum"];
                }
                string newname = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                UpFile uf = new UpFile();
                ArrayList efile = new ArrayList();
                B_MzDesignPlan spi = new B_MzDesignPlan();

                string url = "/UpFile/DesignPlan/";
                string ur = uf.UpFiles(files[0], newname, url, 10240000);
                if (ur.Length > 1)
                {
                    spi.sid = sid;
                    spi.maker = iv.u.ename;
                    spi.place = place;
                    spi.pname = pname;
                    spi.pnum = Convert.ToInt32(pnum);
                    spi.purl = url + ur;
                    spi.cdate = DateTime.Now.ToString();
                    if (bmdpb.Add(spi) > 0)
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