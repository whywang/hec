using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using ViewModel.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using LionvBll.BusiOrderInfo;
using System.Web.Script.Serialization;
using LionvBll.BusiCommon;
using LionvModel.BusiCommon;
using LionvCommonBll;

namespace LionVERP.UIServer.ProductionBusiness.DistributorProduction
{
    public partial class ProductionDetail : System.Web.UI.Page
    {
        private static B_SaleOrderBll bsob = new B_SaleOrderBll();
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
                B_SaleOrder bso = bsob.Query(" and sid='" + sid + "'");
                CB_OrderFlow cof = bwfb.QueryAttrExWorkFlow(sid,"sc");
                B_OrderFacotory bof = bofb.Query(" and sid='" + sid + "'");
                vpo.code=bso.scode;
                vpo.ycode = bso.oscode;
                vpo.customer = bso.customer;
                vpo.address = bso.address;
                vpo.dname = bso.dname;
                vpo.otype = bso.otype;
                vpo.fname = bof==null?"":bof.dname;
                vpo.scdate = cof.edate;
                vpo.overdate = bof==null?"":CommonBll.GetBdate(bof.overdate) ;
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