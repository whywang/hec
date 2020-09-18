using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.SysInfo;

namespace LionVERP.UIServer.BaseSet.WorkFlowManage
{
    public partial class UpBtnImg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string r = "";
            string bname = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            Sys_BtnImgBll bmib = new Sys_BtnImgBll();
            if (iv.f)
            {
                HttpFileCollection files = Request.Files;
                bname = Request.QueryString["bname"];
                string gurl = "";
                string newname = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                UpFile uf = new UpFile();
                string url = "/Image/iconbtn/";
                string ur = uf.UpImage(files[0], newname, url, 10240000);
                if (ur.Length > 1)
                {
                    gurl = url + ur;
                    Sys_BtnImg sbi = new Sys_BtnImg();
                    sbi.bcode = bmib.CreateCode().ToString().PadLeft(4, '0');
                    sbi.bname = bname;
                    sbi.burl = gurl;
                    if (bmib.Add(sbi) > 0)
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