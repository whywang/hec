using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvBll.BusiOrderInfo;
using LionvBll.BusiCommon;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using ViewModel.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using LionvModel.BusiCommon;
using System.Web.Script.Serialization;
using System.Text;
using LionvCommonBll;

namespace LionVERP.UIServer.CityService.DistributorService
{
    public partial class FixDetail : System.Web.UI.Page
    {
        private static B_SaleOrderBll bsob = new B_SaleOrderBll();
        private static CB_OrderFlowBll cofb = new CB_OrderFlowBll();
        private static B_OrderFacotoryBll bofb = new B_OrderFacotoryBll();
        private static CB_OrderStateBll cosb = new CB_OrderStateBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        private static BusiTempletBll btb = new BusiTempletBll();
        private static BusiInvTempBll bitb = new BusiInvTempBll();
        private static B_FixecImgBll bfb = new B_FixecImgBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region// 安装单信息
        [WebMethod(true)]
        public static string FixOrder(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                VFixOrder vfo = new VFixOrder();
                B_SaleOrder bso = bsob.Query(" and osid='" + sid + "'");
                B_OrderFacotory bof = bofb.Query(" and sid='" + sid + "'");
                CB_OrderState cos = cosb.Query(" and sid='" + sid + "'");
                string zt = "";
                if (cos != null)
                {
                    if (cos.ifixed == 0)
                    {
                        zt = "未安装";
                    }
                    if (cos.ifixed == 1)
                    {
                        zt = "部分安装";
                    }
                    if (cos.ifixed == 2)
                    {
                        zt = "已安装";
                    }
                }
                vfo.code = bso.scode;
                vfo.ycode = bso.oscode;
                vfo.wcode = bso.wcode;
                vfo.otype = bso.otype;
                vfo.customer = bso.customer;
                vfo.telephone = bso.telephone;
                vfo.address = bso.address;
                vfo.dname = bso.dname;
                vfo.city = bso.city;
                vfo.gzname = bso.gzname;
                vfo.gztelephone = bso.gztelephone;
                vfo.azzt = zt;
                vfo.bz = bso.remark;
                r = js.Serialize(vfo);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region// 安装确认单
        [WebMethod(true)]
        public static string FixSureOrder(string sid, string emcode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                StringBuilder invhtm = new StringBuilder();
                B_FixecImg pr = bfb.Query(" and sid='" + sid + "'");
                if (pr != null)
                {
                    #region//加载表头
                    invhtm.Append(btb.TempHead(emcode));
                    #endregion
                    #region//加载表体
                    invhtm.Append(bitb.FixOrderHtml(emcode, sid));
                    #endregion
                    #region//加载表脚
                    invhtm.Append(btb.TempFoot(emcode));
                    #endregion
                }
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