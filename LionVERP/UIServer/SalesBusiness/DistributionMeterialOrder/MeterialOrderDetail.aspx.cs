using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvAopModel;
using LionvBll.BusiOrderInfo;
using LionvBll.SysInfo;
using LionvModel.BusiOrderInfo;
using System.Web.Script.Serialization;
using LionvModel.SysInfo;
using LionvCommonBll;
using LionvModel.BusiCommon;
using LionvBll.BusiCommon;
using LionVERP.UIServer.BaseSet.WorkFlowManage;

namespace LionVERP.UIServer.SalesBusiness.DistributionMeterialOrder
{
    public partial class MeterialOrderDetail : System.Web.UI.Page
    {
        private static B_SaleMaterielOrderBll bsmob = new B_SaleMaterielOrderBll();
        private static CB_OrderStateBll cosb = new CB_OrderStateBll();
        private static CB_OrderFlowBll cofb = new CB_OrderFlowBll();
        private static BusiWorkFlowBll bwfb = new BusiWorkFlowBll();
        private static Sys_DepmentBll sdb = new Sys_DepmentBll();
        private static Sys_DepmentDptBll sddb = new Sys_DepmentDptBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region/// 获取销售物料订单
        [WebMethod(true)]
        public static string QueryOrder(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_SaleMaterielOrder bco = bsmob.Query(" and sid='" + sid + "'");
                if (bco != null)
                {
                    r = js.Serialize(bco);
                }
                else
                {
                    Sys_Depment sd = sdb.Query(" and dcode='" + iv.u.dcode + "'");
                    B_SaleMaterielOrder kco = new B_SaleMaterielOrder();
                    if (sd != null)
                    {
                        if (sd.dattr == "cs")
                        {
                            Sys_DepmentDpt sdd = sddb.Query(" and dcode='" + sd.dcode + "'");
                            kco.city = sd.dpname;
                            kco.citycode = sd.dpcode;
                            kco.dname = sd.dname;
                            kco.dcode = sd.dcode;
                            kco.stelephone = sdd != null ? sdd.dcontact : "";
                        }
                        else if (sd.dattr == "dm")
                        {
                            Sys_DepmentDpt sdd = sddb.Query(" and dcode='" + sd.dcode.Substring(0, sd.dcode.Length - 4) + "'");
                            kco.city = sd.dpname;
                            kco.citycode = sd.dpcode;
                            kco.dname = sd.dname;
                            kco.dcode = sd.dcode;
                            kco.stelephone = sdd != null ? sdd.dcontact : "";
                        }
                        else
                        {
                            kco.city = "";
                            kco.citycode = "";
                            kco.dname = "";
                            kco.dcode = "";
                        }
                    }
                    kco.maker = iv.u.ename;
                    r = js.Serialize(kco);
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region/// 保存销售物料订单
        [WebMethod(true)]
        public static string SaveOrder(string bcode,string city,string citycode,string dcode,string dname,string emcode,string maker,string otype,string remark,string saddress,string sid,string sperson,string stelephone,string wltype)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_SaleMaterielOrder bco = new B_SaleMaterielOrder ();
                bco.acode = "";
                bco.aname = "";
                bco.bdcode="";
                bco.cdate = DateTime.Now.ToString();
                bco.city = city;
                bco.citycode = citycode;
                bco.dcode = dcode;
                bco.dname = dname;
                bco.gdiscount = 1;
                bco.maker = maker;
                bco.otype = otype;
                bco.remark = remark;
                bco.saddress = saddress;
                bco.stelephone = stelephone;
                bco.qtimg = "";
                bco.sperson=sperson;
                bco.wltype = wltype;
                bco.bdcode = "00010001";
                if (sid == "")
                {
                    bco.sid=CommonBll.GetSid();
                    if (bsmob.Add(bco) > 0)
                    {
                        CB_OrderState cos = new CB_OrderState();
                        cos.sid = bco.sid;
                        cosb.Add(cos);
                        bwfb.CreateWorkFlow(bco.sid, emcode);
                        r = bco.sid;
                    }
                    else
                    {
                        r = "F";
                    }
                }
                else
                {
                    bco.sid = sid;
                    if (bsmob.Update(bco))
                    {
                        r = bco.sid;
                    }
                    else
                    {
                        r = "F";
                    }
                }
                EventBtnDo.FireEventBtn(bco.sid, bcode, "1", "订单保存");
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