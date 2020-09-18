using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvBll.BusiOrderInfo;
using System.Web.Script.Serialization;
using LionvBll.BusiCommon;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.BusiOrderInfo;
using LionvModel.SysInfo;
using LionvCommonBll;
using LionvModel.BusiCommon;
using LionVERP.UIServer.BaseSet.WorkFlowManage;
using LionvBll.ProductionInfo;
using LionvModel.ProductionInfo;

namespace LionVERP.UIServer.SalesBusiness.DistributorDoorOrder
{
    public partial class SaleOrderDetail : System.Web.UI.Page
    {
        private static B_OrdersBll bob = new B_OrdersBll();
        private static B_CustomerBll bcb = new B_CustomerBll();
        private static B_SaleOrderBll bsob = new B_SaleOrderBll();
        private static B_MeasureOrderBll bmob = new B_MeasureOrderBll();
        private static CB_OrderFlowBll cofb = new CB_OrderFlowBll();
        private static CB_OrderStateBll cosb = new CB_OrderStateBll();
        private static BusiWorkFlowBll bwfb = new BusiWorkFlowBll();
        private static QrCodeBll qcb = new QrCodeBll();
        private static Sys_DepmentDptBll sddb = new Sys_DepmentDptBll();
        private static Sys_BrandsBll sbb = new Sys_BrandsBll();
        private static Sys_CityGetAddressBll scgab = new Sys_CityGetAddressBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region/// 初始化销售订单
        [WebMethod(true)]
        public static string InitOrder(string sid,string zsid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_SaleOrder bco = new B_SaleOrder();
                if (sid != "")
                {
                    bco = bsob.Query(" and sid='" + sid + "'");
                    r = js.Serialize(bco);
                }
                else
                {
                    if (zsid != "")
                    {
                        B_Orders bo = bob.Query(" and sid='" + zsid + "'");
                        Sys_DepmentDpt sdd = sddb.Query(" and dcode='" + bo.dcode + "'");
                        bco.city = bo.city;
                        bco.citycode =bo.citycode;
                        bco.dname = bo.dname;
                        bco.dcode = bo.dcode;
                        bco.zsid = bo.sid;
                        bco.customer = bo.customer;
                        bco.telephone = bo.telephone;
                        bco.address = bo.address;
                        bco.community = bo.community;
                        bco.zcode = bo.zcode;
                        bco.stelephone = sdd != null ? sdd.dcontact : "";
                        bco.maker = iv.u.ename;
                    }
                    r = js.Serialize(bco);
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region/// 获取销售订单
        [WebMethod(true)]
        public static string QueryOrder(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_SaleOrder bco = bsob.Query(" and sid='" + sid + "'");
                r = js.Serialize(bco);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region/// 保存销售订单
        [WebMethod(true)]
        public static string SaveOrder(string acity,string address, string aprovince, string azperson, string bcode, string city, string citycode,string clperson, string ctype,string customer,  string dcode,string discode, string dname, string emcode,string iscl, string maker, string mname,string otype,string pbdcode,string qytype, string remark, string saletelephone,string sdtype, string sid,  string source,string stype,string telephone,string untype,string zcode, string zsid )
        {
            string r = "";
            string saddr = "";
            
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_Orders bo = bob.Query(" and sid='" + zsid + "'");
                Sys_CityGetAddress scga = scgab.QueryFrist(" and dcode='" + citycode + "'");
                Sys_Brands sbs = sbb.Query(" and pbcode='" + pbdcode + "'");
                B_SaleOrder bco = new B_SaleOrder();
                if (scga != null)
                {
                    saddr = scga.address;
                }
                bco.csid = bo != null ? bo.csid : "";
                bco.zsid = zsid;
                bco.zcode = bo!=null?bo.zcode:"";
                bco.wcode = "";
                bco.oscode = "";
                bco.customer = customer;
                bco.telephone = telephone;
                bco.community = "";
                bco.address = address.Replace(",", "，");
                bco.dname = dname;
                bco.dcode = dcode;
                bco.city = city;
                bco.citycode = citycode;
                bco.gzname = "";
                bco.gztelephone = "";
                bco.stelephone = saletelephone;
                bco.otype = otype;
                bco.sendtype = stype;
                bco.sdtype=sdtype;
                bco.mname = mname;
                bco.source = source;
                bco.remark = remark.Replace(",", "，");
                bco.maker = maker;
                bco.cdate = DateTime.Now.ToString();
                bco.istax = false;
                bco.isdf = false;
                bco.iscl = iscl == "0" ? false : true;
                bco.colorpane = "";
                bco.floor = "";
                bco.disactcode = discode;
                bco.bdcode = iv.u.dcode.Substring(0, 8);
                bco.clperson = clperson;
                bco.azperson = azperson;
                bco.pbdcode = pbdcode;
                bco.pbdname = sbs != null ? sbs.pbname : "";
                bco.saddress = aprovince == "" ? saddr : aprovince + acity + address;
                bco.qytype = qytype;
                bco.ctype = ctype;
                bco.untype = untype;
                if (bco.citycode.Substring(0, 12) != "000100010008")
                {
                    bco.package = "外地包装";
                }
                else
                {
                    bco.package = "本地包装";
                }
                bco.sdcode ="S" +DateTime.Now.ToString("yyMM") + bsob.QueryOrderNum();
                if (sid == "")
                {
                    CB_OrderState cos = new CB_OrderState();
                    bco.sid = CommonBll.GetSid();
                    bco.qtimg = qcb.CreateQtCode(System.Web.HttpContext.Current.Server.MapPath("/UpFile/OrderQt/"), CommonBll.GetHost() + "/UIClient/QtScan/OrderDetail.htm?Sid=" + bco.sid);
                    if (bsob.Add(bco) > 0)
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
                    if (bsob.Update(bco))
                    {
                        if (bmob.Exists(" and osid='" + sid + "'"))
                        {
                            if (!bco.iscl)
                            {
                                bmob.Delete(" and osid='" + sid + "'");
                            }
                        }
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