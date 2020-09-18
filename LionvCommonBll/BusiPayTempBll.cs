using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using LionvModel.BusiCommon;
using LionvBll.BusiOrderInfo;
using LionvBll.BusiCommon;
using ViewModel.BusiOrderInfo;

namespace LionvCommonBll
{
    public class BusiPayTempBll
    {
        private BusiTempletBll btb = new BusiTempletBll();
        private B_SaleOrderBll bsob = new B_SaleOrderBll();
        private CB_OrderFlowBll cofb = new CB_OrderFlowBll();
        private CB_OrderStateBll cosb = new CB_OrderStateBll();
        private BusiWorkFlowBll bwfb = new BusiWorkFlowBll();
        private B_PayRecordBll bprb = new B_PayRecordBll();
        private BusiOrderMoneyBll bomb = new BusiOrderMoneyBll();
        private B_AfterSaleOrderBll basob = new B_AfterSaleOrderBll();
        #region//订单付款
        public string  QueryPayOrderHtm(string sid,string emcode,string utype,string dcode)
        {
            StringBuilder thtm = new StringBuilder();
            string htemp = btb.TempHead(dcode, emcode, utype);
            thtm.Append(ReplaceTempHead(sid,htemp));
            string btemp = btb.TempBody(dcode, emcode, utype);
            thtm.Append(ReplaceTempBody(sid, btemp));
            string ftemp = btb.TempFoot(dcode, emcode, utype);
            thtm.Append(ReplaceTempFoot(sid, ftemp));
            return thtm.ToString();
        }
        private string ReplaceTempHead(string sid,string temp)
        {
            string r = "";
            r = temp;
            return r;
        }
        private string ReplaceTempBody(string sid, string temp)
        {
            string zt = "";
            string cxzt = "";
            decimal sdisc = 1;
            decimal gdisc = 1;
            decimal tkje = 0;
            string scode = "";
            string cdate = "";
            string city = "";
            string dname = "";
            string customer = "";
            string address = "";
            string skr = "";
            string remark = "";
            string wcode = "";
            string oscode = "";
            string areason = "";
            string aduty = "";
            string method = "";
            B_SaleOrder bso = bsob.Query(" and sid='" + sid + "'");
            if (bso != null)
            {
                sdisc = bso.sdiscount;
                gdisc = bso.gdiscount;
                scode = bso.scode;
                cdate = CommonBll.GetBdate(cdate);
                city = bso.city;
                dname = bso.dname;
                customer = bso.customer;
                address = bso.address;
                wcode = bso.wcode;
                remark = bso.remark;
            }
            B_AfterSaleOrder baso=basob.Query(" and sid='" + sid + "'");
            if (baso!=null)
            {
                scode = baso.scode;
                oscode = baso.oscode;
                cdate = CommonBll.GetBdate(baso.cdate);
                city = baso.city;
                dname = baso.dname;
                customer = baso.customer;
                address = baso.address;
                remark = baso.remark;
                areason = baso.areason;
                aduty = baso.aduty;
                method = baso.method;
                tkje = baso.omoney;
            }
            B_PayRecord pr = bprb.Query(" and sid='" + sid + "'");
            CB_OrderState cos = cosb.Query("and sid='" + sid + "'");
            CB_OrderFlow cof = bwfb.QueryAttrExWorkFlow(sid, "bj");
            if (cof != null)
            {
                skr = pr == null ? "" : pr.maker;
            }
            VOrderMoney vm = bomb.DoorOrderMoney(sid, sdisc, gdisc, 1);

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
            temp = temp.Replace("[CODE]", scode);
            temp = temp.Replace("[DATE]", cdate);
            temp = temp.Replace("[PLATFORM]",dname);
            temp = temp.Replace("[CITY]", city);
            temp = temp.Replace("[CUSTOMER]", customer);
            temp = temp.Replace("[ADDRESS]", address);
            temp = temp.Replace("[YINGSHOU]", vm.gohjmoney.ToString("#0.00"));
            temp = temp.Replace("[CXHD]", cxzt);
            temp = temp.Replace("[SHISHOU]", vm.godhjmoney.ToString("#0.00"));
            temp = temp.Replace("[YISHOU]", vm.pmoney.ToString("#0.00"));
            temp = temp.Replace("[WEISHOU]", (vm.godhjmoney - vm.pmoney).ToString("#0.00"));
            temp = temp.Replace("[SNAME]", pr == null ? "" : pr.sname);
            temp = temp.Replace("[STATE]", zt);
            temp = temp.Replace("[BJR]", cof.maker);
            temp = temp.Replace("[SKR]", skr);
            temp = temp.Replace("[BZ]", remark);
            temp = temp.Replace("[WGCODE]", wcode);
            temp = temp.Replace("[OSCODE]", oscode);
            temp = temp.Replace("[TKJE]", tkje.ToString("#0.00"));
            temp = temp.Replace("[SHYY]", areason);
            temp = temp.Replace("[SHZR]", aduty);
            temp = temp.Replace("[CLFS]", method);
            return temp;
        }
        private string ReplaceTempFoot(string sid, string temp)
        {
            string r = "";
            r = temp;
            return r;
        }
        #endregion
    }
}
