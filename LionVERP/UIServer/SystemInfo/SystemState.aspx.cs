using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.Services;
using LionvBll.SysInfo;
using LionvModel.SysInfo;
using LionvCommon;

namespace LionVERP.UIServer.SystemInfo
{
    public partial class SystemState : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        private static ISystem ism = new ISystem();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod(true)]
        public static string CheckDataBaseState()
        {
            string r = "F";
            if (ism.CheckDataConnection())
            {
                r = "S";
            }
            else
            {
                r = "F";
            }
            return r;
        }
        [WebMethod(true)]
        public static string BackDataBase(string btype)
        {
            string r = "F";
            if (ism.BackUpDateBase(btype) != 0)
            {
                r = "S";
            }
            else
            {
                r = "F";
            }
            return r;
        }
        [WebMethod(true)]
        public static string InitImg(string mtype)
        {
            string r = "F";
            Sys_SystemImgBll bmib = new Sys_SystemImgBll();
            Sys_SystemImg ssi = new Sys_SystemImg();
            ssi = bmib.Query(" and mtype=" + mtype + "");
            r = js.Serialize(ssi);
            return r;
        }
    }
}