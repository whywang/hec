using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvBll.BusiOrderInfo;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.BusiOrderInfo;
using LionvModel.SysInfo;
using System.Web.Script.Serialization;
using LionvCommonBll;
using LionvModel.BusiCommon;
using LionvBll.BusiCommon;
using LionVERP.UIServer.BaseSet.WorkFlowManage;

namespace LionVERP.UIServer.AfterSaleServiceBusiness.DistributorAfterDoorYqOrder
{
    public partial class AfterApplyOrderDetail : System.Web.UI.Page
    {
        private static B_AfterApplyOrderBll bsob = new B_AfterApplyOrderBll();
        private static CB_OrderStateBll cosb = new CB_OrderStateBll();
        private static BusiOrderStateBll bosb = new BusiOrderStateBll();
        private static BusiWorkFlowBll bwfb = new BusiWorkFlowBll();
        private static Sys_DepmentBll sdb = new Sys_DepmentBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region//初始化售后申请单
        [WebMethod(true)]
        public static string InitAddOrder(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            B_AfterApplyOrder ao = new B_AfterApplyOrder();
            if (iv.f)
            {
                #region//存在原单
                if (sid != "")
                {
                    ao = bsob.Query(" and sid='" + sid + "'");
                }
                #endregion
                #region//不存在原单
                if (sid == "")
                {
                    Sys_Depment sd = sdb.Query(" and dcode='" + iv.u.dcode + "'");
                    ao.id = 0;
                    ao.dcode = iv.u.dcode;
                    ao.dname = iv.u.dname;
                    ao.city = sd.dpname;
                    ao.citycode = sd.dpcode;
                    ao.maker = iv.u.ename;
                }
                #endregion
                r = js.Serialize(ao);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion

        #region//保存反馈单
        [WebMethod(true)]
        public static string SaveOrder(string acity,string address,string aprovince, string areason, string bcode, string city, string citycode, string customer, string dcode, string dname, string emcode, string maker, string oscode, string osid, string remark, string sid, string telephone)
        {
            string r = "";
            B_AfterApplyOrder b = new B_AfterApplyOrder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                b.osid = osid;
                b.address = address;
                b.acity = acity;
                b.aprovince = aprovince;
                b.customer = customer;
                b.dcode = dcode;
                b.dname = dname;
                b.city = city;
                b.citycode = citycode;
                b.maker = iv.u.ename;
                b.osid = osid;
                b.oscode = oscode;
                b.remark = remark;
                b.areason = areason;
                b.telephone = telephone;
                b.cdate = DateTime.Now.ToString("yyyy-MM-dd");
                if (sid == "")
                {
                    b.scode = "HFS" + DateTime.Now.ToString("yyMM") + bsob.GetOrderNum().ToString().PadLeft(5, '0');
                    b.sid = CommonBll.GetSid();
                    if (bsob.Add(b) > 0)
                    {
                        r = b.sid;
                        CB_OrderState cs = new CB_OrderState();
                        cs.sid = b.sid;
                        cosb.Add(cs);
                        bwfb.CreateWorkFlow(b.sid, emcode);
                    }
                    else
                    {
                        r = "F";
                    }
                    EventBtnDo.FireEventBtn(b.sid,bcode,"1","创建售后申请单");
                }
                else
                {
                    b.sid = sid;
                    if (bsob.Update(b))
                    {
                        r = b.sid;
                    }
                    else
                    {
                        r = "F";
                    }
                    EventBtnDo.FireEventBtn(b.sid, bcode, "1", "更新售后申请单");
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