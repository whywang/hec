using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvBll.BusiOrderInfo;
using LionvBll.BusiCommon;
using System.Web.Script.Serialization;
using LionvCommonBll;
using System.Web.Services;
using LionvBll.SysInfo;
using ViewModel.BusiOrderInfo;
using LionvAopModel;
using LionvModel.BusiOrderInfo;
using LionvModel.BusiCommon;

namespace LionVERP.UIServer.ProductionBusiness.DistributorYqDoorProduction
{
    public partial class ProductionDetail : System.Web.UI.Page
    {
        private static B_YqSaleOrderBll bsob = new B_YqSaleOrderBll();
        private static CB_OrderFlowBll cofb = new CB_OrderFlowBll();
        private static B_OrderFacotoryBll bofb = new B_OrderFacotoryBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        private static BusiWorkFlowBll bwfb = new BusiWorkFlowBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region// 生产单信息
        [WebMethod(true)]
        public static string ProductionOrder(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                VProduceOrder vpo = new VProduceOrder();
                B_YqSaleOrder bso = bsob.Query(" and sid='" + sid + "'");
                CB_OrderFlow cof = bwfb.QueryAttrExWorkFlow(sid, "sc");
                B_OrderFacotory bof = bofb.Query(" and sid='" + sid + "'");
                vpo.code = bso.scode;
                vpo.ycode = bso.ycode;
                vpo.customer = bso.customer;
                vpo.address = bso.address;
                vpo.dname = bso.dname;
                vpo.otype = bso.otype;
                vpo.fname = bof == null ? "" : bof.dname;
                vpo.scdate = cof.edate;
                vpo.overdate = bof == null ? "" : CommonBll.GetBdate(bof.overdate);
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