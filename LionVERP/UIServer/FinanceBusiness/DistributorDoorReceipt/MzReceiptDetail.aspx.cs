using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvCommonBll;
using System.Web.Script.Serialization;
using LionvBll.BusiOrderInfo;
using LionvBll.BusiCommon;
using System.Web.Services;
using LionvBll.SysInfo;
using LionvAopModel;
using System.Text;
using ViewModel.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using LionvModel.BusiCommon;

namespace LionVERP.UIServer.FinanceBusiness.DistributorReceipt
{
    public partial class MzReceiptDetail : System.Web.UI.Page
    {
        private static BusiTempletBll btb = new BusiTempletBll();
        private static BusiInvTempBll bitb = new BusiInvTempBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        private static B_PayRecordBll bprb = new B_PayRecordBll();
        private static CB_OrderStateBll cbsb = new CB_OrderStateBll();
        private static CB_OrderFlowBll cofb = new CB_OrderFlowBll();
        private static BusiOrderTempBll botb = new BusiOrderTempBll();
        private static B_MzSaleOrderBll bsob = new B_MzSaleOrderBll();
        private static BusiWorkFlowBll bwfb = new BusiWorkFlowBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region//获取木作收款详情单
        [WebMethod(true)]
        public static string MzPayOrder(string sid, string emcode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                StringBuilder invhtm = new StringBuilder();
                #region//加载表头
                invhtm.Append(btb.TempHead(emcode));
                #endregion
                #region//加载表体
                invhtm.Append(botb.MzPayHtml(emcode, sid));
                #endregion
                #region//加载表脚
                invhtm.Append(btb.TempFoot(emcode));
                #endregion
                r = invhtm.ToString();
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region//获取收款信息
        [WebMethod(true)]
        public static string MzPayOperator(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                VPayOrder vpo = new VPayOrder();
                B_MzSaleOrder bso = bsob.Query(" and sid='" + sid + "'");
                decimal yingshou = bso.omoney;
                decimal yishou = bprb.GetSkMoneyEx(" and sid='" + sid + "'");
                CB_OrderFlow cof = bwfb.QueryAttrExWorkFlow(sid,"bj");
                vpo.code = bso.scode;
                vpo.customer = bso.customer;
                vpo.dname = bso.dname;
                //vpo.settlment = bso.sname;
                vpo.bjr = cof != null ? cof.maker : "";
                vpo.yingshou = yingshou.ToString("#0.00");
                vpo.yishou = yishou.ToString();
                vpo.weishou = (yingshou - yishou).ToString("#0.00");
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
        public static string MzSavePayOperator(string bcode,string bjr, string bz, string dxjine, string settlement, string shoukuan, string sid, string skdate, string skr, string weishou)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_PayRecord bpr = new B_PayRecord();
                bpr.pmoney = Convert.ToDecimal(shoukuan);
                bpr.pmoneystr = dxjine;
                bpr.sname = settlement;
                bpr.sid = sid;
                bpr.ps = bz;
                bpr.maker = skr;
                bpr.pdate = skdate;
                bpr.ptype = "dj";
                bpr.cdate = DateTime.Now.ToString();
                B_PayRecord cb = bprb.Query(" and sid='" + sid + "'");
                CB_OrderState bos = cbsb.Query(" and sid='" + sid + "' and imoney>0");
                if (bos == null)
                {
                    BaseSet.WorkFlowManage.EventBtnDo.FireEventBtn(sid, bcode, "1", "收款");
                }
                if (Convert.ToDecimal(shoukuan) == Convert.ToDecimal(weishou))
                {
                    cbsb.UpState(sid, "imoney", 2);
                }
                else
                {
                    cbsb.UpState(sid, "imoney", 1);
                }
                if (bprb.Add(bpr) > 0)
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
                r = iv.badstr;
            }
            return r;
        }
        #endregion
    }
}