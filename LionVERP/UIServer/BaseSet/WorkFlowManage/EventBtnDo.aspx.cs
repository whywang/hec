using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.SysInfo;
using LionvCommonBll;
using LionvBll.BusiOrderInfo;
using System.Collections;
using LionvBll.BusiCommon;

namespace LionVERP.UIServer.BaseSet.WorkFlowManage
{
    public partial class EventBtnDo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region//获取列表页Btn
        [WebMethod(true)]
        public static string FireEventBtn(string sid,  string bcode , string bstate , string bms)
        {
            string  r = "";
            Sys_ButtonBll sbb = new Sys_ButtonBll();
            BusiWorkFlowBll bwfb = new BusiWorkFlowBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Button sbt = sbb.Query(" and bcode='" + bcode + "'");
                if (sbt != null)
                {
                    if (bwfb.FireEventBtn(sid, sbt, Convert.ToInt32(bstate), bms, iv.u.ename) > 0)
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
                    r = "F";
                }
            }
            else
            {
                r=iv.badstr;
            }
            return r;
        }
        #endregion
        #region//获取列表页Btn返回值
        [WebMethod(true)]
        public static string FireEventBtnAgr(string sid, string bcode, string bstate, string bms)
        {
            string r = "";
            Sys_ButtonBll sbb = new Sys_ButtonBll();
            BusiWorkFlowBll bwfb = new BusiWorkFlowBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Button sbt = sbb.Query(" and bcode='" + bcode + "'");
                if (sbt != null)
                {
                    r = bwfb.FireEventBtnArg(sid, sbt, Convert.ToInt32(bstate), bms, iv.u.ename);
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
        #region//处理流程事件Btn
        [WebMethod(true)]
        public static ArrayList BatchFireEventBtn(string sid, string bcode, string bstate, string bms)
        {
            ArrayList r = new ArrayList();
            string bstr = "";
            Sys_ButtonBll sbb = new Sys_ButtonBll();
            BusiWorkFlowBll bwfb = new BusiWorkFlowBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Button sbt = sbb.Query(" and bcode='" + bcode + "'");
                if (sbt != null)
                {
                    r.Add("S");
                    string[] sids = sid.Split(';');
                    if (sids.Length > 0)
                    {
                        foreach (string id in sids)
                        {
                            if (bwfb.FireEventBtn(id, sbt, Convert.ToInt32(bstate), bms, iv.u.ename) > 0)
                            {
                            }
                            else
                            {
                                bstr = bstr + id + ";";
                            }
                        }
                    }
                    if (bstr.Length > 1)
                    {
                        r.Add(bstr.Substring(0, bstr.Length - 1));
                    }
                }
                else
                {
                    r.Add("F");
                }
            }
            else
            {
                r.Add(iv.badstr);
            }
            return r;
        }
        #endregion
        #region//接口无登录验证事件
        [WebMethod(true)]
        public static string UnUserFireEventBtn(string sid, string bcode, string bstate, string bms)
        {
            string r = "";
            Sys_ButtonBll sbb = new Sys_ButtonBll();
            BusiWorkFlowBll bwfb = new BusiWorkFlowBll();
            Sys_Button sbt = sbb.Query(" and bcode='" + bcode + "'");
            if (sbt != null)
            {
                if (bwfb.FireEventBtn(sid, sbt, Convert.ToInt32(bstate), bms, "admin") > 0)
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
                r = "F";
            }
            return r;
        }
        #endregion
        #region//处理页面事件Btn
        [WebMethod(true)]
        public static string FireGeneralPageBtn(string sid, string bcode, string bms)
        {
            string r = "";
            Sys_ButtonBll sbb = new Sys_ButtonBll();
            BusiWorkFlowBll bwfb = new BusiWorkFlowBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Button sbt = sbb.Query(" and bcode='" + bcode + "'");
                if (sbt != null)
                {
                    if (bwfb.FireGeneralPageBtn(sid, sbt, bms, iv.u.ename) > 0)
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
        #region//批量处理多流程事件Btn
        [WebMethod(true)]
        public static string MBatchFireEventBtn(string sid, string bms)
        {
            string r = "";
            Sys_ButtonBll sbb = new Sys_ButtonBll();
            BusiWorkFlowBll bwfb = new BusiWorkFlowBll();
            CB_OrderFlowBll cofb = new CB_OrderFlowBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                    string[] sids = sid.Split(';');
                    if (sids.Length > 0)
                    {
                        foreach (string id in sids)
                        {
                            string wcode = cofb.QueryCurWorkFlow(id);
                            Sys_Button sbt = sbb.Query(" and wcode='" + wcode + "' and battr='T'");
                            try
                            {
                                if (bwfb.FireEventBtn(id, sbt, 1, bms, iv.u.ename) > 0)
                                {
                                    r = "S";
                                }
                            }
                            catch
                            {
                                r = "F";
                            }
                        }
                    }
            }
            else
            {
                r = iv.badstr; ;
            }
            return r;
        }
        #endregion
    }
}