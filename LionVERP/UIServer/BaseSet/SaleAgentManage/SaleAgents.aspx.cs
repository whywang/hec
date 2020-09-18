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

namespace LionVERP.UIServer.BaseSet.SaleAgentManage
{
    public partial class SaleAgents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region///  设置平台结算方式
        [WebMethod(true)]
        public static string SetAgentsPrice(string dcode, string ptcode)
        {
            string r = "";
            Sys_PriceTypeBll srb = new Sys_PriceTypeBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (srb.SetAgentsPrice(dcode, ptcode) > 0)
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
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///  重置平台结算方式
        [WebMethod(true)]
        public static string ReSetAgentsPrice(string dcode)
        {
            string r = "";
            Sys_PriceTypeBll srb = new Sys_PriceTypeBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (srb.ReSetAgentsPrice(dcode) > 0)
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
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///  获取平台结算方式
        [WebMethod(true)]
        public static string GetAgentsPrice(string dcode)
        {
            string r = "";
            Sys_PriceTypeBll srb = new Sys_PriceTypeBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = srb.GetAgentsPrice(dcode);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion

        #region///  设置城市销售价格体系
        [WebMethod(true)]
        public static string SetAgentsSalePrice(string dcode, string ptcode)
        {
            string r = "";
            Sys_PriceTypeBll srb = new Sys_PriceTypeBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (srb.SetAgentsSalePrice(dcode, ptcode) > 0)
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
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///  重置城市销售价格体系
        [WebMethod(true)]
        public static string ReSetAgentsSalePrice(string dcode)
        {
            string r = "";
            Sys_PriceTypeBll srb = new Sys_PriceTypeBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (srb.ReSetAgentsSalePrice(dcode) > 0)
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
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///  获取城市销售价格体系
        [WebMethod(true)]
        public static string GetAgentsSalePrice(string dcode)
        {
            string r = "";
            Sys_PriceTypeBll srb = new Sys_PriceTypeBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = srb.GetAgentsSalePrice(dcode);
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