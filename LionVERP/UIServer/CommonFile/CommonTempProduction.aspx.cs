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

namespace LionVERP.UIServer.CommonFile
{
    public partial class CommonTempProduction : System.Web.UI.Page
    {
        private static BusiInvDetailProuductionTempBll bidptb = new BusiInvDetailProuductionTempBll();
        private static BusiTempletBll btb = new BusiTempletBll();
        private static BusiInvProduceProuductionTempBll bipptb = new BusiInvProduceProuductionTempBll();
        private static BusiInvProductionGhPriceTempBll bpigptb = new BusiInvProductionGhPriceTempBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region//获取详情产品Html
        [WebMethod(true)]
        public static string ProductionOrderDetail(string emcode, string embcode,string sid,string ttype)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                StringBuilder invhtm = new StringBuilder();
                #region//加载表头
                invhtm.Append(btb.TempHead(iv.u.dcode.Substring(0, 8), emcode, ttype));
                #endregion
                #region//加载表体
                invhtm.Append(bidptb.QueryTableBody(sid,emcode, embcode, iv.u.dcode.Substring(0, 8),iv.u.rcode));
                #endregion
                #region//加载表脚
                invhtm.Append(btb.TempFoot(iv.u.dcode.Substring(0, 8), emcode, ttype));
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

        #region//获取工单产品Html
        [WebMethod(true)]
        public static string ProductionProduceDetail(string emcode, string sid, string ttype)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                StringBuilder invhtm = new StringBuilder();
                #region//加载表头
                invhtm.Append(bipptb.QueryTableHead(sid,iv.u.dcode.Substring(0, 8), emcode, ttype,"mzp"));
                #endregion
                #region//加载表体
               // invhtm.Append(bipptb.QueryTableBody(sid,"","",false));
                invhtm.Append(bidptb.QueryTableBody(sid, emcode, "-", iv.u.dcode.Substring(0, 8), iv.u.rcode));
                #endregion
                #region//加载表脚
                invhtm.Append(bipptb.QueryTableFoot(sid, iv.u.dcode.Substring(0, 8), emcode, ttype));
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

        #region//获取临时返修工单产品Html
        [WebMethod(true)]
        public static string AProductionProduceDetail(string emcode, string sid, string ttype)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                StringBuilder invhtm = new StringBuilder();
                #region//加载表头
                invhtm.Append(bipptb.QueryTableHead(sid, iv.u.dcode.Substring(0, 8), emcode, ttype, "mzp"));
                #endregion
                #region//加载表体
                invhtm.Append(bipptb.QueryAfterTableBody(sid, iv.u.dcode.Substring(0, 8), ttype, emcode));
                #endregion
                #region//加载表脚
                invhtm.Append(bipptb.QueryTableFoot(sid, iv.u.dcode.Substring(0, 8), emcode, ttype));
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

        #region//获取供货报价Html
        [WebMethod(true)]
        public static string ProductionPriceDetail(string emcode, string embcode, string sid, string ttype)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                StringBuilder invhtm = new StringBuilder();
                #region//加载表头
                invhtm.Append(bpigptb.QueryTableHead(sid, iv.u.dcode.Substring(0, 8), emcode, ttype));
                #endregion
                #region//加载表体
                invhtm.Append(bpigptb.QueryTableBody(sid, iv.u.dcode.Substring(0, 8), embcode, iv.u.rcode, ttype));
                #endregion
                #region//加载表脚
                invhtm.Append(bpigptb.QueryTableFoot(sid, iv.u.dcode.Substring(0, 8), emcode, ttype));
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

        #region//获取五金备货单Html
        [WebMethod(true)]
        public static string WjProductionOrderDetail(string emcode, string embcode, string sid, string ttype)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                StringBuilder invhtm = new StringBuilder();
                #region//加载表头
                invhtm.Append(btb.TempHead(iv.u.dcode.Substring(0, 8), emcode, ttype));
                #endregion
                #region//加载表体
                invhtm.Append(bidptb.QueryTableWjBody(sid, emcode, embcode, iv.u.dcode.Substring(0, 8), iv.u.rcode));
                #endregion
                #region//加载表脚
                invhtm.Append(btb.TempFoot(iv.u.dcode.Substring(0, 8), emcode, ttype));
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

        #region//获取木门更改单Html
        [WebMethod(true)]
        public static string ChangeProductionOrderDetail(string emcode, string embcode, string sid, string ttype)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                StringBuilder invhtm = new StringBuilder();
                #region//加载表头
                invhtm.Append(btb.TempHead(iv.u.dcode.Substring(0, 8), emcode, ttype));
                #endregion
                #region//加载表体
                invhtm.Append(bidptb.QueryTableChangeBody(sid, emcode, embcode, iv.u.dcode.Substring(0, 8), iv.u.rcode));
                #endregion
                #region//加载表脚
                invhtm.Append(btb.TempFoot(iv.u.dcode.Substring(0, 8), emcode, ttype));
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

        #region//获取售后单详情产品Html
        [WebMethod(true)]
        public static string AfterProductionOrderDetail(string emcode, string embcode, string sid, string ttype)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                StringBuilder invhtm = new StringBuilder();
                #region//加载表头
                invhtm.Append(btb.TempHead(iv.u.dcode.Substring(0, 8), emcode, ttype));
                #endregion
                #region//加载表体
                invhtm.Append(bipptb.QueryAfterTableBody(sid, embcode, iv.u.rcode, true));
                #endregion
                #region//加载表脚
                invhtm.Append(btb.TempFoot(iv.u.dcode.Substring(0, 8), emcode, ttype));
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

        #region//获取售后单详情产品Html
        [WebMethod(true)]
        public static string NewAfterProductionOrderDetail(string emcode, string embcode, string sid, string ttype)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                StringBuilder invhtm = new StringBuilder();
                #region//加载表头
                invhtm.Append(btb.TempHead(iv.u.dcode.Substring(0, 8), emcode, ttype));
                #endregion
                #region//加载表体
                invhtm.Append(bipptb.QueryAfterTableBody(sid, iv.u.dcode.Substring(0, 8),ttype,emcode, embcode, iv.u.rcode, true));
                #endregion
                #region//加载表脚
                invhtm.Append(btb.TempFoot(iv.u.dcode.Substring(0, 8), emcode, ttype));
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

        #region//获取供货报价Html
        [WebMethod(true)]
        public static string HtProductionPriceDetail(string sid, string ttype)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                StringBuilder invhtm = new StringBuilder();
                
                #region//加载表体
                invhtm.Append(bpigptb.QueryHtTableBody(sid, ttype));
                #endregion
                invhtm.Append(bpigptb.QueryHtTableFoot(sid, ttype));
                r = invhtm.ToString();
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion

        #region//获取详情产品Html
        [WebMethod(true)]
        public static string CustProductionOrderDetail(string emcode, string embcode, string sid, string ttype)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                StringBuilder invhtm = new StringBuilder();
                #region//加载表头
                invhtm.Append("<table width='100%' border='1'><tr><td height='39' colspan='14' align='center'>产品定制需求</td></tr><tr><td height='27' align='center'>序号</td><td align='center'>位置</td><td align='center'>开向</td> <td align='center'>门扇名称</td><td align='center'>门套名称</td><td align='center'>玻璃名称</td><td align='center'>玻璃工艺</td><td align='center'>锁孔</td><td align='center'>合页</td><td align='center'>洞口类型</td><td align='center'>尺寸</td><td align='center'>数量</td><td align='center'>说明</td><td align='center'>操作</td></tr>");
                #endregion
                #region//加载表体
                invhtm.Append(bidptb.CustQueryTableBody(sid, emcode, embcode, iv.u.dcode.Substring(0, 8), iv.u.rcode));
                #endregion
                #region//加载表脚
                invhtm.Append("</table>");
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