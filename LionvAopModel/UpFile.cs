using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Collections;
using System.IO;

namespace LionvAopModel
{
   public class UpFile
    {
       public string UpImage(HttpPostedFile file,string fname, string url, int filelen)
       {
           string r = "";
           HttpPostedFile imgfile = file;
           string efilename = GetFileExName(file);
           ArrayList exfnarr = new ArrayList();
           exfnarr.Add(".png");
           exfnarr.Add(".jpg");
           exfnarr.Add(".gif");
           exfnarr.Add(".jpeg");
           exfnarr.Add(".bmp");
           if (CheckExpName(exfnarr, efilename))
           {
               if (imgfile.ContentLength > filelen)
               {
                   r = "B";
               }
               else
               {
                   string fullname = fname + efilename;
                   if (!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(url)))
                   {
                       Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(url));
                   }
                   imgfile.SaveAs(System.Web.HttpContext.Current.Server.MapPath(url) + fullname);
                   r = fullname;
                }
           }
           else
           {
               r = "K";
           }
           return r;
       }
       public string UpFiles(HttpPostedFile file, string fname, string url, int filelen)
       {
           string r = "";
           HttpPostedFile imgfile = file;
           string efilename =GetFileExName(file);
           ArrayList exfnarr = new ArrayList();
           exfnarr.Add(".rar");
           exfnarr.Add(".zip");
           if (CheckExpName(exfnarr, efilename))
           {
               if (imgfile.ContentLength > filelen)
               {
                   r = "B";
               }
               else
               {
                   string fullname = fname + efilename;
                   if (!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(url)))
                   {
                       Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(url));
                   }
                   imgfile.SaveAs(System.Web.HttpContext.Current.Server.MapPath(url) + fullname);
                   r = fullname;
               }
           }
           else
           {
               r = "K";
           }
           return r;
       }
       public string UpXls(HttpPostedFile file, string fname, string url, int filelen)
       {
           string r = "";
           HttpPostedFile imgfile = file;
           string efilename = GetFileExName(file);
           ArrayList exfnarr = new ArrayList();
           exfnarr.Add(".xls");
           exfnarr.Add(".xlsx");
           if (CheckExpName(exfnarr, efilename))
           {
               if (imgfile.ContentLength > filelen)
               {
                   r = "B";
               }
               else
               {
                   string fullname = fname + efilename;
                   if (!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(url)))
                   {
                       Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(url));
                   }
                   imgfile.SaveAs(System.Web.HttpContext.Current.Server.MapPath(url) + fullname);
                   r = fullname;
               }
           }
           else
           {
               r = "K";
           }
           return r;
       }
       public string GetFileExName(HttpPostedFile file)
       {
           HttpPostedFile imgfile = file;
           int enamenum = imgfile.FileName.LastIndexOf(".");
           int enamelen = imgfile.FileName.Length;
           string efilename = imgfile.FileName.Substring(enamenum, enamelen - enamenum).ToLower();
           return efilename;
       }
       private bool CheckExpName(ArrayList exfnarr,string exname)
       {
           if (exfnarr.Contains(exname))
           {
               return true;
           }
           else
           {
               return false;
           }
       }
    }
}
