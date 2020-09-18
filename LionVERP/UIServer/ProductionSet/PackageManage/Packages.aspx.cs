using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvModel.ProductionInfo;
using LionvBll.SysInfo;
using LionvAopModel;
using LionvBll.ProductionInfo;
using System.Web.Script.Serialization;
using System.Collections;
using System.Text;

namespace LionVERP.UIServer.ProductionSet.PackageManage
{
    public partial class Packages : System.Web.UI.Page
    {
        private static Sys_PackageBll spb = new Sys_PackageBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region///  初始化包装设置
        [WebMethod(true)]
        public static string InitPackage(string pcode)
        {
            string r = "";
            Sys_Package so = new Sys_Package();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Package sob = spb.Query(" and pcode='" + pcode + "'");
                if (sob != null)
                {
                    r = js.Serialize(sob);
                }
                else
                {
                    so.pname = "";
                    so.pcode = spb.CreateCode().ToString().PadLeft(4, '0');
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
        #region///  保存包装设置
        [WebMethod(true)]
        public static string SavePackage(string bcode,string bid, string bjs,string bname,  string bzsx,string cptype,string gsj, string gxj, string ksj,string kxj,string sftz, string tjs,string zdjs,   string zjlx)
        {

            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Package s = new Sys_Package();
                s.pname = bname;
                s.pcode = bcode;
                s.basenum =Convert.ToInt32( bjs);
                s.zjtype = zjlx;
                s.istz = sftz;
                s.tznum =Convert.ToInt32( tjs);
                s.psort = bzsx;
                s.maxnum = Convert.ToInt32(zdjs);
                s.hlvalue = Convert.ToInt32(gxj);
                s.htvalue = Convert.ToInt32(gsj);
                s.klvalue = Convert.ToInt32(kxj);
                s.ktvalue = Convert.ToInt32(ksj);
                s.cdate = DateTime.Now.ToString();
                s.cptype = cptype;
                s.maker = iv.u.ename;
                if (iv.u.rcode != "xtgl")
                {
                    s.dcode = iv.u.dcode.Substring(0, 8);
                }
                else
                {
                    s.dcode = "";
                }
                if (bid == "0")
                {
                    if (spb.Add(s) > 0)
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
                    if (spb.Update(s))
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
        #region///  删除包装设置
        [WebMethod(true)]
        public static string DelPackage(string pcode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (spb.Delete(" and pcode='" + pcode + "'"))
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
        #region///获取包装设置
        [WebMethod(true)]
        public static ArrayList QueryList()
        {
            ArrayList r = new ArrayList();
            List<Sys_Package> lsf = new List<Sys_Package>();
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
                lsf = spb.QueryList("");
                if (lsf != null)
                {
                    foreach (Sys_Package s in lsf)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.pcode);
                        al.Add(s.pname);
                        al.Add(s.basenum);
                        al.Add(s.zjtype);
                        al.Add(s.istz);
                        al.Add(s.tznum);
                        al.Add(s.psort);
                        al.Add(s.maxnum);
                        al.Add(s.hlvalue + "-" + s.htvalue);
                        al.Add(s.klvalue + "-" + s.ktvalue);
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
        public static string SetPackageProduction(string pcode, string icode, string ppcode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                StringBuilder where = new StringBuilder();
                string[] narr = ppcode.Split(';');
                if (spb.SetInvPackage(pcode, icode, narr) > 0)
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
        #region//重置优化产品
        [WebMethod(true)]
        public static string ReSetPackageProduction(string pcode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (spb.ReSetInvPackage(pcode) > 0)
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
        #region//获取优化产品
        [WebMethod(true)]
        public static string GetPackageProduction(string pcode, string icode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = spb.GetInvPackage(pcode, icode);
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