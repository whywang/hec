using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvBll.BusiOrderInfo;
using System.Collections;
using LionvModel.BusiOrderInfo;

namespace LionVERP.UIServer.CityService.DistributorService
{
    public partial class UpFixImg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            B_FixecImgBll bmib = new B_FixecImgBll();
            if (iv.f)
            {
                HttpFileCollection files = Request.Files;
                string sid = Request.QueryString["sid"];
                //string fixer = Request.QueryString["fixer"];
                //string fdate = Request.QueryString["fdate"];
                //string ps = Request.QueryString["ps"];
               // string bcode = Request.QueryString["bcode"];
                string newname = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                UpFile uf = new UpFile();
                ArrayList efile = new ArrayList();
                B_FixecImg spi = new B_FixecImg();

                string url = "/UpFile/ImageFixed/";
                string ur = uf.UpImage(files[0], newname, url, 1024000);
                if (ur.Length > 1)
                {
                    spi.sid = sid;
                    spi.maker = iv.u.ename;
                    spi.fixer = iv.u.ename;
                    spi.fdate = DateTime.Now.ToString();
                    spi.ps = "";
                    spi.domain = "p";
                    spi.url = url + ur;
                    spi.cdate = DateTime.Now.ToString();
                    bmib.Delete(" and sid='" + sid + "'");
                    if (bmib.Add(spi) > 0)
                    {
                        //BaseSet.WorkFlowManage.EventBtnDo.FireEventBtn(sid, bcode, "1", "安装完成");
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