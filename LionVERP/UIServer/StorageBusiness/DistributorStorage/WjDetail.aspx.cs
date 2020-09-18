using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvAopModel;
using LionvBll.SysInfo;
using System.Text;
using LionvCommonBll;
using ViewModel.BusiOrderInfo;
using System.Web.Script.Serialization;
using LionvBll.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using LionvBll.BusiCommon;
using System.Web.Services;

namespace LionVERP.UIServer.StorageBusiness.DistributorStorage
{
    public partial class WjDetail : System.Web.UI.Page
    {
        private static BusiTempletBll btb = new BusiTempletBll();
        private static BusiInvTempBll bitb = new BusiInvTempBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        private static B_SaleOrderBll bsob = new B_SaleOrderBll();
        private static B_GroupProductionBll bgpb = new B_GroupProductionBll();
        private static CB_OrderStateBll cbsb = new CB_OrderStateBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region//五金详情单
        [WebMethod(true)]
        public static string WjOrder(string sid, string emcode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                StringBuilder invhtm = new StringBuilder();
                #region//加载表头
                invhtm.Append(bitb.WjThead(emcode, sid));
                #endregion
                #region//加载表体
                invhtm.Append(bitb.WjTbody(emcode, sid));
                #endregion
                #region//加载表脚
                invhtm.Append(btb.TempFoot(emcode));
                #endregion
                r = invhtm.ToString();
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