using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.Services;
using LionvBll.NewsInfo;
using LionvModel.NewsInfo;
using LionvAopModel;
using LionvBll.SysInfo;
using System.Collections;
using LionvCommonBll;
using System.Text;
using LionvModel.SysInfo;

namespace LionVERP.UIServer.NewsMessage
{
    public partial class News : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        private static Sys_DepmentBll sdb = new Sys_DepmentBll();
        private static NB_DepNewsBll ndnb = new NB_DepNewsBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region///////////新闻管理
        #region///初始化新闻
        [WebMethod(true)]
        public static string InitNews(string id)
        {
            string r = "";
            NB_NewsBll nnb = new NB_NewsBll();
            NB_News n = new NB_News();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                NB_News sn = nnb.Query(" and id=" + id + "");
                if (sn != null)
                {
                    r = js.Serialize(sn);
                }
                else
                {
                    n.id = 0;
                    n.nstate = true;
                    r = js.Serialize(n);
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///保存产品类
        [WebMethod(true)]
        public static string SaveNews(string ndate, string nfbr, string nid, string nshow, string nreader, string ntext, string ntype, string sdep, string tname)
        {
            string r = "";
            NB_NewsBll sicb = new NB_NewsBll();
            NB_News sic = new NB_News();
            ArrayList sbn = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if( nreader== "seldep")
                {
                    string[] darr = sdep.Split(';');
                    foreach(string dstr in darr)
                    {
                        List<Sys_Depment> lsd = sdb.QueryList(" and dcode like '" + dstr + "%' and disend='true'");
                       if(lsd!=null)
                        {
                            foreach(Sys_Depment sd in lsd)
                            {
                                sbn.Add(sd.dcode);
                            }
                        }
                    }
                }
                else
                {
                    nreader = "all";
                    sbn = null;
                }
                sic.ntitle = tname;
                sic.ncontent = ntext;
                sic.nreadnum = 0;
                sic.nstate = nshow=="a"?true:false;
                sic.maker = iv.u.ename;
                sic.cdate = DateTime.Now.ToString();
                sic.nvrange = nreader;
                sic.ntype = ntype;
                sic.nsid= CommonBll.GetSid();
                sic.dcode = "";
                sic.rtype = "a";
                sic.sdcode = sdep;
                if (nid == "0")
                {
                    if (sicb.Add(sic) > 0)
                    {
                        r = "S";
                        NB_News sicc = sicb.Query(" and nsid='"+ sic.nsid + "'");
                        if(sicc!=null)
                        {
                            nid = sicc.id.ToString();
                            ndnb.Add(nid, sbn);
                        }
                    }
                    else
                    {
                        r = "F";
                    }
                }
                else
                {
                    sic.id = Convert.ToInt32(nid);
                    if (sicb.Update(sic))
                    {
                        r = "S";
                        ndnb.Delete(" and nid="+nid+"");
                        ndnb.Add(nid, sbn);
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
        #region///删除产品类
        [WebMethod(true)]
        public static string DelNews(string id)
        {
            string r = "";
            NB_NewsBll sdb = new NB_NewsBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sdb.Delete(" and id="+id+""))
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
        #region///新闻列表
        [WebMethod(true)]
        public static ArrayList QueryListAll(string curpage, string pagesize)
        {
            ArrayList r = new ArrayList();
            BusiEventButtonBll bebb = new BusiEventButtonBll();
            NB_NewsBll sub = new NB_NewsBll();
            List<NB_News> lsr = new List<NB_News>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                int rcount = 0;
                int pcount = 0;
                lsr = sub.QueryList(Convert.ToInt32(curpage), Convert.ToInt32(pagesize), "", "id desc", ref rcount, ref pcount);
                if (lsr != null)
                {
                    r.Add(pcount);
                    foreach (NB_News s in lsr)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.id);
                        al.Add(s.ntitle);
                        al.Add(s.ntype);
                        al.Add(s.nstate==true?"显示":"关闭");
                        al.Add(s.maker);
                        al.Add(s.cdate);
                        al.Add(bebb.QueryBtnListItems("0176",iv.u.rcode,"LX",s.id.ToString()));
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
        #region///新闻列表
        [WebMethod(true)]
        public static ArrayList QueryRoleList(string curpage, string pagesize)
        {
            ArrayList r = new ArrayList();
            BusiEventButtonBll bebb = new BusiEventButtonBll();
            NB_NewsBll sub = new NB_NewsBll();
            List<NB_News> lsr = new List<NB_News>();
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                int rcount = 0;
                int pcount = 0;
                if (iv.u.rcode != "xtgl")
                {
                    where.AppendFormat(" and nvrange like '%{0}%' ", iv.u.dcode.Substring(0, 4));
                }
                lsr = sub.QueryList(Convert.ToInt32(curpage), Convert.ToInt32(pagesize), where.ToString(), "id desc", ref rcount, ref pcount);
                if (lsr != null)
                {
                    r.Add(pcount);
                    foreach (NB_News s in lsr)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.id);
                        al.Add(s.ntitle);
                        al.Add(s.ntype);
                        al.Add(s.nstate == true ? "显示" : "关闭");
                        al.Add(s.maker);
                        al.Add(s.cdate);
                        al.Add(bebb.QueryBtnListItems("0005", iv.u.rcode, "LX", s.id.ToString()));
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

        #region////新闻阅览者
        #region///保存阅览者
        [WebMethod(true)]
        public static string SaveNewsRead(string id)
        {
            string r = "";
            NB_NewsReaderBll sicb = new NB_NewsReaderBll();
            NB_NewsReader sic = new NB_NewsReader();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sic.nid =Convert.ToInt32(id);
                sic.dcode = iv.u.dcode;
                sic.dname = iv.u.dname;
                sic.ename = iv.u.ename;
                sic.cdate = DateTime.Now.ToString();
                NB_NewsReader cn= sicb.Query(" and nid=" + id + " and ename='" + sic.ename + "'");
                if (cn == null)
                {
                    if (sicb.Add(sic) > 0)
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
        #region///获取阅览者
        [WebMethod(true)]
        public static ArrayList QueryListRead(string id)
        {
            ArrayList r = new ArrayList ();
            NB_NewsReaderBll sicb = new NB_NewsReaderBll();
            NB_NewsReader sic = new NB_NewsReader();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<NB_NewsReader> lnb = sicb.QueryList(" and nid=" + id + " order by id desc");
                if (lnb != null)
                {
                    foreach (NB_NewsReader n in lnb)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(n.dname);
                        al.Add(n.ename);
                        al.Add(n.cdate);
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

        #region//获取弹出新闻
        [WebMethod(true)]
        public static string QueryFristNews()
        {
            string r = "";
            NB_NewsBll sicb = new NB_NewsBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string dw = "";
                if (iv.u.dcode.Trim() != "")
                {
                    dw = " and dcode = '" + iv.u.dcode.Substring(0, 8) + "'";
                }
                else
                {
                   
                }
                List<NB_News> lnb = sicb.QueryList(" and cdate>'" + iv.u.ecdate + "' and ((nvrange='all' " + dw+ " ) or (nvrange='seldep' and id in(select nid from NB_DepNews where dcode='" + iv.u.dcode + "') ))and id not in(select nid from NB_NewsReader where ename='" + iv.u.ename + "') order by id desc");
                if (lnb != null)
                {
                    r = js.Serialize(lnb[0]);
                }
            }
            else
            {
                r=iv.badstr;
            }
            return r;
        }
        #endregion

        //---------------------------------Cust---------------------------------------
        #region///新闻列表
        [WebMethod(true)]
        public static ArrayList CustQueryListAll(string curpage, string pagesize)
        {
            ArrayList r = new ArrayList();
            BusiEventButtonBll bebb = new BusiEventButtonBll();
            NB_NewsBll sub = new NB_NewsBll();
            List<NB_News> lsr = new List<NB_News>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                int rcount = 0;
                int pcount = 0;
                
                lsr = sub.QueryList(Convert.ToInt32(curpage), Convert.ToInt32(pagesize), " ", "id desc", ref rcount, ref pcount);
                if (lsr != null)
                {
                    r.Add(pcount);
                    foreach (NB_News s in lsr)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.id);
                        al.Add(s.ntitle);
                        al.Add(s.ntype);
                        al.Add(s.nstate == true ? "显示" : "关闭");
                        al.Add(s.maker);
                        al.Add(s.cdate);
                        al.Add(bebb.QueryBtnListItems("0176", iv.u.rcode, "LX", s.id.ToString()));
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
        #region///新闻列表
        [WebMethod(true)]
        public static ArrayList CustQueryRoleList(string curpage, string pagesize)
        {
            ArrayList r = new ArrayList();
            BusiEventButtonBll bebb = new BusiEventButtonBll();
            NB_NewsBll sub = new NB_NewsBll();
            List<NB_News> lsr = new List<NB_News>();
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                int rcount = 0;
                int pcount = 0;
                if (iv.u.rcode != "xtgl")
                {
                    where.AppendFormat(" and ( id in(select nid from NB_DepNews where dcode='{0}') or rtype='a' )   ", iv.u.dcode);
                }
                lsr = sub.QueryList(Convert.ToInt32(curpage), Convert.ToInt32(pagesize), where.ToString(), "id desc", ref rcount, ref pcount);
                if (lsr != null)
                {
                    r.Add(pcount);
                    foreach (NB_News s in lsr)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.id);
                        al.Add(s.ntitle);
                        al.Add(s.ntype);
                        al.Add(s.nstate == true ? "显示" : "关闭");
                        al.Add(s.maker);
                        al.Add(s.cdate);
                        al.Add(bebb.QueryBtnListItems("0175", iv.u.rcode, "LX", s.id.ToString()));
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
        #region///保存产品类
        [WebMethod(true)]
        public static string CustSaveNews(string ndate, string nfbr, string nid, string nshow, string nreader, string ntext, string ntype, string sdep, string tname)
        {
            string r = "";
            NB_NewsBll sicb = new NB_NewsBll();
            NB_News sic = new NB_News();
            ArrayList sbn = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (nreader == "seldep")
                {
                    string[] darr = sdep.Split(';');
                    foreach (string dstr in darr)
                    {
                        List<Sys_Depment> lsd = sdb.QueryList(" and dcode like '" + dstr + "%'");
                        if (lsd != null)
                        {
                            foreach (Sys_Depment sd in lsd)
                            {
                                sbn.Add(sd.dcode);
                            }
                        }
                    }
                }
                else
                {
                    nreader = "all";
                    sbn = null;
                }
                sic.ntitle = tname;
                sic.ncontent = ntext;
                sic.nreadnum = 0;
                sic.nstate = nshow == "a" ? true : false;
                sic.maker = iv.u.ename;
                sic.cdate = DateTime.Now.ToString();
                sic.nvrange = nreader;
                sic.ntype = ntype;
                sic.dcode = iv.u.dcode.Substring(0,8);
                sic.rtype = "p";
                sic.nsid = CommonBll.GetSid();
                if (nid == "0")
                {
                    if (sicb.Add(sic) > 0)
                    {
                        r = "S";
                        NB_News sicc = sicb.Query(" and nsid='" + sic.nsid + "'");
                        if (sicc != null)
                        {
                            nid = sicc.id.ToString();
                            ndnb.Add(nid, sbn);
                        }
                    }
                    else
                    {
                        r = "F";
                    }
                }
                else
                {
                    sic.id = Convert.ToInt32(nid);
                    if (sicb.Update(sic))
                    {
                        r = "S";
                        ndnb.Delete(" and nid=" + nid + "");
                        ndnb.Add(nid, sbn);
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
    }
}