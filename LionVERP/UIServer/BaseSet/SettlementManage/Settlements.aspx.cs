using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.Services;
using LionvModel.SysInfo;
using LionvBll.SysInfo;
using LionvAopModel;
using System.Collections;

namespace LionVERP.UIServer.BaseSet.SettlementManage
{
    public partial class Settlements : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region///  初始化结算方式
        [WebMethod(true)]
        public static string InitSettlement(string scode)
        {
            string r = "";
            Sys_Settlement sd = new Sys_Settlement();
            Sys_SettlementBll sdb = new Sys_SettlementBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Settlement csd = sdb.Query(" and scode='" + scode + "'");
                if (csd != null)
                {
                    r = js.Serialize(csd);
                }
                else
                {
                    sd.sname = "";
                    sd.scode = sdb.CreateCode().ToString().PadLeft(4, '0');
                    sd.id = 0;
                    r = js.Serialize(sd);
                }
            }
            else
            {
                r = iv.badstr;
            }
             return r;
        }
        #endregion
        #region///  保存结算方式
        [WebMethod(true)]
        public static string SaveSettlement(string jscode,string jsid,string jsname)
        {
            string r = "";
            Sys_Settlement sd = new Sys_Settlement();
            Sys_SettlementBll sdb = new Sys_SettlementBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sd.scode = jscode;
                sd.sname = jsname;
                sd.maker = iv.u.ename;
                sd.cdate = DateTime.Now.ToString();
                if (iv.u.rcode == "xtgl")
                {
                    sd.stype = "a";
                    sd.sread = true;
                    sd.dcode = "";
                }
                else
                {
                    sd.stype = "p";
                    sd.sread = false;
                    sd.dcode = iv.u.dcode.Substring(0,8);
                }
                if (jsid == "0")
                {
                    if (sdb.Add(sd) > 0)
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
                    if (sdb.Update(sd))
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
        #region///  获取结算方式
        [WebMethod(true)]
        public static ArrayList QuerySettlementList()
        {
            ArrayList r = new ArrayList();
            Sys_Settlement sd = new Sys_Settlement();
            Sys_SettlementBll sdb = new Sys_SettlementBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                string where = "";
                if (iv.u.rcode == "xtgl")
                {
                }
                else
                {
                    where = " and  dcode='" + iv.u.dcode.Substring(0, 8) + "'";
                }
                List<Sys_Settlement> ls = sdb.QueryList(where);
                if (ls != null)
                {
                    foreach (Sys_Settlement s in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.scode);
                        al.Add(s.sname);
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
        #region///  删除结算方式
        [WebMethod(true)]
        public static string DelSettlement(string scode)
        {
            string r = "";
            Sys_Settlement sd = new Sys_Settlement();
            Sys_SettlementBll sdb = new Sys_SettlementBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                
                if (sdb.Delete(scode))
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
        #region///  设置平台结算方式
        [WebMethod(true)]
        public static string SetSettlement(string dcode,string scode)
        {
            string r = "";
            Sys_Settlement sd = new Sys_Settlement();
            Sys_SettlementBll sdb = new Sys_SettlementBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sdb.SetSettlemnt(dcode, scode) > 0)
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
        #region///  重置平台结算方式
        [WebMethod(true)]
        public static string ReSetSettlement(string dcode)
        {
            string r = "";
            Sys_Settlement sd = new Sys_Settlement();
            Sys_SettlementBll sdb = new Sys_SettlementBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sdb.ReSetSettlemnt(dcode) > 0)
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
        #region///  获取平台结算方式
        [WebMethod(true)]
        public static string GetSettlement(string dcode)
        {
            string r = "";
            Sys_Settlement sd = new Sys_Settlement();
            Sys_SettlementBll sdb = new Sys_SettlementBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = sdb.GetSettlemnt(dcode);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion

        //-------------------------------Cust--------------------------------------
        #region///  删除结算方式
        [WebMethod(true)]
        public static string CustDelSettlement(string scode)
        {
            string r = "";
            Sys_Settlement sd = new Sys_Settlement();
            Sys_SettlementBll sdb = new Sys_SettlementBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sd = sdb.Query(" and scode='" + scode + "'");
                if (sd != null)
                {
                    if (sd.sread)
                    {
                        r = "R";
                    }
                    else
                    {
                        if (sdb.Delete(scode))
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
    }
}