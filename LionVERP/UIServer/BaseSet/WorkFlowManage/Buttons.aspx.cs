using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.SysInfo;
using System.Collections;

namespace LionVERP.UIServer.BaseSet.WorkFlowManage
{
    public partial class Buttons : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region///初始化或状态流程Button
        [WebMethod(true)]
        public static string InitWButton(string wcode,string bcode)
        {
            string r = "";
            Sys_WorkEventBll sweb = new Sys_WorkEventBll();
            Sys_WorkEvent swe = new Sys_WorkEvent();
            Sys_ButtonBll sbb = new Sys_ButtonBll();
            Sys_Button sb = new Sys_Button();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (bcode == "" || bcode == null)
                {
                    swe=sweb.Query(" and wcode='"+wcode+"'");
                    sb.id = 0;
                    sb.bname= "";
                    sb.bcode = sbb.CreateCode().ToString().PadLeft(4, '0');
                    sb.wname = swe.wname == null ? "" : swe.wname;
                    sb.wcode = swe.wcode == null ? "" : swe.wcode;
                }
                else
                {
                    sb = sbb.Query(" and bcode='" + bcode + "'");
                }
                r = js.Serialize(sb);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///保存流程节点Button
        [WebMethod(true)]
        public static string SaveButton(
            string babc, string battr, string bcheck, string bcode, string bfunction,string bico, string bid, string bisstate,
            string bname, string brcode,string bremark, string bshow, string bsql, string bstate, string bstyle, string btip,
            string btsattr, string btype,string burl, string bwcode, string bwname, string emcode, string emname)
        {
            string r = "";
            Sys_ButtonBll sbb = new Sys_ButtonBll();
            Sys_Button sb = new Sys_Button();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.babc = babc;
                sb.battr = battr;
                sb.bcheck = bcheck == "0" ? false : true;
                sb.bcode = bcode;
                sb.bfn = bfunction;
                sb.biszt = bisstate == "0" ? false : true;
                sb.bname = bname;
                sb.brcode = brcode;
                sb.bshow = bshow == "0" ? false : true;
                sb.bsql = bsql;
                sb.bstate = Convert.ToInt32(bstate);
                sb.bstyle = bstyle;
                sb.btype = btype;
                sb.bspeattr = Convert.ToInt32(btsattr);
                sb.burl = burl;
                sb.emname = emname;
                sb.emcode = emcode;
                sb.remcode = "";
                sb.wname = bwname;
                sb.wcode = bwcode;
                sb.rwcode = "";
                sb.brname = "";
                sb.bsort = 0;
                sb.bproname = "";
                sb.bprocedure = "";
                sb.btip = Convert.ToInt32(btip);
                sb.bremark = bremark;
                sb.bico = bico;
                if (bname == "返回")
                {
                    sb.bsort = 9999;
                }
                if (bname == "导出" || bname == "打印")
                {
                    sb.bsort = 9998;
                }
                if (bid == "0")
                {
                    if (sbb.Add(sb) > 0)
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
                    if (sbb.Update(sb))
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
        #region///获取事件Button列表
        [WebMethod(true)]
        public static ArrayList QueryListWButton(string wcode)
        {
            ArrayList r = new ArrayList();
            Sys_ButtonBll sdb = new Sys_ButtonBll();
            List<Sys_Button> lsb = new List<Sys_Button>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                lsb = sdb.QueryList(" and wcode='" + wcode + "'");
                if (lsb != null)
                {
                    foreach (Sys_Button s in lsb)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.bcode);
                        al.Add(s.wname);
                        al.Add(s.bname);
                        al.Add(s.battr);
                        al.Add(s.bshow);
                        al.Add(s.bstyle);
                        al.Add(s.bremark);
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
        #region///删除按钮
        [WebMethod(true)]
        public static string DelButton(string bcode)
        {
            string r = "";
            Sys_ButtonBll sdb = new Sys_ButtonBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sdb.Delete(bcode))
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

        #region///初始化或状态特殊按钮
        [WebMethod(true)]
        public static string InitTButton(string wmcode, string bcode)
        {
            string r = "";
            Sys_EventMenuBll sweb = new Sys_EventMenuBll();
            Sys_EventMenu swe = new Sys_EventMenu();
            Sys_ButtonBll sbb = new Sys_ButtonBll();
            Sys_Button sb = new Sys_Button();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (bcode == "" || bcode == null)
                {
                    swe = sweb.Query(" and emcode='" + wmcode + "'");
                    sb.id = 0;
                    sb.bname = "";
                    sb.bcode = sbb.CreateCode().ToString().PadLeft(4, '0');
                    sb.emname = swe.emname == null ? "" : swe.emname;
                    sb.emcode = swe.emcode == null ? "" : swe.emcode;
                }
                else
                {
                    sb = sbb.Query(" and bcode='" + bcode + "'");
                }
                r = js.Serialize(sb);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///保存事件特殊节点Button
        [WebMethod(true)]
        public static string SaveTButton(
            string tbabc,string tbattr,string tbcode,string tbfunction, string tbid ,string tbimg,
            string tbname,string tbshow, string tbsql,string tbstyle,string tbszt,
            string tburl, string temcode,string temname,  string trcode, string ttip)
        {
            string r = "";
            Sys_ButtonBll sbb = new Sys_ButtonBll();
            Sys_Button sb = new Sys_Button();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                tbattr = tbattr == "" ? "0" : tbattr;
                sb.babc = tbabc;
                sb.battr = "";
                sb.bcheck =false;
                sb.bcode = tbcode;
                sb.bfn = tbfunction;
                sb.biszt = tbszt == "0" ? false : true;
                sb.bname = tbname;
                sb.brcode = trcode;
                sb.bshow = tbshow == "0" ? false : true; ;
                sb.bsql = tbsql;
                sb.bstate =0;
                sb.bstyle = tbstyle;
                sb.btype = "";
                sb.bspeattr = Convert.ToInt32(tbattr);
                sb.burl = tburl;
                sb.emname = temname;
                sb.emcode = temcode;
                sb.remcode = "";
                sb.wname = "";
                sb.wcode = "";
                sb.rwcode = "";
                sb.brname ="";
                sb.bsort = 0;
                sb.bproname = "";
                sb.bprocedure = "";
                sb.btip = Convert.ToInt32(ttip);
                sb.bico = tbimg;
                if (tbname == "返回")
                {
                    sb.bsort = 9999;
                }
                if (tbname == "导出" || tbname == "打印")
                {
                    sb.bsort = 9998;
                }
                if (tbid == "0")
                {
                    if (sbb.Add(sb) > 0)
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
                    if (sbb.Update(sb))
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
        #region///特殊按钮列表
        [WebMethod(true)]
        public static ArrayList QueryListTButton(string emcode)
        {
            ArrayList r = new ArrayList();
            Sys_ButtonBll sdb = new Sys_ButtonBll();
            List<Sys_Button> lsb = new List<Sys_Button>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                lsb = sdb.QueryList(" and emcode='" + emcode + "'");
                if (lsb != null)
                {
                    foreach (Sys_Button s in lsb)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.bcode);
                        al.Add(s.emname);
                        al.Add(s.bname);
                        al.Add(s.bspeattr);
                        al.Add(s.bstyle);
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

        
        #region///后台事件
        [WebMethod(true)]
        public static string InitBackEvent(string bcode, string ecode)
        {
            string r = "";
            Sys_BackEventBll sbeb = new Sys_BackEventBll();
            Sys_BackEvent sbe = new Sys_BackEvent();
            Sys_ButtonBll sbb = new Sys_ButtonBll();
            Sys_Button sb = new Sys_Button();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (ecode == "" || ecode == null)
                {
                    sb = sbb.Query(" and bcode='" + bcode + "'");
                    sbe.id = 0;
                    sbe.ename = "";
                    sbe.ecode = sbeb.CreateCode().ToString().PadLeft(4, '0');
                    sbe.bname = sb.bname == null ? "" : sb.bname;
                    sbe.bcode = sb.bcode == null ? "" : sb.bcode;
                }
                else
                {
                    sbe = sbeb.Query(" and ecode='" + ecode + "'");
                }
                r = js.Serialize(sbe);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
 
        #region///保存后台事件
        [WebMethod(true)]
        public static string SaveBackEvent(string hbcode, string hbname, string hbstate, string hcode, string hid, string hname, string hsql, string hsort, string hsoure)
        {
            string r = "";
            Sys_BackEventBll sbb = new Sys_BackEventBll();
            Sys_BackEvent sb = new Sys_BackEvent();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.bcode = hcode;
                sb.bname = hname;
                sb.ename = hbname;
                sb.ecode = hbcode;
                sb.esort = hsort;
                sb.source = hsoure;
                sb.ebody = hsql.Replace("\n", " ");
                sb.estate = hbstate;
                if (hid == "0")
                {
                    if (sbb.Add(sb) > 0)
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
                    if (sbb.Update(sb))
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
        #region///保存后台特殊Button
        [WebMethod(true)]
        public static string SaveTBackEvent(string htbcode,string htbname,string htcode, string thid,string htname,  
            string htsort,  string htsource, string htsql, string htstate)
        {
            string r = "";
            Sys_BackEventBll sbb = new Sys_BackEventBll();
            Sys_BackEvent sb = new Sys_BackEvent();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.bcode = htbcode;
                sb.bname = htbname;
                sb.ename = htname;
                sb.ecode = htcode;
                sb.esort = htsort;
                sb.source = htsource;
                sb.ebody = htsql;
                sb.estate = htstate;
                if (thid == "0")
                {
                    if (sbb.Add(sb) > 0)
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
                    if (sbb.Update(sb))
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
        #region///  按钮列表
        [WebMethod(true)]
        public static ArrayList QueryListBackEvent(string bcode)
        {
            ArrayList r = new ArrayList();
            Sys_BackEventBll sdb = new Sys_BackEventBll();
            List<Sys_BackEvent> lsb = new List<Sys_BackEvent>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                lsb = sdb.QueryList(" and bcode='" + bcode + "'");
                if (lsb != null)
                {
                    foreach (Sys_BackEvent s in lsb)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.ecode);
                        al.Add(s.bname);
                        al.Add(s.ename);
                        al.Add(s.esort);
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
        #region///  删除按钮
        [WebMethod(true)]
        public static string DelBackEvent(string ecode)
        {
            string r = "";
            Sys_BackEventBll sdb = new Sys_BackEventBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sdb.Delete( ecode))
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

        #region//列表Button
        #region//初始化列表Button
        [WebMethod(true)]
        public static string InitLButton(string emcode, string bcode)
        {
            string r = "";
            Sys_EventMenuBll semb = new Sys_EventMenuBll();
            Sys_EventMenu sem = new Sys_EventMenu();
            Sys_ButtonBll sbb = new Sys_ButtonBll();
            Sys_Button sb = new Sys_Button();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (bcode == "" || bcode == null)
                {
                    sem = semb.Query(" and emcode='" + emcode + "'");
                    sb.id = 0;
                    sb.bname = "";
                    sb.bcode = sbb.CreateCode().ToString().PadLeft(4, '0');
                    sb.emname = sem.emname == null ? "" : sem.emname;
                    sb.emcode = sem.emcode == null ? "" : sem.emcode;
                    sb.bshow = true;
                }
                else
                {
                    sb = sbb.Query(" and bcode='" + bcode + "'");
                }
                r = js.Serialize(sb);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///保存列表单Button
        [WebMethod(true)]
        public static string SaveLButton(string lbico,string lmbabc, string lmbcode, string lmbfunction, string lmbname, string lmbsql,string lmbshow,
            string lmbstyle,string lmbtab, string lmburl, string lmename, string lmecode, string lmbid)
        {
            string r = "";
            Sys_ButtonBll sbb = new Sys_ButtonBll();
            Sys_Button sb = new Sys_Button();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.babc = lmbabc;
                sb.battr = "";
                sb.bcheck = false;
                sb.bcode = lmbcode;
                sb.bfn = lmbfunction;
                sb.biszt = false;
                sb.bname = lmbname;
                sb.brcode = "";
                sb.bico = lbico;
                if (lmbshow == "1")
                {
                    sb.bshow = true;
                }
                else
                {
                    sb.bshow = false;
                }
                sb.bsql = lmbsql;
                sb.bstate = 0;
                sb.bstyle = lmbstyle;
                sb.btype = "L";
                sb.bspeattr = 0;//Convert.ToInt32(tbattr);
                sb.burl = lmburl;
                sb.emname = lmename;
                sb.emcode = lmecode;
                sb.wname = "";
                sb.wcode = "";
                sb.brname = "";
                sb.bsort = 0;
                sb.bproname = "";
                sb.bprocedure = "";
                sb.btip = 0;
                sb.btab = lmbtab;
                if (lmbname == "返回")
                {
                    sb.bsort = 9999;
                }
                if (lmbname == "导出" || lmbname == "打印")
                {
                    sb.bsort = 9998;
                }
                if (lmbid == "0")
                {
                    if (sbb.Add(sb) > 0)
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
                    if (sbb.Update(sb))
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
        #region///获取列表单Button列表
        [WebMethod(true)]
        public static ArrayList QueryListLButton(string emcode,string bt)
        {
            ArrayList r = new ArrayList();
            Sys_ButtonBll sdb = new Sys_ButtonBll();
            List<Sys_Button> lsb = new List<Sys_Button>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                lsb = sdb.QueryList(" and emcode='" + emcode + "' and btype='"+bt+"'");
                if (lsb != null)
                {
                    foreach (Sys_Button s in lsb)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.bcode);
                        al.Add(s.emname);
                        al.Add(s.bname);
                        al.Add(s.bspeattr);
                        al.Add(s.bstyle);
                        al.Add(s.bshow==true?"是":"否");
                        al.Add(s.bremark);
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

        #region//列表项Button
      
        #region///保存列表项事件
        [WebMethod(true)]
        public static string SaveLXButton(string ibabc,string ibcode,string ibform, string ibfunction,string ibico, 
            string ibid,string ibjdcode,string ibname,  string ibsql, string ibstate, string ibstyle,
            string iburl, string imcode, string imname)
        {
            string r = "";
            Sys_ButtonBll sbb = new Sys_ButtonBll();
            Sys_Button sb = new Sys_Button();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.babc = ibabc;
                sb.bico = ibico;
                sb.battr = "";
                sb.bcheck = false;
                sb.bcode = ibcode;
                sb.bfn = ibfunction;
                sb.biszt = false;
                sb.bname = ibname;
                sb.brcode = "";
                sb.rwcode=ibjdcode;
                sb.remcode = ibform;
                sb.bshow = true;
                sb.bsql = ibsql;
                sb.bstate = Convert.ToInt32(ibstate);
                sb.bstyle = ibstyle;
                sb.btype = "LX";
                sb.bspeattr = 0;//Convert.ToInt32(tbattr);
                sb.burl = iburl;
                sb.emname = imname;
                sb.emcode = imcode;
                sb.wname = "";
                sb.wcode = "";// ibjdcode;
                sb.brname = "";
                sb.bsort = 0;
                sb.bproname = "";
                sb.bprocedure = "";
                sb.btip = 0;
                if (sb.bname == "返回")
                {
                    sb.bsort = 9999;
                }
                if (sb.bname == "导出" || sb.bname == "打印")
                {
                    sb.bsort = 9998;
                }
                if (ibid == "0")
                {
                    if (sbb.Add(sb) > 0)
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
                    if (sbb.Update(sb))
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
        #endregion

        #region//页面按钮

        #region///保存页面节点
        [WebMethod(true)]
        public static string SavePButton(string pbabc, string pbcode, string pbform, string pbfunction,string pbico,
            string pbid, string pbjdcode, string pbname,string pbproname, string pbrcode,string pbremark,string pbshow,string pbsql, string pbstate, string pbstyle,
            string pburl, string pmcode, string pmname)
        {
            string r = "";
            Sys_ButtonBll sbb = new Sys_ButtonBll();
            Sys_Button sb = new Sys_Button();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.babc = pbabc;
                sb.bico = pbico;
                sb.battr = "";
                sb.bcheck = false;
                sb.bcode = pbcode;
                sb.bfn = pbfunction;
                sb.biszt = false;
                sb.bname = pbname;
                sb.brcode = pbrcode;
                sb.bshow =pbshow=="1"?true:false;
                sb.bsql = pbsql;
                sb.bstate = Convert.ToInt32(pbstate);
                sb.bstyle = pbstyle;
                sb.btype = "N";
                sb.bspeattr = 0;//Convert.ToInt32(tbattr);
                sb.burl = pburl;
                sb.emname = pmname;
                sb.emcode = pmcode;
                sb.remcode = pbform;
                sb.wname = "";
                sb.wcode = "";
                sb.rwcode = pbjdcode;
                sb.brname = "";
                sb.bsort = 0;
                sb.bproname = pbproname;
                sb.bprocedure = "";
                sb.btip = 0;
                sb.bremark = pbremark;
                if (sb.bname == "返回")
                {
                    sb.bsort = 9999;
                }
                if (sb.bname == "导出" || sb.bname == "打印")
                {
                    sb.bsort = 9998;
                }
                if (pbid == "0")
                {
                    if (sbb.Add(sb) > 0)
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
                    if (sbb.Update(sb))
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
        #endregion

        #region//页面详情事件

        #region///保存页面详情事件
        [WebMethod(true)]
        public static string SaveDButton(string dbabc, string dbcode, string dbform, string dbfunction,
            string dbid, string dbjdcode, string dbname, string dbrcode, string dbsql, string dbstate, string dbstyle,
            string dburl,string dico, string dmcode, string dmname)
        { 
            string r = "";
            Sys_ButtonBll sbb = new Sys_ButtonBll();
            Sys_Button sb = new Sys_Button();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.babc = dbabc;
                sb.bico = dico;
                sb.battr = "";
                sb.bcheck = false;
                sb.bcode = dbcode;
                sb.bfn = dbfunction;
                sb.biszt = false;
                sb.bname = dbname;
                sb.brcode = dbrcode;
                sb.bshow = true;
                sb.bsql = dbsql;
                sb.bstate = Convert.ToInt32(dbstate);
                sb.bstyle = dbstyle;
                sb.btype = "D";
                sb.bspeattr = 0;//Convert.ToInt32(tbattr);
                sb.burl = dburl;
                sb.emname = dmname;
                sb.emcode = dmcode;
                sb.remcode = dbform;
                sb.wname = "";
                sb.wcode = "";
                sb.rwcode = dbjdcode;
                sb.brname = "";
                sb.bsort = 0;
                sb.bproname = "";
                sb.bprocedure = "";
                sb.btip = 0;
                if (sb.bname == "返回")
                {
                    sb.bsort = 9999;
                }
                if (sb.bname == "导出" || sb.bname == "打印")
                {
                    sb.bsort = 9998;
                }
                if (dbid == "0")
                {
                    if (sbb.Add(sb) > 0)
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
                    if (sbb.Update(sb))
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
        #endregion

        #region//设置角色列表单按钮
        [WebMethod(true)]
        public static string SetRolePageListBtn(string rcode,string emcode,string bcode)
        {
            string r = "";
            Sys_ButtonBll sdb = new Sys_ButtonBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (bcode != "")
                {
                    string[] bcodearr = bcode.Split(';');
                    if (sdb.SetRoleEmenuBtn(rcode, emcode, bcodearr,"L") > 0)
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
                    if (sdb.SetRoleEmenuBtn(rcode, emcode, null,"L") > 0)
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
                r=iv.badstr;
            }
            return r;
        }
        #endregion
        #region//获取角色列表单按钮
        [WebMethod(true)]
        public static string GetRolePageBtn(string rcode, string emcode)
        {
            string r = "";
            Sys_ButtonBll sdb = new Sys_ButtonBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = sdb.GetRolePageBtn(rcode, emcode);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region//设置角色列表Item单按钮
        [WebMethod(true)]
        public static string SetRolePageListItemBtn(string rcode, string emcode, string bcode)
        {
            string r = "";
            Sys_ButtonBll sdb = new Sys_ButtonBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (bcode != "")
                {
                    string[] bcodearr = bcode.Split(';');
                    if (sdb.SetRoleEmenuBtn(rcode, emcode, bcodearr,"LX") > 0)
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
                    if (sdb.SetRoleEmenuBtn(rcode, emcode, null,"LX") > 0)
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
        #region//获取角色列Item表单按钮
        [WebMethod(true)]
        public static string GetRolePageItemBtn(string rcode, string emcode)
        {
            string r = "";
            Sys_ButtonBll sdb = new Sys_ButtonBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = sdb.GetRolePageItemBtn(rcode, emcode);
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