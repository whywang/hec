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

namespace LionVERP.UIServer.BaseSet.EmploeeManage
{
    public partial class Designers : System.Web.UI.Page
    {
        private static Sys_DesignerBll sdb = new Sys_DesignerBll();
        private static Sys_DesignerProductionBll sdpb = new Sys_DesignerProductionBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region//保存设计师
        [WebMethod(true)]
        public static string SaveDesigner( string eno, string id,string sappraise,string sintroduce, string sname, string sqq, string stelephone)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Designer sd = new Sys_Designer();
                sd.eno = eno;
                sd.dappraise = sappraise;
                sd.dintroduce = sintroduce;
                sd.dname = sname;
                sd.dqq = sqq;
                sd.dtelephone = stelephone;
                sd.cdate = DateTime.Now.ToString();
                sd.maker = iv.u.ename;
                if (!sdb.Exists(" and eno='" + eno + "'"))
                {
                    if (sdb.Add(sd) > 0)
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
                    if (sdb.Update(sd))
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
        #region//获取设计师
        [WebMethod(true)]
        public static string Query(string eno)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Designer sd = sdb.Query(" and eno='"+eno+"'");
                List<Sys_DesignerProduction> lsp=sdpb.QueryList(" and eno='" + eno + "' order by id");
                if (lsp != null)
                {
                    sd.sdp = lsp;
                }
                r = js.Serialize(sd);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region//查询设计师
        [WebMethod(true)]
        public static ArrayList QueryList()
        {
            ArrayList r = new ArrayList ();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                List<Sys_Designer> sdl = sdb.QueryList(" ");
                if(sdl!=null)
                {
                    foreach (Sys_Designer sd in sdl)
                    {
                        List<Sys_DesignerProduction> lsp = sdpb.QueryList(" and eno='" + sd.eno + "' order by id");
                        sd.sdp = lsp;
                        r.Add(sd);
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