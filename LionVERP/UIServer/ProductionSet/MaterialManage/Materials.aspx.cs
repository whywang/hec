using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Serialization;
using LionvBll.ProductionInfo;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.ProductionInfo;
using System.Collections;
using LionvBll.StatisticsInfo;

namespace LionVERP.UIServer.ProductionSet.MaterialManage
{
    public partial class Materials : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region///////////材质类管理
        #region///初始化材质类
        [WebMethod(true)]
        public static string InitMaterialCategory(string mccode,string mcode)
        {
            string r = "";
            Sys_MaterialCategoryBll smb = new Sys_MaterialCategoryBll();
            Sys_MaterialCategory sm = new Sys_MaterialCategory();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_MaterialCategory smp = smb.Query(" and mccode='" + mccode + "'");
                if (mcode == "")
                {
                   
                    if (smp != null)
                    {
                        sm.mcpcode = smp.mccode;
                        sm.mcpname = smp.mcname;
                    }
                    else
                    {
                        sm.mcpcode = "";
                        sm.mcpname = "";
                    }
                    sm.mccode = mccode + smb.CreateCode(mccode).ToString().PadLeft(3, '0');
                    sm.mcname = "";
                    sm.id = 0;
                }
                else
                {
                    sm =  smb.Query(" and mccode='" + mcode + "'");;
                }
                r = js.Serialize(sm);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///保存材质类
        [WebMethod(true)]
        public static string SaveMaterialCategory(string btype,string mcode, string mname, string mid, string mpcode, string mpname,string mtype)
        {
            string r = "";
            Sys_MaterialCategoryBll sub = new Sys_MaterialCategoryBll();
            Sys_MaterialCategory smc = new Sys_MaterialCategory();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                smc.mccode = mcode;
                smc.mcpcode = mpcode;
                smc.mcname = mname;
                smc.mcpname = mpname;
                smc.maker = iv.u.ename;
                smc.cdate = DateTime.Now.ToString();
                smc.mtype = mtype;
                smc.btype = btype;
                if (iv.u.rcode != "xtgl")
                {
                    smc.dcode = iv.u.dcode.Substring(0, 8);
                }
                else
                {
                    smc.dcode = "";
                }
                if (mid == "0")
                {
                    if (sub.Add(smc) > 0)
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
                    if (sub.Update(smc))
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
        #region///删除材质类
        [WebMethod(true)]
        public static string DelMaterialCategory(string mcode)
        {
            string r = "";
            Sys_MaterialCategoryBll sdb = new Sys_MaterialCategoryBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sdb.Delete( mcode))
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
        #region///材质类列表
        [WebMethod(true)]
        public static ArrayList QueryListMaterialCategory( string mpcode)
        {
            ArrayList r = new ArrayList();
            Sys_MaterialCategoryBll sub = new Sys_MaterialCategoryBll();
            List<Sys_MaterialCategory> lsr = new List<Sys_MaterialCategory>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                string where = "";
                if (iv.u.rcode == "xtgl")
                {
                    where = "and mcpcode='" + mpcode + "'";
                }
                else
                {
                    where = " and mcpcode='" + mpcode + "' and dcode='" + iv.u.dcode.Substring(0, 8) + "'";
                }
                lsr = sub.QueryList(where);
                if (lsr != null)
                {
                    foreach (Sys_MaterialCategory s in lsr)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.mccode);
                        al.Add(s.mcname);
                        al.Add(s.mcstate);
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
        #endregion
        #region/////////////材质管理
        #region///初始化材质
        [WebMethod(true)]
        public static string InitMaterial(string mccode,string mcode)
        {
            string r = "";
            Sys_MaterialBll smb = new Sys_MaterialBll();
            Sys_MaterialCategoryBll smcb = new Sys_MaterialCategoryBll();
            Sys_Material sm = new Sys_Material();
            Sys_MaterialCategory smc = new Sys_MaterialCategory();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                smc = smcb.Query(" and mccode='" + mccode + "'");
                if (mcode == "")
                {

                    if (smc != null)
                    {
                        sm.mccode = smc.mccode;
                        sm.mcname = smc.mcname;
                    }
                    else
                    {
                        sm.mccode = "";
                        sm.mcname = "";
                    }
                    sm.mcode = mccode + smb.CreateCode(mccode).ToString().PadLeft(3, '0');
                    sm.mname = "";
                    sm.mstate = true;
                    sm.id = 0;
                }
                else
                {
                    sm = smb.Query(" and mcode='" + mcode + "'");
                }
                r = js.Serialize(sm);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///保存材质
        [WebMethod(true)]
        public static string SaveMaterial(string ccode, string cname, string cid,string cpcode, string cpname, string cstate,string ctype)
        {
            string r = "";
            Sys_MaterialBll sub = new Sys_MaterialBll();
            Sys_Material smc = new Sys_Material();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                smc.mccode = cpcode;
                smc.mcname = cpname;
                smc.mname = cname;
                smc.mcode = ccode;
                smc.mtype = ctype;
                smc.mstate = cstate == "1" ? true : false;
                smc.maker = iv.u.ename;
                smc.cdate = DateTime.Now.ToString();
                if (cid == "0")
                {
                    if (sub.Add(smc) > 0)
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
                    if (sub.Update(smc))
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
        #region///删除材质
        [WebMethod(true)]
        public static string DelMaterial(string mcode)
        {
            string r = "";
            Sys_MaterialBll sdb = new Sys_MaterialBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sdb.Delete(" and mcode='" + mcode + "'"))
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
        #region///材质列表
        [WebMethod(true)]
        public static ArrayList QueryListMaterial(string mcode)
        {
            ArrayList r = new ArrayList();
            Sys_MaterialBll sub = new Sys_MaterialBll();
            List<Sys_Material> lsr = new List<Sys_Material>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                lsr = sub.QueryList(" and mccode='"+mcode+"'");
                if (lsr != null)
                {
                    foreach (Sys_Material s in lsr)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.mcode);
                        al.Add(s.mname);
                        al.Add(s.mstate==true?"启用":"<span style='color:#ff0000'>停用</span>");
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
        #region///材质列表
        [WebMethod(true)]
        public static ArrayList QueryListItem()
        {
            ArrayList r = new ArrayList();
            Sys_MaterialBll sub = new Sys_MaterialBll();
            List<Sys_Material> lsr = new List<Sys_Material>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string dcode = "";
                r.Add(iv.badstr);
                if(iv.u.dcode.Trim()!="")
                {
                    dcode = iv.u.dcode.Substring(0, 8);
                }
                else
                {
                    dcode = "00010001";
                }
                lsr = sub.QueryList(" and mstate='true' and mccode in(select mccode from Sys_MaterialCategory where dcode='" + dcode + "')");
                if (lsr != null)
                {
                    foreach (Sys_Material s in lsr)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.mcode);
                        al.Add(s.mname);
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
        #region///材质Talbe列表
        [WebMethod(true)]
        public static ArrayList QueryTableMaterial(string mcode)
        {
            ArrayList r = new ArrayList();
            Sys_MaterialBll sub = new Sys_MaterialBll();
            List<Sys_Material> lsr = new List<Sys_Material>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                lsr = sub.QueryList(" and mccode='" + mcode + "'");
                if (lsr != null)
                {
                    foreach (Sys_Material s in lsr)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.mcode);
                        al.Add(s.mname);
                        al.Add(s.mstate);
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

        #region///材质列表
        [WebMethod(true)]
        public static ArrayList QueryListItemEx(string mname)
        {
            ArrayList r = new ArrayList();
            Sys_MaterialBll sub = new Sys_MaterialBll();
            List<Sys_Material> lsr = new List<Sys_Material>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                lsr = sub.QueryList(" and mstate='true' and mname like '%" + mname + "%'");
                if (lsr != null)
                {
                    foreach (Sys_Material s in lsr)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.mcode);
                        al.Add(s.mname);
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
        #region///材质分类材质
        [WebMethod(true)]
        public static ArrayList QueryListByTypeEx(string mname, string btype)
        {
            ArrayList r = new ArrayList();
            Sys_MaterialBll sub = new Sys_MaterialBll();
            List<Sys_Material> lsr = new List<Sys_Material>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                lsr = sub.QueryList(" and mstate='true' and mname like '%" + mname + "%' and mccode in (select mccode from Sys_MaterialCategory where btype='" + btype + "' or btype='')");
                if (lsr != null)
                {
                    foreach (Sys_Material s in lsr)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.mcode);
                        al.Add(s.mname);
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
        #region///材质列表
        [WebMethod(true)]
        public static ArrayList QueryListItemByType(string mtype)
        {
            ArrayList r = new ArrayList();
            Sys_MaterialBll sub = new Sys_MaterialBll();
            List<Sys_Material> lsr = new List<Sys_Material>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                lsr = sub.QueryList(" and mstate='true' and mccode in(select mccode from Sys_MaterialCategory where dcode='" + iv.u.dcode.Substring(0, 8) + "' and mtype='"+mtype+"')");
                if (lsr != null)
                {
                    foreach (Sys_Material s in lsr)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.mcode);
                        al.Add(s.mname);
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
        #region///材质列表
        [WebMethod(true)]
        public static ArrayList QueryListItemByBrand(string mname,string bcode)
        {
            ArrayList r = new ArrayList();
            Sys_MaterialBll sub = new Sys_MaterialBll();
            List<Sys_Material> lsr = new List<Sys_Material>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                lsr = sub.QueryList(" and mstate='true' and mname like'%"+mname+"%' and mname in(select mcode from Sys_RBrandsMaterial where pbcode='" + bcode + "')");
                if (lsr != null)
                {
                    foreach (Sys_Material s in lsr)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.mcode);
                        al.Add(s.mname);
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
        #endregion

        //--------------------------------Cust-----------------------------------------
        #region///保存材质类
        [WebMethod(true)]
        public static string CustSaveMaterialCategory(string mcode, string mname, string mid, string mpcode, string mpname,string mtype)
        {
            string r = "";
            Sys_MaterialCategoryBll sub = new Sys_MaterialCategoryBll();
            Sys_MaterialCategory smc = new Sys_MaterialCategory();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                smc.mccode = mcode;
                smc.mcpcode = mpcode;
                smc.mcname = mname;
                smc.mcpname = mpname;
                smc.maker = iv.u.ename;
                smc.dcode = iv.u.dcode.Substring(0, 8);
                smc.cdate = DateTime.Now.ToString();
                smc.mtype = mtype;
                if (mid == "0")
                {
                    if (sub.Add(smc) > 0)
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
                    if (sub.Update(smc))
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
        #region///材质类列表
        [WebMethod(true)]
        public static ArrayList CustQueryListMaterialCategory(string mpcode)
        {
            ArrayList r = new ArrayList();
            Sys_MaterialCategoryBll sub = new Sys_MaterialCategoryBll();
            List<Sys_MaterialCategory> lsr = new List<Sys_MaterialCategory>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                lsr = sub.QueryList(" and mcpcode='" + mpcode + "' and dcode='"+iv.u.dcode.Substring(0,8)+"'");
                if (lsr != null)
                {
                    foreach (Sys_MaterialCategory s in lsr)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.mccode);
                        al.Add(s.mcname);
                        al.Add(s.mcstate);
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
        #region///材质列表
        [WebMethod(true)]
        public static ArrayList CustQueryListItem()
        {
            ArrayList r = new ArrayList();
            Sys_MaterialBll sub = new Sys_MaterialBll();
            List<Sys_Material> lsr = new List<Sys_Material>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                lsr = sub.QueryList(" and mstate='true' and mccode in(select mccode from Sys_MaterialCategory where dcode='"+iv.u.dcode.Substring(0,8)+"')");
                if (lsr != null)
                {
                    foreach (Sys_Material s in lsr)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.mcode);
                        al.Add(s.mname);
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
        #region///分类型材质类列表
        [WebMethod(true)]
        public static ArrayList CustQueryListMaterialCategoryByType(string mtype, string mpcode)
        {
            ArrayList r = new ArrayList();
            Sys_MaterialCategoryBll sub = new Sys_MaterialCategoryBll();
            List<Sys_MaterialCategory> lsr = new List<Sys_MaterialCategory>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                lsr = sub.QueryList(" and mtype='" + mtype + "' and mcpcode='" + mpcode + "' and dcode='" + iv.u.dcode.Substring(0, 8) + "'");
                if (lsr != null)
                {
                    foreach (Sys_MaterialCategory s in lsr)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.mccode);
                        al.Add(s.mcname);
                        al.Add(s.mcstate);
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
        #region///通过品牌获取材质类别
        [WebMethod(true)]
        public static ArrayList QueryMaterialListCategoryByBdcode(string btype, string mpcode)
        {
            ArrayList r = new ArrayList();
            Sys_MaterialCategoryBll sub = new Sys_MaterialCategoryBll();
            T_StatisticsBll tsb = new T_StatisticsBll();
            List<Sys_MaterialCategory> lsr = new List<Sys_MaterialCategory>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                lsr = sub.QueryList(" and mcpcode='" + mpcode + "' and dcode='" + iv.u.dcode.Substring(0, 8) + "'");
                if (lsr != null)
                {
                    foreach (Sys_MaterialCategory s in lsr)
                    {
                        ArrayList al = new ArrayList();
                        if (tsb.BaseExists("Sys_RBrandsMaterial", " and pbcode='" + btype + "' and mpcode like'" + s.mccode + "%' "))
                        {
                            al.Add(s.mccode);
                            al.Add(s.mcname);
                            al.Add(s.mcstate);
                            r.Add(al);
                        }
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