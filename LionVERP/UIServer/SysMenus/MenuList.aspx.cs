using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Text;
using LionvModel.SysInfo;
using LionvBll;
using LionvBll.SysInfo;
using LionvAopModel;
using System.Collections;

namespace LionVERP.UIServer.SysMenus
{
    public partial class MenuList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod(true)]
        public static string LoadMenu(string md, string pmenucode)
        {
             string r = "";
             SessionUserValidate iv = SysValidateBll.ValidateSession();
             StringBuilder MenuHtml = new StringBuilder();
             StringBuilder where = new StringBuilder();
             Sys_MenuBll smb = new Sys_MenuBll();
             if (iv.f)
             {
                 if (pmenucode != "")
                 {
                     #region//子栏目组分类
                     ArrayList agl = smb.QueryMenuGroup(pmenucode);
                     foreach (string g in agl)
                     {
                         where.Clear();
                         if (iv.u.rcode != "xtgl")
                         {
                             where.Append(" and mpcode ='" + pmenucode + "' and  mcode in(select mcode from  Sys_RMenuRole where rcode =  '" + iv.u.rcode + "' ) and mgroup='" + g + "'  order by msort");
                         }
                         else
                         {
                             where.Append(" and mpcode ='" + pmenucode + "'  and mgroup='" + g + "' order by msort");
                         }
                         List<Sys_Menu> lm = smb.QueryList(where.ToString());
                         if (lm != null)
                         {
                             if (lm.Count > 0)
                             {
                                 if (g != "")
                                 {
                                     MenuHtml.AppendFormat("<li class='jg'> </li>");
                                 }
                                 for (int i = 0; i < lm.Count; i++)
                                 {
                                     Sys_Menu m = lm[i];
                                     m.mstyle = m.mstyle == "" ? "no" : m.mstyle;
                                     if (m.mhaschild)
                                     {
                                         MenuHtml.Append("<ul class='ul'>");
                                         MenuHtml.AppendFormat("<li class='pbar'><span class='{0}'>&nbsp;</span> <a id='P{1}' href='javascript:void(0)' onclick='Expend(this.id)'> <span>{2}</span></a></li>", m.mstyle, m.mcode, m.mname);
                                         MenuHtml.Append("</ul>");
                                         MenuHtml.AppendFormat("<ul  id='C{0}' class='cmenuinit'>", m.mcode);
                                         MenuHtml.Append("</ul>");

                                     }
                                     else
                                     {
                                         MenuHtml.AppendFormat("<li  class='pbar'><span class='{0}'>&nbsp;</span> <a id='{1}' href=\"{2}\" onclick='{3}' target='Main'> <span>{4}</span></a></li>", m.mstyle, m.mcode, m.murl + "?menucode=" + m.mcode+"&v="+DateTime.Now.ToString("yyyyMMddHHmmss"), "GoUrl(this.id)", m.mname);
                                     }
                                 }
                             }
                         }
                     }
                     #endregion
                 }
                 else
                 {
                     where.Clear();
                     #region//主菜单无组分类
                     if (iv.u.rcode != "xtgl")
                     {
                         where.Append(" and mpcode ='" + pmenucode + "' and  mcode in(select mcode from  Sys_RMenuRole where rcode =  '" + iv.u.rcode + "' )  order by msort");
                     }
                     else
                     {
                         where.Append(" and mpcode ='" + pmenucode + "' order by msort");
                     }
                     List<Sys_Menu> lm = smb.QueryList(where.ToString());
                     if (lm != null)
                     {
                         if (lm.Count > 0)
                         {
                             for (int i = 0; i < lm.Count; i++)
                             {
                                 Sys_Menu m = lm[i];
                                 m.mstyle = m.mstyle == "" ? "no" : m.mstyle;
                                 if (m.mhaschild)
                                 {
                                     MenuHtml.Append("<ul class='ul'>");
                                     MenuHtml.AppendFormat("<li class='pbar'><span class='{0}'>&nbsp;</span> <a id='P{1}' href='javascript:void(0)' onclick='Expend(this.id)'> <span>{2}</span></a></li>", m.mstyle, m.mcode, m.mname);
                                     MenuHtml.Append("</ul>");
                                     MenuHtml.AppendFormat("<ul  id='C{0}' class='cmenuinit'>", m.mcode);
                                     MenuHtml.Append("</ul>");
                                 }
                                 else
                                 {
                                     MenuHtml.AppendFormat("<li  class='pbar'><span class='{0}'>&nbsp;</span> <a id='{1}' href=\"{2}\" onclick='{3}' target='Main'> <span>{4}</span></a></li>", m.mstyle, m.mcode, m.murl + "?menucode=" + m.mcode, "GoUrl(this.id)", m.mname);
                                 }
                             }
                         }
                     }
                     #endregion
                 }
                 r=MenuHtml.ToString();
             }
             else
             {
                 r=iv.badstr;
             }
             return r ;
        }
    }
}