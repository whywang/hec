using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvBll.Account;
using LionvModel.Account;
using System.Web.Script.Serialization;
using LionvModel.BusiCommon;
using LionvBll.BusiCommon;
using LionvCommonBll;
using LionVERP.UIServer.BaseSet.WorkFlowManage;

namespace LionVERP.UIServer.FinanceBusiness.DistributorCityPay
{
    public partial class CityPayOrderDetail : System.Web.UI.Page
    {
        private static B_CityPayOrderBll bcpob = new B_CityPayOrderBll();
        private static CB_OrderFlowBll cofb = new CB_OrderFlowBll();
        private static CB_OrderStateBll cosb = new CB_OrderStateBll();
        private static QrCodeBll qcb = new QrCodeBll();
        private static BusiWorkFlowBll bwfb = new BusiWorkFlowBll();
        private static Sbk_PaymentAccountBll spab = new Sbk_PaymentAccountBll();
        private static Sbk_CollectionAccountBll scab = new Sbk_CollectionAccountBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region//初始化订单
        [WebMethod(true)]
        public static string InitOrder(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_CityPayOrder bpo = new B_CityPayOrder();
                if (sid == "")
                {
                    bpo.dcode = iv.u.dcode;
                    bpo.dname = iv.u.dname;
                    bpo.maker = iv.u.ename;
                }
                else
                {
                    bpo = bcpob.Query(" and sid='" + sid + "'");
                }
                r = js.Serialize(bpo);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region//获取订单
        [WebMethod(true)]
        public static string QueryOrder(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_CityPayOrder bpo = new B_CityPayOrder();
                bpo = bcpob.Query(" and sid='" + sid + "'");
                r = js.Serialize(bpo);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region//获取订单
        [WebMethod(true)]
        public static string SaveOrder(string account,string bcode, string city, string citycode,string emcode, string maker, string paccount, string pdate, string pmethod, string pmoney, string remark, string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sbk_PaymentAccount pa = spab.Query(" and pcode=" + paccount + "");
                Sbk_CollectionAccount ca = scab.Query(" and id=" + account + "");
                B_CityPayOrder bco = new B_CityPayOrder();
                bco.caccount = ca.aname;
                bco.cbank=ca.abank;
                bco.cperson = ca.aperson;
                bco.cbcode = ca.bcode;
                bco.ctype = "";
                bco.dcode = citycode;
                bco.dname = city;
                bco.maker = maker;
                bco.paccount=pa.pname;
                bco.pbank = pa.pbank;
                bco.pbcode = pa.pbcode;
                bco.sacode = pa.sacode;
                bco.pcode = "P" + DateTime.Now.ToString("yyyyMMddHHmmss");
                bco.pdate = pdate;
                bco.pmethod = pmethod;
                bco.pmoney = Convert.ToDecimal(pmoney);
                bco.pperson = pa.pperson;
                bco.pstate = 0;
                bco.remark = remark.Replace(",", "，");
                bco.maker = maker;
                bco.cdate = DateTime.Now.ToString();
                if (sid == "")
                {
                    CB_OrderState cos = new CB_OrderState();
                    bco.sid = CommonBll.GetSid();
                    bco.pimg = qcb.CreateQtCode(System.Web.HttpContext.Current.Server.MapPath("/UpFile/OrderQt/"), CommonBll.GetHost() + "UIClient/SalesBusiness/DistributorOrder/SaleOrderDetail.htm?Sid=" + bco.sid);
                    if (bcpob.Add(bco) > 0)
                    {
                        bwfb.CreateWorkFlow(bco.sid, emcode);
                        cos.sid = bco.sid;
                        cosb.Add(cos);
                        r = bco.sid;
                    }
                    else
                    {
                        r = "F";
                    }
                    EventBtnDo.FireEventBtn(bco.sid, bcode, "1", " 保存订单");
                }
                else
                {
                    bco.sid = sid;
                    if (bcpob.Update(bco))
                    {
                        r = bco.sid;
                    }
                    else
                    {
                        r = "F";
                    }
                    EventBtnDo.FireEventBtn(bco.sid, bcode, "1", " 更改订单");
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