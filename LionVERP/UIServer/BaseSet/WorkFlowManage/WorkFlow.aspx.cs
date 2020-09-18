using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvBll.SysInfo;
using LionvModel.SysInfo;
using LionvAopModel;
using System.Web.Script.Serialization;
using System.Collections;

namespace LionVERP.UIServer.BaseSet.WorkFlowManage
{
    public partial class WorkFlow : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region///  初始化或查询事件节点
        [WebMethod(true)]
        public static string InitEventJd(string emcode, string wcode)
        {
            string r = "";
            Sys_WorkEventBll sweb = new Sys_WorkEventBll();
            Sys_WorkEvent swe = new Sys_WorkEvent();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (wcode == "")
                {
                    swe.emcode = emcode;
                    swe.wcode = sweb.CreateCode().ToString().PadLeft(4, '0');
                    swe.id = 0;
                    swe.wattr = 2;
                }
                else
                {
                    swe = sweb.Query(" and wcode='" + wcode + "'");
                }
                r = js.Serialize(swe);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///保存事件节点
        [WebMethod(true)]
        public static string SaveEventJd(string emrcode, string jdcode,string wattrex, string wcondtion, string wcycletime, string wemcode, string wemname, string wid, string wname, string wprewcode, string wrwcode,string wrwtype, string wtype)
        {
            string r = "";
            Sys_WorkEventBll sweb = new Sys_WorkEventBll();
            Sys_WorkEvent swe = new Sys_WorkEvent();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                swe.emcode = wemcode;
                swe.wcode = jdcode;
                swe.wcondtion = wcondtion;
                swe.wname = wname;
                swe.wnextwcode = "";
                swe.wprewcode = wprewcode;
                swe.wrwcode = wrwcode;
                swe.wattr = Convert.ToInt32(wtype);
                swe.wcycletime = Convert.ToInt32(wcycletime);
                swe.wremcode = emrcode;
                swe.wattrex = wattrex;
                swe.wrwtype = wrwtype;
                if (wid == "0")
                {
                    if (sweb.Add(swe) > 0)
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
                    if (sweb.Update(swe))
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
        #region///删除事件节点
        [WebMethod(true)]
        public static string DelEventJd(string wcode)
        {
            string r = "";
            Sys_WorkEventBll sweb = new Sys_WorkEventBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sweb.Delete(wcode))
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
        #region///获取事件节点列表
        [WebMethod(true)]
        public static ArrayList QueryEventJdList(string emcode)
        {
            ArrayList r = new ArrayList ();
            Sys_WorkEventBll sweb = new Sys_WorkEventBll();
            List<Sys_WorkEvent> lswe = new List<Sys_WorkEvent>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                lswe = sweb.QueryList(" and emcode='" + emcode + "'");
                if (lswe != null)
                {
                    foreach (Sys_WorkEvent s in lswe)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.wcode);
                        al.Add(s.wname);
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