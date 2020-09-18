using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvBll.BusiOrderInfo;
using LionvBll.BusiCommon;
using System.Web.Script.Serialization;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using ViewModel.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using LionvModel.BusiCommon;
using LionvCommonBll;

namespace LionVERP.UIServer.ProductionBusiness.DistributorMzOrderProduction
{
    public partial class MzProductionDetail : System.Web.UI.Page
    {
        private static B_MzSaleOrderBll bsob = new B_MzSaleOrderBll();
        private static CB_OrderFlowBll cofb = new CB_OrderFlowBll();
        private static B_OrderFacotoryBll bofb = new B_OrderFacotoryBll();
        private static BusiWorkFlowBll bwfb = new BusiWorkFlowBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region// 生产单信息
        [WebMethod(true)]
        public static string MzProductionOrder(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                VProduceOrder vpo = new VProduceOrder();
                B_MzSaleOrder bso = bsob.Query(" and sid='" + sid + "'");
                CB_OrderFlow cof = bwfb.QueryAttrExWorkFlow(sid, "sc");
                B_OrderFacotory bof = bofb.Query(" and sid='" + sid + "'");
                vpo.code = bso.scode;
                vpo.ycode = bso.ycode;
                vpo.customer = bso.customer;
                vpo.address = bso.address;
                vpo.dname = bso.dname;
                vpo.otype = bso.otype;
                vpo.fname = bof == null ? "" : bof.dname;
                vpo.scdate = cof != null ? cof.edate : "";
                vpo.overdate = bof == null ? "" : bof.overdate;
                vpo.bz = bso.remark;
                r = js.Serialize(vpo);
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