using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.BusiOrderInfo;
using LionvBll.BusiOrderInfo;
using LionvCommonBll;

namespace LionVERP.UIServer.CommonFile
{
    public partial class CommonOrderType : System.Web.UI.Page
    {
        private static B_SaleOrderBll bsob = new B_SaleOrderBll();
        private static B_YqSaleOrderBll ybsob = new B_YqSaleOrderBll();
        private static BusiOrderCodeBll bocb = new BusiOrderCodeBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region/// 设置订单编码
        [WebMethod(true)]
        public static string SetOrderCode(string sid,string otype)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = "F";
               bool iscode = false;
                B_SaleOrder bso = bsob.Query(" and sid='" + sid + "'");
                if (bso != null)
                {
                    if (bso.scode == "")
                    {
                        iscode = true;
                    }
                    if (bocb.SetOrderCode(sid, otype, iv.u.dcode.Substring(0, 8), "", bso.citycode, iscode))
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
    }
}