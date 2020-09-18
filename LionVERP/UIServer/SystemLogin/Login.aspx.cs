using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvModel.SysInfo;
using LionvBll.SysInfo;
using LionvCommon;
using LionvAopModel;

namespace LionVERP.UIServer.SystemLogin
{
    public partial class Login : System.Web.UI.Page
    {
        private static Sys_DepmentBll sdb = new Sys_DepmentBll();
        private static Sys_EmployeeDptBll sedb = new Sys_EmployeeDptBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod(true)]
        public static string LoginSystem(string iuname, string iupwd)
        {
             string r = "";
             SysExpireBll seb = new SysExpireBll();
             //if (seb.SysExpire())
             //{
             string jmsz = DES.EncryptDES(iupwd);
             if (!string.IsNullOrEmpty(iuname) && !string.IsNullOrEmpty(iupwd))
             {
                 Sys_User model = new Sys_User();
                 Sys_Employee ee = new Sys_Employee();
                 Sys_EmployeeDpt eed = new Sys_EmployeeDpt();
                 Sys_UserBll sub = new Sys_UserBll();
                 Sys_EmployeeBll eb = new Sys_EmployeeBll();
                 model = sub.Query(" and uname='" + iuname + "' and upass='" + jmsz + "' and ulogin='true'");
                 if (model == null)
                 {
                     r = "F";
                 }
                 else
                 {
                     r = "S";
                     ee = eb.Query(" and eno='" + model.eno + "'");
                     if (ee.dcode != "")
                     {
                         Sys_Depment sd = sdb.Query(" and dcode='" + ee.dcode + "'");
                         ee.dname = sd != null ? sd.dname : "";
                     }
                     eed = sedb.Query(" and eno='" + ee.eno + "'");
                     if (eed != null)
                     {
                         ee.etelephone = eed.etelephone;
                     }
                     ee.elname = iuname;
                     HttpContext.Current.Session["LUser"] = ee;
                     Guid uniqueID = Guid.NewGuid();
                     OnLineUser olu = new OnLineUser();
                     olu.Gid = uniqueID;
                     olu.Zt = 0;
                     olu.Username = model.uname;
                     UserCacheImp uci = new UserCacheImp();
                     if (HttpContext.Current.Request.Cookies["Cuser"] != null)
                     {
                         HttpCookie cok = HttpContext.Current.Request.Cookies["Cuser"];
                         cok.Values["cuser"] = System.Web.HttpUtility.UrlEncode(model.uname);
                         HttpContext.Current.Response.AppendCookie(cok);
                     }
                     else
                     {
                         HttpCookie cookie = new HttpCookie("Cuser");
                         cookie.Values.Add("cuser", System.Web.HttpUtility.UrlEncode(model.uname));
                         HttpContext.Current.Response.AppendCookie(cookie);
                     }
                     uci.Add(olu, "U");
                 }
             }
             else
             {
                 HttpContext.Current.Session["LUser"] = null;
                 r = "F";
             }
             // }
             //else
             //{
             //    r = "F";
             //}
             return r;
        }
    }
}