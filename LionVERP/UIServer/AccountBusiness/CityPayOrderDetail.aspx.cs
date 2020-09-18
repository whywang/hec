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
using LionvCommonBll;
using LionvBll.BusiCommon;
using System.Web.Script.Serialization;
using ViewModel.Account;
using LionvModel.BusiCommon;
using LionvBll.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using System.Text;

namespace LionVERP.UIServer.AccountBusiness
{
    public partial class CityPayOrderDetail : System.Web.UI.Page
    {
        private static B_CityPayOrderBll bcpob = new B_CityPayOrderBll();
        private static BusiWorkFlowBll bwfb = new BusiWorkFlowBll();
        private static CB_OrderStateBll cosb = new CB_OrderStateBll();
        private static B_PayImgBll bpib = new B_PayImgBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod(true)]
        public static string InitPayOrder(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_CityPayOrder bcp = new B_CityPayOrder();
                if (sid != "")
                {
                    bcp = bcpob.Query(" and sid='" + sid + "'");
                }
                else
                {
                    bcp.sid = CommonBll.GetSid();
                    bcp.dname = iv.u.dname;
                    bcp.dcode = iv.u.dcode;
                    bcp.pstate = 0;
                    bcp.cdate = DateTime.Now.ToString();
                    bcp.maker = iv.u.ename;
                    bcp.id = 0;
                    bcpob.AddDraft(bcp);
                }
                r = js.Serialize(bcp);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        [WebMethod(true)]
        public static string SavePayOrder(string caccount,string cbank,string cperson,string ctype,string id, string paccount, string pbank,string pdate , string pmethod, string pmoney,string pperson,string remark,string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_CityPayOrder bcp = new B_CityPayOrder();
                bcp.sid = sid;
                bcp.caccount = caccount;
                bcp.cbank = cbank;
                bcp.cperson = cperson;
                bcp.ctype = ctype;
                bcp.paccount = paccount;
                bcp.pbank = pbank;
                bcp.pdate = pdate;
                bcp.pmethod = pmethod;
                bcp.pmoney = Convert.ToDecimal(pmoney);
                bcp.pperson = pperson;
                bcp.pstate = 1;
                bcp.remark = remark;
                bcp.cdate = DateTime.Now.ToString();
                bcp.maker = iv.u.ename;
                if (bcpob.Exists(" and pstate=0"))
                {
                    bcp.pcode = "MKDP"+DateTime.Now.ToString("yyMMddhhmmss");
                    bwfb.CreateWorkFlow(bcp.sid, "0099");
                    cosb.Add(sid);
                }
                if (bcpob.Update(bcp))
                {
                    r = sid;
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
        [WebMethod(true)]
        public static string QueryPayOrder(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                VCPaymentOrder vp = new VCPaymentOrder();
                B_CityPayOrder bcp = new B_CityPayOrder();
                if (sid != "")
                {
                    StringBuilder mhtm = new StringBuilder ();
                    CB_OrderState cos=cosb.Query(" and sid='"+sid+"'");

                    bcp = bcpob.Query(" and sid='" + sid + "'");
                    vp.caccount = bcp.caccount;
                    vp.cbank = bcp.cbank;
                    vp.cdate = CommonBll.GetBdate(bcp.cdate);
                    vp.ctype = bcp.ctype;
                    vp.dname = bcp.dname;
                    vp.kj = "";
                    vp.maker = bcp.maker;
                    vp.paccount = bcp.paccount;
                    vp.pbank = bcp.pbank;
                    vp.pcode = bcp.pcode;
                    vp.pdate = CommonBll.GetBdate(bcp.pdate);
                    vp.pmethod = bcp.pmethod;
                    vp.pmoney = bcp.pmoney.ToString();
                    vp.remark = bcp.remark;
                    if (cos.iover > 0)
                    {
                        vp.zt = "取消";
                    }
                    else
                    {
                        vp.zt = "正常";
                    }
                    List<B_PayImg> lbp = bpib.QueryList(" and sid='" + sid + "' and ptype='cp'");
                    if (lbp != null)
                    {
                        foreach (B_PayImg b in lbp)
                        {
                            mhtm.AppendFormat("<img id='{0}' onclick='nck(this.id)' src='{1}' alt='' style='width:100%'/><br>", b.id, b.url);
                        }
                    }
                    vp.ming = mhtm.ToString();
                }
                r = js.Serialize(vp);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
    }
}