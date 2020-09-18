using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvBll.BusiOrderInfo;
using LionvBll.BusiCommon;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.BusiOrderInfo;
using System.Web.Script.Serialization;
using LionvCommonBll;
using LionvModel.BusiCommon;

namespace LionVERP.UIServer.ChangeServiceBusiness.DistributorChangeDoorMqOrder
{
    public partial class CSaleMqOrder : System.Web.UI.Page
    {
        private static B_SaleChangeOrderBll bscob = new B_SaleChangeOrderBll();
        private static CB_OrderFlowBll cofb = new CB_OrderFlowBll();
        private static CB_OrderStateBll cosb = new CB_OrderStateBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        private static B_SaleOrderBll bsob = new B_SaleOrderBll();
        private static BusiWorkFlowBll bwfb = new BusiWorkFlowBll();
        private static QrCodeBll qcb = new QrCodeBll();
        private static B_GroupProductionChangeBll bgpcb = new B_GroupProductionChangeBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region/// 获取更改订单
        [WebMethod(true)]
        public static string QueryOrder(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_SaleChangeOrder bsco = new B_SaleChangeOrder();
                B_SaleChangeOrder bco = bscob.Query(" and sid='" + sid + "'");
                if (bco != null)
                {
                    bsco = bco;
                    if (bgpcb.Exists(" and sid='" + sid + "'"))
                    {
                        bsco.hasproduction = "1";
                    }
                    
                }
                else
                {
                    B_SaleOrder bso = bsob.Query(" and sid='" + sid + "'");
                    if (bso != null)
                    {
                        bsco.scode = "";
                        bsco.oscode = bso.scode;
                        bsco.e_city = bso.city;
                        bsco.dname= bso.dname;
                        bsco.customer = bso.customer;
                        bsco.telephone = bso.telephone;
                        bsco.address = bso.address;
                        bsco.otype = "木门更改单";
                        bsco.mname = bso.mname;
                        bsco.sname = "";// bso.sname;
                        bsco.cdate = DateTime.Now.ToString();
                        bsco.maker = "";
                        bsco.creason = "";
                        bsco.osid = sid;
                        bsco.sid = "";
                    }
                }
                r = js.Serialize(bsco);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region/// 保存更改订单
        [WebMethod(true)]
        public static string SaveOrder(string bcode,string creason,string emcode,string mtype,string sid, string osid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_SaleChangeOrder bsco = new B_SaleChangeOrder();
                if (sid == "")
                {
                    bsco.sid = CommonBll.GetSid();
                    bsco.osid = osid;
                    bsco.creason = creason;
                    bsco.mtype = mtype;
                    bsco.sqcode = "BS" + DateTime.Now.ToString("yyMMddHHmmss");
                    bsco.maker = iv.u.ename;
                    bsco.cdate = DateTime.Now.ToString();
                    bsco.qtimg = qcb.CreateQtCode(System.Web.HttpContext.Current.Server.MapPath("/UpFile/OrderQt/"), CommonBll.GetHost() + "UIClient/ChangeServiceBusiness/DistributorChangeDoorMqOrder/CDoorFrameSaleOrder.htm?Sid=" + bsco.sid);
                    if (bscob.Add(bsco)>0)
                    {
                        CB_OrderState cos = new CB_OrderState();
                        cos.sid = bsco.sid;
                        cosb.Add(cos);
                        bwfb.CreateWorkFlow(bsco.sid, emcode);
                        r= bsco.sid;
                    }
                }
                else
                {
                    bsco.sid =sid;
                    bsco.osid = osid;
                    bsco.creason = creason;
                    bsco.maker = iv.u.ename;
                    bsco.cdate = DateTime.Now.ToString();
                    if (bscob.Update(bsco))
                    {
                        r = bsco.sid;
                    }
                }
                BaseSet.WorkFlowManage.EventBtnDo.FireEventBtn(bsco.sid, bcode, "1", "保存更改单");
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region/// 保存更改成本信息
        [WebMethod(true)]
        public static string UpChangeCost(string sid, string ccost, string cremark, string pjd)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (bscob.UpChangeCost(sid,Convert.ToDecimal( ccost), cremark, pjd))
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