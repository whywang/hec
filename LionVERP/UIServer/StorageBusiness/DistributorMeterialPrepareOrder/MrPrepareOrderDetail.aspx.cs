using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using System.Collections;

namespace LionVERP.UIServer.StorageBusiness.DistributorMeterialPrepareOrder
{
    public partial class MrPrepareOrderDetail : System.Web.UI.Page
    {
        //private static B_WjPartOrderBll bsob = new B_WjPartOrderBll();
        //private static B_WjPartGroupProductionBll bwgpb = new B_WjPartGroupProductionBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //#region/// 获取销售订单
        //[WebMethod(true)]
        //public static string QueryPrePareOrder(string sid)
        //{
        //    string r = "";
        //    SessionUserValidate iv = SysValidateBll.ValidateSession();
        //    if (iv.f)
        //    {
        //        B_WjPartOrder bco = bsob.Query(" and sid='" + sid + "'");
        //        if (bco != null)
        //        {
        //            r = js.Serialize(bco);
        //        }
        //    }
        //    else
        //    {
        //        r = iv.badstr;
        //    }
        //    return r;
        //}
        //#endregion
        //#region/// 获取销售订单
        //[WebMethod(true)]
        //public static ArrayList QueryPrePareProductionList(string sid)
        //{
        //    ArrayList r = new ArrayList();
        //    SessionUserValidate iv = SysValidateBll.ValidateSession();
        //    if (iv.f)
        //    {
        //        r.Add(iv.badstr);
        //        List<B_WjPartGroupProduction> lp = bwgpb.QueryList(" and sid='" + sid + "'");
        //        if (lp != null)
        //        {
        //            foreach (B_WjPartGroupProduction p in lp)
        //            {
        //                decimal npnum = 0;
        //                ArrayList al = new ArrayList();
        //                al.Add(p.id);
        //                al.Add(p.iname);
        //                al.Add(p.uname);
        //                al.Add(p.inum);
        //                al.Add(p.pnum);
        //                npnum = p.inum - p.pnum;
        //                if (npnum > 0)
        //                {
        //                    al.Add(npnum);
        //                    r.Add(al);
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        r.Add(iv.badstr);
        //    }
        //    return r;
        //}
        //#endregion
    }
}