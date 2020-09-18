using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using LionvBll.BusiOrderInfo;
using LionvModel.BusiOrderInfo;

namespace LionVERP.UIServer.CommonFile
{
    public partial class DownFile : System.Web.UI.Page
    {
        private B_MzRequstDesignBll bmrdpb = new B_MzRequstDesignBll();
        private B_MzDesignPlanBll bmdpb = new B_MzDesignPlanBll();
        private B_MzPriceFileBll bmpfb = new B_MzPriceFileBll();
        private B_AfterPriceFileBll bapfb = new B_AfterPriceFileBll();
        private B_AttachmentBll bmib = new B_AttachmentBll();
        private B_DesignPlanBll bdpb = new B_DesignPlanBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["sid"] != null)
            {
                string filePath = "";
                string fileName = "";
                string sid = Request.QueryString["sid"].ToString();
                string otype = Request.QueryString["otype"].ToString();
                string ftype = Request.QueryString["ftype"].ToString();
                bool urlencode = true;
                string brower = Request.Browser.Browser;
                if (brower == "Firefox")
                {
                    urlencode = false;
                }
                #region//附件
                if (otype == "")
                {
                    if (ftype == "a")
                    {
                        B_Attachment ba = bmib.Query(" and id=" + sid + "");
                        if (ba != null)
                        {
                            filePath = Server.MapPath(ba.furl);
                            fileName = ba.fname;
                        }
                    }
                    if (ftype == "d")
                    {
                        B_DesignPlan ba = bdpb.Query(" and id=" + sid + "");
                        if (ba != null)
                        {
                            filePath = Server.MapPath(ba.durl);
                            fileName = ba.dname;
                        }
                    }
                }
                #endregion
                #region//木门单下载
                #endregion
                #region//木作单下载
                if (otype == "mz")
                {
                    if (ftype == "rplan")
                    {
                        B_MzRequstDesign bp = bmrdpb.Query(" and id=" + sid + "");
                        if (bp != null)
                        {
                            filePath = Server.MapPath(bp.url);
                            fileName = bp.pname;
                        }
                    }
                    if (ftype == "plan")
                    {
                        B_MzDesignPlan bp = bmdpb.Query(" and id=" + sid + "");
                        if (bp != null)
                        {
                            filePath = Server.MapPath(bp.purl);
                            fileName = bp.pname;
                        }
                    }
                    if (ftype == "bj")
                    {
                        B_MzPriceFile bp = bmpfb.Query(" and id=" + sid + "");
                        if (bp != null)
                        {
                            filePath = Server.MapPath(bp.furl);
                            fileName = bp.fname;
                        }
                    }
                }
                #endregion
                #region//反馈单下载
                if (otype == "fk")
                {
                    if (ftype == "bj")
                    {
                        B_AfterPriceFile bp = bapfb.Query(" and id=" + sid + "");
                        if (bp != null)
                        {
                            filePath = Server.MapPath(bp.furl);
                            fileName = bp.fname;
                        }
                    }
                }
                #endregion
                if (filePath != "" && fileName != "")
                {
                    Downfiles(filePath, fileName, urlencode);
                }
            }
        }
        private void Downfiles(string filePath, string fileName, bool t)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open);
            byte[] bytes = new byte[(int)fs.Length];
            fs.Read(bytes, 0, bytes.Length);
            fs.Close();
            Response.ContentType = "application/octet-stream";
            if (t)
            {
                Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));
            }
            else
            {
                Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
            }
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }
    }
}