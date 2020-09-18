using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvBll.BusiOrderInfo;
using System.Web.Script.Serialization;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.BusiOrderInfo;
using LionvBll.BusiCommon;
using LionvModel.BusiCommon;
using System.Collections;
using System.Text;
using LionvModel.SysInfo;

namespace LionWap.UIServer
{
    public partial class WapFixOrder : System.Web.UI.Page
    {
        private static B_FixOrderBll bfb = new B_FixOrderBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        private static CB_OrderFlowBll cofb = new CB_OrderFlowBll();
        private static B_FixProductionBll bfpb = new B_FixProductionBll();
        private static B_FixGetGoodsImgBll bfggib = new B_FixGetGoodsImgBll();
        private static B_FixecImgBll bfib = new B_FixecImgBll();
        private static Sys_DomainBll sdb = new Sys_DomainBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod(true)]
        public static string QueryFixOrder(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_FixOrder bfo = bfb.Query(" and sid='" + sid + "'");
                if (bfo != null)
                {
                   CB_OrderFlow cof= cofb.Query(" and sid='"+sid+"' and [state]=1 order by id desc");
                    if(cof!=null)
                    {
                        if(cof.wcode=="0040")
                        {
                            bfo.fixstate="未安装";
                        }
                        if(cof.wcode=="0041")
                        {
                            bfo.fixstate="已确认";
                        }
                        if(cof.wcode=="0042"||cof.wcode=="0043")
                        {
                            bfo.fixstate="已安装";
                        }
                    }
                    B_FixGetGoodsImg sh = bfggib.Query(" and sid='" + sid + "'");
                    if (sh != null)
                    {
                        bfo.fixsh = 1;
                    }
                    B_FixecImg az = bfib.Query(" and sid='" + sid + "'");
                    if (az != null)
                    {
                        bfo.fixaz = 1;
                    }
                }
                r = js.Serialize(bfo);
            }
            else
            {
                r=iv.badstr;
            }
            return r;
        }
        #region//获取安装产品
        [WebMethod(true)]
        public static ArrayList QueryFixProduction(string sid)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<B_FixProduction> lsfp = bfpb.QueryList(" and sid='" + sid + "' order by id asc");
                if (lsfp != null)
                {
                    int k = 1;
                    foreach (B_FixProduction m in lsfp)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(k);
                        al.Add(m.pname);
                        al.Add(m.pnum);
                        r.Add(al);
                        k++;
                    }
                }
               
            }
            else
            {
                r.Add(iv.badstr);
            }
            return r;
        }
        #endregion
        #region//获取收货图片缩略图列表
         [WebMethod(true)]
        public static string QueryShFixImgListZip(string sid)
        {
            string r = "";
            StringBuilder divstr = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Domain wd = sdb.Query(" and dtype='w'");
                Sys_Domain pd = sdb.Query(" and dtype='p'");
                string wurl = wd==null?"":wd.url;
                string purl = pd == null ? "" : pd.url;
                List<B_FixGetGoodsImg> bfggi = bfggib.QueryList(" and sid='" + sid + "' order by id ");
                if (bfggi != null)
                {
                    divstr.Append("<div style='width:100%'>");
                    foreach (B_FixGetGoodsImg bg in bfggi)
                    {
                        divstr.Append("<div style='width:100px;height:100px;float:left'>");
                        divstr.Append("<div style='width:100px;height:20px;float:left'>");
                        divstr.AppendFormat("<img id='{0}' src='Image/sysimg/close.gif' style='cursor:pointer;float:right' onclick='DelShImg(this.id)'/>", bg.id);
                        divstr.Append("</div>");
                        divstr.Append("<div style='width:100px;height:80px;float:right'>");
                        if (bg.domain == "w")
                        {
                            divstr.AppendFormat("<img src='{0}' style='width:80px;height:80px;'/>",wurl+ bg.url);
                        }
                        if (bg.domain == "p")
                        {
                            divstr.AppendFormat("<img src='{0}' style='width:80px;height:80px;'/>", purl + bg.url);
                        }
                        divstr.Append("</div>");
                        divstr.Append("</div>");
                    }
                    divstr.Append("</div>");
                }
                r= divstr.ToString();
            }
            else
            {
                r= iv.badstr;
            }
            return r;
        }
        #endregion
        #region//删除收货图片
        [WebMethod(true)]
         public static string DelShFixImg(string id)
         {
             string r = "";
             StringBuilder divstr = new StringBuilder();
             SessionUserValidate iv = SysValidateBll.ValidateSession();
             if (iv.f)
             {
                 if (bfggib.Delete(" and id=" + id + " "))
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
         #endregion
        #region//获取收货图片列表
        [WebMethod(true)]
        public static string QueryShFixImgList(string sid)
        {
            string r = "";
            StringBuilder divstr = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Domain wd = sdb.Query(" and dtype='w'");
                Sys_Domain pd = sdb.Query(" and dtype='p'");
                string wurl = wd == null ? "" : wd.url;
                string purl = pd == null ? "" : pd.url;
                List<B_FixGetGoodsImg> bfggi = bfggib.QueryList(" and sid='" + sid + "' order by id ");
                if (bfggi != null)
                {
 
                    foreach (B_FixGetGoodsImg bg in bfggi)
                    {
                        if (bg.domain == "w")
                        {
                            divstr.AppendFormat("<li><img src='{0}' style='top:10px;left:10px;'/></li>", wurl + bg.url);
                        }
                        if (bg.domain == "p")
                        {
                            divstr.AppendFormat("<li><img src='{0}' style='top:10px;left:10px;'/></li>", purl + bg.url);
                        }
                    }
 
                }
                r = divstr.ToString();
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion

        #region//获取收货图片缩略图列表
        [WebMethod(true)]
        public static string QueryAzFixImgListZip(string sid)
        {
            string r = ""; ;
            StringBuilder divstr = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                List<B_FixecImg> bfggi = bfib.QueryList(" and sid='" + sid + "' order by id ");
                if (bfggi != null)
                {
                    Sys_Domain wd = sdb.Query(" and dtype='w'");
                    Sys_Domain pd = sdb.Query(" and dtype='p'");
                    string wurl = wd == null ? "" : wd.url;
                    string purl = pd == null ? "" : pd.url;
                    divstr.Append("<div style='width:100%'>");
                    foreach (B_FixecImg bg in bfggi)
                    {
                        divstr.Append("<div style='width:100px;height:100px;float:left'>");
                        divstr.Append("<div style='width:100px;height:20px;float:left'>");
                        divstr.AppendFormat("<img id='{0}' src='Image/sysimg/close.gif' style='cursor:pointer;float:right' onclick='DelAzImg(this.id)'/>", bg.id);
                        divstr.Append("</div>");
                        divstr.Append("<div style='width:100px;height:80px;float:right'>");
                        if (bg.domain == "w")
                        {
                            divstr.AppendFormat("<img src='{0}' style='width:80px;height:80px;'/>", wurl + bg.url);
                        }
                        if (bg.domain == "p")
                        {
                            divstr.AppendFormat("<img src='{0}' style='width:80px;height:80px;'/>", purl + bg.url);
                        }
                        divstr.Append("</div>");
                        divstr.Append("</div>");
                    }
                    divstr.Append("</div>");
                }
                r = divstr.ToString();
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region//获取收货图片缩略图列表
        [WebMethod(true)]
        public static string QueryAzFixImgList(string sid)
        {
            string r="";
            StringBuilder divstr = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                List<B_FixecImg> bfggi = bfib.QueryList(" and sid='" + sid + "' order by id ");
                if (bfggi != null)
                {
                    Sys_Domain wd = sdb.Query(" and dtype='w'");
                    Sys_Domain pd = sdb.Query(" and dtype='p'");
                    string wurl = wd == null ? "" : wd.url;
                    string purl = pd == null ? "" : pd.url;
                    foreach (B_FixecImg bg in bfggi)
                    {
                        if (bg.domain == "w")
                        {
                            divstr.AppendFormat("<li><img src='{0}' style='top:10px;left:10px;'/></li>", wurl + bg.url);
                        }
                        if (bg.domain == "p")
                        {
                            divstr.AppendFormat("<li><img src='{0}' style='top:10px;left:10px;'/></li>", purl + bg.url);
                        }
                    }
                }
                r= divstr.ToString();
            }
            else
            {
                r= iv.badstr;
            }
            return r;
        }
        #endregion
        #region//删除收货图片
        [WebMethod(true)]
        public static string DelAzFixImg(string id)
        {
            string r = "";
            StringBuilder divstr = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (bfib.Delete(" and id=" + id + " "))
                {
                    r = "S";
                }
                else
                {
                    r= "F";
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