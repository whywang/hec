using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvBll.BusiOrderInfo;
using System.Web.Script.Serialization;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.BusiOrderInfo;
using LionvBll.BusiCommon;
using LionvModel.BusiCommon;

namespace LionVERP.UIServer.StorageBusiness.DistributorGlassPrepareOrder
{
    public partial class PerpareGlassOrderDetail : System.Web.UI.Page
    {
        private static B_GlassOrderBll bsob = new B_GlassOrderBll();
        private static CB_ProduceStartDateBll cpsdb = new CB_ProduceStartDateBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region/// 获取订单
        [WebMethod(true)]
        public static string QueryOrder(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_GlassOrder bco = bsob.Query(" and sid='" + sid + "'");
                if (bco != null)
                {
                    CB_ProduceStartDate csd=cpsdb.Query(" and sid='" + sid + "'");
                    bco.ddate =csd!=null? csd.sdate:"";
                    r = js.Serialize(bco);
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
    }
}