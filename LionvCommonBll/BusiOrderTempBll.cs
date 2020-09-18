using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using LionvModel.BusiCommon;
using LionvBll.BusiOrderInfo;
using LionvBll.BusiCommon;

namespace LionvCommonBll
{
    public class BusiOrderTempBll
    {
        private BusiTempletBll btb = new BusiTempletBll();
        private BusiSaleDiscountBll bsdb = new BusiSaleDiscountBll();
        private B_PayRecordBll bprb = new B_PayRecordBll();
        private CB_OrderStateBll cosb = new CB_OrderStateBll();
        private CB_OrderFlowBll cofb = new CB_OrderFlowBll();
        private B_MzSaleOrderBll bsob = new B_MzSaleOrderBll();
        private BusiWorkFlowBll bwfb = new BusiWorkFlowBll();
        #region//木作订金收款
        public string MzCustomePayHtml(string emcode, string sid)
        {
            string r = "";
            string porder = btb.TempBody("0012", "");
            r = PayRePlace(sid, porder);
            return r;
        }
        private string PayRePlace(string sid, string temp)
        {
            string zt = "";
            string cxzt = "";
            B_MzSaleOrder bso = bsob.Query(" and sid='" + sid + "'");
            decimal yingshou = bso.dmoney;
            decimal yishou = bprb.GetSkMoney(sid);
            B_PayRecord pr = bprb.Query(" and sid='" + sid + "'");
            CB_OrderState cos = cosb.Query("and sid='" + sid + "'");
            CB_OrderFlow cof = bwfb.QueryAttrExWorkFlow( sid ,"bj" );
            if (cos.idmoney == 0)
            {
                zt = "未收款";
            }
            if (cos.idmoney == 1)
            {
                zt = "部分款";
            }
            if (cos.idmoney == 2)
            {
                zt = "全部款";
            }
            temp = temp.Replace("[CODE]", bso.scode);
            temp = temp.Replace("[DATE]", bso.cdate);
            temp = temp.Replace("[PLATFORM]", bso.dname);
            temp = temp.Replace("[CITY]", bso.city);
            temp = temp.Replace("[CUSTOMER]", bso.customer);
            temp = temp.Replace("[ADDRESS]", bso.address);
            temp = temp.Replace("[YINGSHOU]", yingshou.ToString());
            temp = temp.Replace("[CXHD]", cxzt);
            temp = temp.Replace("[SHISHOU]", yingshou.ToString("#0.00"));
            temp = temp.Replace("[YISHOU]", yishou.ToString());
            temp = temp.Replace("[WEISHOU]", (yingshou - yishou).ToString("#0.00"));
            temp = temp.Replace("[SNAME]", "");
            temp = temp.Replace("[STATE]", zt);
            temp = temp.Replace("[BJR]", cof.maker);
            temp = temp.Replace("[SKR]", pr == null ? "" : pr.maker);
            temp = temp.Replace("[BZ]", bso.remark);
            temp = temp.Replace("[WGCODE]", bso.wcode);
            return temp;
        }
        #endregion
        #region//木作收款
        public string MzPayHtml(string emcode, string sid)
        {
            string r = "";
            string porder = btb.TempBody(emcode, "");
            r = MzPayRePlace(sid, porder);
            return r;
        }
        private string MzPayRePlace(string sid, string temp)
        {
            string zt = "";
            string cxzt = "";
            B_MzSaleOrder bso = bsob.Query(" and sid='" + sid + "'");
            decimal yingshou = bso.omoney;
            decimal cmoney = bso.dmoney;
            decimal yishou = bprb.GetSkMoney(sid);
            B_PayRecord pr = bprb.Query(" and sid='" + sid + "'");
            CB_OrderState cos = cosb.Query("and sid='" + sid + "'");
            CB_OrderFlow cof = bwfb.QueryAttrExWorkFlow(sid, "bj"); ;
            if (cos.imoney == 0)
            {
                zt = "未收款";
            }
            if (cos.imoney == 1)
            {
                zt = "部分款";
            }
            if (cos.imoney == 2)
            {
                zt = "全部款";
            }
            temp = temp.Replace("[CODE]", bso.scode);
            temp = temp.Replace("[DATE]", bso.cdate);
            temp = temp.Replace("[PLATFORM]", bso.dname);
            temp = temp.Replace("[CITY]", bso.city);
            temp = temp.Replace("[CUSTOMER]", bso.customer);
            temp = temp.Replace("[ADDRESS]", bso.address);
            temp = temp.Replace("[YINGSHOU]", yingshou.ToString());
            temp = temp.Replace("[CXHD]", cxzt);
            temp = temp.Replace("[DMONEY]", cmoney.ToString("#0.00"));
            temp = temp.Replace("[SHISHOU]", yingshou.ToString("#0.00"));
            temp = temp.Replace("[YISHOU]", yishou.ToString());
            temp = temp.Replace("[WEISHOU]", (yingshou - yishou).ToString("#0.00"));
            temp = temp.Replace("[SNAME]", "");
            temp = temp.Replace("[STATE]", zt);
            temp = temp.Replace("[BJR]", cof.maker);
            temp = temp.Replace("[SKR]", pr == null ? "" : pr.maker);
            temp = temp.Replace("[BZ]", bso.remark);
            temp = temp.Replace("[WGCODE]", bso.wcode);
            return temp;
        }
        #endregion
    }
}
