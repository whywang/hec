using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using System.Web.Script.Serialization;
using LionvModel.SysInfo;
using System.Collections;
using ViewModel.BaseSet.Depment;
using LionvCommon;
using LionvModel.ProductionInfo;
using LionvBll.ProductionInfo;
using LionvBll.API;
using LionvModel.Api;

namespace LionVERP.UIServer.BaseSet.DepManage
{
    public partial class Depment : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region///  新增部门是通过父级编码初始化部门信息 
        [WebMethod(true)]
        public static string InitDepment(string pdepcode)
        {
            string r = "";
            Sys_Depment psd = new Sys_Depment();
            Sys_Depment sd = new Sys_Depment();
            Sys_DepmentBll sdb=new Sys_DepmentBll ();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                psd = sdb.Query(" and dcode='" + pdepcode + "'");
                if (psd != null)
                {
                    sd.dpname = psd.dname;
                    sd.dpcode = psd.dcode;
                    sd.dcode =pdepcode+ sdb.CreateCode(psd.dcode).ToString().PadLeft(4, '0');
                    sd.dsort = sdb.CreateCode(psd.dcode);
                    sd.id = 0;
                    r = js.Serialize(sd);
                }
                else
                {
                    sd.dpname = "";
                    sd.dpcode = "";
                    sd.dcode = sdb.CreateCode("").ToString().PadLeft(4, '0');
                    sd.dsort = sdb.CreateCode("");
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
        #region///  新增/编辑部门是通初始化部门信息
        [WebMethod(true)]
        public static string InitDepmentEx(string pdepcode,string cdcode)
        {
            string r = "";
            Sys_Depment psd = new Sys_Depment();
            Sys_Depment sd = new Sys_Depment();
            Sys_DepmentBll sdb = new Sys_DepmentBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (cdcode == "")
                {
                    psd = sdb.Query(" and dcode='" + pdepcode + "'");
                    if (psd != null)
                    {
                        sd.dpname = psd.dname;
                        sd.dpcode = psd.dcode;
                        sd.dcode = pdepcode + sdb.CreateCode(psd.dcode).ToString().PadLeft(4, '0');
                        sd.id = 0;
                        r = js.Serialize(sd);
                    }
                    else
                    {
                        sd.dpname = "";
                        sd.dpcode = "";
                        sd.dcode = sdb.CreateCode("").ToString().PadLeft(4, '0');
                        sd.id = 0;
                        r = js.Serialize(sd);
                    }
                }
                else
                {
                    sd = sdb.Query(" and dcode='" + cdcode + "'");
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
        #region/// 通过部门编码初始化部门信息
        [WebMethod(true)]
        public static string QueryDepmentByDepCode(string dcode)
        {
            string r = "";
            VDepment vsd = new VDepment();
            Sys_Depment sd = new Sys_Depment();
            Sys_DepmentBll sdb = new Sys_DepmentBll();
            Sys_DepmentDpt sdd = new Sys_DepmentDpt();
            Sys_DepmentDptBll sddb = new Sys_DepmentDptBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sd = sdb.Query(" and dcode='" + dcode + "'");
                sdd=sddb.Query(" and dcode='" + dcode + "'");
                if (sd != null)
                {
                    vsd.dcode = sd.dcode;
                    vsd.dname = sd.dname;
                    vsd.dpname = sd.dpname;
                    vsd.dpcode = sd.dpcode;
                    vsd.khcode = sd.khcode;
                    vsd.id = sd.id;
                    vsd.dattr = sd.dattr;
                    vsd.dabc = sd.dabc;
                    vsd.dsort = sd.dsort.ToString();
                    if (sdd != null)
                    {
                        vsd.dmanager = sdd.dmanager;
                        vsd.dcontact = sdd.dcontact;
                    }
                    r = js.Serialize(vsd);
                }
                else
                {
                    r = iv.badstr;
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region/// 获取全部部门
        [WebMethod(true)]
        public static ArrayList QueryAllList (string dcode)
        {
            ArrayList r = new ArrayList() ;
            Sys_DepmentBll sdb = new Sys_DepmentBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string wsql = "";
                r.Add(iv.badstr);
                if (iv.u.rcode != "xtgl")
                {
                    if (dcode != "")
                    {
                        wsql = " and dpcode='" + dcode + "' and dcode like '" + iv.u.dcode.Substring(0, 8) + "%'";
                    }
                    else
                    {
                        wsql = " and dcode = '" + iv.u.dcode.Substring(0, 8) + "'";
                    }
                }
                else
                {
                    wsql = " and dpcode='" + dcode + "'";
                }
                List<Sys_Depment> ls = sdb.QueryList(wsql);
                if (ls != null)
                {
                    foreach (Sys_Depment s in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.dcode);
                        al.Add(s.dname);
                        al.Add(s.disend);
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
        #region/// 获取使用部门
        [WebMethod(true)]
        public static ArrayList QueryList(string dcode)
        {
            ArrayList r = new ArrayList();
            Sys_DepmentBll sdb = new Sys_DepmentBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_Depment> ls = sdb.QueryList(" and dpcode='" + dcode + "' and disused='true'");
                if (ls != null)
                {
                    foreach (Sys_Depment s in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.dcode);
                        al.Add(s.dname);
                        al.Add(s.disend);
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
        #region/// 模糊查询部门
        [WebMethod(true)]
        public static ArrayList DimQueryDep(string dcode,string attr,string dname)
        {
            ArrayList r = new ArrayList();
            Sys_DepmentBll sdb = new Sys_DepmentBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                string where = "";
                if (dname == "")
                {
                    where = " and dpcode like '" + dcode + "%' and dattr='" + attr + "'   and disused='true'";
                }
                else
                {
                    where = " and dpcode like '" + dcode + "%' and dattr='" + attr + "'   and disused='true' and dname like '%" + dname + "%'";
                }
                List<Sys_Depment> ls = sdb.QueryList(where);
                if (ls != null)
                {
                    foreach (Sys_Depment s in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.dcode);
                        al.Add(s.dname);
                        al.Add(s.disend);
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
        #region/// 获取属性部门
        [WebMethod(true)]
        public static ArrayList QueryListByAttr(string attr)
        {
            ArrayList r = new ArrayList();
            Sys_DepmentBll sdb = new Sys_DepmentBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                string where = "";
                if (iv.u.rcode != "xtgl")
                {
                    where = "and dattr='" + attr + "' and disused='true' and dcode like'"+ iv.u.dcode.Substring(0,8)+"%'";
                }
                else
                {
                    where = "and dattr='" + attr + "' and disused='true'";
                }
                List<Sys_Depment> ls = sdb.QueryList(where);
                if (ls != null)
                {
                    foreach (Sys_Depment s in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.dcode);
                        al.Add(s.dname);
                        al.Add(s.disend);
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
        #region/// 获取属性部门
        [WebMethod(true)]
        public static ArrayList QueryListByDepAttr(string dcode, string attr)
        {
            ArrayList r = new ArrayList();
            Sys_DepmentBll sdb = new Sys_DepmentBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                string where = "";
                where = "and dattr='" + attr + "' and disused='true' and dcode like'" + dcode  + "%'";
                List<Sys_Depment> ls = sdb.QueryList(where);
                if (ls != null)
                {
                    foreach (Sys_Depment s in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.dcode);
                        al.Add(s.dname);
                        al.Add(s.disend);
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
        #region/// 保存部门
        [WebMethod(true)]
        public static string SaveDep(string adepattr, string adepcode, string adepmanager, string adepname, string adeptelephone, string admattr, string adsort, string adsquare, string aid, string akhcode, string dabc, string pdepcode, string pdepname)
        {
            string r = "";
            Sys_Depment sd = new Sys_Depment();
            Sys_DepmentDpt sdd = new Sys_DepmentDpt();
            Sys_DepmentBll sdb = new Sys_DepmentBll();
            Sys_DepmentDptBll sddb = new Sys_DepmentDptBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sd.dname = adepname;
                sd.dcode = adepcode;
                sd.disend = true;
                sd.disused = true;
                sd.dattr = adepattr;
                sd.dcdate = DateTime.Now.ToString();
                sd.cdate = DateTime.Now.ToString();
                sd.dmaker = iv.u.ename;
                sd.dpcode = pdepcode;
                sd.dpname = pdepname;
                sd.dcdep = "";
                sd.dread = true;
                sd.dabc = dabc;
                sd.khcode = akhcode;
                sd.dsquare =adsquare==""?0: Convert.ToDecimal(adsquare);
                sd.dsort = Convert.ToInt32(adsort);
                if (adepattr == "dm")
                {
                    sd.dmattr = admattr;
                }
                else
                {
                    sd.dmattr = "";
                }
                sdd.dcode = adepcode;
                sdd.daddress = "";
                sdd.dcontact = adeptelephone;
                sdd.ddetail = "";
                sdd.dfitment = DateTime.Now.ToString();
                sdd.dmaker = iv.u.ename;
                sdd.dmanager = adepmanager;
                sdd.dno = "";
                sdd.dperson = 0;
                if (aid == "0")
                {
                    if (sdb.AddDepWithChildDep(sd) > 0)
                    {
                        sddb.Add(sdd);
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
                        sddb.Update(sdd);
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
        #region/// 删除部门信息
        [WebMethod(true)]
        public static string Del(string dcode)
        {
            string r = "";
            Sys_DepmentBll sdb = new Sys_DepmentBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sdb.Delete(dcode))
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
        #region/// 获取人员属性部门
        [WebMethod(true)]
        public static ArrayList QueryEmployeeByAttr(string attr)
        {
            ArrayList r = new ArrayList();
            Sys_DepmentBll sdb = new Sys_DepmentBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_Depment> ls = new List<Sys_Depment>();
                if (iv.u.rcode == "xtgl")
                {
                    ls = sdb.QueryList(" and dattr='" + attr + "' and disused='true'  ");
                }
                else
                {
                    ls = sdb.QueryList(" and dattr='" + attr + "' and disused='true' and dcode in ( select dcode from Sys_REmployeeAgent where eno='"+iv.u.eno+"')");
                }
                if (ls != null)
                {
                    foreach (Sys_Depment s in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.dcode);
                        al.Add(s.dname);
                        al.Add(s.disend);
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

        ////--------------------用户添加部门---------------------
        #region/// 获取全部部门
        [WebMethod(true)]
        public static ArrayList CustQueryAllList(string dcode)
        {
            ArrayList r = new ArrayList();
            Sys_DepmentBll sdb = new Sys_DepmentBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string where = "";
                r.Add(iv.badstr);
                if (iv.u.rcode == "xtgl")
                {
                }
                else
                {
                    where = " and substring(dcode,1,4)='" + iv.u.dcode.Substring(0, 4) + "'";
                }
                List<Sys_Depment> ls = sdb.QueryList(" and dpcode='" + dcode + "'"+where);
                if (ls != null)
                {
                    foreach (Sys_Depment s in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.dcode);
                        al.Add(s.dname);
                        al.Add(s.disend);
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
        #region/// 删除部门信息
        [WebMethod(true)]
        public static string CustDel(string dcode)
        {
            string r = "";
            Sys_DepmentBll sdb = new Sys_DepmentBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Depment psd = sdb.Query(" and dcode='" + dcode + "'");
                if (psd.dread)
                {
                    r = "R";
                }
                else
                {
                    if (sdb.Delete(dcode))
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
        #region/// 通过部门编码初始化部门信息
        [WebMethod(true)]
        public static string CustQueryDepmentByDepCode(string dcode)
        {
            string r = "";
            VDepment vsd = new VDepment();
            Sys_Depment sd = new Sys_Depment();
            Sys_DepmentBll sdb = new Sys_DepmentBll();
            Sys_DepmentDpt sdd = new Sys_DepmentDpt();
            Sys_DepmentDptBll sddb = new Sys_DepmentDptBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sd = sdb.Query(" and dcode='" + dcode + "'");
                sdd = sddb.Query(" and dcode='" + dcode + "'");
                if (sd != null)
                {
                    vsd.dcode = sd.dcode;
                    vsd.dname = sd.dname;
                    vsd.dpname = sd.dpname;
                    vsd.dpcode = sd.dpcode;
                    vsd.id = sd.id;
                    vsd.khcode = sd.khcode;
                    vsd.dattr = sd.dattr;
                    if (sdd != null)
                    {
                        vsd.dmanager = sdd.dmanager;
                        vsd.dcontact = sdd.dcontact;
                    }
                    if (sd.dread)
                    {
                        r = "R";
                    }
                    else
                    {
                        r = js.Serialize(vsd);
                    }
                }
                else
                {
                    r = iv.badstr;
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region/// 保存部门
        [WebMethod(true)]
        public static string CustSaveDep(string adepattr, string adepcode, string adepmanager, string adepname, string adeptelephone, string aid, string pdepcode, string pdepname)
        {
            string r = "";
            Sys_Depment sd = new Sys_Depment();
            Sys_DepmentDpt sdd = new Sys_DepmentDpt();
            Sys_DepmentBll sdb = new Sys_DepmentBll();
            Sys_DepmentDptBll sddb = new Sys_DepmentDptBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sd.dname = adepname;
                sd.dcode = adepcode;
                sd.disend = true;
                sd.disused = true;
                sd.dattr = adepattr;
                sd.dcdate = DateTime.Now.ToString();
                sd.dmaker = iv.u.ename;
                sd.dpcode = pdepcode;
                sd.dpname = pdepname;
                sd.dcdep = "";
                sd.dread = false;
                sdd.dcode = adepcode;
                sdd.daddress = "";
                sdd.dcontact = adeptelephone;
                sdd.ddetail = "";
                sdd.dfitment = DateTime.Now.ToString();
                sdd.dmaker = iv.u.ename;
                sdd.dmanager = adepmanager;
                sdd.dno = "";
                sdd.dperson = 0;
                if (aid == "0")
                {
                    if (sdb.Add(sd) > 0)
                    {
                        sddb.Add(sdd);
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
                        sddb.Update(sdd);
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
        #region/// 获取属性部门
        [WebMethod(true)]
        public static ArrayList CustQueryListByAttr(string attr)
        {
            ArrayList r = new ArrayList();
            Sys_DepmentBll sdb = new Sys_DepmentBll();
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
                    where = " and dcode like '"+iv.u.dcode+"'";
                }
                List<Sys_Depment> ls = sdb.QueryList(" and dattr='" + attr + "' and disused='true'"+where);
                if (ls != null)
                {
                    foreach (Sys_Depment s in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.dcode);
                        al.Add(s.dname);
                        al.Add(s.disend);
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

        ///-------------------------企业信息--------------------------
        #region/// 保存企业信息
        [WebMethod(true)]
        public static string AddCompany(string aid,string dabc,string daddress, string dcode, string dname,string dtype, string iadmin, string idep,string iproduction,  string manager, string telephone)
        {
            string r = "";
            Sys_Depment sd = new Sys_Depment();
            Sys_DepmentDpt sdd = new Sys_DepmentDpt();
            Sys_DepmentBll sdb = new Sys_DepmentBll();
            Sys_DepmentDptBll sddb = new Sys_DepmentDptBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sd.dname = dname;
                sd.dcode = dcode;
                sd.disend = true;
                sd.disused = true;
                sd.dattr = dtype;
                sd.dcdate = DateTime.Now.ToString();
                sd.dmaker = iv.u.ename;
                sd.dpcode = "0001";
                sd.dpname = "北京联汇软件";
                sd.dcdep = idep;
                sd.dread = true;
                sd.dabc = dabc;
                sdd.dcode = dcode;
                sdd.daddress = daddress;
                sdd.dcontact = telephone;
                sdd.ddetail = "";
                sdd.dfitment = DateTime.Now.ToString();
                sdd.dmaker = iv.u.ename;
                sdd.dmanager = manager;
                sdd.dno = "";
                sdd.iadmin = iadmin == "1" ? true : false;
                sdd.idepment = idep;
                sdd.logo = "";
                sdd.iproduction = iproduction == "1" ? true : false;
                sdd.dperson = 0;
                if (aid == "0")
                {
                    if (sdb.AddDepWithChildDep(sd) > 0)
                    {
                        if (sdd.iadmin)
                        {
                            #region
                            Sys_Employee se = new Sys_Employee();
                            Sys_User su = new Sys_User();
                            Sys_EmployeeDpt sed = new Sys_EmployeeDpt();
                            Sys_EmployeeBll seb = new Sys_EmployeeBll();
                            Sys_UserBll sub = new Sys_UserBll();
                            Sys_Employee cse = new Sys_Employee();
                            Sys_EmployeeDptBll sedb = new Sys_EmployeeDptBll();

                            se.dname = sd.dname;
                            se.dcode = sd.dcode;
                            se.eno = "E" + seb.GetEno().ToString().PadLeft(8, '0');
                            se.ename = sd.dname+"管理员";
                            se.estate = true ;
                            se.dtcode = "";
                            se.elogin = true ;
                            se.ecdate = DateTime.Now.ToString();
                            se.emaker = iv.u.ename;
                            se.rcode = "0001";

                            sed.eaddress = "";
                            sed.eage = 0;
                            sed.eeducation = "";
                            sed.eemail = "";
                            sed.eheadimage = "";
                            sed.eidentity = "";
                            sed.enativeplace = "";
                            sed.eno = se.eno;
                            sed.esex = true;
                            sed.etelephone = "";
                            sed.eworkdate = DateTime.Now.ToString();

                            su.eno = se.eno;
                            su.upass = DES.EncryptDES("123456");
                            su.uname = sd.dabc + "_admin" ;
                            su.ulogin = true;
                            su.uip = "";
                            su.ulogintime = "";
                            seb.AddList(se, sed, su);
                            #endregion
                        }
                        if (sdd.iproduction)
                        {
                            #region
                            Sys_InventoryCategoryBll sicb = new Sys_InventoryCategoryBll();
                            Sys_InventoryCategory zcp = new Sys_InventoryCategory();
                            zcp.iccode = sd.dcode;
                            zcp.icpcode = "";
                            zcp.icname = sd.dname + "产品";
                            zcp.icpname = "";
                            zcp.maker = iv.u.ename;
                            zcp.cdate = DateTime.Now.ToString();
                            zcp.icsend = true;
                            zcp.icstate = false;
                            zcp.icms = "";
                            sicb.Add(zcp);
                            Sys_InventoryCategory ztm = new Sys_InventoryCategory();
                            ztm.iccode = sd.dcode+"10";
                            ztm.icpcode = sd.dcode;
                            ztm.icname = "整套门";
                            ztm.icpname = "";
                            ztm.maker = iv.u.ename;
                            ztm.cdate = DateTime.Now.ToString();
                            ztm.icsend = true;
                            ztm.icstate = true;
                            ztm.icms = "";
                            ztm.isort = 1;
                            sicb.Add(ztm);
                            Sys_InventoryCategory ms = new Sys_InventoryCategory();
                            ms.iccode = sd.dcode + "01";
                            ms.icpcode = sd.dcode;
                            ms.icname = "门扇";
                            ms.icpname = "";
                            ms.maker = iv.u.ename;
                            ms.cdate = DateTime.Now.ToString();
                            ms.icsend = true;
                            ms.icstate = false;
                            ms.icms = "";
                            ms.isort = 2;
                            sicb.Add(ms);
                            Sys_InventoryCategory dms = new Sys_InventoryCategory();
                            dms.iccode = ms.iccode + "01";
                            dms.icpcode = ms.iccode;
                            dms.icname = "单开门";
                            dms.icpname = "门扇";
                            dms.maker = iv.u.ename;
                            dms.cdate = DateTime.Now.ToString();
                            dms.icsend = true;
                            dms.icstate = true;
                            dms.icms = "";
                            dms.isort = 21;
                            sicb.Add(dms);
                            Sys_InventoryCategory sms = new Sys_InventoryCategory();
                            sms.iccode = ms.iccode + "02";
                            sms.icpcode = ms.iccode;
                            sms.icname = "对开门";
                            sms.icpname = "门扇";
                            sms.maker = iv.u.ename;
                            sms.cdate = DateTime.Now.ToString();
                            sms.icsend = true;
                            sms.icstate = true;
                            sms.icms = "";
                            sms.isort = 22;
                            sicb.Add(sms);
                            Sys_InventoryCategory zms = new Sys_InventoryCategory();
                            zms.iccode = ms.iccode + "03";
                            zms.icpcode = ms.iccode;
                            zms.icname = "子母门";
                            zms.icpname = "门扇";
                            zms.maker = iv.u.ename;
                            zms.cdate = DateTime.Now.ToString();
                            zms.icsend = true;
                            zms.icstate = true;
                            zms.icms = "";
                            zms.isort = 23;
                            sicb.Add(zms);
                            Sys_InventoryCategory tlm = new Sys_InventoryCategory();
                            tlm.iccode = ms.iccode + "04";
                            tlm.icpcode = ms.iccode;
                            tlm.icname = "推拉门";
                            tlm.icpname = "门扇";
                            tlm.maker = iv.u.ename;
                            tlm.cdate = DateTime.Now.ToString();
                            tlm.icsend = true;
                            tlm.icstate = false;
                            tlm.icms = "";
                            tlm.isort = 24;
                            sicb.Add(tlm);
                            Sys_InventoryCategory stlm = new Sys_InventoryCategory();
                            stlm.iccode = tlm.iccode + "01";
                            stlm.icpcode = tlm.iccode;
                            stlm.icname = "两扇推拉门";
                            stlm.icpname = "推拉门";
                            stlm.maker = iv.u.ename;
                            stlm.cdate = DateTime.Now.ToString();
                            stlm.icsend = true;
                            stlm.icstate = true;
                            stlm.icms = "";
                            stlm.isort = 241;
                            sicb.Add(stlm);
                            Sys_InventoryCategory ftlm = new Sys_InventoryCategory();
                            ftlm.iccode = tlm.iccode + "02";
                            ftlm.icpcode = tlm.iccode;
                            ftlm.icname = "四扇推拉门";
                            ftlm.icpname = "推拉门";
                            ftlm.maker = iv.u.ename;
                            ftlm.cdate = DateTime.Now.ToString();
                            ftlm.icsend = true;
                            ftlm.icstate = true;
                            ftlm.icms = "";
                            ftlm.isort = 242;
                            sicb.Add(ftlm);
                            Sys_InventoryCategory mt = new Sys_InventoryCategory();
                            mt.iccode = sd.dcode + "02";
                            mt.icpcode = sd.dcode;
                            mt.icname = "门套";
                            mt.icpname = "";
                            mt.maker = iv.u.ename;
                            mt.cdate = DateTime.Now.ToString();
                            mt.icsend = true;
                            mt.icstate = false;
                            mt.icms = "";
                            mt.isort = 3;
                            sicb.Add(mt);
                            Sys_InventoryCategory dmt = new Sys_InventoryCategory();
                            dmt.iccode = mt.iccode + "01";
                            dmt.icpcode = mt.iccode;
                            dmt.icname = "单开门套";
                            dmt.icpname = "门套";
                            dmt.maker = iv.u.ename;
                            dmt.cdate = DateTime.Now.ToString();
                            dmt.icsend = true;
                            dmt.icstate = true;
                            dmt.icms = "";
                            dmt.isort = 31;
                            sicb.Add(dmt);
                            Sys_InventoryCategory smt = new Sys_InventoryCategory();
                            smt.iccode = mt.iccode + "02";
                            smt.icpcode = mt.iccode;
                            smt.icname = "对开门套";
                            smt.icpname = "门套";
                            smt.maker = iv.u.ename;
                            smt.cdate = DateTime.Now.ToString();
                            smt.icsend = true;
                            smt.icstate = true;
                            smt.icms = "";
                            smt.isort = 32;
                            sicb.Add(smt);
                            Sys_InventoryCategory zmt = new Sys_InventoryCategory();
                            zmt.iccode = mt.iccode + "03";
                            zmt.icpcode = mt.iccode;
                            zmt.icname = "子母门套";
                            zmt.icpname = "门套";
                            zmt.maker = iv.u.ename;
                            zmt.cdate = DateTime.Now.ToString();
                            zmt.icsend = true;
                            zmt.icstate = true;
                            zmt.icms = "";
                            zmt.isort = 33;
                            sicb.Add(zmt);
                            Sys_InventoryCategory tmt = new Sys_InventoryCategory();
                            tmt.iccode = mt.iccode + "04";
                            tmt.icpcode = mt.iccode;
                            tmt.icname = "推拉门套";
                            tmt.icpname = "门套";
                            tmt.maker = iv.u.ename;
                            tmt.cdate = DateTime.Now.ToString();
                            tmt.icsend = true;
                            tmt.icstate = true;
                            tmt.icms = "";
                            tmt.isort = 34;
                            sicb.Add(tmt);
                            Sys_InventoryCategory wj = new Sys_InventoryCategory();
                            wj.iccode = sd.dcode + "04";
                            wj.icpcode = sd.dcode;
                            wj.icname = "五金";
                            wj.icpname = "";
                            wj.maker = iv.u.ename;
                            wj.cdate = DateTime.Now.ToString();
                            wj.icsend = true;
                            wj.icstate = true;
                            wj.icms = "";
                            wj.isort = 4;
                            sicb.Add(wj);
                            Sys_InventoryCategory bl = new Sys_InventoryCategory();
                            bl.iccode = sd.dcode + "05";
                            bl.icpcode = sd.dcode;
                            bl.icname = "玻璃";
                            bl.icpname = "";
                            bl.maker = iv.u.ename;
                            bl.cdate = DateTime.Now.ToString();
                            bl.icsend = true;
                            bl.icstate = true;
                            bl.icms = "";
                            bl.isort = 5;
                            sicb.Add(bl);
                            Sys_InventoryCategory ct = new Sys_InventoryCategory();
                            ct.iccode = sd.dcode + "06";
                            ct.icpcode = sd.dcode;
                            ct.icname = "窗套";
                            ct.icpname = "";
                            ct.maker = iv.u.ename;
                            ct.cdate = DateTime.Now.ToString();
                            ct.icsend = true;
                            ct.icstate = true;
                            ct.icms = "";
                            ct.isort = 6;
                            sicb.Add(ct);
                            Sys_InventoryCategory yk = new Sys_InventoryCategory();
                            yk.iccode = sd.dcode + "07";
                            yk.icpcode = sd.dcode;
                            yk.icname = "垭口";
                            yk.icpname = "";
                            yk.maker = iv.u.ename;
                            yk.cdate = DateTime.Now.ToString();
                            yk.icsend = true;
                            yk.icstate = true;
                            yk.icms = "";
                            yk.isort = 7;
                            sicb.Add(yk);
                            Sys_InventoryCategory hj = new Sys_InventoryCategory();
                            hj.iccode = sd.dcode + "08";
                            hj.icpcode = sd.dcode;
                            hj.icname = "护角";
                            hj.icpname = "";
                            hj.maker = iv.u.ename;
                            hj.cdate = DateTime.Now.ToString();
                            hj.icsend = true;
                            hj.icstate = true;
                            hj.icms = "";
                            hj.isort = 8;
                            sicb.Add(hj);
                            Sys_InventoryCategory qt = new Sys_InventoryCategory();
                            qt.iccode = sd.dcode + "09";
                            qt.icpcode = sd.dcode;
                            qt.icname = "其他";
                            qt.icpname = "";
                            qt.maker = iv.u.ename;
                            qt.cdate = DateTime.Now.ToString();
                            qt.icsend = true;
                            qt.icstate = true;
                            qt.icms = "";
                            qt.isort = 9;
                            sicb.Add(qt);
                            #endregion
                        }
                        sddb.Add(sdd);
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
                        sddb.Update(sdd);
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
        #region/// 获取企业信息
        [WebMethod(true)]
        public static string QueryCompany(string dcode)
        {
            string r = "";
            Sys_Depment sd = new Sys_Depment();
            Sys_DepmentDpt sdd = new Sys_DepmentDpt();
            Sys_DepmentBll sdb = new Sys_DepmentBll();
            Sys_DepmentDptBll sddb = new Sys_DepmentDptBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                VDepment vd = new VDepment();
                if (dcode == "")
                {
                    vd.dcode = "0001" + sdb.CreateCode("0001").ToString().PadLeft(4, '0');
                    vd.id = 0;
                }
                else
                {
                    sd = sdb.Query(" and dcode='" + dcode + "'");
                    sdd = sddb.Query(" and dcode='" + dcode + "'");
                    vd.id = sd.id;
                    vd.dcode = sd.dcode;
                    vd.dname = sd.dname;
                    vd.dabc = sd.dabc;
                    vd.dattr = sd.dattr;
                    vd.daddress = sdd.daddress;
                    vd.dcontact = sdd.dcontact;
                    vd.dmanager = sdd.dmanager;
                    vd.disused = sd.disused;
                    vd.iadmin = sdd.iadmin == true ? "1" : "0";
                    vd.idepment = sdd.idepment;
                    vd.logo = sdd.logo;
                    vd.iproduction = sdd.iproduction == true ? "1" : "0";
                }
                r = js.Serialize(vd);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion

        ///---------------------------代理区域城市设置-----------------
        #region/// 设置区域代理城市
        [WebMethod(true)]
        public static string SetProxyCity(string dcode, string ccode)
        {
            string r ="";
            Sys_DepmentBll sdb = new Sys_DepmentBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sdb.SetProxyCity(dcode, ccode))
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
        #region/// 重置区域代理城市
        [WebMethod(true)]
        public static string ReSetProxyCity(string dcode)
        {
            string r = "";
            Sys_DepmentBll sdb = new Sys_DepmentBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sdb.ReSetProxyCity(dcode))
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
        #region/// 获取区域代理城市
        [WebMethod(true)]
        public static string GetProxyCity(string dcode)
        {
            string r = "";
            Sys_DepmentBll sdb = new Sys_DepmentBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = sdb.GetProxyCity(dcode);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        /// <summary>
        /// ------------------------------API设置-----------------
        #region/// 设置用友Api
        [WebMethod(true)]
        public static string SetYyApi(string dcode, string dname, string yycode )
        {
            string r = "";
            API_yyBll ayb = new API_yyBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                API_yy ay = new API_yy();
                ay.dcode = dcode;
                ay.dname = dname;
                ay.yycode = yycode;
                if (ayb.Exists(" and dcode='" + dcode + "'"))
                {
                    if (ayb.Update(ay))
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
                    if (ayb.Add(ay) > 0)
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
        #region///获取部门用友Api
        [WebMethod(true)]
        public static string QueryYyApi(string dcode)
        {
            string r = "";
            API_yyBll ayb = new API_yyBll();
            Sys_DepmentBll sdb = new Sys_DepmentBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                API_yy ay = new API_yy();
                if (ayb.Exists(" and dcode='" + dcode + "'"))
                {
                    ay = ayb.Query(" and dcode='" + dcode + "'");
                }
                else
                {
                    Sys_Depment sd = sdb.Query(" and dcode='" + dcode + "'");
                    if (sd != null)
                    {
                        ay.dname = sd.dname;
                        ay.dcode = sd.dcode;
                        ay.yycode = "";
                    }
                }
                r = js.Serialize(ay);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///获取用友Api
        [WebMethod(true)]
        public static ArrayList QueryYyApiList(string dcode)
        {
            ArrayList r = new ArrayList ();
            API_yyBll ayb = new API_yyBll();
            Sys_DepmentBll sdb = new Sys_DepmentBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<API_yy> lay = ayb.QueryList(" and dcode='" + dcode + "'");
                if (lay != null)
                {
                    foreach (API_yy ay in lay)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(ay.dcode);
                        al.Add(ay.dname);
                        al.Add(ay.yycode);
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
        #region///获取登录这部门信息
        [WebMethod(true)]
        public static string QueryLoginUser()
        {
            string r = "";
            Sys_DepmentBll sdb = new Sys_DepmentBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Depment lay = sdb.Query(" and dcode='" + iv.u.dcode + "'");
                if (lay != null)
                {
                    r = js.Serialize(lay);
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