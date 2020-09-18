using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.Services;
using LionvBll.SysInfo;
using LionvModel.SysInfo;
using LionvAopModel;
using System.Collections;

namespace LionVERP.UIServer.BaseSet.TaxManage
{
    public partial class Taxs : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region///  初始化税费
        [WebMethod(true)]
        public static string InitTax(string tcode)
        {
            string r = "";
            Sys_Tax st = new Sys_Tax();
            Sys_TaxBll stb = new Sys_TaxBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Tax cst = new Sys_Tax();
                cst = stb.Query(" and tcode='" + tcode + "'");
                if (cst != null)
                {
                    r = js.Serialize(cst);
                }
                else
                {
                    st.tname = "";
                    st.tcode = stb.CreateCode().ToString().PadLeft(4, '0');
                    st.id = 0;
                    r = js.Serialize(st);
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///  保存税费
        [WebMethod(true)]
        public static string SaveTax(string fcode, string fid, string fname,string fvalue)
        {
            string r = "";
            Sys_Tax sd = new Sys_Tax();
            Sys_TaxBll sdb = new Sys_TaxBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sd.tcode = fcode;
                sd.tname = fname;
                sd.tax = Convert.ToDecimal(fvalue);
                sd.maker = iv.u.ename;
                sd.cdate = DateTime.Now.ToString();
                if (fid == "0")
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
        #region///  获取税费
        [WebMethod(true)]
        public static ArrayList QueryList()
        {
            ArrayList r = new ArrayList();
            Sys_Tax sd = new Sys_Tax();
            Sys_TaxBll sdb = new Sys_TaxBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_Tax> ls = sdb.QueryList(" ");
                if (ls != null)
                {
                    foreach (Sys_Tax s in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.tcode);
                        al.Add(s.tname);
                        al.Add(s.tax);
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
        #region///  删除税费
        [WebMethod(true)]
        public static string DelTax(string tcode)
        {
            string r = "";
            Sys_Tax sd = new Sys_Tax();
            Sys_TaxBll sdb = new Sys_TaxBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {

                if (sdb.Delete(" and tcode='"+tcode+"'"))
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
        #region///  设置平台税费
        [WebMethod(true)]
        public static string SetTax(string dcode, string tcode)
        {
            string r = "";
            Sys_Tax sd = new Sys_Tax();
            Sys_TaxBll sdb = new Sys_TaxBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sdb.SetAgentTax(dcode, tcode) > 0)
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
        #region///  重置税费
        [WebMethod(true)]
        public static string ReSetTax(string dcode)
        {
            string r = "";
            Sys_Tax sd = new Sys_Tax();
            Sys_TaxBll sdb = new Sys_TaxBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sdb.ReSetAgentTax(dcode) > 0)
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
        #region///  获取税费
        [WebMethod(true)]
        public static string GetTax(string dcode)
        {
            string r = "";
            Sys_Tax sd = new Sys_Tax();
            Sys_TaxBll sdb = new Sys_TaxBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = sdb.GetAgentTax(dcode);
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