using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvBll.BusiOrderInfo;
using System.Collections;
using LionvModel.BusiOrderInfo;
using LionvBll.BusiCommon;
using LionvCommonBll;
using System.Text;

namespace LionVERP.UIServer.AfterSaleServiceBusiness.DistributorAfterSale
{
    public partial class AfterOrderDetail : System.Web.UI.Page
    {
        private static B_FeedBackImgBll basob = new B_FeedBackImgBll();
        private static BusiEventButtonBll bebb = new BusiEventButtonBll();
        private static B_AfterSaleOrderBll abasob = new B_AfterSaleOrderBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    
        #region// 反馈 责任及处理方式
        [WebMethod(true)]
        public static string SetDuty(string sid, string duty, string clfs)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            { 
                r = "S";
                //if (abasob.SetDuty(sid, duty, clfs) > 0)
                //{
                   
                //}
                //else
                //{
                //    r = "F";
                //}

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