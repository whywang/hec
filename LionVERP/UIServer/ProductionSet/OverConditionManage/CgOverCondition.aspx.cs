using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.Services;
using LionvBll.ProductionInfo;
using LionvModel.ProductionInfo;
using LionvAopModel;
using LionvBll.SysInfo;
using System.Collections;
using System.Text;

namespace LionVERP.UIServer.ProductionSet.OverConditionManage
{
    public partial class CgOverCondition : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        private static Sys_CgOverCondtionCategoryBll snsb = new Sys_CgOverCondtionCategoryBll();
        private static Sys_CgOverCondtionBll cocb = new Sys_CgOverCondtionBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region///  初始化超标类
        [WebMethod(true)]
        public static string InitOverConditionCate(string ocode)
        {
            string r = "";
            Sys_CgOverCondtionCategory sns = new Sys_CgOverCondtionCategory();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_CgOverCondtionCategory csns = snsb.Query(" and ocode='" + ocode + "'");
                if (csns != null)
                {
                    r = js.Serialize(csns);
                }
                else
                {
                    sns.oname = "";
                    sns.ocode = snsb.CreateCode().ToString().PadLeft(4, '0');
                    sns.id = 0;
                    r = js.Serialize(sns);
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///  保存超标类
        [WebMethod(true)]
        public static string SaveOverConditionCate(string lcode, string lid, string lname, string ltype, string lunit)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_CgOverCondtionCategory s = new Sys_CgOverCondtionCategory();
                s.oname = lname;
                s.ocode = lcode;
                s.otype = ltype;
                s.ounit = lunit;
                s.cdate = DateTime.Now.ToString();
                s.maker = iv.u.ename;
                if (iv.u.rcode != "xtgl")
                {
                    s.dcode = iv.u.dcode.Substring(0, 8);
                }
                else
                {
                    s.dcode = "";
                }
                if (lid == "0")
                {
                    if (snsb.Add(s) > 0)
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
                    if (snsb.Update(s))
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
        #region///  删除超标类
        [WebMethod(true)]
        public static string DelOverConditionCate(string ocode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (snsb.Delete(ocode))
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
        #region///  标准超标类
        [WebMethod(true)]
        public static ArrayList QueryListCate()
        {
            ArrayList r = new ArrayList();
            List<Sys_CgOverCondtionCategory> lsf = new List<Sys_CgOverCondtionCategory>();
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
                lsf = snsb.QueryList(where.ToString());
                if (lsf != null)
                {
                    foreach (Sys_CgOverCondtionCategory s in lsf)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.ocode);
                        al.Add(s.oname);
                        al.Add(s.otype);
                        al.Add(s.ounit);
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

        #region///  初始化超标条件
        [WebMethod(true)]
        public static string InitOverCondition(string ocode, string ccode)
        {
            string r = "";
            Sys_CgOverCondtion soc = new Sys_CgOverCondtion();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_CgOverCondtion csns = cocb.Query(" and ccode='" + ccode + "'");
                if (csns != null)
                {
                    r = js.Serialize(csns);
                }
                else
                {
                    soc.ocode = ocode;
                    soc.oname = snsb.Query(" and ocode='" + ocode + "'").oname;
                    soc.ccode = cocb.CreateCode().ToString().PadLeft(4, '0');
                    soc.id = 0;
                    r = js.Serialize(soc);
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///  保存超标条件
        [WebMethod(true)]
        public static string SaveOverCondition(string tattr, string tbvalue, string tcity, string tcode, string tid, string tjs, string tlcode, string tlname, string tname,
            string tprice, string tsz, string ttvalue, string ttype, string txs
            )
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_CgOverCondtion s = new Sys_CgOverCondtion();
                s.oname = tlname;
                s.ocode = tlcode;
                s.cname = tname;
                s.ccode = tcode;
                s.bvalue = Convert.ToInt32(tbvalue);
                s.tvalue = Convert.ToInt32(ttvalue); ;
                s.cattr = tattr;
                s.cfscale = Convert.ToDecimal(tsz);
                s.cfstr = tjs;
                s.cxs = Convert.ToDecimal(txs);
                s.cpricetype = tprice;
                s.cdate = DateTime.Now.ToString();
                s.pcity = tcity;
                s.maker = iv.u.ename;
                if (tid == "0")
                {
                    if (cocb.Add(s) > 0)
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
                    if (cocb.Update(s))
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
        #region///  删除超标条件
        [WebMethod(true)]
        public static string DelOverCondition(string ccode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (cocb.Delete(" and ccode='" + ccode + "'"))
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
        #region///标准超标条件
        [WebMethod(true)]
        public static ArrayList QueryList(string ocode)
        {
            ArrayList r = new ArrayList();
            List<Sys_CgOverCondtion> lsf = new List<Sys_CgOverCondtion>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                StringBuilder where = new StringBuilder();
                lsf = cocb.QueryList(" and ocode='" + ocode + "'");
                if (lsf != null)
                {
                    foreach (Sys_CgOverCondtion s in lsf)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.ccode);
                        al.Add(s.oname);
                        al.Add(s.cname);
                        al.Add(s.cattr);
                        al.Add(s.bvalue);
                        al.Add(s.tvalue);
                        al.Add(s.cfstr);
                        al.Add(s.cfscale);
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

        #region///   设置产品减尺
        [WebMethod(true)]
        public static string SetProductionOc(string icode, string pcode, string ocode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (cocb.SetProductionOc(icode, pcode, ocode) > 0)
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
        #region///  重置产品减尺
        [WebMethod(true)]
        public static string ReSetProductionOc(string icode, string ocode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (cocb.ReSetProductionOc(icode, ocode) > 0)
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
        #region///  获取产品减尺
        [WebMethod(true)]
        public static string GetProductionOc(string icode, string ocode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = cocb.GetProductionOcEx(icode, ocode);
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