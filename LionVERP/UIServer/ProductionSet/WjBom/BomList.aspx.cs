using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using LionvBll.ProductionInfo;
using System.Web.Services;
using LionvModel.ProductionInfo;
using LionvAopModel;
using LionvBll.SysInfo;
using System.Collections;

namespace LionVERP.UIServer.ProductionSet.WjBom
{
    public partial class BomList : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        private static Sys_WjBomBll swbb = new Sys_WjBomBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region///  初始化五金部件
        [WebMethod(true)]
        public static string InitWjBom(string bcode)
        {
            string r = "";
            Sys_WjBom sr = new Sys_WjBom();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (bcode != "")
                {
                    sr = swbb.Query(" and bcode='"+bcode+"'");
                }
                else
                {
                    sr.id = 0;
                    sr.bcode = swbb.CreateCode().ToString().PadLeft(4, '0');
                }
                r = js.Serialize(sr);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///  保存五金部件
        [WebMethod(true)]
        public static string SaveWjBom( string bcode, string bid,string bname, string bnum,string bprice ,string bunit,string ebcode, string icode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_WjBom sr = new Sys_WjBom();
                sr.bcode = bcode;
                sr.bname = bname;
                sr.becode = ebcode;
                sr.bnum = Convert.ToDecimal(bnum);
                sr.bprice = Convert.ToDecimal(bprice);
                sr.cdate = DateTime.Now.ToString();
                sr.bunit = bunit;
                sr.icode = icode;
                if (bid == "0")
                {
                    if (swbb.Add(sr) > 0)
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
                    if (swbb.Update(sr))
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
        #region///  删除五金部件
        [WebMethod(true)]
        public static string DelWjBom(string bcode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (swbb.Delete(" and bcode='" + bcode + "'"))
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
        #region///   五金部件
        [WebMethod(true)]
        public static ArrayList QueryWjBomLIst()
        {
            ArrayList r = new ArrayList ();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_WjBom> ls=swbb.QueryList(" ");
                if (ls != null)
                {
                    foreach (Sys_WjBom s in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.bcode);
                        al.Add(s.bname);
                        al.Add(s.becode);
                        al.Add(s.bnum);
                        al.Add(s.bprice);
                        al.Add(s.bunit);
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
        #region///   五金部件设置
        [WebMethod(true)]
        public static string SetWjBom(string pcode,string bcode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (pcode != "" && bcode != "")
                {
                    string [] bcodes=bcode.Split(';');
                    if (swbb.SetWjBom(pcode, bcodes))
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
        #endregion///
        #region///   五金部件设置
        [WebMethod(true)]
        public static string ReSetWjBom(string pcode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (pcode != ""  )
                {
                    if (swbb.ReSetWjBom(pcode))
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
        #region///   获取五金部件设置
        [WebMethod(true)]
        public static string GetWjBom(string pcode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (pcode != "")
                {
                    r = swbb.GetWjBom(pcode);
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