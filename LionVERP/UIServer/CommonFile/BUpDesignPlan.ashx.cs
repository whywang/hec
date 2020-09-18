using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LionvBll.SysInfo;
using LionvBll.BusiOrderInfo;
using LionvAopModel;
using System.Collections;
using LionvModel.BusiOrderInfo;
using System.IO;
using System.Web.SessionState;

namespace LionVERP.UIServer.CommonFile
{
    /// <summary>
    /// BUpDesignPlan 的摘要说明
    /// </summary>
    public class BUpDesignPlan : IHttpHandler, IRequiresSessionState 
    {

        public void ProcessRequest(HttpContext context)
        {
            string r = "", sid = "", place = "", pname = "", pnum = "", ptype = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            B_MzDesignPlanBll bmdpb = new B_MzDesignPlanBll();
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
                if (context.Request.QueryString["pnum"] != null)
                {
                    pnum = context.Request.QueryString["pnum"];
                }
                if (context.Request.QueryString["ptype"] != null)
                {
                    ptype = context.Request.QueryString["ptype"];
                }
                string newname = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                UpFile uf = new UpFile();
                ArrayList efile = new ArrayList();
                B_MzDesignPlan spi = new B_MzDesignPlan();
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
                    string sfname = SavePath + "/" + newname + Path.GetExtension(rfname);
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
                        List<B_TempUpFile> lufp = btufb.QueryList("and fname like '" + rfname + "' and sid='" + sid + "' order by fdate asc");
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
                            btufb.Delete(" and fname = '" + rfname + "' and sid='" + sid + "' ");
                            spi.sid = sid;
                            spi.maker = iv.u.ename;
                            spi.place = place;
                            spi.pname = pname + Path.GetExtension(rfname);
                            spi.pnum = Convert.ToInt32(pnum);
                            spi.purl = xsfname;
                            spi.ptype = ptype;
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