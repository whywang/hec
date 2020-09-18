using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvBll.ProductionInfo;
using LionvBll.SysInfo;
using LionvAopModel;

namespace LionVERP.UIServer.BaseSet.FactoryPriceManage
{
    public partial class FactoryPrice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region///  设置工厂价格
        [WebMethod(true)]
        public static string SetFactoryPrice(string dcode, string ptcode,string cdcode)
        {
            string r = "";
            Sys_PriceTypeBll srb = new Sys_PriceTypeBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (srb.SetFactoryPrice( ptcode,dcode,cdcode) > 0)
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
        #region///  重置工厂价格
        [WebMethod(true)]
        public static string ReSetFactoryPrice(string dcode,string cdcode)
        {
            string r = "";
            Sys_PriceTypeBll srb = new Sys_PriceTypeBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (srb.ReSetFactoryPrice(dcode, cdcode) > 0)
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
        #region///  获取工厂价格
        [WebMethod(true)]
        public static string GetFactoryPrice(string dcode,string cdcode)
        {
            string r = "";
            Sys_PriceTypeBll srb = new Sys_PriceTypeBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = srb.GetFactoryPrice(dcode, cdcode);
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