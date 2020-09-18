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

namespace LionVERP.UIServer.BaseSet.SapApi
{
    public partial class SapApiList : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        private static Sys_SapApiBll ssb = new Sys_SapApiBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region//初始化接口
        [WebMethod(true)]
        public static string InitApi(string scode)
        {
            string r = "";
            Sys_SapApi ss = new Sys_SapApi();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (scode == "")
                {
                    ss.scode = ssb.CreateCode().ToString().PadLeft(4, '0');
                    ss.id = 0;
                }
                else
                {
                    ss = ssb.Query(" and scode='" + scode + "'");
                }
                r = js.Serialize(ss);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region//保存接口
        [WebMethod(true)]
        public static string SaveApi(string scode, string sfwname, string sid,string smethod,string sname, string spwd,  string surl, string suser)
        {
            string r = "";
            Sys_SapApi ss = new Sys_SapApi();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                ss.scode = scode;
                ss.sfwmethod = smethod;
                ss.sfwname = sfwname;
                ss.sname = sname;
                ss.spwd = spwd;
                ss.surl = surl;
                ss.suser = suser;
                if (sid == "0")
                {
                    if (ssb.Add(ss) > 0)
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
                    if (ssb.Update(ss))
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
        #region//删除接口
        [WebMethod(true)]
        public static string DelApi(string scode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (ssb.Delete(" and scode='" + scode + "'"))
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
        #region//查询接口
        [WebMethod(true)]
        public static ArrayList QueryList()
        {
            ArrayList r = new ArrayList ();
            Sys_SapApi ss = new Sys_SapApi();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_SapApi> lss = ssb.QueryList("");
                if (lss != null)
                {
                    foreach (Sys_SapApi s in lss)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.sname);
                        al.Add(s.scode);
                        al.Add(s.surl);
                        al.Add(s.suser);
                        al.Add(s.spwd);
                        al.Add(s.sfwname);
                        al.Add(s.sfwmethod);
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