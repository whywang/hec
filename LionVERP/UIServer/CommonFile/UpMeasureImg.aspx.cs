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

namespace LionVERP.UIServer.CommonFile
{
    public partial class UpMeasureImg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            B_MeasureImgBll bmib = new B_MeasureImgBll();
            if (iv.f)
            {
                HttpFileCollection files = Request.Files;
                string csid = Request.QueryString["sid"];
                string clname = Request.QueryString["clname"];
                string newname = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                UpFile uf = new UpFile();
                ArrayList efile = new ArrayList();
                B_MeasureImg spi = new B_MeasureImg();

                string url = "/UpFile/ImageMeasure/";
                string ur = uf.UpImage(files[0], newname, url, 10240000);
                if (ur.Length > 1)
                {
                    spi.csid = csid;
                    spi.maker = iv.u.ename;
                    spi.imgname = clname;
                    spi.url = url + ur;
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