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
using LionvBll.BusiCommon;
using LionvCommonBll;

namespace LionVERP.UIServer.CommonFile
{
    public partial class UpDesignFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string r = "", sid = "", fname = "", dtype="";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            B_DesignPlanBll bmib = new B_DesignPlanBll();
            CB_OrderFlowBll cofb = new CB_OrderFlowBll();
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
                if (Request.QueryString["dtype"] != null)
                {
                    dtype = Request.QueryString["dtype"];
                }
                string newname = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                UpFile uf = new UpFile();
                ArrayList efile = new ArrayList();
                B_DesignPlan spi = new B_DesignPlan();
                string url = "/UpFile/DesignFile/";
                string ur = uf.UpFiles(files[0], newname, url, 102400000);
                if (ur.Length > 1)
                {
                    string xname = uf.GetFileExName(files[0]);
                    spi.osid = sid;
                    spi.sid = CommonBll.GetSid();
                    spi.maker = iv.u.ename;
                    spi.dname = fname + xname;
                    spi.durl = url + ur;
                    spi.emcode ="";
                    spi.dtype = dtype;
                    spi.rcode = iv.u.rcode;
                    spi.wcode = cofb.QueryCurWorkFlow(sid);
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