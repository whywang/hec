using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvBll.BusiOrderInfo;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using System.Web.Script.Serialization;
using ViewModel.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using LionvCommonBll;
using LionvBll.Account;
using LionvModel.Account;
using LionvBll.BusiCommon;

namespace LionVERP.UIServer.SalesBusiness.DistributorOrder
{
    public partial class CustomerGatherDetail : System.Web.UI.Page
    {
        private static B_CustomerGatherBll bcgb = new B_CustomerGatherBll();
        private static B_CustormOrderBll bcob = new B_CustormOrderBll();
        private static BusiInvTempBll bitb = new BusiInvTempBll();
        private static A_CustomeAccountBll acab = new A_CustomeAccountBll();
        private static BusiWorkFlowBll bwfb = new BusiWorkFlowBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region/// 初始化订金收款单
        [WebMethod(true)]
        public static string InitGatherOrder(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                VGatherOrder vg = new VGatherOrder();
                B_CustormOrder bco = bcob.Query(" and csid='" + sid + "'");
                A_CustomeAccount bcg = acab.Query(" and sid='" + sid + "'");
                if (bcg != null)
                {
                    vg.customer = bco.customer;
                    vg.wcode = bco.wcode;
                    vg.gmethod = bcg.pmethod;
                    vg.gmoney = bcg.pmoney;
                    vg.gperson = bcg.maker;
                    vg.remark = bcg.remark;
                    vg.gdate = bcg.ddate;
                }
                else
                {
                    vg.customer = bco.customer;
                    vg.wcode = bco.wcode;
                    vg.gmoney = 0;
                }
                r = js.Serialize(vg);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region/// 保存订金收款单
        [WebMethod(true)]
        public static string SaveGatherOrder(string gdate, string gmoney, string gmethod, string gperson, string gremark, string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_CustormOrder bco = bcob.Query(" and csid='" + sid + "'");
                A_CustomeAccount bcg = new A_CustomeAccount();
                bcg.gsid = CommonBll.GetSid();
                bcg.address = bco.address;
                bcg.customer = bco.customer;
                bcg.telephone = bco.telephone;
                bcg.citycode = bco.e_citycode;
                bcg.cityname = bco.e_city;
                bcg.dcode = bco.dcode;
                bcg.dname = bco.dname;
                bcg.pcate = "订金";
                bcg.scode = bco.wcode;
                bcg.ptype = 1;
                bcg.pstate = 0;
                bcg.pmethod = gmethod;
                bcg.pmoney = Convert.ToDecimal(gmoney);
                bcg.maker = gperson;
                bcg.remark = gremark;
                bcg.ddate =CommonBll.GetBdate( gdate);
                bcg.cdate = DateTime.Now.ToString();
                bcg.sid = sid;
                if (acab.Exists(" and sid='" + sid + "'"))
                {
                    if (acab.UpdateEx(bcg))
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
                    if (acab.Add(bcg) > 0)
                    {
                        bwfb.CreateWorkFlow(bcg.gsid, "0092");
                        r = "S";
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
        #region/// 订金收款单Temp
        [WebMethod(true)]
        public static string GatherOrderHtm(string sid, string emcode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = bitb.GatherOrderHtml(emcode, sid);
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