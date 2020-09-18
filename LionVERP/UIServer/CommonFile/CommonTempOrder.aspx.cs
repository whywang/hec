using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvCommonBll;

namespace LionVERP.UIServer.CommonFile
{
    public partial class CommonTempOrder : System.Web.UI.Page
    {
        private static BusiPayTempBll bptb = new BusiPayTempBll();
        private static BusiSendTempBll bstb = new BusiSendTempBll();
        private static BusiServiceTempBll stb = new BusiServiceTempBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
         
        #region//获取发货清单
        [WebMethod(true)]
        public static string QuerySendOrderHtm(string sid, string emcode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = bstb.QuerySendOrderHtm(sid, emcode, "qt", iv.u.dcode.Substring(0, 8));
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region//获取服务清单
        [WebMethod(true)]
        public static string QueryServiceOrderHtm(string sid, string emcode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = stb.QueryServiceOrderHtm(sid, emcode, "xq", iv.u.dcode.Substring(0, 8));
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