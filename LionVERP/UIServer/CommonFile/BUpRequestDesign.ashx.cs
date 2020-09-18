using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvBll.BusiOrderInfo;
using System.Collections;
using System.IO;
using LionvModel.BusiOrderInfo;

namespace LionVERP.UIServer.CommonFile
{
    /// <summary>
    /// BUpRequestDesign 的摘要说明
    /// </summary>
    public class BUpRequestDesign : IHttpHandler, IRequiresSessionState 
    {

        public void ProcessRequest(HttpContext context)
        {
            string r = "", sid = "", place = "", pname = "", fdrq = "", fdrk = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            B_MzRequstDesignBll bmdpb = new B_MzRequstDesignBll();
            B_TempUpFileBll btufb = new B_TempUpFileBll();
            if (iv.f)
            {
                string rfname = context.Request["fileName"].ToString();
                string pfname = context.Request["partName"].ToString();
                HttpFileCollection files = context.Request.Files;
                if (context.Request.QueryString["sid"] != null)
                {
                    sid = context.Request.QueryString["sid"];
                }
                if (context.Request.QueryString["fplace"] != null)
                {
                    place = context.Request.QueryString["fplace"];
                }
                if (context.Request.QueryString["fname"] != null)
                {
                    pname = context.Request.QueryString["fname"];
                }
                if (context.Request.QueryString["fdrq"] != null)
                {
                    fdrq = context.Request.QueryString["fdrq"];
                }
                if (context.Request.QueryString["fdrk"] != null)
                {
                    fdrk = context.Request.QueryString["fdrk"];
                }
                string newname = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                UpFile uf = new UpFile();
                ArrayList efile = new ArrayList();
                B_MzRequstDesign spi = new B_MzRequstDesign();
                HttpPostedFile file = files[0];
                if (btufb.Exists(" and sid='" + sid + "' and fname='" + pfname + "'"))
                {
                }
                else
                {
                    string url = "/UpFile/DesignPlan/Temp";
                    string durl = "/UpFile/DesignPlan";
                    string temSavePath = context.Server.MapPath(url);
                    string SavePath = context.Server.MapPath(durl);
                    string saveFileName = String.Format("{0}{1}", DateTime.Now.ToString("yyyyMMddhhmmssffff"), Path.GetExtension(rfname));//保存文件名称
                    string fileName = String.Format(@"{0}\{1}", temSavePath, saveFileName);
                    string sfname=SavePath + "/" + newname + Path.GetExtension(rfname);
                    string xsfname = durl + "/" + newname + Path.GetExtension(rfname);
                    B_TempUpFile btuf = new B_TempUpFile();
                    btuf.sid = sid;
                    btuf.fname = rfname;
                    btuf.fover = 0;
                    btuf.fpname = pfname;
                    btuf.fsize = file.ContentLength;
                    btuf.furl = fileName;
                    btufb.Add(btuf);
                    file.SaveAs(fileName);
                    btufb.UpOver(" and sid='" + sid + "' and fpname='" + pfname + "'");
                    if (btufb.Exists(" and fname like '" + rfname + "%' and fsize<1000000"))
                    {
                        List<B_TempUpFile> lufp = btufb.QueryList("and fname like '" + rfname + "' and sid='"+sid+"' order by fdate asc");
                        if (lufp != null)
                        {
                            using (System.IO.FileStream fileStram = File.Open(sfname, FileMode.Create, FileAccess.Write))
                            {
                                foreach (B_TempUpFile u in lufp)
                                {
                                    using (FileStream save = new FileStream(u.furl, FileMode.Open, FileAccess.Read))
                                    {
                                        byte[] bt = new byte[1024];
                                        int count = -1;
                                        while ((count = save.Read(bt, 0, bt.Length)) > 0)
                                        {
                                            fileStram.Write(bt, 0, count);
                                        }
                                    }
                                }
                            }
                            foreach (B_TempUpFile u in lufp)
                            {
                                File.Delete(u.furl);
                            }
                            btufb.Delete(" and fname = '" + rfname + "' and sid='"+sid+"' ");
                            spi.sid = sid;
                            spi.maker = iv.u.ename;
                            spi.place = place;
                            spi.pname = pname + Path.GetExtension(rfname);
                            spi.pdemo = fdrk;
                            spi.url = xsfname;
                            spi.preqest = fdrq;
                            spi.cdate = DateTime.Now.ToString();
                            if (bmdpb.Add(spi) > 0)
                            {
                                r = "S";
                            }
                            else
                            {
                                r = "F";
                            }
                        }
                    }
                }
            }
            else
            {
                r = iv.badstr;
            }
           
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}