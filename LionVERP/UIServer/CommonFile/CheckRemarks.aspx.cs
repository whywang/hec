using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvBll.ProductionInfo;
using LionvModel.ProductionInfo;

namespace LionVERP.UIServer.CommonFile
{
    public partial class CheckRemarks : System.Web.UI.Page
    {
        private static Sys_RemarkBll srb = new Sys_RemarkBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region/// 获取产品组件类
        [WebMethod(true)]
        public static string CheckInvRemark(string icode)
        {
            string r = "";
            string ccode = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                ccode = srb.GetProductionBz(icode);
                if (ccode != "")
                {
                    Sys_Remark scc = srb.Query(" and rcode='" + ccode + "'");
                    if (scc != null)
                    {
                        r = scc.rchangtext;
                    }
                    else
                    {
                        r = "";
                    }
                }
                else
                {
                    r = "";
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