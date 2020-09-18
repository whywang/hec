using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using System.Text;
using LionvCommonBll;

namespace LionVERP.UIServer.SalesBusiness.DistributorOrder
{
    public partial class SaleReceipt : System.Web.UI.Page
    {
        private static BusiTempletBll btb = new BusiTempletBll();
        private static BusiInvTempBll bitb = new BusiInvTempBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region/// 获取平台确认单产品价格
        [WebMethod(true)]
        public static string SaleSureProduction(string sid, string emcode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                StringBuilder invhtm = new StringBuilder();
                #region//加载表头
                invhtm.Append(btb.TempHead("0009"));
                #endregion
                #region//加载表体
                invhtm.Append(bitb.SureProductionHtml("0009", sid));
                #endregion
                #region//加载表脚
                invhtm.Append(bitb.SureFootHtml("0009", sid));
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