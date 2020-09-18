using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvBll.BusiCommon;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.BusiCommon;

namespace LionVERP.UIServer.CommonFile
{
    public partial class Notify : System.Web.UI.Page
    {
        private static CB_MessageBll cbmb = new CB_MessageBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region/////获取订单工作流程
        [WebMethod(true)]
        public static string ReadNotify(string id)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                CB_Message cm = new CB_Message();
                cm.id=Convert.ToInt32(id);
                cm.dstate = 1;
                cm.dmaker = iv.u.ename;
                cm.ddate = DateTime.Now.ToString();
                cbmb.Update(cm);
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