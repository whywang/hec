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
using ViewModel.BusiOrderInfo;
using System.Web.Script.Serialization;
using LionvModel.SysInfo;
using LionvCommonBll;
using LionvBll.BusiCommon;
using LionvModel.BusiCommon;

namespace LionVERP.UIServer.CommonFile
{
    public partial class CommoOrder : System.Web.UI.Page
    {
        private static B_SaleOrderBll bsob = new B_SaleOrderBll();
        private static B_YqSaleOrderBll ybsob = new B_YqSaleOrderBll();
        private static B_AfterSaleOrderBll basob = new B_AfterSaleOrderBll();
        private static B_SaleMaterielOrderBll bswob = new B_SaleMaterielOrderBll();
        private static B_GroupProductionBll bgpb = new B_GroupProductionBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        private static B_MzSaleOrderBll bmsob = new B_MzSaleOrderBll();
        private static B_MzDesignTaskBll bmdtb = new B_MzDesignTaskBll();
        private static B_OrderFacotoryBll bofb = new B_OrderFacotoryBll();
        private static Sys_DepmentBll sdb = new Sys_DepmentBll();
        private static BusiProduceCycBll spcb = new BusiProduceCycBll();
        private static BusiProduceProcessBll bppb = new BusiProduceProcessBll();
        private static Sys_MzOrderTypeBll smotb = new Sys_MzOrderTypeBll();
        private static B_MeasureOrderBll bmob = new B_MeasureOrderBll();
        private static BusiCreateNewOrderFlow bcnof = new BusiCreateNewOrderFlow();
        private static B_OrderFavorableBll bofbb = new B_OrderFavorableBll();
        private static B_DismantleOrderTaskBll bdotb = new B_DismantleOrderTaskBll();
        private static CB_OrderStateBll cosb = new CB_OrderStateBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region/// 设置订单折扣
        [WebMethod(true)]
        public static string SetDiscount(string sid, string dv)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
               r = "F";
               B_SaleOrder bso= bsob.Query(" and sid='" + sid + "'");
               if (bso != null)
               {
                   if (bsob.SetGDiscount(sid, Convert.ToDecimal(dv)))
                   {
                       r = "S";
                   }
               }
               B_YqSaleOrder ybso = ybsob.Query(" and sid='" + sid + "'");
               if (ybso != null)
               {
                   if (ybsob.SetGDiscount(sid, Convert.ToDecimal(dv)))
                   {
                       r = "S";
                   }
               }
               B_AfterSaleOrder baso = basob.Query(" and sid='" + sid + "'");
               if (bso != null)
               { 
                   r = "S";
                   //if (basob.SetGDiscount(sid, Convert.ToDecimal(dv)))
                   //{
                      
                   //}
               }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion

        //#region///获取订单金额
        //[WebMethod(true)]
        //public static string QueryOrderMoney(string sid)
        //{
        //    string r = "";
        //    SessionUserValidate iv = SysValidateBll.ValidateSession();
        //    if (iv.f)
        //    {
        //        r = "F";
        //        decimal disc = 1;
        //        VOrderMoney vom = new VOrderMoney();
        //        B_SaleOrder bso = bsob.Query(" and sid='" + sid + "'");
        //        B_AfterSaleOrder baso = basob.Query(" and sid='" + sid + "'");
        //        if (bso != null)
        //        {
        //            disc = bso.gdiscount;
        //        }
        //        vom.smhjmoney = bgpb.QuerySaleOrderMzpSummerPrice(sid);
        //        vom.smdisc = bso.gdiscount;
        //        vom.smdhjmoney = vom.smhjmoney * vom.smdisc;
        //        vom.gmhjmoney = bgpb.QueryGhOrderSummerPrice(sid);
        //        vom.gmdisc = bso.gdiscount;
        //        vom.gmdhjmoney = vom.gmhjmoney * vom.gmdisc;
        //        vom.swhjmoney = bgpb.QuerySaleOrderWjSummerPrice(sid);
        //        vom.swdisc = 1;
        //        vom.swdhjmoney = vom.swhjmoney;
        //        vom.gwhjmoney = bgpb.QueryGhOrderWjSummerPrice(sid);
        //        vom.gmdisc = 1;
        //        vom.gwdhjmoney = vom.gwhjmoney;
        //        r = js.Serialize(vom);
        //    }
        //    else
        //    {
        //        r = iv.badstr;
        //    }
        //    return r;
        //}
        //#endregion

        #region/// 设置订单编码
        [WebMethod(true)]
        public static string SetOrderCode(string sid, string code)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = "F";
                B_SaleOrder bso = bsob.Query(" and sid='" + sid + "'");
                if (bso != null)
                {
                   if( bsob.Exists(" and scode='"+code+"' and sid!='"+sid+"'"))
                    {
                        r = "T";
                    }
                    else
                    {
                        if(bsob.SetOrderCode(sid, code))
                        {
                            r = "S";
                        }
                        else
                        {
                            r = "F";
                        }
                    }
                }
                B_YqSaleOrder ybso = ybsob.Query(" and sid='" + sid + "'");
                if (ybso != null)
                {
                    if (ybsob.Exists(" and scode='" + code + "' and sid!='" + sid + "'"))
                    {
                        r = "T";
                    }
                    else
                    {
                        if (ybsob.SetOrderCode(sid, code))
                        {
                            r = "S";
                        }
                        else
                        {
                            r = "F";
                        }
                    }
                }
                B_AfterSaleOrder baso = basob.Query(" and sid='" + sid + "'");
                if (baso != null)
                {
                    if (basob.Exists(" and scode='" + code + "' and sid!='" + sid + "'"))
                    {
                        r = "T";
                    }
                    else
                    {
                        r = "S";
                        //if (basob.SetOrderCode(sid, code))
                        //{
                        //    r = "S";
                        //}
                        //else
                        //{
                        //    r = "F";
                        //}
                    }
                }
                B_MzSaleOrder bmso = bmsob.Query(" and sid='" + sid + "'");
                if (bmso != null)
                {
                    if (bmsob.Exists(" and scode='" + code + "' and sid!='" + sid + "'"))
                    {
                        r = "T";
                    }
                    else
                    {
                        if (bmsob.SetOrderCode(sid, code))
                        {
                            r = "S";
                        }
                        else
                        {
                            r = "F";
                        }
                    }
                }
                B_SaleMaterielOrder bswo = bswob.Query(" and sid='" + sid + "'");
                if (bswo != null)
                {
                    if (bswob.Exists(" and scode='" + code + "' and sid!='" + sid + "'"))
                    {
                        r = "T";
                    }
                    else
                    {
                        if (bswob.SetOrderCode(sid, code))
                        {
                            r = "S";
                        }
                        else
                        {
                            r = "F";
                        }
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

        #region/// 设置木作订单设计类型
        [WebMethod(true)]
        public static string SetOrderType(string sid, string stype)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (bmsob.SetOrderType(sid, stype))
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

        #region/// 设置木作订单产品类型
        [WebMethod(true)]
        public static string SetProductionType(string sid, string ptype)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (bmsob.SetProductionType(sid, ptype))
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

        #region/// 获取木作订单设计类型
        [WebMethod(true)]
        public static string QueryOrderType(string sid, string attr)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_MzSaleOrder bms = bmsob.Query("and sid='" + sid + "'");
               if (bms != null)
               {
                   Sys_MzOrderType smot = smotb.Query(" and mtname='" + bms.dtype + "' and otype='" + attr + "'");
                  r = smot != null ? smot.emcode : "";
               }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion

        #region/// 设置订单订金
        [WebMethod(true)]
        public static string SetOrderCustomMoney(string sid, string dmoney)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (bmsob.SetCustomMoney(sid, dmoney))
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

        #region/// 设置木作设计师
        [WebMethod(true)]
        public static string SetOrderDesigner(string sid, string dv)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_MzSaleOrder bo = bmsob.Query(" and sid='" + sid + "'");
                if (bo != null)
                {
                    bmsob.SetDesign(sid, dv);
                    B_MzDesignTask bmdt = new B_MzDesignTask();
                    bmdt.sid = sid;
                    bmdt.curstate = true;
                    bmdt.designer = dv;
                    bmdt.dstate = 0;
                    bmdt.maker = iv.u.ename;
                    bmdt.cdate = DateTime.Now.ToString();
                    if (bmdtb.Exists(" and sid='" + sid + "' and designer='" + dv + "'"))
                    {
                        if (bmdtb.Update(bmdt))
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
                        //bmdtb.Delete(" and sid='" + sid + "'");
                        if (bmdtb.Add(bmdt) > 0)
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

        #region/// 获取订单工厂生产周期
        [WebMethod(true)]
        public static string QueryFactoryDate(string bdcode, string fcode,string  sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_ProduceCyc spc = spcb.QueryCheckList(bdcode, fcode, sid);
                if (spc != null)
                {
                    r = DateTime.Now.AddDays(spc.cnum).ToString();
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
        public static string SaveFactory(string bcode, string fcode, string fdate, string sid,string emcode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
               // int dn = 0;
                Sys_Depment sd = sdb.Query(" and dcode='" + fcode + "'");
                B_OrderFacotory bf = new B_OrderFacotory();
                B_OrderFacotory bof = bofb.Query(" and sid='" + sid + "'");
                bf.dname = sd != null ? sd.dname : "";
                bf.dcode = fcode;
                bf.maker = iv.u.ename;
                bf.sid = sid;
                bf.overdate =CommonBll.GetBdate( fdate);
                bf.fdate = DateTime.Now.ToString();
                bf.otype = "";
                bf.cdate = DateTime.Now.ToString();
                if (bof != null)
                {
                    if (bofb.Update(bf))
                    {
                        r = "S";
                        //if (fline != "")
                        //{
                        //    bppb.SetProduceProcess(sid, fline);
                        //}
                        //bcpb.OrderCgComputePrice(sid);
                        BaseSet.WorkFlowManage.EventBtnDo.FireEventBtn(sid, bcode, "1", "分单");
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
                        //if (fline != "")
                        //{
                        //    bppb.SetProduceProcess(sid, fline);
                        //}
                        //bcpb.OrderCgComputePrice(sid);
                        BaseSet.WorkFlowManage.EventBtnDo.FireEventBtn(sid, bcode, "1", "分单");
                       
                    }
                    else
                    {
                        r = "F";
                    }
                }
                bcnof.CreateNewOrders(sid, emcode);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion

        #region/// 设置测量师
        [WebMethod(true)]
        public static string SetMeasurePerson(string bcode, string clperson, string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (bmob.SetMeasurePerson(clperson, sid))
                {
                    r = "S";
                    BaseSet.WorkFlowManage.EventBtnDo.FireEventBtn(sid, bcode, "1", "分配测量师");
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

        #region/// 设置订单优惠
        [WebMethod(true)]
        public static string SetOrderFavorable(string sid, string fmoney, string remark)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_OrderFavorable bf = new B_OrderFavorable();
                bf.cdate = DateTime.Now.ToString();
                bf.fmoney = Convert.ToDecimal(fmoney);
                bf.maker = iv.u.ename;
                bf.remark = remark;
                bf.sid = sid;
                if (bofbb.Exists(" and sid='"+sid+"'"))
                {
                    if (bofbb.Update(bf))
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
                    if (bofbb.Add(bf)>0)
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

        #region///分配技术拆单
        [WebMethod(true)]
        public static string SetOrderDismantle(string sid, string cdy)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_DismantleOrderTask bf = new B_DismantleOrderTask();
                bf.cdate = DateTime.Now.ToString();
                bf.dcode = iv.u.dcode;
                bf.dname = iv.u.dname;
                bf.maker = iv.u.ename;
                bf.cdy = cdy;
                bf.sid = sid;
                if (bdotb.Exists(" and sid='" + sid + "'"))
                {
                    if (bdotb.Update(bf))
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
                    if (bdotb.Add(bf) > 0)
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

        #region/// 设置订单金额
        [WebMethod(true)]
        public static string SetOrderMoney(string sid, string omoney,string mremark)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (bsob.SetOrderMoney(sid,Convert.ToDecimal( omoney),mremark))
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

        #region/// 设置订单金额
        [WebMethod(true)]
        public static string SetOrderPrint(string sid,string bcode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Depment sd = sdb.Query(" and dcode='" + iv.u.dcode + "'");
                if (sd != null)
                {
                    if (sd.dattr == "gc")
                    {
                        cosb.UpState(sid, "iprint", 1);
                        LionVERP.UIServer.BaseSet.WorkFlowManage.EventBtnDo.FireEventBtn(sid, bcode, "1", "");
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