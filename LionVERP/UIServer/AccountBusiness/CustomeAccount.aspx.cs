using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvBll.Account;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.Account;
using System.Web.Script.Serialization;
using ViewModel.Account;
using System.Collections;
using LionvModel.SysInfo;
using LionvCommonBll;

namespace LionVERP.UIServer.AccountBusiness
{
    public partial class CustomeAccount : System.Web.UI.Page
    {
        private static A_CustomeAccountBll acab = new A_CustomeAccountBll();
        private static Sys_DepmentBll sdb = new Sys_DepmentBll();
        private static BusiInvTempBll bitb = new BusiInvTempBll();
        private static BusiWorkFlowBll bwfb = new BusiWorkFlowBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region//查询账户信息（部门）
        [WebMethod(true)]
        public static string SearchCustomeAccountInfo(string telephone)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                A_CustomeAccount sd = acab.Query(" and dcode like '" + iv.u.dcode + "%' and telephone='" + telephone + "'");
                if (sd != null)
                {
                    r = js.Serialize(sd);
                }
                else
                {
                    r = "";
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region//查询账户信息（All）
        [WebMethod(true)]
        public static string AllSearchCustomeAccountInfo(string telephone)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                A_CustomeAccount sd = acab.Query(" and telephone='" + telephone + "'");
                if (sd != null)
                {
                    r = js.Serialize(sd);
                }
                else
                {
                    r = "";
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region//查询账户金额(部门)
        [WebMethod(true)]
        public static string SearchCustomeAccount(string telephone)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            VCustomeAccount ao = new VCustomeAccount();
            if (iv.f)
            {
               ao= acab.QueryCustomeAccount(" and dcode like '" + iv.u.dcode + "%' and telephone='" + telephone + "'");
               r = js.Serialize(ao);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region//查询账户金额（All）
        [WebMethod(true)]
        public static string AllSearchCustomeAccount(string telephone)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            VCustomeAccount ao = new VCustomeAccount();
            if (iv.f)
            {
                ao = acab.QueryCustomeAccount(" and telephone='" + telephone + "'");
                r = js.Serialize(ao);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region//查询账户付款金额（部门）
        [WebMethod(true)]
        public static ArrayList QueryGetRecoder(string telephone)
        {
            ArrayList r = new ArrayList ();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            List<A_CustomeAccount> ao = new  List<A_CustomeAccount> ();
            if (iv.f)
            {
                r.Add(iv.badstr);
                ao = acab.QueryList(" and ptype=1 and dcode like '" + iv.u.dcode + "%' and telephone='" + telephone + "'");
                if (ao != null)
                {
                    foreach (A_CustomeAccount a in ao)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(a.pmoney);
                        al.Add(a.cdate);
                        al.Add(a.maker);
                        if (a.pstate == 1)
                        {
                            al.Add("已处理");
                        }
                        else
                        {
                            al.Add("未处理");
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
        #region//查询账户付款金额（All）
        [WebMethod(true)]
        public static ArrayList AllQueryGetRecoder(string telephone)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            List<A_CustomeAccount> ao = new List<A_CustomeAccount>();
            if (iv.f)
            {
                r.Add(iv.badstr);
                ao = acab.QueryList(" and ptype=1  and telephone='" + telephone + "'");
                if (ao != null)
                {
                    foreach (A_CustomeAccount a in ao)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(a.pmoney);
                        al.Add(a.cdate);
                        al.Add(a.maker);
                        if (a.pstate == 1)
                        {
                            al.Add("已处理");
                        }
                        else
                        {
                            al.Add("未处理");
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
        #region//查询账户退款金额（部门）
        [WebMethod(true)]
        public static ArrayList QueryPayRecoder(string telephone)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            List<A_CustomeAccount> ao = new List<A_CustomeAccount>();
            if (iv.f)
            {
                r.Add(iv.badstr);
                ao = acab.QueryList(" and ptype=-1 and dcode like '" + iv.u.dcode + "%' and telephone='" + telephone + "'");
                if (ao != null)
                {
                    foreach (A_CustomeAccount a in ao)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(a.pmoney);
                        al.Add(a.cdate);
                        al.Add(a.maker);
                        if (a.pstate == 1)
                        {
                            al.Add("已处理");
                        }
                        else
                        {
                            al.Add("未处理");
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
        #region//查询账户退款金额（All）
        [WebMethod(true)]
        public static ArrayList AllQueryPayRecoder(string telephone)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            List<A_CustomeAccount> ao = new List<A_CustomeAccount>();
            if (iv.f)
            {
                r.Add(iv.badstr);
                ao = acab.QueryList(" and ptype=-1 and telephone='" + telephone + "'");
                if (ao != null)
                {
                    foreach (A_CustomeAccount a in ao)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(a.pmoney);
                        al.Add(a.cdate);
                        al.Add(a.maker);
                        if (a.pstate == 1)
                        {
                            al.Add("已处理");
                        }
                        else
                        {
                            al.Add("未处理");
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
        #region//初始化收款
        [WebMethod(true)]
        public static string InitCustomeAccount(string id,string ptype)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                A_CustomeAccount sd = new A_CustomeAccount();
                if (id == "")
                {
                    Sys_Depment sdm = sdb.Query(" and dcode='" + iv.u.dcode + "' and dattr='d'");
                    if (sdm != null)
                    {
                        Sys_Depment sc = sdb.Query(" and dcode='" + sdm.dcode.Substring(0,sdm.dcode.Length-2) + "' and dattr='s'");
                        if (ptype == "g")
                        {
                            sd.pcate = "补款";
                        }
                        if (ptype == "p")
                        {
                            sd.pcate = "退款";
                        }
                        sd.citycode = sc.dcode;
                        sd.cityname = sc.dname;
                        sd.dcode = sdm.dcode;
                        sd.dname = sdm.dname;
                        sd.customer = "";
                        sd.telephone = "";
                        sd.address = "";
                        sd.pmoney = 0;
                        sd.id = 0;
                    }
                    else
                    {
                        r = "PB";
                    }
                }
                else
                {
                    sd = acab.Query(" and gsid='" + id + "'");
                }
                r = js.Serialize(sd);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region//保存收款
        [WebMethod(true)]
        public static string SaveCustomeAccount(string address, string citycode, string cityname, string customer, string dcode, string dname,string gsid, string id, string pcate, string pmoney, string remark, string scode, string telephone)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                A_CustomeAccount sd = new A_CustomeAccount();
                sd.citycode = citycode;
                sd.cityname = cityname;
                sd.dcode = dcode;
                sd.dname = dname;
                sd.customer = customer;
                sd.telephone = telephone;
                sd.address = address;
                sd.pmoney = Convert.ToDecimal(pmoney);
                sd.ptype = 1;
                sd.scode = scode;
                sd.pstate = 0;
                sd.pcate = pcate;
                sd.sid = "";
                sd.gsid=CommonBll.GetSid();
                sd.ddate = DateTime.Now.ToString();
                sd.cdate = DateTime.Now.ToString();
                sd.remark = remark;
                sd.maker = iv.u.ename;
                if (id == "" || id == "0")
                {
                    if (acab.Add(sd) > 0)
                    {
                        bwfb.CreateWorkFlow(sd.gsid, "0092");
                        r = sd.gsid;
                    }
                    else
                    {
                        r = "F";
                    }
                }
                else
                {
                    sd.gsid = gsid;
                    if (acab.Update(sd))
                    {
                        r = sd.gsid;
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
        #region//保存收款
        [WebMethod(true)]
        public static string SavePayCustomeAccount(string address, string citycode, string cityname, string customer, string dcode, string dname, string gsid, string id, string pcate, string pmoney, string remark, string scode, string telephone)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                A_CustomeAccount sd = new A_CustomeAccount();
                sd.citycode = citycode;
                sd.cityname = cityname;
                sd.dcode = dcode;
                sd.dname = dname;
                sd.customer = customer;
                sd.telephone = telephone;
                sd.address = address;
                sd.pmoney = Convert.ToDecimal(pmoney);
                sd.ptype = -1;
                sd.scode = scode;
                sd.pstate = 0;
                sd.pcate = pcate;
                sd.sid = "";
                sd.gsid = CommonBll.GetSid();
                sd.ddate = DateTime.Now.ToString();
                sd.cdate = DateTime.Now.ToString();
                sd.remark = remark;
                sd.maker = iv.u.ename;
                if (id == "" || id == "0")
                {
                    if (acab.Add(sd) > 0)
                    {
                        bwfb.CreateWorkFlow(sd.gsid, "0094");
                        r = sd.gsid;
                    }
                    else
                    {
                        r = "F";
                    }
                }
                else
                {
                    if (acab.Update(sd))
                    {
                        r = sd.gsid;
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
        #region//获取收款单Html
        [WebMethod(true)]
        public static string QueryCustomeAccountHtm(string emcode,string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = bitb.CustomerGetHtml(emcode, sid);
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