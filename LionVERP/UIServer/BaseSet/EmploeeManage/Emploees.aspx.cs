using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvBll.SysInfo;
using LionvModel.SysInfo;
using ViewModel.BaseSet.Emploee;
using System.Web.Script.Serialization;
using System.Collections;
using LionvAopModel;
using LionvCommon;
using System.Data;
using System.Text;

namespace LionVERP.UIServer.BaseSet.EmploeeManage
{
    public partial class Emploees : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region//保存员工
        [WebMethod(true)]
        public static string SaveEmploee( string account,string depcode, string depname, string duty,
        string eaddress,string eage,string eemail,string egradute,string eid,string elogin, string ename,string eno,
        string epwd,string esex,  string esfz,string estate, string etelephone, string eworkdate, string role)
        {
            string r = "";
            Sys_Employee se = new Sys_Employee();
            Sys_User su = new Sys_User();
            Sys_EmployeeDpt sed = new Sys_EmployeeDpt();
            Sys_EmployeeBll seb = new Sys_EmployeeBll();
            Sys_UserBll sub = new Sys_UserBll();
            Sys_Employee cse = new Sys_Employee();
            Sys_DepmentBll sdb = new Sys_DepmentBll();
            Sys_EmployeeDptBll sedb = new Sys_EmployeeDptBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Depment sd=sdb.Query(" and dcode='" + depcode.Substring(0, 8) + "'");
                se.dname = depname;
                se.dcode = depcode;
                se.eno = eno;
                se.ename = ename;
                se.estate = estate=="1"?true:false;
                se.dtcode = "";
                se.elogin = elogin == "1" ? true : false;
                se.ecdate = DateTime.Now.ToString();
                se.emaker = iv.u.ename;
                se.rcode = role;

                sed.eaddress = eaddress;
                sed.eage = Convert.ToInt32(eage);
                sed.eeducation = egradute;
                sed.eemail = eemail;
                sed.eheadimage = "";
                sed.eidentity = esfz;
                sed.enativeplace = "";
                sed.eno = eno;
                sed.esex = esex == "1" ? true : false ;
                sed.etelephone = etelephone;
                sed.eworkdate = eworkdate;

                su.eno = eno;
                su.upass = DES.EncryptDES(epwd);
                if (sd.dabc != "")
                {
                    su.uname =sd.dabc+"_"+account;
                }
                else
                {
                    su.uname = account;
                }
                su.ulogin = elogin=="1"?true:false;
                su.uip = "";
                su.ulogintime = "";
                if (eid == "0")
                {
                    if (!seb.Exists(" and eno='" + eno + "'"))
                    {
                        if (!sub.Exists(" and uname='" + su.uname + "'"))
                        {
                            if (seb.AddList(se, sed, su) > 0)
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
                            r = "TA";
                        }
                    }
                    else
                    {
                        r = "T";
                    }
                }
                else
                {
                    if (!seb.Exists(" and eno='" + eno + "' and id<>" + eid + ""))
                    {
                        if (!sub.Exists(" and uname='" + su.uname + "' and eno<>'" + eno + "'"))
                        {
                            cse = seb.Query(" and id=" + eid + "");
                            if (cse != null)
                            {
                                if (seb.UpdateList(cse.eno, se, sed, su) > 0)
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
                            r = "TA";
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
        #region//获取员工
        [WebMethod(true)]
        public static string QueryEmploee(string eno )
        {
            string r = "";
            VEmploee ve = new VEmploee();
            Sys_Employee se = new Sys_Employee();
            Sys_User su = new Sys_User();
            Sys_EmployeeDpt sed = new Sys_EmployeeDpt();
            Sys_EmployeeBll seb = new Sys_EmployeeBll();
            Sys_UserBll sub = new Sys_UserBll();
            Sys_EmployeeDptBll sedb = new Sys_EmployeeDptBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (eno == "")
                {
                    ve.eno = "E"+seb.GetEno().ToString().PadLeft(8, '0');
                    ve.eaddress = "";
                    ve.eage = "0";
                    ve.eeducation = "";
                    ve.eemail = "";
                    ve.eheadimage = "";
                    ve.eidentity = "";
                    ve.enativeplace = "";
                    ve.esex = "0";
                    ve.etelephone = "";
                    ve.eworkdate = "";
                    ve.estate = "1";
                    ve.elogin = "1";
                    ve.id = 0;
                }
                else
                {
                    se = seb.Query(" and eno='" + eno + "'");
                    sed = sedb.Query(" and eno='" + eno + "'");
                    su = sub.Query(" and eno='" + eno + "'");
                    ve.dname = se.dname;
                    ve.dcode = se.dcode;
                    ve.eno = se.eno;
                    ve.ename = se.ename;
                    ve.estate = se.estate == true ? "1" : "0";
                    ve.dtcode = "";
                    ve.elogin = se.elogin == true ? "1" : "0";
                    ve.rcode = se.rcode;
                    if (sed != null)
                    {
                        ve.eaddress = sed.eaddress;
                        ve.eage = sed.eage.ToString();
                        ve.eeducation = sed.eeducation;
                        ve.eemail = sed.eemail;
                        ve.eheadimage = sed.eheadimage;
                        ve.eidentity = sed.eidentity;
                        ve.enativeplace = sed.enativeplace;
                        ve.esex = sed.esex == true ? "1" : "0";
                        ve.etelephone = sed.etelephone;
                        ve.eworkdate = sed.eworkdate;
                    }
                    else
                    {
                        ve.eaddress = "";
                        ve.eage = "";
                        ve.eeducation = "";
                        ve.eemail = "";
                        ve.eheadimage = "";
                        ve.eidentity = "";
                        ve.enativeplace = "";
                        ve.esex = "0";
                        ve.etelephone = "";
                        ve.eworkdate = "";
                    }
                    if (su != null)
                    {
                        ve.upass = DES.DecryptDES(su.upass);
                        ve.uname = su.uname;
                    }

                    ve.id = se.id;
                }

                r = js.Serialize(ve);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region//获取部门人员
        [WebMethod(true)]
        public static ArrayList QueryList(string dcode)
        {
            ArrayList r = new ArrayList();
            Sys_EmployeeBll seb = new Sys_EmployeeBll();
            Sys_DepmentBll sdb = new Sys_DepmentBll();
            Sys_RoleBll srb = new Sys_RoleBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_Employee> ls = seb.QueryList(" and dcode='" + dcode + "' and estate='true'");
                if (ls != null)
                {
                    foreach (Sys_Employee s in ls)
                    {
                        Sys_Depment dep = sdb.Query(" and dcode='" + s.dcode + "'");
                        Sys_Role sr = srb.Query(" and rcode='" + s.rcode + "'");
                        ArrayList al = new ArrayList();
                        al.Add(s.eno);
                        al.Add(s.ename);
                        al.Add(dep==null?"":dep.dname);
                        al.Add(sr == null ? "" :sr.rname);
                        al.Add(s.estate == true ? "是" : "否");
                        al.Add(s.elogin==true?"是":"否");
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
        #region//获取部门和角色人员
        [WebMethod(true)]
        public static ArrayList QueryListEx(string dcode,string rcode)
        {
            ArrayList r = new ArrayList();
            Sys_EmployeeBll seb = new Sys_EmployeeBll();
            Sys_DepmentBll sdb = new Sys_DepmentBll();
            Sys_RoleBll srb = new Sys_RoleBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string where = "";
                r.Add(iv.badstr);
                if (dcode != "")
                {
                    where = where+" and dcode='" + dcode + "'";
                }
                if (rcode != "")
                {
                    where = where + " and rcode='" + rcode + "'";
                }
                List<Sys_Employee> ls = seb.QueryList(where+" and estate='true'");
                if (ls != null)
                {
                    foreach (Sys_Employee s in ls)
                    {
                        Sys_Depment dep = sdb.Query(" and dcode='" + s.dcode + "'");
                        Sys_Role sr = srb.Query(" and rcode='" + s.rcode + "'");
                        ArrayList al = new ArrayList();
                        al.Add(s.eno);
                        al.Add(s.ename);
                        al.Add(dep == null ? "" : dep.dname);
                        al.Add(sr == null ? "" : sr.rname);
                        al.Add(s.estate == true ? "是" : "否");
                        al.Add(s.elogin == true ? "是" : "否");
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
        #region//模糊获取部门和角色人员
        [WebMethod(true)]
        public static ArrayList QueryListEx2(string dcode, string rcode)
        {
            ArrayList r = new ArrayList();
            Sys_EmployeeBll seb = new Sys_EmployeeBll();
            Sys_DepmentBll sdb = new Sys_DepmentBll();
            Sys_RoleBll srb = new Sys_RoleBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string where = "";
                r.Add(iv.badstr);
                if (dcode != "")
                {
                    where = where + " and dcode like'" + dcode + "%'";
                }
                if (rcode != "")
                {
                    where = where + " and rcode='" + rcode + "'";
                }
                List<Sys_Employee> ls = seb.QueryList(where + " and estate='true'");
                if (ls != null)
                {
                    foreach (Sys_Employee s in ls)
                    {
                        Sys_Depment dep = sdb.Query(" and dcode='" + s.dcode + "'");
                        Sys_Role sr = srb.Query(" and rcode='" + s.rcode + "'");
                        ArrayList al = new ArrayList();
                        al.Add(s.eno);
                        al.Add(s.ename);
                        al.Add(dep == null ? "" : dep.dname);
                        al.Add(sr == null ? "" : sr.rname);
                        al.Add(s.estate == true ? "是" : "否");
                        al.Add(s.elogin == true ? "是" : "否");
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
        #region
        [WebMethod(true)]
        public static string QueryEmploeeTel(string ename)
        {
            string r = "";
            Sys_EmployeeDpt sed = new Sys_EmployeeDpt();
            Sys_EmployeeBll seb = new Sys_EmployeeBll();
            Sys_EmployeeDptBll sedb = new Sys_EmployeeDptBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sed = sedb.Query(" and eno=(select eno from Sys_Employee where ename='"+ename+"') ");
                if (sed != null)
                {
                    r = sed.etelephone;
                }
                else
                {
                    r = "";
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region//获取全部人员信息
        [WebMethod(true)]
        public static ArrayList AllQueryEmploee()
        {
            ArrayList r = new ArrayList ();
            Sys_EmployeeBll seb = new Sys_EmployeeBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                DataTable dt = seb.QueryEmploy("");
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(dr["ename"].ToString());
                        al.Add(dr["dname"].ToString());
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
        #region//获取设计师信息
        [WebMethod(true)]
        public static ArrayList QueryDesignerList(string rcode)
        {
            ArrayList r = new ArrayList() ;
            Sys_EmployeeBll seb = new Sys_EmployeeBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                StringBuilder where=new StringBuilder ();
                string [] rarr=rcode.Split(',');
                if(rarr.Length>0)
                {
                     int k=1;
                     foreach (string s in rarr)
                     {
                         if (k == 1)
                         {
                             where.AppendFormat(" rcode='{0}'", s);
                         }
                         else
                         {
                             where.AppendFormat(" or rcode='{0}'", s);
                         }
                         k++;
                     }
                }
                List<Sys_Employee> lse = seb.QueryList(" and (" + where.ToString() + ")");
                if (lse != null)
                {
                    foreach (Sys_Employee se in lse)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(se.eno);
                        al.Add(se.ename);
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
        #region//获取拆单员信息
        [WebMethod(true)]
        public static ArrayList QueryCdyList(string rcode)
        {
            ArrayList r = new ArrayList();
            Sys_EmployeeBll seb = new Sys_EmployeeBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                StringBuilder where = new StringBuilder();
                string[] rarr = rcode.Split(',');
                if (rarr.Length > 0)
                {
                    int k = 1;
                    foreach (string s in rarr)
                    {
                        if (k == 1)
                        {
                            where.AppendFormat(" rcode='{0}'", s);
                        }
                        else
                        {
                            where.AppendFormat(" or rcode='{0}'", s);
                        }
                        k++;
                    }
                }
                List<Sys_Employee> lse = seb.QueryList(" and dcode='"+iv.u.dcode+"' and (" + where.ToString() + ")");
                if (lse != null)
                {
                    foreach (Sys_Employee se in lse)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(se.eno);
                        al.Add(se.ename);
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