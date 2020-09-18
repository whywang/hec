using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvBll.SysInfo;
using LionvCommonBll;
using LionvAopModel;
using LionvModel.SysInfo;

namespace LionWap.UIServer
{
    public partial class EvenDo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region//获取列表页Btn
        [WebMethod(true)]
        public static string FireEventBtn(string sid, string bcode, string bstate, string bms)
        {
            string r = "";
            Sys_ButtonBll sbb = new Sys_ButtonBll();
            BusiWorkFlowBll bwfb = new BusiWorkFlowBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Button sbt = sbb.Query(" and bcode='" + bcode + "'");
                if (sbt != null)
                {
                    if (bwfb.FireEventBtn(sid, sbt, Convert.ToInt32(bstate), bms, iv.u.ename) > 0)
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
                    r = "F";
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