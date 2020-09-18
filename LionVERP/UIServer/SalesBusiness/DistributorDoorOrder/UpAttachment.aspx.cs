using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvAopModel;
using LionvBll.BusiOrderInfo;
using LionvBll.SysInfo;
using System.Collections;
using LionvModel.BusiOrderInfo;

namespace LionVERP.UIServer.SalesBusiness.DistributorOrder
{
    public partial class UpAttachment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string r = "", sid = "", gsid = "", fname = "", ftype="";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            B_AttachmentBll bmib = new B_AttachmentBll();
            if (iv.f)
            {
                HttpFileCollection files = Request.Files;
                if (Request.QueryString["sid"] != null)
                {
                    sid = Request.QueryString["sid"];
                }
                if (Request.QueryString["gsid"] != null)
                {
                    gsid = Request.QueryString["gsid"];
                }
                if (Request.QueryString["fname"] != null)
                {
                    fname = Request.QueryString["fname"];
                }
                if (Request.QueryString["ftype"] != null)
                {
                    ftype = Request.QueryString["ftype"];
                }
                string newname = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                UpFile uf = new UpFile();
                ArrayList efile = new ArrayList();
                B_Attachment spi = new B_Attachment();
                string url = "/UpFile/Attachment/";
                string ur = uf.UpFiles(files[0], newname, url, 102400000);
                if (ur.Length > 1)
                {
                   string xname= uf.GetFileExName(files[0]);
                    spi.sid = sid;
                    spi.gsid = gsid;
                    spi.maker = iv.u.ename;
                    spi.fname = fname + xname;
                    spi.furl = url + ur;
                    spi.ftype = ftype;
                    spi.cdate = DateTime.Now.ToString();
                    if (bmib.Add(spi) > 0)
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
                    r = ur;
                }
            }
            else
            {
                r = iv.badstr;
            }
            Response.Write("{  msg:'" + r + "'}");
            Response.End();
        }
    }
}