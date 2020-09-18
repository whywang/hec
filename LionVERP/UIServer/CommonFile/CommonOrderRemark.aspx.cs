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
    public partial class CommonOrderRemark : System.Web.UI.Page
    {
        private static BusiOrderRemarkBll borb = new BusiOrderRemarkBll();
        private static BusiBtnExceBll bbeb = new BusiBtnExceBll();
        private static BusiOrderCodeBll bocb = new BusiOrderCodeBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region/// 设置订单总部备注
        [WebMethod(true)]
        public static string SetOrderZbRemark(string sid, string emcode,string bcode,string remark)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = "F";
                if (borb.SetZbRemark(sid, emcode, remark))
                {
                    r = "S";
                }
                else
                {
                    r = "F";
                }
                bbeb.WriteBtnRecoder(sid, bcode, iv.u.ename);
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