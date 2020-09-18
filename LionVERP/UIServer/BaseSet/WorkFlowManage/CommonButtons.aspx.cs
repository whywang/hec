using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Collections;
using LionvCommonBll;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.SysInfo;

namespace LionVERP.UIServer.BaseSet.WorkFlowManage
{
    public partial class CommonButtons : System.Web.UI.Page
    {
        private static Sys_BtnImgBll sbib = new Sys_BtnImgBll();
        private static Sys_DomainBll sdb = new Sys_DomainBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region//获取列表页Btn
        [WebMethod(true)]
        public static ArrayList ListPageBtn(string emcode, string btype)
        {
            ArrayList r = new ArrayList();
            BusiEventButtonBll bebb = new BusiEventButtonBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_Button> lsb = bebb.QueryBtnList(emcode,iv.u.rcode, btype);
                if (lsb != null)
                {
                    Sys_Domain ym = sdb.Query(" and dtype='p'");
                    foreach (Sys_Button s in lsb)
                    {
                        ArrayList al = new ArrayList();
                        string burl = sbib.QueryBurl(s.bico);
                        al.Add(s.babc);
                        al.Add(s.bname);
                        al.Add(s.bfn.Replace(",", "_"));
                        al.Add(s.burl);
                        al.Add(s.bstyle);
                        al.Add(s.btip);
                        s.bico = burl != "" ? ym.url + burl : "";
                        al.Add(s.bico);
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
        #region//Ex获取列表页Btn
        [WebMethod(true)]
        public static ArrayList ListPageBtnEx(string emcode, string btype,string tab)
        {
            ArrayList r = new ArrayList();
            BusiEventButtonBll bebb = new BusiEventButtonBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                Sys_Domain ym = sdb.Query(" and dtype='p'");
                List<Sys_Button> lsb = bebb.QueryBtnListEx(emcode, iv.u.rcode, btype,tab);
                if (lsb != null)
                {
                    foreach (Sys_Button s in lsb)
                    {
                        ArrayList al = new ArrayList();
                        string burl = sbib.QueryBurl(s.bico);
                        al.Add(s.babc);
                        al.Add(s.bname);
                        al.Add(s.bfn.Replace(",", "_"));
                        al.Add(s.burl);
                        al.Add(s.bstyle);
                        al.Add(s.btip);
                        s.bico = burl != "" ? ym.url + burl : "";
                        al.Add(s.bico);
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
        #region//获取WorkFlowBtn
        [WebMethod(true)]
        public static ArrayList ListWorkFlowBtn(string emcode, string sid)
        {
            ArrayList r = new ArrayList();
            BusiEventButtonBll bebb = new BusiEventButtonBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_Button> lsb = bebb.QueryWorkFlowBtnList(sid,emcode, iv.u.rcode);
                if (lsb != null)
                {
                    Sys_Domain ym = sdb.Query(" and dtype='p'");
                    foreach (Sys_Button s in lsb)
                    {
                        ArrayList al = new ArrayList();
                        string burl = sbib.QueryBurl(s.bico);
                        al.Add(s.babc);
                        al.Add(s.bname);
                        al.Add(s.bfn.Replace(",","_"));
                        al.Add(s.burl);
                        al.Add(s.bstyle);
                        al.Add(s.bcode);
                        al.Add(s.btip);
                        s.bico = burl != "" ? ym.url + burl : "";
                        al.Add(s.bico);
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
        #region//获取增加页SingleBtn
        [WebMethod(true)]
        public static ArrayList SinglePageBtn(string emcode, string sid)
        {
            ArrayList r = new ArrayList();
            BusiEventButtonBll bebb = new BusiEventButtonBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_Button> lsb = bebb.SinglePageBtnList(sid, emcode, iv.u.rcode);
                if (lsb != null)
                {
                    Sys_Domain ym = sdb.Query(" and dtype='p'");
                    foreach (Sys_Button s in lsb)
                    {
                        ArrayList al = new ArrayList();
                        string burl = sbib.QueryBurl(s.bico);
                        al.Add(s.babc);
                        al.Add(s.bname);
                        al.Add(s.bfn.Replace(",", "_"));
                        al.Add(s.burl);
                        al.Add(s.bstyle);
                        al.Add(s.bcode);
                        al.Add(s.btip);
                        s.bico = burl != "" ? ym.url + burl : "";
                        al.Add(s.bico);
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