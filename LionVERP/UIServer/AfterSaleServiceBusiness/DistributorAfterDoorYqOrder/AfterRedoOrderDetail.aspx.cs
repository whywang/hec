using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvBll.SysInfo;
using LionvAopModel;
using LionvModel.BusiOrderInfo;
using LionvBll.BusiOrderInfo;
using System.Web.Script.Serialization;
using System.Collections;
using LionvModel.SysInfo;
using System.Text;
using LionvCommonBll;
using LionvModel.BusiCommon;
using LionvBll.BusiCommon;
using LionVERP.UIServer.BaseSet.WorkFlowManage;

namespace LionVERP.UIServer.AfterSaleServiceBusiness.DistributorAfterDoorYqOrder
{
    public partial class AfterRedoOrderDetail : System.Web.UI.Page
    {
        private static B_AfterReModifyOrderBll basob = new B_AfterReModifyOrderBll();
        private static B_AfterFreeBackOrderBll bsob = new B_AfterFreeBackOrderBll();
        private static B_AfterPartInHouseOrderBll baihob = new B_AfterPartInHouseOrderBll();
        private static CB_OrderFlowBll cofb = new CB_OrderFlowBll();
        private static Sys_RepairDutyBll srdb = new Sys_RepairDutyBll();
        private static B_AfterOrderDutyBll abodb = new B_AfterOrderDutyBll();
        private static CB_OrderStateBll cosb = new CB_OrderStateBll();
        private static BusiWorkFlowBll bwfb = new BusiWorkFlowBll();
        private static Sys_DepmentBll sdb = new Sys_DepmentBll();
        private static Sys_CityGetAddressBll scgab = new Sys_CityGetAddressBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region//初始化反馈单
        [WebMethod(true)]
        public static string initOrder(string sid,string asid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            B_AfterReModifyOrder ao = new B_AfterReModifyOrder();
            if (iv.f)
            {
                if (sid != "")
                {
                    ao = basob.Query(" and sid='" + sid + "'");
                    r = js.Serialize(ao);
                }
                else
                {
                    if (asid != "")
                    {
                        B_AfterFreeBackOrder bo = bsob.Query(" and sid='" + asid + "'");
                        ao.city = bo.city;
                        ao.citycode = bo.citycode;
                        ao.dcode = bo.dcode;
                        ao.dname = bo.dname;
                        ao.acity = bo.acity;
                        ao.aprovince = bo.aprovince;
                        ao.areason = bo.areason;
                        ao.ascode = bo.scode;
                        ao.asid = bo.sid;
                        ao.osid = bo.osid;
                        ao.otype = bo.otype;
                        ao.customer = bo.customer;
                        ao.telephone = bo.telephone;
                        ao.remark = bo.remark;
                        ao.maker = iv.u.ename;
                        ao.oscode = bo.oscode;
                    }
                    else
                    {
                        Sys_Depment sd = sdb.Query(" and dcode='" + iv.u.dcode + "'");
                        ao.id = 0;
                        ao.dcode = iv.u.dcode;
                        ao.dname = iv.u.dname;
                        ao.city = sd.dpname;
                        ao.citycode = sd.dpcode;
                        ao.maker = iv.u.ename;
                    }
                    r = js.Serialize(ao);
                }
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
        public static string SaveOrder(string acity,string address,string aprovince,string areason,string ascode,string asid,string bcode,string city,string citycode,string customer,string dcode,string dname,string emcode,string isfc,string maker,string oscode,string osid,string otype,string ptype,string remark, string sid,string stype, string telephone)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            B_AfterReModifyOrder ao = new B_AfterReModifyOrder();
            if (iv.f)
            {
                ao.acity = acity;
                ao.aprovince = aprovince;
                if (acity == "")
                {
                    Sys_CityGetAddress sca = scgab.QueryRefFrist(dcode);
                    ao.address = sca != null ? sca.address : "";
                }
                else
                {
                    ao.address = address;
                }
                Sys_Depment sd = sdb.Query(" and dcode='" + dcode + "'");
                ao.ascode = ascode.Trim();
                ao.asid = asid;
                ao.cdate = DateTime.Now.ToString();
                ao.city = city;
                ao.citycode = citycode;
                ao.customer = customer;
                ao.dcode = dcode;
                ao.dname = dname;
                ao.isbf = isfc == "1" ? true : false;
                ao.maker = maker;
                ao.oscode = oscode;
                ao.osid = osid;
                ao.otype = otype;
                ao.ptype = ptype;
                ao.remark = remark;
                ao.sendtype = stype;
                ao.telephone = telephone;
                ao.areason = areason;
                ao.qytype = sd != null ? sd.dmattr : "";
                if (sid == "")
                {
                    string cnstr = basob.GetOrderNum().ToString().PadLeft(4, '0');
                    if (cnstr.Length > 4)
                    {
                        cnstr = cnstr.Substring(1, cnstr.Length - 1);
                    }
                    ao.scode = "HF" + DateTime.Now.ToString("yyMM") + cnstr;
                    ao.sid = CommonBll.GetSid();
                    if (basob.Add(ao) > 0)
                    {
                        r = ao.sid;
                        CB_OrderState cs = new CB_OrderState();
                        cs.sid = ao.sid;
                        cosb.Add(cs);
                        bwfb.CreateWorkFlow(ao.sid, emcode);
                    }
                    else
                    {
                        r = "F";
                    }
                    EventBtnDo.FireEventBtn(ao.sid, bcode, "1", "创建返修单");
                }
                else
                {
                    ao.sid = sid;
                    if (basob.Update(ao))
                    {
                        r = ao.sid;
                    }
                    else
                    {
                        r = "F";
                    }
                    EventBtnDo.FireEventBtn(ao.sid, bcode, "1", "更新返修单");
                }
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
        public static string SaveOrderKf(string acity, string address, string aprovince, string areason, string ascode, string asid, string bcode, string customer, string dcode, string emcode, string isfc, string maker, string oscode, string osid, string otype, string ptype, string remark, string sid, string stype, string telephone)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            B_AfterReModifyOrder ao = new B_AfterReModifyOrder();
            if (iv.f)
            {
                ao.acity = acity;
                ao.aprovince = aprovince;
                if (acity == "")
                {
                    Sys_CityGetAddress sca = scgab.QueryRefFrist(dcode);
                    ao.address = sca != null ? sca.address : "";
                }
                else
                {
                    ao.address = address;
                }
                Sys_Depment sd = sdb.Query(" and dcode='" + dcode + "'");
                Sys_Depment csd = sdb.Query(" and dcode='" + sd.dpcode + "'");
                ao.ascode = ascode.Trim();
                ao.asid = asid;
                ao.cdate = DateTime.Now.ToString();
                ao.city = csd.dname;
                ao.citycode = csd.dcode;
                ao.customer = customer;
                ao.dcode = dcode;
                ao.dname = sd.dname;
                ao.isbf = isfc == "1" ? true : false;
                ao.maker = maker;
                ao.oscode = oscode;
                ao.osid = osid;
                ao.otype = otype;
                ao.ptype = ptype;
                ao.remark = remark;
                ao.sendtype = stype;
                ao.telephone = telephone;
                ao.areason = areason;
                ao.qytype = sd != null ? sd.dmattr : "";
                if (sid == "")
                {
                    ao.scode = "HF" + DateTime.Now.ToString("yyMM") + basob.GetOrderNum().ToString().PadLeft(4, '0');
                    ao.sid = CommonBll.GetSid();
                    if (basob.Add(ao) > 0)
                    {
                        r = ao.sid;
                        CB_OrderState cs = new CB_OrderState();
                        cs.sid = ao.sid;
                        cosb.Add(cs);
                        bwfb.CreateWorkFlow(ao.sid, emcode);
                    }
                    else
                    {
                        r = "F";
                    }
                    EventBtnDo.FireEventBtn(ao.sid, bcode, "1", "创建返修单");
                }
                else
                {
                    ao.sid = sid;
                    if (basob.Update(ao))
                    {
                        r = ao.sid;
                    }
                    else
                    {
                        r = "F";
                    }
                    EventBtnDo.FireEventBtn(ao.sid, bcode, "1", "更新返修单");
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region//获取反馈单
        [WebMethod(true)]
        public static string QueryOrder(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            B_AfterReModifyOrder ao = new B_AfterReModifyOrder();
            if (iv.f)
            {
                ao = basob.Query(" and sid='" + sid + "'");
                ao.rcode = iv.u.rcode;
                ao.tsdate = cofb.Query(" and sid='" + sid + "' and wcode='0096'").edate;
                r = js.Serialize(ao);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region// 获取售后单责任信息
        [WebMethod(true)]
        public static ArrayList QueryOrderDuty(string sid)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_RepairDuty> lrd = srdb.QueryList("");
                if (lrd != null)
                {
                    foreach (Sys_RepairDuty rd in lrd)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(rd.rdetail);
                        al.Add(rd.rcode);
                        B_AfterOrderDuty ad = abodb.Query(" and sid='" + sid + "' and dcode='" + rd.rcode + "'");
                        if (ad != null)
                        {
                            al.Add(ad.dprev);
                            al.Add(ad.dmoney);
                        }
                        else
                        {
                            al.Add(0);
                            al.Add(0);
                        }
                        r.Add(al);
                    }
                }
            }
            else
            {
                r.Add(iv.badstr);
            }
            return r;
        }
        #endregion
        #region// 反馈 责任及处理方式
        [WebMethod(true)]
        public static string SetDuty(string sid, ArrayList pduty, string clfs, string om)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                decimal blnum = 0;
                StringBuilder dstr = new StringBuilder();
                List<B_AfterOrderDuty> lbd = new List<B_AfterOrderDuty>();
                if (pduty != null)
                {
                    foreach (object[] pdl in pduty)
                    {
                        if (pdl[2].ToString() != "" && pdl[2].ToString() != "0")
                        {
                            B_AfterOrderDuty rd = new B_AfterOrderDuty();
                            rd.sid = sid;
                            rd.dname = pdl[0].ToString();
                            rd.dcode = pdl[1].ToString();
                            rd.dprev = Convert.ToDecimal(pdl[2].ToString());
                            rd.dmoney = Convert.ToDecimal(pdl[3].ToString());
                            rd.maker = iv.u.ename;
                            rd.cdate = DateTime.Now.ToString();
                            lbd.Add(rd);
                            blnum = blnum + rd.dprev;
                            dstr.AppendFormat("{0}-{1}-{2};", rd.dname, rd.dprev, rd.dmoney);
                        }
                    }
                }
                if (blnum > 100)
                {
                    r = "BLB";
                }
                else
                {
                    abodb.Delete(" and sid='" + sid + "'");
                    abodb.AddList(lbd);
                    B_AfterReModifyOrder baso = basob.Query(" and sid='" + sid + "'");
                    if (baso != null)
                    {
                        //if (basob.SetDuty(sid, dstr.ToString(), clfs, Convert.ToDecimal(om)) > 0)
                        //{
                        //    r = "S";
                        //}
                        //else
                        //{
                        //    r = "F";
                        //}
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
        #region// 反馈 责任及处理方式
        [WebMethod(true)]
        public static string SaveDuty(string adremark, string aduty,string afcode,string afname,string areason, string omoney, string premark, string qmoney,string sid,   string stype)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_AfterReModifyOrder co = basob.Query("and sid='" + sid + "'");

                B_AfterReModifyOrder bao = new B_AfterReModifyOrder();
                bao.sid = sid;
                bao.aduty = aduty;
                bao.adremark = adremark;
                bao.fname = afname;
                bao.fcode = afcode;
                bao.omoney = Convert.ToDecimal(omoney);
                bao.qmoney = Convert.ToDecimal(qmoney);
                bao.premark = premark;
                bao.settlment = stype;
                bao.areason = areason == "" ? co.areason : areason;
                if (basob.SaveDuty(bao))
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
        #region// 设置完工日期
        [WebMethod(true)]
        public static string SaveOverDate(string sid, string odate)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (basob.SaveOverDate(sid, odate))
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
        #region// 设置包装数
        [WebMethod(true)]
        public static string SetPackageNum(string sid, string bnum)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (basob.SetPackageNum(sid, bnum))
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
        #region// 设置发货日期
        [WebMethod(true)]
        public static string SaveSendDate(string sid, string odate)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (basob.SaveSendDate(sid, odate))
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
        #region// 获取入库单
        [WebMethod(true)]
        public static ArrayList QueryInHouseList(string sid)
        {
            ArrayList r = new ArrayList ();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<B_AfterPartInHouseOrder> lbo = baihob.QueryList(" and osid='" + sid + "'");
                if (lbo != null)
                {
                    foreach (B_AfterPartInHouseOrder b in lbo)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(b.sid);
                        al.Add(b.pscode);
                        al.Add(b.maker);
                        al.Add(b.cdate);
                        al.Add(b.remark);
                        r.Add(al);
                    }
                }
            }
            else
            {
                r.Add(iv.badstr);
            }
            return r;
        }
        #endregion
        #region//预约反馈单
        [WebMethod(true)]
        public static string UpdateAppointment(string sid, string cv, string gv, string vv, string sv,string sdv)
        {
            string r = "";
            B_AfterReModifyOrder b = new B_AfterReModifyOrder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                b.sid = sid;
                if (cv == null || cv == "")
                {
                    b.sdate = "2000-01-01";
                }
                else
                {
                    b.sdate = CommonBll.GetBdate(cv);
                }
                b.senddate = CommonBll.GetBdate(sdv);
                b.gofee = Convert.ToDecimal(gv);
                b.servfee = Convert.ToDecimal(vv);
                b.stext = sv;
                if (basob.SetAppointment(b))
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
        #region//设置实际收款
        [WebMethod(true)]
        public static string SetTrueMoney(string sid, string cv)
        {
            string r = "";
            B_AfterReModifyOrder b = new B_AfterReModifyOrder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {

                if (basob.SetTMoney(sid, Convert.ToDecimal(cv)))
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
        #region//设置付款方式
        [WebMethod(true)]
        public static string SetPmethod(string sid, string pmethod)
        {
            string r = "";
            B_AfterReModifyOrder b = new B_AfterReModifyOrder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {

                if (basob.SetPmethod(sid, pmethod))
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