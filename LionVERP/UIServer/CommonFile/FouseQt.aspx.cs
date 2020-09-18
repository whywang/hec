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
using LionvBll.WxChat;
using LionvModel.WxChat;
using LionvModel.SysInfo;

namespace LionVERP.UIServer.CommonFile
{
    public partial class FouseQt : System.Web.UI.Page
    {
        private static QrCodeBll qcb = new QrCodeBll();
        private static Sys_WxChatConfigBll swccb = new Sys_WxChatConfigBll();
        private static Sys_DomainBll sdb = new Sys_DomainBll();
        private static Sys_EmplyeeFouseWxBll sefwb = new Sys_EmplyeeFouseWxBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region///获取微信二位码
        [WebMethod(true)]
        public static string QueryQtImg()
        {
            string r = "F";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string url = "";
                Sys_Domain sd = sdb.Query(" and dtype='p'");
                Sys_WxChatConfig wc=swccb.Query(" and acode='0001'");
                if (wc != null)
                {
                    url = "https://open.weixin.qq.com/connect/oauth2/authorize?appid="+wc.appid+"&redirect_uri="+wc.aurl+"&response_type=" + iv.u.eno + "&scope=snsapi_userinfo&state=STATE#wechat_redirect";
                    string img= qcb.CreateFQtCode(System.Web.HttpContext.Current.Server.MapPath("/UpFile/ImageMeasure/"), url);
                    swccb.setImg("0001", "/UpFile/ImageMeasure/" + img);
                    //r = sd.url+"/UpFile/ImageMeasure/" + img;
                    r = "../../../UpFile/ImageMeasure/" + img;
                }
            }
            else
            {
                r ="F";
            }
            return r;
        }
        #endregion
        #region///获取微信二位码
        [WebMethod(true)]
        public static string CheckFouse()
        {
            string r = "F";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_EmplyeeFouseWx sef = sefwb.Query(" and ename='" + iv.u.eno + "'");
                if (sef != null)
                {
                    r = "S";
                }
            }
            else
            {
                r = "F";
            }
            return r;
        }
        #endregion
        #region///取消微信二位码
        [WebMethod(true)]
        public static string DelFouse()
        {
            string r = "F";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sefwb.Delete(" and ename='" + iv.u.eno + "'"))
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
            return r;
        }
        #endregion
    }

}