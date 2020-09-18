using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvBll.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using System.Web.Script.Serialization;
using LionvModel.SysInfo;
using LionvCommonBll;
using LionvModel.BusiCommon;
using LionvBll.BusiCommon;

namespace LionVERP.UIServer.SalesBusiness.DistributionMzOrder
{
    public partial class MzSaleOrderDetail : System.Web.UI.Page
    {
        private static B_MzSaleOrderBll bmsob = new B_MzSaleOrderBll();
        private static Sys_DepmentBll sdb = new Sys_DepmentBll();
        private static BusiOrderStateBll bosb = new BusiOrderStateBll();
        private static CB_OrderStateBll cosb = new CB_OrderStateBll();
        private static B_CustomerBll bcb = new B_CustomerBll();
        private static CB_OrderFlowBll cofb = new CB_OrderFlowBll();
        private static BusiWorkFlowBll bwfb = new BusiWorkFlowBll();
        private static Sys_MzOrderTypeBll smotb = new Sys_MzOrderTypeBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region--获取木作单信息
        [WebMethod(true)]
        public static string QueryMzOrder(string sid)
        {
            string r = "";
            B_MzSaleOrder bms = new B_MzSaleOrder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sid == "")
                {
                    Sys_Depment sd = sdb.Query(" and dcode='" + iv.u.dcode + "'");
                    bms.id = 0;
                    bms.city = sd.dpname;
                    bms.citycode = sd.dpcode;
                    bms.dcode = iv.u.dcode;
                    bms.dname = iv.u.dname;
                    bms.maker = iv.u.ename;
                }
                else
                {
                    bms = bmsob.Query("and sid='" + sid + "'");
                    //bms.ztimg = bosb.QueryOrderStateImg(sid);
                }
                r = js.Serialize(bms);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region--保存木作单信息
        [WebMethod(true)]
        public static string SaveOrder(string address, string bcode, string city, string citycode, string community, string customer, string dcode, string designer, string dname, string emcode, string id, string maker, string mname, string precode, string remark, string saletelephone, string sid, string source, string telephone, string zbdesigner)
        {
            string r = "";
            B_MzSaleOrder bms = new B_MzSaleOrder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                bms.acode = "";
                bms.aname = "";
                bms.address = address;
                bms.community = community;
                bms.city = city;
                bms.citycode = citycode;
                bms.customer = customer;
                bms.dname = dname;
                bms.dcode = dcode;
                bms.designer = designer;
                bms.maker = iv.u.ename;
                bms.mname = mname;
                bms.ycode = precode;
                bms.remark = remark;
                bms.source = source;
                bms.telephone = telephone;
                bms.zbdesigner = zbdesigner;
                bms.cdate = DateTime.Now.ToString();
                if (id == "0")
                {
                    bms.sid = CommonBll.GetSid();
                    CB_OrderState cos = new CB_OrderState();
                    if (bmsob.Add(bms) > 0)
                    {
                        bwfb.CreateWorkFlow(bms.sid,emcode);
                        cos.sid = bms.sid;
                        cosb.Add(cos);
                        if (!bcb.Exists(" and telephone='" + telephone + "'"))
                        {
                            B_Customer bc = new B_Customer();
                            bc.dname = bms.dname;
                            bc.dcode = bms.dcode;
                            bc.customer = bms.customer;
                            bc.telephone = bms.telephone;
                            bc.community = bms.community;
                            bc.address = bms.address;
                            bc.cdate = DateTime.Now.ToString();
                            bc.maker = bms.maker;
                            bcb.Add(bc);
                        }
                        r = bms.sid;
                    }
                    else
                    {
                        r = "F";
                    }
                }
                else
                {
                    bms.sid = sid;
                    if (bmsob.Update(bms))
                    {
                        r = bms.sid;
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