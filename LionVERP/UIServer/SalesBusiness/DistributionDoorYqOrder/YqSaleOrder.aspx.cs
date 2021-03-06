﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using LionvBll.BusiOrderInfo;
using LionvBll.BusiCommon;
using LionvBll.SysInfo;
using LionvCommonBll;
using System.Web.Services;
using LionvAopModel;
using LionvModel.BusiOrderInfo;
using LionvModel.SysInfo;
using LionvModel.BusiCommon;
using LionVERP.UIServer.BaseSet.WorkFlowManage;

namespace LionVERP.UIServer.SalesBusiness.DistributionDoorYqOrder
{
    public partial class YqSaleOrder : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        private static B_YqSaleOrderBll bsob = new B_YqSaleOrderBll();
        private static B_AfterSaleOrderBll basob = new B_AfterSaleOrderBll();
        private static B_OrderFacotoryBll bofb = new B_OrderFacotoryBll();
        private static BusiComputePriceBll bcpb = new BusiComputePriceBll();
        private static BusiProduceCycBll spcb = new BusiProduceCycBll();
        private static Sys_EmployeeDptBll sedb = new Sys_EmployeeDptBll();
        private static CB_OrderFlowBll cofb = new CB_OrderFlowBll();
        private static Sys_DepmentBll sdb = new Sys_DepmentBll();
        private static CreateOrderCodeBll cocb = new CreateOrderCodeBll();
        private static B_CustomerBll bcb = new B_CustomerBll();
        private static Sys_SettlementBll sslb = new Sys_SettlementBll();
        private static CB_OrderStateBll cosb = new CB_OrderStateBll();
        private static Sys_SaleDiscountBll ssdb = new Sys_SaleDiscountBll();
        private static BusiProduceProcessBll bppb = new BusiProduceProcessBll();
        private static BusiOrderStateBll bosb = new BusiOrderStateBll();
        private static BusiSaleDiscountBll bsdb = new BusiSaleDiscountBll();
        private static B_CustormOrderBll bcob = new B_CustormOrderBll();
        private static QrCodeBll qcb = new QrCodeBll();
        private static Sys_DepmentDptBll sddb = new Sys_DepmentDptBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region///保存销售订单
        [WebMethod(true)]
        public static string SaveOrder(string address, string azperson,string bcode, string citycode, string cityname, string colorpane, string community, string customer, string emcode, string floor,string gytype, string ismb,string maker, string mname, string mtype, string otype, string qbcode, string remark,string saddress, string saletelephone, string shopcode, string shopname, string sid, string source, string surveyor, string telephone, string ycode)
        {
            string r = "";
            BusiWorkFlowBll bwfb = new BusiWorkFlowBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Depment sd = sdb.Query(" and dcode='" + citycode + "'");
                Sys_Depment cd = sdb.Query(" and dcode='" + iv.u.dcode.Substring(0, 8) + "'");
                B_YqSaleOrder bco = new B_YqSaleOrder();
                bco.ccode = cd.dabc + DateTime.Now.ToString("yyyyMMddHHmmss");
                bco.ycode = ycode;
                bco.wcode = "";
                bco.customer = customer;
                bco.telephone = telephone;
                bco.community = "";
                bco.address = address.Replace(",", "，");
                bco.aname = "";
                bco.acode = "";
                bco.dname = shopname;
                bco.dcode = shopcode;
                bco.city = sd != null ? sd.dname : "";
                bco.citytype = "";
                bco.citycode = citycode;
                bco.gzname = "";
                bco.gztelephone = "";
                bco.saletelephone = saletelephone;
                bco.mname = mname;
                bco.source = source;
                bco.remark = remark.Replace(",", "，");
                bco.maker = maker;
                bco.wlcompany = "";
                bco.cdate = DateTime.Now.ToString();
                bco.istax = false;
                bco.isdf = false;
                bco.lxtype = "";
                bco.colorpane = colorpane;
                bco.sname = sd.khcode;
                bco.floor = floor;
                bco.ismb = ismb=="1"?true:false;
                bco.iswj = false;
                bco.saddress = saddress;
                bco.gytype = gytype;
                bco.mtype = "yq";
                bco.bdcode = iv.u.dcode.Substring(0, 8);
                if (sid == "")
                {
                    CB_OrderState cos = new CB_OrderState();
                    bco.sid = CommonBll.GetSid();
                    //bco.qtimg = qcb.CreateUrlQtCode("/UpFile/OrderQt/", CommonBll.GetHost() + "SaleOrderDetail.htm?Sid=", bco.sid);
                    if (bsob.Add(bco) > 0)
                    {
                        bwfb.CreateWorkFlow(bco.sid, emcode);
                        cos.sid = bco.sid;
                        cosb.Add(cos);
                        if (!bcb.Exists(" and customer='" + bco.customer + "' and bdcode='" + iv.u.dcode.Substring(0, 8) + "'"))
                        {
                            B_Customer bc = new B_Customer();
                            bc.dname = bco.dname;
                            bc.dcode = bco.dcode;
                            bc.customer = bco.customer;
                            bc.telephone = bco.telephone;
                            bc.community = bco.community;
                            bc.address = bco.address;
                            bc.cdate = DateTime.Now.ToString();
                            bc.maker = bco.maker;
                            bc.bdcode = iv.u.dcode.Substring(0, 8);
                            bcb.Add(bc);
                        }
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
                    if (bsob.Update(bco))
                    {
                        r = bco.sid;
                    }
                    else
                    {
                        r = "F";
                    }
                }
                EventBtnDo.FireEventBtn(bco.sid, bcode, "1", "保存订单");
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
        public static string LoadSaleOrder(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_YqSaleOrder bco = bsob.Query(" and sid='" + sid + "'");
                if (bco != null)
                {
                    B_CustormOrder bdj = bcob.Query(" and csid='" + bco.csid + "'");
                    r = js.Serialize(bco);
                }
                else
                {
                    Sys_Depment sd = sdb.Query(" and dcode='" + iv.u.dcode + "'");
                    B_SaleOrder kco = new B_SaleOrder();
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
        #region/// 获取销售订单金额订金
        [WebMethod(true)]
        public static string QueryOrderMoney(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_YqSaleOrder bco = bsob.Query(" and sid='" + sid + "'");
                if (bco != null)
                {
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
        #region/// 设置订单工厂
        [WebMethod(true)]
        public static string SaveFactory(string bcode, string fcode, string fline, string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                int dn = 0;
                Sys_Depment sd = sdb.Query(" and dcode='" + fcode + "'");
                B_OrderFacotory bf = new B_OrderFacotory();
                B_YqSaleOrder bso = bsob.Query(" and sid='" + sid + "'");
                B_AfterSaleOrder baso = basob.Query(" and sid='" + sid + "'");
                B_OrderFacotory bof = bofb.Query(" and sid='" + sid + "'");
                if (bso != null)
                {
                    string otype = bso.otype == "补单" ? "补单" : "新单";
                    List<Sys_ProduceCyc> lc = spcb.QueryCheckList(" and emcode='0006' and dcode='" + fcode + "' and otype='" + otype + "'");
                    if (lc != null)
                    {
                        dn = lc[0].cnum;
                    }
                }
                if (baso != null)
                {
                    string otype = baso.otype == "补单" ? "补单" : "新单";
                    List<Sys_ProduceCyc> lc = spcb.QueryCheckList(" and emcode='0035' and dcode='" + fcode + "' and otype='" + otype + "'");
                    if (lc != null)
                    {
                        dn = lc[0].cnum;
                    }
                }
                bf.dname = sd != null ? sd.dname : "";
                bf.dcode = fcode;
                bf.maker = iv.u.ename;
                bf.sid = sid;
                bf.overdate = DateTime.Now.AddDays(dn).ToString();
                bf.otype = bso == null ? "" : bso.otype;
                bf.cdate = DateTime.Now.ToString();
                if (bof != null)
                {
                    if (bofb.Update(bf))
                    {
                        r = "S";
                        if (fline != "")
                        {
                            bppb.SetProduceProcess(sid, fline);
                        }
                        BaseSet.WorkFlowManage.EventBtnDo.FireEventBtn(sid, bcode, "1", "分单");
                        //bcpb.OrderCgComputePrice(sid);
                    }
                    else
                    {
                        r = "F";
                    }
                }
                else
                {
                    if (bofb.Add(bf) > 0)
                    {
                        r = "S";
                        if (fline != "")
                        {
                            bppb.SetProduceProcess(sid, fline);
                        }
                        BaseSet.WorkFlowManage.EventBtnDo.FireEventBtn(sid, bcode, "1", "分单");
                        //bcpb.OrderCgComputePrice(sid);
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