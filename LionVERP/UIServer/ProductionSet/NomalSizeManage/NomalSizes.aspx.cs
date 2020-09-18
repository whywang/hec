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

namespace LionVERP.UIServer.ProductionSet.NomalSizeManage
{
    public partial class NomalSizes : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region///  初始化标准尺寸
        [WebMethod(true)]
        public static string InitNomalSize(string ncode)
        {
            string r = "";
            Sys_NomalSize sns = new Sys_NomalSize();
            Sys_NomalSizeBll snsb = new Sys_NomalSizeBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_NomalSize csns = snsb.Query(" and ncode='" + ncode + "'");
                if (csns != null)
                {
                    r = js.Serialize(csns);
                }
                else
                {
                    sns.nname = "";
                    sns.ncode = snsb.CreateCode().ToString().PadLeft(4, '0');
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
        #region///  保存标准尺寸
        [WebMethod(true)]
        public static string SaveNomalSize(string bcd, string bcode, string bfc, string bhd, string bid, string bkd,string bname, string bsl, string btype ,string rhd,string rgd,string rkd,string rsl,string rtype)
        {
 
            string r = "";
            Sys_NomalSizeBll snsb = new Sys_NomalSizeBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_NomalSize s = new Sys_NomalSize();
                s.nname = bname;
                s.ncode = bcode;
                s.ng = Convert.ToInt32(bcd = bcd == "" ? "0" : bcd);
                s.nk = Convert.ToInt32(bkd = bkd == "" ? "0" : bkd);
                s.nh = Convert.ToInt32(bhd = bhd == "" ? "0" : bhd);
                s.nsl = Convert.ToInt32(bsl = bsl == "" ? "0" : bsl);
                s.nf = Convert.ToInt32(bfc = bfc == "" ? "0" : bfc);
                s.nattr = btype;
                if (rtype == "1")
                {
                    s.nrelate = true;
                }
                else
                {
                    s.nrelate = false;
                }
                s.nrg = Convert.ToInt32(rgd);
                s.nrk = Convert.ToInt32(rkd);
                s.nrn = Convert.ToInt32(rhd);
                s.nrsl = Convert.ToInt32(rsl);
                s.cdate = DateTime.Now.ToString();
                s.maker = iv.u.ename;
                if (iv.u.rcode == "xtgl")
                {
                    s.dcode = "";
                }
                else
                {
                    s.dcode = iv.u.dcode.Substring(0, 8);
                }
                if (bid == "0")
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
        #region///  删除标准尺寸
        [WebMethod(true)]
        public static string DelNomalSize(string ncode)
        {
            string r = "";
            Sys_NomalSizeBll snsb = new Sys_NomalSizeBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (snsb.Delete(" and ncode='" + ncode + "'"))
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
        #region///  标准尺寸列表
        [WebMethod(true)]
        public static ArrayList QueryList()
        {
            ArrayList r = new ArrayList();
            Sys_NomalSizeBll snsb = new Sys_NomalSizeBll();
            List<Sys_NomalSize> lsf = new List<Sys_NomalSize>();
            SqlCondtion sc = new SqlCondtion();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                StringBuilder where = new StringBuilder();
                if (iv.u.rcode == "xtgl")
                {
                }
                else
                {
                    where.Append(" and dcode ='" + iv.u.dcode.Substring(0, 8) + "'");
                }
                lsf = snsb.QueryList(where.ToString());
                if (lsf != null)
                {
                    foreach (Sys_NomalSize s in lsf)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.ncode);
                        al.Add(s.nname);
                        al.Add(s.nattr);
                        al.Add(s.ng);
                        al.Add(s.nk);
                        al.Add(s.nh);
                        al.Add(s.nf);
                        al.Add(s.nsl);
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
        public static string SetProductionNs(string pcode, string ncode)
        {
            string r = "";
            Sys_NomalSizeBll snsb = new Sys_NomalSizeBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {

                if (snsb.SetProductionNs(pcode, ncode) > 0)
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
        public static string ReSetProductionNs(string pcode)
        {
            string r = "";
            Sys_NomalSizeBll snsb = new Sys_NomalSizeBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {

                if (snsb.ReSetProductionNs(pcode) > 0)
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
        public static string GetProductionNs(string pcode)
        {
            string r = "";
            Sys_NomalSizeBll snsb = new Sys_NomalSizeBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = snsb.GetProductionNs(pcode);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion

        //-------------------------------Cust------------------------------
        #region///  保存标准尺寸
        [WebMethod(true)]
        public static string CustSaveNomalSize(string bcd, string bcode, string bfc, string bhd, string bid, string bkd, string bname, string bsl, string btype, string rhd, string rgd, string rkd, string rsl, string rtype)
        {

            string r = "";
            Sys_NomalSizeBll snsb = new Sys_NomalSizeBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_NomalSize s = new Sys_NomalSize();
                s.nname = bname;
                s.ncode = bcode;
                s.ng = Convert.ToInt32(bcd);
                s.nk = Convert.ToInt32(bkd);
                s.nh = Convert.ToInt32(bhd);
                s.nsl = Convert.ToInt32(bsl);
                s.nf = Convert.ToInt32(bfc);
                s.nattr = btype;
                s.dcode = iv.u.dcode.Substring(0, 8);
                if (rtype == "1")
                {
                    s.nrelate = true;
                }
                else
                {
                    s.nrelate = false;
                }
                s.nrg = Convert.ToInt32(rgd);
                s.nrk = Convert.ToInt32(rkd);
                s.nrn = Convert.ToInt32(rhd);
                s.nrsl = Convert.ToInt32(rsl);
                s.cdate = DateTime.Now.ToString();
                s.maker = iv.u.ename;
                if (bid == "0")
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
        #region///  标准尺寸列表
        [WebMethod(true)]
        public static ArrayList CustQueryList()
        {
            ArrayList r = new ArrayList();
            Sys_NomalSizeBll snsb = new Sys_NomalSizeBll();
            List<Sys_NomalSize> lsf = new List<Sys_NomalSize>();
            SqlCondtion sc = new SqlCondtion();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                StringBuilder where = new StringBuilder();
                lsf = snsb.QueryList(" and dcode ='"+iv.u.dcode.Substring(0,8)+"'");
                if (lsf != null)
                {
                    foreach (Sys_NomalSize s in lsf)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.ncode);
                        al.Add(s.nname);
                        al.Add(s.nattr);
                        al.Add(s.ng);
                        al.Add(s.nk);
                        al.Add(s.nh);
                        al.Add(s.nf);
                        al.Add(s.nsl);
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
    }
}