using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvModel.SysInfo;
using LionvBll.SysInfo;
using LionvAopModel;
using System.Web.Script.Serialization;
using LionvModel.ProductionInfo;
using System.Collections;
using System.Data;

namespace LionVERP.UIServer.ProductionSet.PartTypeManage
{
    public partial class Parttypes : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        private static Sys_PartTypeBll srb = new Sys_PartTypeBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region///初始化类型
        [WebMethod(true)]
        public static string InitPartType(string pcode)
        {
            string r = "";
            Sys_PartType sr = new Sys_PartType();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_PartType csr = srb.Query(" and pcode='" + pcode + "'");
                if (csr != null)
                {
                    r = js.Serialize(csr);
                }
                else
                {
                    sr.pname = "";
                    sr.pcode = srb.CreateCode().ToString().PadLeft(4, '0');
                    sr.id = 0;
                    r = js.Serialize(sr);
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///保存类型
        [WebMethod(true)]
        public static string SavePartType(string pabc ,string pcname,string pcode,string pctype, string pid, string pname)
        {
            string r = "";
            Sys_PartTypeBll srb = new Sys_PartTypeBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_PartType sr = new Sys_PartType();
                sr.pcode = pcode;
                sr.pname = pname;
                sr.ptype = pabc;
                sr.pcname = pcname;
                sr.pctype = pctype;
                sr.cdate = DateTime.Now.ToString();
                sr.maker = iv.u.ename;
                if (pid == "0")
                {
                    if (!srb.Exists(" and ptype='" + pabc + "'"))
                    {
                        if (srb.Add(sr) > 0)
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
                        r = "T";
                    }
                }
                else
                {
                    if (!srb.Exists(" and ptype='" + pabc + "'"))
                    {
                        if (srb.Update(sr))
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
                        r = "T";
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
        #region///备注类型
        [WebMethod(true)]
        public static ArrayList QueryList()
        {
            ArrayList r = new ArrayList();
            Sys_PartTypeBll srb = new Sys_PartTypeBll();
            List<Sys_PartType> lsf = new List<Sys_PartType>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                lsf = srb.QueryList("");
                if (lsf != null)
                {
                    foreach (Sys_PartType s in lsf)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.pcode);
                        al.Add(s.pname);
                        al.Add(s.ptype);
                        al.Add(s.pcname);
                        al.Add(s.pctype);
                        al.Add(s.pread);
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
        #region///删除类型
        [WebMethod(true)]
        public static string DelPartType(string pcode)
        {
            string r = "";
            Sys_PartTypeBll srb = new Sys_PartTypeBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (srb.Exists(" and pcode='" + pcode + "' and pread='false'"))
                {
                    if (srb.Delete(" and pcode='" + pcode + "'"))
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
                    r = "T";
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///获取类型
        [WebMethod(true)]
        public static ArrayList QueryCateList()
        {
            Sys_PartTypeBll srb = new Sys_PartTypeBll();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                DataTable lsf = srb.QueryCateList("");
                if (lsf != null)
                {
                    foreach (DataRow dr in lsf.Rows)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(dr["pctype"].ToString());
                        al.Add(dr["pcname"].ToString());
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