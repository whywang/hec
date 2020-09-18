using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using System.Text;
using LionvCommonBll;
using ViewModel.BusiOrderInfo;
using System.Web.Script.Serialization;
using LionvBll.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using LionvBll.BusiCommon;
using LionvModel.BusiCommon;

namespace LionVERP.UIServer.FinanceBusiness.DistributorReceipt
{
    public partial class ReceiptDetail : System.Web.UI.Page
    {
        
        private static BusiInvTempBll bitb = new BusiInvTempBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        private static B_SaleOrderBll bsob = new B_SaleOrderBll();
        private static B_GroupProductionBll bgpb = new B_GroupProductionBll();
        private static B_PayRecordBll bprb = new B_PayRecordBll();
        private static CB_OrderStateBll cbsb = new CB_OrderStateBll();
        private static BusiSaleDiscountBll bsdb = new BusiSaleDiscountBll();
        private static CB_OrderFlowBll cofb = new CB_OrderFlowBll();
        private static BusiWorkFlowBll bwfb = new BusiWorkFlowBll();
        private static BusiPayTempBll bptb = new BusiPayTempBll();
        private static BusiOrderMoneyBll bomb = new BusiOrderMoneyBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
       
        #region//收款
        [WebMethod(true)]
        public static string SalePayOperator(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_SaleOrder bso=bsob.Query(" and sid='"+sid+"'");
                VPayOrder vpo = new VPayOrder();
                VOrderMoney vm = bomb.DoorOrderMoney(sid, bso.sdiscount, bso.gdiscount, 1);
                CB_OrderFlow cof = bwfb.QueryAttrExWorkFlow(sid, "bj"); 
                vpo.code = bso.scode;
                vpo.customer = bso.customer;
                vpo.dname = bso.dname;
                vpo.dcode = bso.citycode;
                vpo.settlment = "";// bso.sname;
                vpo.bjr = cof!=null?cof.maker:"";
                vpo.yingshou =vm.godhjmoney.ToString();
                vpo.yishou = vm.pmoney.ToString();
                vpo.weishou = (vm.godhjmoney - vm.pmoney).ToString();
                vpo.telephone = bso.telephone;
                r = js.Serialize(vpo);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region//保存收款记录
        [WebMethod(true)]
        public static string SavePayOperator(string acdate, string acje, string aperson, string bcode, string dxje, string paccount, string priperson, string remark, string settlement, string sid, string unaje)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                int pzt = 0;
                B_PayRecord bpr = new B_PayRecord();
                bpr.pmoney = Convert.ToDecimal(acje);
                bpr.pmoneystr = dxje;
                bpr.sname = settlement;
                bpr.sid = sid;
                bpr.ps = remark;
                bpr.maker = aperson;
                bpr.pdate = acdate;
                bpr.cdate = DateTime.Now.ToString();
                bpr.paccount = paccount;
                CB_OrderState bos= cbsb.Query(" and sid='" + sid + "' and imoney>0");

                if (bprb.Add(bpr) > 0)
                {
                    r = "S";
                    if (Convert.ToDecimal(acje) == Convert.ToDecimal(unaje))
                    {
                        pzt = 2;
                    }
                    else
                    {
                        pzt = 1;
                    }
                    cbsb.UpState(sid, "imoney", pzt);
                    if (bos == null)
                    {
                        BaseSet.WorkFlowManage.EventBtnDo.FireEventBtn(sid, bcode, "1", "收款");
                    }
                    else
                    {
                        BaseSet.WorkFlowManage.EventBtnDo.FireEventBtn(sid, bcode, "1", "尾款收款");
                    }
                    //判定是否执行成功
                    CB_OrderState cbos = cbsb.Query(" and sid='" + sid + "'");
                    if (cbos.imoney == pzt)
                    {
                        r = "S";
                    }
                    else
                    {
                        r = "ML";
                    }
                }
                else
                {
                    r = "F";
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