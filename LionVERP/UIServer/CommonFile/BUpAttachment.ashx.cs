using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvBll.BusiOrderInfo;
using System.Collections;
using LionvModel.BusiOrderInfo;
using System.IO;
using System.Web.SessionState;
using LionvCommon;

namespace LionVERP.UIServer.CommonFile
{
    /// <summary>
    /// BUpAttachment 的摘要说明
    /// </summary>
    public class BUpAttachment : IHttpHandler,  IRequiresSessionState 
    {

        public void ProcessRequest(HttpContext context)
        {
            string r = "", sid = "", gsid = "", fname = "", ftype = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            B_AttachmentBll bmdpb = new B_AttachmentBll();
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
                if (context.Request.QueryString["gsid"] != null)
                {
                    gsid = context.Request.QueryString["gsid"];
                }
                if (context.Request.QueryString["fname"] != null)
                {
                    fname = context.Request.QueryString["fname"];
                }
                if (context.Request.QueryString["ftype"] != null)
                {
                    ftype = context.Request.QueryString["ftype"];
                }
                string newname = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                UpFile uf = new UpFile();
                ArrayList efile = new ArrayList();
                B_Attachment spi = new B_Attachment();
                HttpPostedFile file = files[0];
                if (sid != "")
                {
                    string[] f = pfname.Split('-');
                    if (f[1] == "0")
                    {
                        try
                        {
                            List<B_TempUpFile> lufp = btufb.QueryList("and fname like '" + rfname + "' and sid='" + sid + "' order by fdate asc");
                            if (lufp != null)
                            {
                                foreach (B_TempUpFile u in lufp)
                                {
                                    File.Delete(u.furl);
                                }
                                btufb.Delete(" and fname = '" + rfname + "' and sid='" + sid + "' ");
                            }
                        }
                        catch (Exception e)
                        {
                            Log4.WriteLog(e.ToString());
                        }
                    }
                    if (btufb.Exists(" and sid='" + sid + "' and fpname='" + pfname + "'"))
                    {
                    }
                    else
                    {
                        string url = "/UpFile/Attachment/Temp";
                        string durl = "/UpFile/Attachment/";
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
                        try
                        {
                            if (System.IO.File.Exists(fileName))
                            {
                                File.Delete(fileName);
                            }
                            file.SaveAs(fileName);
                            if (GetFileSize(fileName) != file.ContentLength)
                            {
                                r = "F";
                            }
                            else
                            {
                                btufb.Add(btuf);
                            }
                        }
                        catch
                        {
                            r = "F";
                        }
                        if (r != "F")
                        {
                            btufb.UpOver(" and sid='" + sid + "' and fpname='" + pfname + "'");
                            if (btufb.Exists(" and fname like '" + rfname + "%' and fsize<1000000 and sid='" + sid + "'"))
                            {
                                try
                                {
                                    List<B_TempUpFile> lufp = btufb.QueryList("and fname like '" + rfname + "' and sid='" + sid + "' order by fdate asc");
                                    if (lufp != null)
                                    {
                                        System.IO.FileStream fileStram = File.Open(sfname, FileMode.Create, FileAccess.Write);
                                        foreach (B_TempUpFile u in lufp)
                                        {
                                            FileStream save = new FileStream(u.furl, FileMode.Open, FileAccess.Read);
                                            byte[] bt = new byte[1024];
                                            int count = -1;
                                            while ((count = save.Read(bt, 0, bt.Length)) > 0)
                                            {
                                                fileStram.Write(bt, 0, count);
                                            }
                                            save.Close();
                                            save.Dispose();
                                        }
                                        fileStram.Close();
                                        fileStram.Dispose();
                                        spi.sid = sid;
                                        spi.gsid = gsid;
                                        spi.maker = iv.u.ename;
                                        spi.fname = fname + Path.GetExtension(rfname);
                                        spi.furl = xsfname;
                                        spi.ftype = ftype;
                                        spi.cdate = DateTime.Now.ToString();
                                        if (bmdpb.Add(spi) > 0)
                                        {
                                            r = "S";
                                        }
                                        else
                                        {
                                            r = "F";
                                        }
                                        foreach (B_TempUpFile u in lufp)
                                        {
                                            File.Delete(u.furl);
                                        }
                                        btufb.Delete(" and fname = '" + rfname + "' and sid='" + sid + "' ");
                                    }
                                }
                                catch (Exception e)
                                {
                                    Log4.WriteLog(e.ToString());
                                }
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
        public long GetFileSize(string sFullName)
        {
            long lSize = 0;
            if (File.Exists(sFullName))
                lSize = new FileInfo(sFullName).Length;
            return lSize;
        }
    }
}