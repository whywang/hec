using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.Services;
using LionvModel.ProductionInfo;
using LionvBll.ProductionInfo;
using LionvAopModel;
using LionvBll.SysInfo;
using System.Collections;
using System.Text;

namespace LionVERP.UIServer.ProductionSet.NomalSizeManage
{
    public partial class CgNomalSizes : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        private static Sys_CgNomalSizeBll snsb = new Sys_CgNomalSizeBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region///  初始化标准尺寸
        [WebMethod(true)]
        public static string InitNomalSize(string ncode)
        {
            string r = "";
            Sys_CgNomalSize sns = new Sys_CgNomalSize();
            
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_CgNomalSize csns = snsb.Query(" and ncode='" + ncode + "'");
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
        public static string SaveNomalSize(string bcode, string bname, string bid,  string bod, string bof,string bol, string bow, string btd, string btl, string btype, string btw)
        {

            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_CgNomalSize s = new Sys_CgNomalSize();
                s.nname = bname;
                s.ncode = bcode;
                s.ntype = btype;
                s.olen = Convert.ToInt32(bol);
                s.owid = Convert.ToInt32(bow);
                s.odee = Convert.ToInt32(bod);
                s.ofc = Convert.ToInt32(bof);
                s.tlen = Convert.ToInt32(btl);
                s.twid = Convert.ToInt32(btw);
                s.tdee = Convert.ToInt32(btd);
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
        #region///标准尺寸列表
        [WebMethod(true)]
        public static ArrayList QueryList()
        {
            ArrayList r = new ArrayList();
            List<Sys_CgNomalSize> lsf = new List<Sys_CgNomalSize>();
            SqlCondtion sc = new SqlCondtion();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                StringBuilder where = new StringBuilder();
                if (iv.u.rcode != "xtgl")
                {
                    where.Append(" and dcode='"+iv.u.dcode.Substring(0,8)+"'");
                }
                lsf = snsb.QueryList("");
                if (lsf != null)
                {
                    foreach (Sys_CgNomalSize s in lsf)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.ncode);
                        al.Add(s.nname);
                        switch (s.ntype)
                        {
                            case "ms":
                                al.Add("门");
                                break;
                            case "mt":
                                al.Add("套");
                                break;
                            case "qt":
                                al.Add("其他");
                                break;
                        }
                        al.Add(s.olen);
                        al.Add(s.owid);
                        al.Add(s.odee);
                        al.Add(s.ofc);
                        al.Add(s.tlen);
                        al.Add(s.twid);
                        al.Add(s.tdee);
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
    }
}