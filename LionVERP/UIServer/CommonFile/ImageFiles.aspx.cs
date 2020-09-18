using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvBll.BusiOrderInfo;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using System.Collections;
using LionvModel.BusiOrderInfo;
using System.Text;
using LionvBll.BusiCommon;

namespace LionVERP.UIServer.CommonFile
{
    public partial class ImageFiles : System.Web.UI.Page
    {
        private readonly static B_SelectProduceImgBll bspib = new B_SelectProduceImgBll();
        private readonly static B_ProduceGyImgBll bpgib = new B_ProduceGyImgBll();
        private readonly static B_AttachmentBll bahb = new B_AttachmentBll();
        private readonly static B_PayImgBll bpb=new B_PayImgBll ();
        private readonly static B_FeedBackImgBll bfbib = new B_FeedBackImgBll();
        private readonly static B_ServiceImgBll bsib = new B_ServiceImgBll();
        private readonly static B_AfterProductionImgBll bapib = new B_AfterProductionImgBll();
        private readonly static B_MeasureImgBll bmib = new B_MeasureImgBll();
        private readonly static B_MeasureOrderBll bmob = new B_MeasureOrderBll();
        private readonly static B_DesignPlanBll bdpb = new B_DesignPlanBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region//选品单图片处理
        [WebMethod(true)]
        public static ArrayList QuerySelectProduceList(string sid)
        {
            ArrayList r = new ArrayList ();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add("S");
                List<B_SelectProduceImg> lbsp = bspib.QueryList(" and sid='" + sid + "'");
                if (lbsp != null)
                {
                    foreach (B_SelectProduceImg b in lbsp)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(b.xsid);
                        al.Add(b.xpname);
                        r.Add(al);
                    }
                }
            }
            else
            {
                r.Add(iv.badstr);
            }
            return r;
        }
        [WebMethod(true)]//删除选品图片
        public static string DelSelectProduce(string psid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (bspib.Delete(psid))
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
                r=iv.badstr;
            }
            return r;
        }
        [WebMethod(true)]//获取选品单图片Html
        public static string QuerySelectProduceHtm(string sid)
        {
            string r = "";
            StringBuilder htmstr = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                List<B_SelectProduceImg> lbsp = bspib.QueryList(" and sid='" + sid + "'");
                if (lbsp != null)
                {
                    htmstr.Append("<tabel style='width:100%'>");
                    foreach (B_SelectProduceImg b in lbsp)
                    {
                        htmstr.AppendFormat("<tr ><td style='height:25px'>图片名称</td><td style=' height:25px'>{0}</td></tr>", b.xpname);
                        htmstr.AppendFormat("<tr ><td colspan='2'><img src='{0}' alt=''/></td> </tr>", b.xpurl);
                    }
                    htmstr.Append("</tabel>");
                }
                r = htmstr.ToString();
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region//工艺图片处理
        [WebMethod(true)]
        public static ArrayList QueryGyProduceList(string sid)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add("S");
                List<B_ProduceGyImg> lbsp = bpgib.QueryList(" and sid='" + sid + "'");
                if (lbsp != null)
                {
                    foreach (B_ProduceGyImg b in lbsp)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(b.gsid);
                        al.Add(b.gname);
                        r.Add(al);
                    }
                }
            }
            else
            {
                r.Add(iv.badstr);
            }
            return r;
        }
        [WebMethod(true)]//删除选品图片
        public static string DelGyProduce(string psid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (bpgib.Delete(psid))
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
                r=iv.badstr;
            }
            return r;
        }
        [WebMethod(true)]//获取选品单图片Html
        public static string QueryGyProduceHtm(string sid)
        {
            string r = "";
            StringBuilder htmstr = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                List<B_ProduceGyImg> lbsp = bpgib.QueryList(" and sid='" + sid + "'");
                if (lbsp != null)
                {
                    htmstr.Append("<tabel style='width:100%'>");
                    foreach (B_ProduceGyImg b in lbsp)
                    {
                        htmstr.AppendFormat("<tr ><td style='background:#ABC9D3; height:25px'>图片名称</td><td style='background-color:#ABC9D3; height:25px'>{0}</td></tr>", b.gname);
                        htmstr.AppendFormat("<tr ><td colspan='2'><img src='{0}' alt=''/></td> </tr>", b.gurl);
                    }
                    htmstr.Append("</tabel>");
                }
                r = htmstr.ToString();
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region//附件处理
        [WebMethod(true)]
        public static ArrayList QueryAttachmentList(string sid,string gsid,string ftype)
        {
            ArrayList r = new ArrayList();
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add("S");
                if (ftype != "")
                {
                    where.AppendFormat(" and ftype='{0}'", ftype);
                }
                if (gsid != "")
                {
                    where.AppendFormat(" and gsid='{0}'", gsid);
                }
                if (sid != "")
                {
                    where.AppendFormat(" and sid='{0}'", sid);
                }
                List<B_Attachment> lbsp = bahb.QueryList(where.ToString());
                if (lbsp != null)
                {
                    foreach (B_Attachment b in lbsp)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(b.id);
                        al.Add(b.fname);
                        al.Add("<button id='" + b.id + "' onclick=\"DownFile(this.id&#44;''&#44;'a')\">下载</button>");
                        r.Add(al);
                    }
                }
            }
            else
            {
                r.Add(iv.badstr);
            }
            return r;
        }
        [WebMethod(true)]//删除选品附件
        public static string DelSelectAttachment(string psid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (bahb.Delete(" and id="+psid+""))
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
        #region//方案处理
        [WebMethod(true)]
        public static ArrayList QueryDesignList(string sid,string dtype)
        {
            ArrayList r = new ArrayList();
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add("S");
                if (sid != "")
                {
                    where.AppendFormat(" and osid='{0}' and dtype='{1}'", sid, dtype);
                }
                List<B_DesignPlan> lbsp = bdpb.QueryList(where.ToString());
                if (lbsp != null)
                {
                    foreach (B_DesignPlan b in lbsp)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(b.id);
                        al.Add(b.dname);
                        al.Add("<button id='" + b.id + "' onclick=\"DownFile(this.id&#44;''&#44;'d')\">下载</button>");
                        r.Add(al);
                    }
                }
            }
            else
            {
                r.Add(iv.badstr);
            }
            return r;
        }
        [WebMethod(true)]//删除选品附件
        public static string DelSelectDesign(string psid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (bdpb.Delete(" and id=" + psid + ""))
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
        #region//付款凭证图片
        [WebMethod(true)]
        public static ArrayList QueryPayImgList(string sid, string ptype)
        {
            ArrayList r = new ArrayList();
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add("S");
                if (sid != "")
                {
                    where.AppendFormat(" and sid='{0}' and ptype='{1}'", sid, ptype);
                }
                List<B_PayImg> lbsp = bpb.QueryList(where.ToString());
                if (lbsp != null)
                {
                    foreach (B_PayImg b in lbsp)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(b.id);
                        al.Add("<img id='"+b.id+"' src='"+b.url+ "' onclick='nck(this.id)'/>");
                        al.Add(b.remark);
                        r.Add(al);
                    }
                }
            }
            else
            {
                r.Add(iv.badstr);
            }
            return r;
        }
        [WebMethod(true)]//删除付款图片
        public static string DelPayImg(string pid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (bpb.Delete(" and id=" + pid + ""))
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
        [WebMethod(true)]//获取付款图片Html
        public static string QueryPayImgHtml(string sid,string ptype)
        {
            string r = "";
            StringBuilder htm = new StringBuilder();
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sid != "")
                {
                    where.AppendFormat(" and sid='{0}' and ptype='{1}'", sid, ptype);
                }
                 List<B_PayImg> lbsp = bpb.QueryList(where.ToString());
                if (lbsp != null)
                {
                    htm.Append("<table width='100%' border='1'><tr><td height='40' colspan='2' align='center'><span style='font-size:16px; color:#666666'>收款凭证</span></td> </tr>");
                    int xh=1;
                    foreach (B_PayImg b in lbsp)
                    {
                        htm.AppendFormat("<tr><td width='50' rowspan='2' align='center'>{0}</td>", xh);
                        htm.AppendFormat("<td width='950'><img id='{0}' src='{1}' alt=''onclick='nck(this.id)'/></td></tr>", b.id, b.url);
                        htm.AppendFormat("<tr><td height='25'>{0}</td></tr>", b.remark);
                       xh++;
                    }
                    htm.Append("</table>");
                }
                r = htm.ToString();
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region//反馈单图片
        [WebMethod(true)]
        public static ArrayList QueryAfterImgList(string sid)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add("S");
                List<B_FeedBackImg> lbsp = bfbib.QueryList(" and sid='" + sid + "'");
                if (lbsp != null)
                {
                    foreach (B_FeedBackImg b in lbsp)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(b.id);
                        al.Add(b.iname);
                        al.Add(b.remark);
                        al.Add("<img src='" + b.url + "' alt=''/>");
                        r.Add(al);
                    }
                }
            }
            else
            {
                r.Add(iv.badstr);
            }
            return r;
        }
        [WebMethod(true)]//删除反馈图片
        public static string DelAfterImg(string psid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (bfbib.Delete(" and id="+psid+""))
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
        #region// 反馈单图片列表
        [WebMethod(true)]
        public static string AfterImgShow(string sid)
        {
            string rr = "";
            StringBuilder r = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                List<B_FeedBackImg> lb = new List<B_FeedBackImg>();
                lb = bfbib.QueryList(" and sid='" + sid + "'");
                if (lb != null)
                {
                    r.Append("<table style='width:100%'>");
                    r.Append("<tr style='background:#f2f2f2; height:30px'>");
                    r.Append("<td style='background:#f2f2f2; height:30px; width:10%' align='center'><span style='font-size:16px; font-weight:bolder;color:#666666'>名称</span></td>");
                    r.Append("<td style='background:#f2f2f2; height:30px' align='center'><span style='font-size:16px; font-weight:bolder;color:#666666'>详情</span></td>");
                    r.Append("</tr>");
                    foreach (B_FeedBackImg b in lb)
                    {
                        r.Append("<tr>");
                        r.Append("<td style=' height:25px' align='center'><span style='font-size:14px; font-weight:bolder;color:#666666'>名称</span></td>");
                        r.Append("<td  align='left'>" + b.iname + "</td>");
                        r.Append("<tr>");
                        r.Append("<tr>");
                        r.Append("<td   style=' height:25px 'align='center'><span style='font-size:14px; font-weight:bolder;color:#666666'>说明</span></td>");
                        r.Append("<td  align='left'>" + b.remark + "</td>");
                        r.Append("<tr>");
                        r.Append("<tr>");
                        r.Append("<td style=' height:25px' align='center'><span style='font-size:14px; font-weight:bolder;color:#666666'>图片</span></td>");
                        r.Append("<td><img id='F" + b.id + "' src='" + b.url + "' onclick='nck(this.id)'/></td>");
                        r.Append("</tr>");
                        r.Append("<tr>");
                        r.Append("<td style=' background:#f2f2f2;height:5px' colspan='2'> &nbsp;</td>");
                        r.Append("<tr>");

                    }
                    r.Append("</table>");
                }
                rr = r.ToString();
            }
            else
            {
                rr = iv.badstr;
            }
            return rr;
        }
        #endregion
        #endregion
        #region//服务单
        [WebMethod(true)]
        public static string QueryServiceImgHtm(string sid)
        {
            string r = "";
            StringBuilder htxt = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                htxt.Append("<div class='cimg' style='width:100%; height:100px;'><ul>");
                List<B_ServiceImg> lbsp = bsib.QueryList(" and sid='" + sid + "'");
                if (lbsp != null)
                {
                    foreach (B_ServiceImg b in lbsp)
                    {
                        htxt.Append("<li style='width:80px; height:100px;float:left;border:1px solid #cccccc; margin-left:10px'><ul style='margin-left:-40px'>");
                        htxt.AppendFormat("<li style='width:80px; height:18px;background:#91baf2'><img src='../../../Image/opeimage/dele.png' alt='' id='{0}' style='cursor:pointer;float:right' onclick='DelImg(this.id)'/></li>", b.id);
                        htxt.AppendFormat(" <li style='width:80px; height:80px;'><img src='{0}' alt=''style='width:80px; height:80px;'/></li>", b.iurl);
                        htxt.Append("</ul></li>");
                    }
                }
                htxt.Append("</ul></div>");
                r = htxt.ToString();
            }
            else
            {
                r=iv.badstr;
            }
            return r;
        }
        [WebMethod(true)]//删除图片
        public static string DelServiceImg(string id)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (bsib.Delete(" and id=" + id + ""))
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
        [WebMethod(true)]
        public static string ServiceImgShow(string sid)
        {
            string rr = "";
            StringBuilder r = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                List<B_ServiceImg> lb = new List<B_ServiceImg>();
                lb = bsib.QueryList(" and sid='" + sid + "'");
                if (lb != null)
                {
                    r.Append("<table style='width:100%'>");
                    foreach (B_ServiceImg b in lb)
                    {
                        r.Append("<tr>");
                        r.Append("<td style=' height:25px; width:100px' align='center'><span style='font-size:14px; font-weight:bolder;color:#666666'>图片</span></td>");
                        r.Append("<td><img id='F" + b.id + "' src='" + b.iurl + "' onclick='nck(this.id)'/></td>");
                        r.Append("</tr>");
                        r.Append("<tr>");
                        r.Append("<td style=' background:#f2f2f2;height:5px' colspan='2'> &nbsp;</td>");
                        r.Append("<tr>");
                    }
                    r.Append("</table>");
                }
                rr = r.ToString();
            }
            else
            {
                rr = iv.badstr;
            }
            return rr;
        }
        #endregion
        #region//售后产品图
        [WebMethod(true)]
        public static string QueryAfterProductionImgHtm(string sid,string gnum)
        {
            string r = "";
            StringBuilder htxt = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                htxt.Append("<div class='cimg' style='width:100%; height:100px;'><ul>");
                List<B_AfterProductionImg> lbsp = bapib.QueryList(" and sid='" + sid + "' and gnum=" + gnum + "");
                if (lbsp != null)
                {
                    foreach (B_AfterProductionImg b in lbsp)
                    {
                        htxt.Append("<li style='width:80px; height:100px;float:left;border:1px solid #cccccc; margin-left:10px'><ul style='margin-left:-40px'>");
                        htxt.AppendFormat("<li style='width:80px; height:18px;background:#91baf2'><img src='../../../Image/opeimage/dele.png' alt='' id='{0}' style='cursor:pointer;float:right' onclick='DelImg(this.id)'/></li>", b.id);
                        htxt.AppendFormat(" <li style='width:80px; height:80px;'><img src='{0}' alt=''style='width:80px; height:80px;'/></li>", b.url);
                        htxt.Append("</ul></li>");
                    }
                }
                htxt.Append("</ul></div>");
                r = htxt.ToString();
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        [WebMethod(true)]//删除图片
        public static string DelAfterProductionImg(string id)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (bapib.Delete(id))
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
        [WebMethod(true)]
        public static string AfterProductionImgShow(string sid,string gnum)
        {
            string rr = "";
            StringBuilder r = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                List<B_AfterProductionImg> lb = new List<B_AfterProductionImg>();
                lb = bapib.QueryList(" and sid='" + sid + "'");
                if (lb != null)
                {
                    r.Append("<table style='width:100%'>");
                    foreach (B_AfterProductionImg b in lb)
                    {
                        r.Append("<tr>");
                        r.Append("<td style=' height:25px; width:100px' align='center'><span style='font-size:14px; font-weight:bolder;color:#666666'>图片</span></td>");
                        r.Append("<td><img id='F" + b.id + "' src='" + b.url + "' onclick='nck(this.id)'/></td>");
                        r.Append("</tr>");
                        r.Append("<tr>");
                        r.Append("<td style=' background:#f2f2f2;height:5px' colspan='2'> &nbsp;</td>");
                        r.Append("<tr>");
                    }
                    r.Append("</table>");
                }
                rr = r.ToString();
            }
            else
            {
                rr = iv.badstr;
            }
            return rr;
        }
        #endregion

        #region//测量单
        [WebMethod(true)]
        public static string QueryMeasureImgHtm(string sid)
        {
            string r = "";
            StringBuilder htxt = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                htxt.Append("<div class='cimg' style='width:100%; height:100px;'><ul>");
                List<B_MeasureImg> lbsp = bmib.QueryList(" and csid='" + sid + "'");
                if (lbsp != null)
                {
                    foreach (B_MeasureImg b in lbsp)
                    {
                        htxt.Append("<li style='width:80px; height:100px;float:left;border:1px solid #cccccc; margin-left:10px'><ul style='margin-left:-40px'>");
                        htxt.AppendFormat("<li style='width:80px; height:18px;background:#91baf2'><img src='../../../Image/opeimage/dele.png' alt='' id='{0}' style='cursor:pointer;float:right' onclick='DelImg(this.id)'/></li>", b.id);
                        htxt.AppendFormat(" <li style='width:80px; height:80px;'><img src='{0}' alt=''style='width:80px; height:80px;'/></li>", b.url);
                        htxt.Append("</ul></li>");
                    }
                }
                htxt.Append("</ul></div>");
                r = htxt.ToString();
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        [WebMethod(true)]//删除图片
        public static string DelMeasureImg(string id)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (bmib.Delete(" and id=" + id + ""))
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
        [WebMethod(true)]
        public static string MeasureImgShow(string sid)
        {
            string rr = "";
            StringBuilder r = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                List<B_MeasureImg> lb = new List<B_MeasureImg>();
                lb = bmib.QueryList(" and csid='" + sid + "'");
                if (lb != null)
                {
                    r.Append("<table style='width:100%'>");
                    foreach (B_MeasureImg b in lb)
                    {
                        r.Append("<tr>");
                        r.Append("<td style=' height:25px; width:100px' align='center'><span style='font-size:14px; font-weight:bolder;color:#666666'>图片</span></td>");
                        r.Append("<td><img id='F" + b.id + "' src='" + b.url + "' onclick='nck(this.id)'/></td>");
                        r.Append("</tr>");
                        r.Append("<tr>");
                        r.Append("<td style=' background:#f2f2f2;height:5px' colspan='2'> &nbsp;</td>");
                        r.Append("<tr>");
                    }
                    r.Append("</table>");
                }
                rr = r.ToString();
            }
            else
            {
                rr = iv.badstr;
            }
            return rr;
        }
        //销售单显示测量单
        [WebMethod(true)]
        public static string OMeasureImgShow(string sid)
        {
            string rr = "";
            StringBuilder r = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_MeasureOrder bmo = bmob.Query(" and osid='" + sid + "'"); 
                List<B_MeasureImg> lb = new List<B_MeasureImg>();
                lb = bmib.QueryList(" and csid='" + bmo.sid + "'");
                if (lb != null)
                {
                    r.Append("<table style='width:100%'>");
                    foreach (B_MeasureImg b in lb)
                    {
                        r.Append("<tr>");
                        r.Append("<td style=' height:25px; width:100px' align='center'><span style='font-size:14px; font-weight:bolder;color:#666666'>图片</span></td>");
                        r.Append("<td><img id='F" + b.id + "' src='" + b.url + "' onclick='nck(this.id)'/></td>");
                        r.Append("</tr>");
                        r.Append("<tr>");
                        r.Append("<td style=' background:#f2f2f2;height:5px' colspan='2'> &nbsp;</td>");
                        r.Append("<tr>");
                    }
                    r.Append("</table>");
                }
                rr = r.ToString();
            }
            else
            {
                rr = iv.badstr;
            }
            return rr;
        }
        #endregion
    }
}