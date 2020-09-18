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
using LionvModel.SysInfo;
using LionvCommonBll;

namespace LionVERP.UIServer.ProductionBusiness.DistributorAfterYqDoorProduction
{
    public partial class AfterProductionDetail : System.Web.UI.Page
    {
        private static B_YqAfterSaleOrderBll bsob = new B_YqAfterSaleOrderBll();
        private static CB_OrderFlowBll cofb = new CB_OrderFlowBll();
        private static B_OrderFacotoryBll bofb = new B_OrderFacotoryBll();
        private static Sys_DepmentBll sdb = new Sys_DepmentBll();
        private static B_SaleOrderBll sbs = new B_SaleOrderBll();
        private static BusiWorkFlowBll bwfb = new BusiWorkFlowBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        private static CB_OrderStateBll cosb = new CB_OrderStateBll();
        private static BusiProduceCycBll spcb = new BusiProduceCycBll();
        private static BusiComputePriceBll bcpb = new BusiComputePriceBll();
        private static BusiProduceProcessBll bppb = new BusiProduceProcessBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region// 生产单信息
        [WebMethod(true)]
        public static string AfterProductionOrder(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                VProduceOrder vpo = new VProduceOrder();
                B_YqAfterSaleOrder bso = bsob.Query(" and sid='" + sid + "'");
                CB_OrderFlow cof = bwfb.QueryAttrExWorkFlow(sid, "sc"); ;
                B_OrderFacotory bof = bofb.Query(" and sid='" + sid + "'");
                vpo.code = bso.scode;
                vpo.ycode = bso.pcode;
                vpo.customer = bso.customer;
                vpo.address = bso.address;
                vpo.dname = bso.dname;
                vpo.otype = "售后单";
                vpo.fname = bof == null ? "" : bof.dname;
                vpo.scdate = cof.edate;
                vpo.overdate = bof == null ? "" : bof.overdate;
                vpo.bz = bso.remark;
                vpo.duty = bso.aduty;
                vpo.reason = bso.areason;
                vpo.city = bso.city;
                r = js.Serialize(vpo);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region/// 设置订单工厂
        [WebMethod(true)]
        public static string SaveFactory(string bcode, string fcode, string fline, string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                int dn = 0;
                Sys_Depment sd = sdb.Query(" and dcode='" + fcode + "'");
                B_OrderFacotory bf = new B_OrderFacotory();
                B_YqAfterSaleOrder baso = bsob.Query(" and sid='" + sid + "'");
                B_OrderFacotory bof = bofb.Query(" and sid='" + sid + "'");
                List<Sys_ProduceCyc> lc = spcb.QueryCheckList(" and emcode='0006' and dcode='" + fcode + "'");
                if (lc != null)
                {
                    dn = lc[0].cnum;
                }
                bf.dname = sd != null ? sd.dname : "";
                bf.dcode = fcode;
                bf.maker = iv.u.ename;
                bf.sid = sid;
                bf.overdate = DateTime.Now.AddDays(dn).ToString("yyyy-MM-dd");
                bf.otype = baso == null ? "" : baso.otype;
                bf.cdate = DateTime.Now.ToString();
                if (bof != null)
                {
                    if (bofb.Update(bf))
                    {
                        r = "S";
                        bppb.SetProduceProcess(sid, fline);
                        BaseSet.WorkFlowManage.EventBtnDo.FireEventBtn(sid, bcode, "1", "分单");
                        //bcpb.OrderCgComputePrice(sid);
                    }
                    else
                    {
                        r = "F";
                    }
                }
                else
                {
                    if (bofb.Add(bf) > 0)
                    {
                        r = "S";
                        bppb.SetProduceProcess(sid, fline);
                        BaseSet.WorkFlowManage.EventBtnDo.FireEventBtn(sid, bcode, "1", "分单");
                        //bcpb.OrderCgComputePrice(sid);
                    }
                    else
                    {
                        r = "F";
                    }
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