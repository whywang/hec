using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.Services;
using LionvCommonBll;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.ProductionInfo;

namespace LionVERP.UIServer.CommonFile
{
    public partial class RefNomalSize : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region/////获取订单工作流程
        [WebMethod(true)]
        public static string RefNSize(string icode)
        {
            string r = "";
            BusiInvSizeBll snsb = new BusiInvSizeBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_NomalSize sns = snsb.RefInvSize(icode);
                if (sns != null)
                {
                    r = js.Serialize(sns);
                }
            }
            else
            {
                r=iv.badstr;
            }
            return r;
        }
        #endregion
    }
}