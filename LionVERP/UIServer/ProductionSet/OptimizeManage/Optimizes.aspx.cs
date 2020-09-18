using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Collections;
using LionvBll.ProductionInfo;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.ProductionInfo;
using System.Web.Script.Serialization;
using System.Text;

namespace LionVERP.UIServer.ProductionSet.OptimizeManage
{
    public partial class Optimizes : System.Web.UI.Page
    {
        private static Sys_OptimizeBll sob = new Sys_OptimizeBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region///  初始化优化设置
        [WebMethod(true)]
        public static string InitOpt(string ocode)
        {
            string r = "";
            Sys_Optimize so = new Sys_Optimize();
            
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Optimize csns = sob.Query(" and ocode='" + ocode + "'");
                if (csns != null)
                {
                    r = js.Serialize(csns);
                }
                else
                {
                    so.oname = "";
                    so.ocode = sob.CreateCode().ToString().PadLeft(4, '0');
                    so.id = 0;
                    r = js.Serialize(so);
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///  保存优化设置
        [WebMethod(true)]
        public static string SaveOpt(string mtype,string scol, string stype, string ycol,string ycode, string yid,  string yname)
        {

            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Optimize s = new Sys_Optimize();
                s.oname = yname;
                s.ocode = ycode;
                s.ocols = ycol;
                s.pcols = scol;
                s.mtype = mtype;
                s.stype = stype;
                s.cdate = DateTime.Now.ToString();
                s.maker = iv.u.ename;
                if (iv.u.rcode != "xtgl")
                {
                    s.dcode = iv.u.dcode.Substring(0, 8);
                }
                else
                {
                    s.dcode ="";
                }
                if (yid == "0")
                {
                    if (sob.Add(s) > 0)
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
                    if (sob.Update(s))
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
        #region///删除优化设置
        [WebMethod(true)]
        public static string DelOpt(string ocode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sob.Delete(" and ocode='" + ocode + "'"))
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
        #region///获取优化设置
        [WebMethod(true)]
        public static ArrayList QueryList()
        {
            ArrayList r = new ArrayList();
            List<Sys_Optimize> lsf = new List<Sys_Optimize>();
            SqlCondtion sc = new SqlCondtion();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                StringBuilder where = new StringBuilder();
                if (iv.u.rcode != "xtgl")
                {
                    where.Append(" and dcode='" + iv.u.dcode.Substring(0, 8) + "'");
                }
                else
                {
                    where.Append(" ");
                }
                lsf = sob.QueryList(where.ToString());
                if (lsf != null)
                {
                    foreach (Sys_Optimize s in lsf)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.ocode);
                        al.Add(s.oname);
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

        #region//设置优化产品
        [WebMethod(true)]
        public static string SetOptProduction(string ocode,string pcode,string ncode )
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                StringBuilder where = new StringBuilder();
                string[] narr = ncode.Split(';');
                if (sob.SetOptProduction(ocode, pcode, narr) > 0)
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
                r=iv.badstr;
            }
            return r;
        }
        #endregion
        #region//重置优化产品
        [WebMethod(true)]
        public static string ReSetOptProduction(string ocode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sob.ReSetOptProduction(ocode) > 0)
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
                r=iv.badstr;
            }
            return r;
        }
        #endregion
        #region//获取优化产品
        [WebMethod(true)]
        public static string GetOptProduction(string ocode,string pcode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = sob.GetOptProduction(ocode, pcode);
            }
            else
            {
                r=iv.badstr;
            }
            return r;
        }
        #endregion
    }
}