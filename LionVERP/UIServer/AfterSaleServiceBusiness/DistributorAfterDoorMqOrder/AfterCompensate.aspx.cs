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
using LionvModel.BusiOrderInfo;
using System.Web.Script.Serialization;
using LionvCommonBll;

namespace LionVERP.UIServer.AfterSaleServiceBusiness.DistributorAfterSale
{
    public partial class AfterCompensate : System.Web.UI.Page
    {
        private static B_AfterCompensateBll bacb = new B_AfterCompensateBll();
        private static B_AfterSaleOrderBll bsob = new B_AfterSaleOrderBll();
        private static BusiTempletBll btb = new BusiTempletBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region// 初始化赔偿单
        [WebMethod(true)]
        public static string InitCompensate(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_AfterCompensate ba = new B_AfterCompensate();
                B_AfterCompensate bac = bacb.Query(" and sid='" + sid + "'");
                if (bac != null)
                {
                    r = js.Serialize(bac);
                }
                else
                {
                    B_AfterSaleOrder aso = bsob.Query(" and sid='" + sid + "'");
                    if (aso != null)
                    {
                        ba.address = aso.address;
                        ba.cljg = "";
                        ba.customer = aso.customer;
                        ba.pmoney = 0;
                        ba.reason = "";
                        ba.scode = aso.pcode;
                        ba.telephone = aso.telephone;
                    }
                    r = js.Serialize(ba);
                }
            }
            else
            {
                r=iv.badstr;
            }
            return r;
        }
        #endregion
        #region// 保存赔偿单
        [WebMethod(true)]
        public static string SaveCompensate(string paddress, string pcljg, string pcode, string pcustomer, string pmoney, string pqtyy, string ptelephone, string pyy, string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_AfterCompensate ba = new B_AfterCompensate();
                ba.address = paddress;
                ba.cdate = DateTime.Now.ToString();
                ba.cljg = pcljg;
                ba.customer = pcustomer;
                ba.maker = iv.u.ename;
                ba.pmoney = Convert.ToDecimal(pmoney);
                ba.pstate = 0;
                ba.qtreason = pqtyy;
                ba.reason = pyy;
                ba.scode = pcode;
                ba.sid = sid;
                ba.telephone = ptelephone;
                if (bacb.Exists(" and sid='" + sid + "'"))
                {
                    if (bacb.Update(ba))
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
                    if (bacb.Add(ba) > 0)
                    {
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
        #region// 赔偿单Html
        [WebMethod(true)]
        public static string QueryHtml(string emcode,string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string temp = "";
                B_AfterCompensate bac = bacb.Query(" and sid='" + sid + "'");
                if (bac != null)
                {
                    temp = btb.TempBody(emcode, "");
                    temp=temp.Replace("[CUSTOMER]",bac.customer);
                    temp = temp.Replace("[SCODE]", bac.scode);
                    temp = temp.Replace("[ADDRESS]", bac.address);
                    temp = temp.Replace("[TELEPHONE]", bac.telephone);
                    temp = temp.Replace("[QYY]", bacb.SelPcyy(bac.reason, "Q"));
                    temp = temp.Replace("[HYY]", bacb.SelPcyy(bac.reason, "H"));
                    temp = temp.Replace("[QTYY]", bac.qtreason);
                    temp = temp.Replace("[CLJG]", bac.cljg);
                    temp = temp.Replace("[PMONEY]", bac.pmoney.ToString());
                }
                r = temp;
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