using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvBll.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using LionvBll.SysInfo;
using LionvAopModel;
using LionvModel.SysInfo;
using LionvCommonBll;
using System.Web.Script.Serialization;
using LionvBll.BusiCommon;
using LionvModel.BusiCommon;

namespace LionVERP.UIServer.AfterSaleServiceBusiness.DistributorAfterSale
{
    public partial class AddAfterOrder : System.Web.UI.Page
    {
        private static B_AfterSaleOrderBll basob = new B_AfterSaleOrderBll();
        private static Sys_DepmentBll sdb = new Sys_DepmentBll();
        private static B_SaleOrderBll sbs = new B_SaleOrderBll();
        private static BusiWorkFlowBll bwfb = new BusiWorkFlowBll();
        private static B_QbqqSaleOrderBll bmsob = new B_QbqqSaleOrderBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        private static CB_OrderStateBll cosb = new CB_OrderStateBll();
        private static BusiOrderStateBll bosb = new BusiOrderStateBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region//初始化反馈单
        [WebMethod(true)]
        public static string InitAfterOrder(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            B_AfterSaleOrder ao = new B_AfterSaleOrder ();
            Sys_Depment sd = sdb.Query(" and dcode='" + iv.u.dcode + "'");
            if (iv.f)
            {
                ao = basob.Query(" and sid='" + sid + "'");
                ao.cdate = CommonBll.GetBdate(ao.cdate);
               // ao.ztimg = bosb.QueryOrderStateImg(sid);
                r = js.Serialize(ao);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region//初始化反馈单
        [WebMethod(true)]
        public static string InitAddAfterOrder(string sid,string m)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            B_AfterSaleOrder ao = new B_AfterSaleOrder();
            
            if (iv.f)
            {
                #region//存在原单
                if (sid != "")
                {
                    B_AfterSaleOrder aso = basob.Query(" and sid='" + sid + "'");
                    if (aso != null)
                    {
                        if (m == "a")
                        {
                            ao = aso;
                        }
                        else
                        {
                            aso.osid = aso.sid;
                            aso.sid = "";
                            aso.id = 0;
                            aso.otype = "售后反馈";
                            ao = aso;
                        }
                    }
                    B_SaleOrder bso = sbs.Query(" and sid='" + sid + "'");
                    if (bso != null)
                    {
                        ao.id = 0;
                        ao.sid = "";
                        ao.osid = bso.sid;
                        ao.customer = bso.customer;
                        ao.telephone = bso.telephone;
                        ao.address = bso.address;
                        ao.pcode = bso.scode;
                        ao.dcode = bso.dcode;
                        ao.dname = bso.dname;
                        ao.city = bso.city;
                        ao.citytype = "";// bso.citytype;
                        ao.citycode = bso.citycode;
                        ao.maker = iv.u.ename; ;
                        ao.mname = bso.mname;
                        ao.source = "";
                        ao.aduty = "";
                        ao.areason = "";
                        ao.remark = "";
                        ao.method = "";
                        ao.otype = "木门反馈";
                        ao.wlcompany = "";//bso.wlcompany;
                    }
                    B_QbqqSaleOrder bmso = bmsob.Query(" and sid='" + sid + "'");
                    if (bmso != null)
                    {
                        ao.id = 0;
                        ao.sid = "";
                        ao.osid = bmso.sid;
                        ao.customer = bmso.customer;
                        ao.telephone = bmso.telephone;
                        ao.address = bmso.address;
                        ao.pcode = bmso.scode;
                        ao.dcode = bmso.dcode;
                        ao.dname = bmso.dname;
                        ao.city = bmso.city;
                        ao.citytype = bmso.citytype;
                        ao.citycode = bmso.citycode;
                        ao.maker = iv.u.ename; ;
                        ao.mname = bmso.mname;
                        ao.source = "";
                        ao.areason = "";
                        ao.aduty = "";
                        ao.remark = "";
                        ao.method = "";
                        ao.otype = "木作反馈";
                        ao.wlcompany = bmso.wlcompany;
                    }
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
                    ao.citytype = "";
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
        public static string SaveOrder(string address, string ccode, string citycode, string cityname, string customer, string dcode, string dname,  string duty,string emcode,string e_citytype, string id, string isdf, string maker, string method, string mname,  string osid, string otype, string reason, string remark, string sid, string telephone, string wlcompany)
        {
            string r = "";
            B_AfterSaleOrder b = new B_AfterSaleOrder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
 
                b.osid = osid;
                b.address = address;
                b.aname = "";
                b.acode = "";
                b.community ="";
                b.customer = customer;
                b.dcode = dcode;
                b.dname = dname;
                b.city = cityname;
                b.citytype = e_citytype;
                b.citycode = citycode;
                b.fcode = "";
                b.maker = iv.u.ename;
                b.mname = mname;
                b.osid = osid;
                b.otype = otype;
                b.pcode = ccode;
                b.aduty = duty;
                b.remark = remark;
                b.wlcompany = wlcompany;
                b.areason = reason;
                b.scode = "";
                b.method = method;
                b.source = "";
                b.telephone = telephone;
                b.cdate = DateTime.Now.ToString("yyyy-MM-dd");
                if (sid == "")
                {
                    b.sid = CommonBll.GetSid();
                    if (basob.Add(b) > 0)
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
                }
                else
                {
                    b.sid = sid;
                    if (basob.Update(b))
                    {
                        r = b.sid;
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
    }
}