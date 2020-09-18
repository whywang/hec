using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.Services;
using LionvBll.ProductionInfo;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.ProductionInfo;
using LionvSqlServerDal.ProductionInfo;
using System.Collections;

namespace LionVERP.UIServer.ProductionSet.ComponentManage
{
    public partial class Components : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        private static Sys_ComponentCateBll sccb = new Sys_ComponentCateBll();
        private static Sys_ComponentBll scb = new Sys_ComponentBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region///  初始组件类
        [WebMethod(true)]
        public static string InitComClass(string cccode)
        {
            string r = "";
            Sys_ComponentCate scc = new Sys_ComponentCate();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (cccode != "")
                {
                    scc = sccb.Query(" and cccode='" + cccode + "'");
                }
                else
                {
                    scc.ccname = "";
                    scc.cccode = sccb.CreateCode("").ToString().PadLeft(4, '0');
                    scc.id = 0;
                }
                r = js.Serialize(scc);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///  保存组件类
        [WebMethod(true)]
        public static string SaveComClass(string lbcode, string lbid, string lbname, string lbtype)
        {
            string r = "";
 
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_ComponentCate sr = new Sys_ComponentCate();
                sr.cccode = lbcode;
                sr.ccname = lbname;
                sr.ctype = lbtype;
                sr.cdate = DateTime.Now.ToString();
                sr.maker = iv.u.ename;
                if (lbid == "0")
                {
                    if (!sccb.Exists(" and ccname='" + lbname + "'"))
                    {
                        if (sccb.Add(sr) > 0)
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
                    if (!sccb.Exists(" and ccname='" + lbname + "' and cccode<>'" + lbcode + "'"))
                    {
                        if (sccb.Update(sr))
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
        #region///  删除组件类
        [WebMethod(true)]
        public static string DelComClass(string cccode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sccb.Delete(cccode))
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
        #region/// 组件类列表
        [WebMethod(true)]
        public static ArrayList QueryComClassList()
        {
            ArrayList r = new ArrayList();
            List<Sys_ComponentCate> lsf = new List<Sys_ComponentCate>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                lsf = sccb.QueryList("");
                if (lsf != null)
                {
                    foreach (Sys_ComponentCate s in lsf)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.cccode);
                        al.Add(s.ccname);
                        al.Add(s.ctype);
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

        #region///  初始组件
        [WebMethod(true)]
        public static string InitCom(string cccode,string ccode)
        {
            string r = "";
            Sys_Component sc = new Sys_Component();
            Sys_ComponentCate scc = new Sys_ComponentCate();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (cccode != "")
                {
                    scc = sccb.Query(" and cccode='" + cccode + "'");
                    sc.cccode = scc.cccode;
                    sc.ccname = scc.ccname;
                    sc.ccode = scb.CreateCode("").ToString().PadLeft(4, '0');
                    sc.id = 0;
                }
                else
                {
                    sc = scb.Query(" and ccode='" + ccode + "'");
                }
                r = js.Serialize(sc);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///  保存组件
        [WebMethod(true)]
        public static string SaveCom(string isshow, string zjcgp, string zjcode, string zjgg, string zjghp, string zjid, string zjlbcode, string zjlbname, string zjmname, string zjname, string zjsize, string zjxsp)
        {
            string r = "";

            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (zjmname != "")
                {
                    string[] arrm = zjmname.Split(';');
                    List<Sys_Component> lsc = new List<Sys_Component>();
                    for (int i = 0; i < arrm.Length; i++)
                    {
                        Sys_Component sr = new Sys_Component();
                        sr.cccode = zjlbcode;
                        sr.ccname = zjlbname;
                        sr.ccode = zjcode;
                        sr.cname = zjname;
                        sr.cggtype = zjgg;
                        sr.cisshow = isshow == "1" ? true : false;
                        sr.xsprice = Convert.ToDecimal(zjxsp);
                        sr.mname = arrm[i];
                        sr.ghprice = Convert.ToDecimal(zjghp);
                        sr.cgprice = Convert.ToDecimal(zjcgp);
                        sr.csize = zjsize;
                        sr.cdate = DateTime.Now.ToString();
                        sr.maker = iv.u.ename;
                        lsc.Add(sr);
                    }
                    if (scb.AddList(lsc) > 0)
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
                    Sys_Component sr = new Sys_Component();
                    sr.cccode = zjlbcode;
                    sr.ccname = zjlbname;
                    sr.ccode = zjcode;
                    sr.cname = zjname;
                    sr.cggtype = zjgg;
                    sr.cisshow = isshow == "1" ? true : false;
                    sr.xsprice = Convert.ToDecimal(zjxsp);
                    sr.mname = zjmname;
                    sr.ghprice = Convert.ToDecimal(zjghp);
                    sr.cgprice = Convert.ToDecimal(zjcgp);
                    sr.csize = zjsize;
                    sr.cdate = DateTime.Now.ToString();
                    sr.maker = iv.u.ename;
                    if (zjid == "0")
                    {
                        if (scb.Add(sr) > 0)
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
                        if (scb.Update(sr))
                        {
                            r = "S";
                        }
                        else
                        {
                            r = "F";
                        }
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
        #region///  删除组件
        [WebMethod(true)]
        public static string DelCom(string ccode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (scb.Delete(ccode))
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
        #region/// 组件类列表
        [WebMethod(true)]
        public static ArrayList QueryComList(string cccode)
        {
            ArrayList r = new ArrayList();
            List<Sys_Component> lsf = new List<Sys_Component>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                lsf = scb.QueryList(" and cccode='" + cccode + "'");
                if (lsf != null)
                {
                    foreach (Sys_Component s in lsf)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.ccode);
                        al.Add(s.cname);
                        al.Add(s.ccname);
                        al.Add(s.cisshow==true?"显示":"隐藏");
                        al.Add(s.xsprice);
                        al.Add(s.ghprice);
                        al.Add(s.cgprice);
                        al.Add(s.csize);
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

        #region/// 设置产品组件类
        [WebMethod(true)]
        public static string SetInvCom(string icode,string ccode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sccb.SetInvComCate(icode, ccode) > 0)
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
        #region/// 重置产品组件类
        [WebMethod(true)]
        public static string ReSetInvCom(string icode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sccb.ReSetInvComCate(icode) > 0)
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
        #region/// 获取产品组件类
        [WebMethod(true)]
        public static string GetInvCom(string icode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                 r=sccb.GetInvComCate(icode) ;
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region/// 获取产品组件列表
        [WebMethod(true)]
        public static ArrayList QueryInvComList(string icode,string mname)
        {
            ArrayList r = new ArrayList ();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
              string  zjccode = sccb.GetInvComCate(icode);
              List<Sys_Component> lsc = scb.QueryList(" and cccode='" + zjccode + "' and mname='" + mname + "' and cisshow='true'");
              if (lsc != null)
              {
                  foreach (Sys_Component s in lsc)
                  {
                      ArrayList al = new ArrayList();
                      al.Add(s.cname);
                      al.Add(s.ccode);
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
    }
}