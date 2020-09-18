using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvBll.BusiOrderInfo;
using LionvBll.BusiCommon;
using LionvCommonBll;
using System.Web.Script.Serialization;
using LionvBll.SysInfo;
using System.Web.Services;
using LionvAopModel;
using LionvModel.BusiOrderInfo;
using LionvModel.SysInfo;
using LionvModel.BusiCommon;
using LionVERP.UIServer.BaseSet.WorkFlowManage;

namespace LionVERP.UIServer.AfterSaleServiceBusiness.DistributorAfterDoorYqOrder
{
    public partial class AfterFreeBackOrderDetail : System.Web.UI.Page
    {
        private static B_AfterFreeBackOrderBll bsob = new B_AfterFreeBackOrderBll();
        private static B_AfterReModifyOrderBll basmob = new B_AfterReModifyOrderBll();
        private static B_AfterApplyOrderBll basob = new B_AfterApplyOrderBll();
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
        public static string InitAddOrder(string sid,string asid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            B_AfterFreeBackOrder ao = new B_AfterFreeBackOrder();
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
                    if (asid != "")
                    {
                        B_AfterApplyOrder aao = basob.Query(" and sid='" + asid + "'");
                        if (aao != null)
                        {
                            ao.id = 0;
                            ao.dcode = aao.dcode;
                            ao.acity = aao.acity;
                            ao.aprovince = aao.aprovince;
                            ao.sscode = aao.scode;
                            ao.address = aao.address;
                            ao.areason = aao.areason;
                            ao.customer = aao.customer;
                            ao.oscode = aao.oscode;
                            ao.osid = aao.osid;
                            ao.asid = aao.sid;
                            ao.stext = aao.remark;
                            ao.telephone = aao.telephone;
                            ao.maker = iv.u.ename;
                        }
                    }
                    else
                    {
                        ao.maker = iv.u.ename;
                    }
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
        #region//初始化售后申请单
        [WebMethod(true)]
        public static string QueryOrder(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            B_AfterFreeBackOrder ao = new B_AfterFreeBackOrder();
            if (iv.f)
            {
                #region//存在原单
                if (sid != "")
                {
                    ao = bsob.Query(" and sid='" + sid + "'");
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
        public static string SaveOrder(string acity, string address, string aprovince, string areason, string asid,string bcode, string customer, string dcode,  string emcode,string gofee, string maker, string oscode, string osid, string remark,string sdate,string servfee, string sid,string sscode,string stext, string telephone)
        {
            string r = "";
            B_AfterFreeBackOrder b = new B_AfterFreeBackOrder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Depment sd = sdb.Query(" and dcode='" + dcode + "'");
                Sys_Depment cs = sdb.Query(" and dcode='" + dcode.Substring(0, dcode.Length-4) + "'");
                b.osid = osid;
                b.asid = asid;
                b.address = address;
                b.acity = acity;
                b.aprovince = aprovince;
                b.customer = customer;
                b.telephone = telephone;
                b.dcode = dcode;
                b.dname = sd.dname;
                b.city = cs.dname;
                b.citycode = cs.dcode;
                b.maker = iv.u.ename;
                b.oscode = oscode;
                b.sscode = sscode;
                b.gofee = Convert.ToDecimal(gofee) ;
                b.servfee = Convert.ToDecimal(servfee);
                b.sdate = CommonBll.GetBdate(sdate);
                b.stext = stext;
                b.remark = remark;
                b.scode = "HAS" + DateTime.Now.ToString("yyMM") + bsob.GetOrderNum().ToString().PadLeft(5, '0');
                b.areason = areason;
                b.telephone = telephone;
                b.cdate = DateTime.Now.ToString("yyyy-MM-dd");
                if (sid == "")
                {
                    b.sid = CommonBll.GetSid();
                    if (bsob.Add(b) > 0)
                    {
                        r = b.sid;
                        CB_OrderState cos = new CB_OrderState();
                        cos.sid = b.sid;
                        cosb.Add(cos);
                        bwfb.CreateWorkFlow(b.sid, emcode);
                    }
                    else
                    {
                        r = "F";
                    }
                    EventBtnDo.FireEventBtn(b.sid, bcode, "1", "创建售后单");
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
                    EventBtnDo.FireEventBtn(b.sid, bcode, "1", "更新售后单");
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region//预约反馈单
        [WebMethod(true)]
        public static string UpdateAppointment(string sid, string cv, string gv, string vv, string sv )
        {
            string r = "";
            B_AfterFreeBackOrder b = new B_AfterFreeBackOrder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                b.sid = sid;
                b.sdate = CommonBll.GetBdate(cv);
                b.gofee = Convert.ToDecimal(gv);
                b.servfee = Convert.ToDecimal(vv);
                b.stext = sv;
                if (bsob.UpdateAppointment(b))
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
        #region//分配安装师单
        [WebMethod(true)]
        public static string SetFixter(string sid, string azperson)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_AfterReModifyOrder bo = basmob.Query(" and sid='" + sid + "'");
                if (bo != null)
                {
                    if (basmob.SetFixer(sid, azperson))
                    {
                        r = "S";
                    }
                    else
                    {
                        r = "F";
                    }
                }
                B_AfterFreeBackOrder bao = bsob.Query(" and sid='" + sid + "'");
                if (bao != null)
                {
                    if (bsob.SetFixer(sid, azperson))
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
        #region//服务完成
        [WebMethod(true)]
        public static string SetServiceOver(string sid, string otype, string odate, string oinfo, string cinfo, string fmoney)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_AfterReModifyOrder bo = basmob.Query(" and sid='" + sid + "'");
                if (bo != null)
                {
                    if (basmob.SetOverInfo(sid, otype, odate, oinfo, cinfo, fmoney))
                    {
                        r = "S";
                    }
                    else
                    {
                        r = "F";
                    }
                }
                 B_AfterFreeBackOrder bao = bsob.Query(" and sid='" + sid + "'");
                 if (bao != null)
                 {
                     if (bsob.SetOverInfo(sid, otype, odate, oinfo, cinfo))
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
    }
}