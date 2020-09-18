using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvBll.SysInfo;
using LionvAopModel;
using System.Text;
using LionvModel.BusiOrderInfo;
using LionvCommonBll;
using LionvBll.BusiCommon;
using LionvBll.BusiOrderInfo;
using LionvModel.SysInfo;
using LionvModel.BusiCommon;

namespace LionVERP.UIServer.CommonFile
{
    public partial class OrderAttrs : System.Web.UI.Page
    {
        private static BusiOrderStateBll bosb = new BusiOrderStateBll();
        private static CB_OrderProduceTypeBll coptb = new CB_OrderProduceTypeBll();
        private static CB_ButtonEventBll snsb = new CB_ButtonEventBll();
        private static B_AttachmentBll bmib = new B_AttachmentBll();
        private static Sys_DomainBll sdb = new Sys_DomainBll();
        private static CB_OrderStateBll cbsb = new CB_OrderStateBll();
        private static B_FeedBackImgBll bfbib = new B_FeedBackImgBll();
        private static B_DesignPlanBll bdpb = new B_DesignPlanBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region///销售订单状态属性图
        [WebMethod(true)]
        public static string OrderAttrImg(string sid)
        {
            string r = "";
            StringBuilder hstr = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Domain sd = sdb.Query(" and dtype='p'");
                string zt = bosb.QueryOrderStateImg(sid);
                B_Attachment ba = bmib.Query(" and sid='" + sid + "'");
                CB_OrderState cos=cbsb.Query("and sid='" + sid + "'");
                CB_OrderProduceType ct = coptb.Query("and sid='" + sid + "'");
                B_FeedBackImg bfi = bfbib.Query(" and sid='" + sid + "'");
                B_DesignPlan bdp=bdpb.Query(" and osid='" + sid + "' and dtype='0'");
                B_DesignPlan bdpt = bdpb.Query(" and osid='" + sid + "' and dtype='1'");
                hstr.Append("<table style='border:none; width:100%'> ");
                hstr.AppendFormat("<tr><td align='center' height='40'><strong>状态：</strong></td><td align='center'><img src='{0}'></td></tr>", zt);
                hstr.AppendFormat("<tr><td align='center'height='40'><strong>日志：</strong></td><td align='center'><img src='" + sd.url + "/Image/opeimage/makep.png' id='{0}' onclick='ShowLogs(this.id)' style='cursor:pointer'/></td></tr>", sid);
                if (ba != null)
                {
                    hstr.AppendFormat("<tr><td align='center'height='40'><strong>附件：</strong></td><td align='center'><img src='" + sd.url + "/Image/opeimage/zip.gif' id='{0}' onclick='ShowAttachment(this.id)'style='cursor:pointer'/></td></tr>", sid);
                }
                if (bdp != null)
                {
                    hstr.AppendFormat("<tr><td align='center'height='40'><strong>方案：</strong></td><td align='center'><img src='" + sd.url + "/Image/opeimage/design.gif' id='{0}' onclick='ShowDesign(this.id,0)'style='cursor:pointer'/></td></tr>", sid);
                }
                if (bdpt != null)
                {
                    hstr.AppendFormat("<tr><td align='center'height='40'><strong>二次方案：</strong></td><td align='center'><img src='" + sd.url + "/Image/opeimage/design.gif' id='{0}' onclick='ShowDesign(this.id,1)'style='cursor:pointer'/></td></tr>", sid);
                }
                if (bfi != null)
                {
                    hstr.AppendFormat("<tr><td align='center'height='40'><strong>售后：</strong></td><td align='center'><img src='" + sd.url + "/Image/opeimage/afterimg.gif' id='{0}' onclick='ShowAfterImg()'style='cursor:pointer'/></td></tr>", sid);
                }
                if (ct != null)
                {
                    if (ct.gytype == "线上")
                    {
                        hstr.AppendFormat("<tr><td align='center'height='40'><strong>生产：</strong></td><td align='center'><img src='" + sd.url + "/Image/opeimage/online.gif'  style='cursor:pointer'/></td></tr>");
                    }
                    if (ct.gytype == "线下")
                    {
                        hstr.AppendFormat("<tr><td align='center'height='40'><strong>生产：</strong></td><td align='center'><img src='" + sd.url + "/Image/opeimage/offline.gif'  style='cursor:pointer'/></td></tr>");
                    }
                }
                if (cos != null)
                {
                    if (cos.inewpp>0)
                    {
                        hstr.AppendFormat("<tr><td align='center'height='40'><strong>新报价：</strong></td><td align='center'><img src='" + sd.url + "/Image/opeimage/nbj.png' id='{0}' style='cursor:pointer'/></td></tr>", sid);
                    }
                    if (cos.ipdraw == 1)
                    {
                        hstr.AppendFormat("<tr><td align='center'height='40'><strong>绘图中：</strong></td><td align='center'><img src='" + sd.url + "/Image/opeimage/drawing.png' id='{0}' style='cursor:pointer'/></td></tr>", sid);
                    }
                    if (cos.ipdraw == 2)
                    {
                        hstr.AppendFormat("<tr><td align='center'height='40'><strong>已绘图：</strong></td><td align='center'><img src='" + sd.url + "/Image/opeimage/drawed.png' id='{0}' onclick='ShowDrawImage(this.id)'style='cursor:pointer'/></td></tr>", sid);
                    }
                    if (cos.imeasure == 1)
                    {
                        hstr.AppendFormat("<tr><td align='center'height='40'><strong>测量中：</strong></td><td align='center'><img src='" + sd.url + "/Image/opeimage/measuring.png' id='{0}' style='cursor:pointer'/></td></tr>", sid);
                    }
                    if (cos.imeasure == 2)
                    {
                        hstr.AppendFormat("<tr><td align='center'height='40'><strong>已测量：</strong></td><td align='center'><img src='" + sd.url + "/Image/opeimage/measured.png' id='{0}' style='cursor:pointer'/></td></tr>", sid);
                    }
                }
                 
                hstr.Append("</table>");
                r = hstr.ToString();
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///销售订单状态属性图
        [WebMethod(true)]
        public static string PrepareOrderAttrImg(string sid)
        {
            string r = "";
            StringBuilder hstr = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Domain sd = sdb.Query(" and dtype='p'");
                string zt = bosb.QueryOrderStateImg(sid);
                B_Attachment ba = bmib.Query(" and sid='" + sid + "'");
                CB_OrderState cos = cbsb.Query("and sid='" + sid + "'");
                hstr.Append("<table style='border:none; width:100%'> ");
                hstr.AppendFormat("<tr><td align='center' height='40'><strong>状态：</strong></td><td align='center'><img src='{0}'></td></tr>", zt);
                hstr.AppendFormat("<tr><td align='center'height='40'><strong>日志：</strong></td><td align='center'><img src='" + sd.url + "/Image/opeimage/makep.png' id='{0}' onclick='ShowLogs(this.id)' style='cursor:pointer'/></td></tr>", sid);
                if (ba != null)
                {
                    hstr.AppendFormat("<tr><td align='center'height='40'><strong>附件：</strong></td><td align='center'><img src='" + sd.url + "/Image/opeimage/zip.gif' id='{0}' onclick='ShowAttachment(this.id)'style='cursor:pointer'/></td></tr>", sid);
                }
                if (cos != null)
                {
                    if (cos.iproduce > 0)
                    {
                        hstr.AppendFormat("<tr><td align='center'height='40'><strong>工单：</strong></td><td align='center'><img src='" + sd.url + "/Image/opeimage/has.png' id='{0}' style='cursor:pointer'/></td></tr>", sid);
                    }
                    else
                    {
                        hstr.AppendFormat("<tr><td align='center'height='40'><strong>工单：</strong></td><td align='center'><img src='" + sd.url + "/Image/opeimage/cancel.png' id='{0}' style='cursor:pointer'/></td></tr>", sid);
                    }
                    if (cos.iwjbh > 0)
                    {
                        hstr.AppendFormat("<tr><td align='center'height='40'><strong>备货：</strong></td><td align='center'><img src='" + sd.url + "/Image/opeimage/has.png' id='{0}' style='cursor:pointer'/></td></tr>", sid);
                    }
                    else
                    {
                        hstr.AppendFormat("<tr><td align='center'height='40'><strong>备货：</strong></td><td align='center'><img src='" + sd.url + "/Image/opeimage/cancel.png' id='{0}' style='cursor:pointer'/></td></tr>", sid);
                    }
                }
                hstr.Append("</table>");
                r = hstr.ToString();
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region//生产单状态显示
        [WebMethod(true)]
        public static string OrderProduceState(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = bosb.QueryOrderProduceState(sid);
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