using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvBll.SysInfo;
using LionvModel.SysInfo;

namespace LionvCommonBll
{
   public class BusiTempletBll
   {
       private Sys_TempletBll stb = new Sys_TempletBll();
       private Sys_DomainBll sdb = new Sys_DomainBll();
       #region//获取表单模板
       public string TempHead(string emcode)
       {
           string r = "";
           Sys_Templet st = new Sys_Templet();
           st = stb.Query(" and emcode='" + emcode + "' and ttype='h'");
           if (st != null)
           {
               r = st.ttext;
           }
           return r;
       }
       public string TempBody(string emcode, string tinvtype)
       {
           string r = "";
           Sys_Templet st = new Sys_Templet();
           st = stb.Query(" and emcode='" + emcode + "' and ttype='b' and utype='" + tinvtype + "'");
           if (st != null)
           {
               r = st.ttext;
           }
           return r;
       }
       public string TempFoot(string emcode,string utype )
       {
           string r = "";
           Sys_Templet st = new Sys_Templet();
           st = stb.Query(" and emcode='" + emcode + "' and ttype='f' and  utype='" + utype + "'");
           if (st != null)
           {
               r = st.ttext + "<br><br><br>";
           }
           return r;
       }
       public string TempFoot(string emcode)
       {
           string r = "";
           Sys_Templet st = new Sys_Templet();
           st = stb.Query(" and emcode='" + emcode + "' and ttype='f'");
           if (st != null)
           {
               r = st.ttext + "<br><br><br>";
           }
           return r;
       }
       public string TempHead(string dcode, string emcode, string utype)
       {
           string r = "";
           Sys_Templet temp = stb.Query(" and emcode='" + emcode + "' and dcode='" + dcode + "' and ttype='h' and utype='" + utype + "'");
           if (temp != null)
           {
               Sys_Domain sd = sdb.Query(" and dtype='p'");
               if (temp.limg != "")
               {
                   temp.ttext = temp.ttext.Replace("[LIMG]", "<img src='" + sd.url + temp.limg + "'/>");
               }
               else
               {
                   temp.ttext = temp.ttext.Replace("[LIMG]", "");
               }
               r = temp.ttext;
           }
           return r;
       }
       public string TempHead(string dcode, string emcode, string utype,string ptype)
       {
           string r = "";
           Sys_Templet temp = stb.Query(" and emcode='" + emcode + "' and dcode='" + dcode + "' and ttype='h' and utype='" + utype + "' and ptype='" + ptype + "'");
           if (temp != null)
           {
               Sys_Domain sd = sdb.Query(" and dtype='p'");
               if (temp.limg != "")
               {
                   temp.ttext = temp.ttext.Replace("[LIMG]", "<img src='" + sd.url + temp.limg + "'/>");
               }
               else
               {
                   temp.ttext = temp.ttext.Replace("[LIMG]", "");
               }
               r = temp.ttext;
           }
           return r;
       }
       public string TempBody(string dcode, string emcode, string utype)
       {
           string r = "";
           Sys_Templet temp = stb.Query(" and emcode='" + emcode + "'and dcode='" + dcode + "' and ttype='b' and utype='" + utype + "'");
           if (temp != null)
           {
               r = temp.ttext;
           }
           return r;
       }
       public string TempBody(string dcode, string emcode, string utype,string ptype)
       {
           string r = "";
           Sys_Templet temp = stb.Query(" and emcode='" + emcode + "'and dcode='" + dcode + "' and ttype='b' and utype='" + utype + "' and ptype='" + ptype + "'");
           if (temp != null)
           {
               r = temp.ttext;
           }
           return r;
       }
       public string TempFoot(string dcode, string emcode, string utype)
       {
           string r = "";
           Sys_Templet temp = stb.Query("and emcode='" + emcode + "' and dcode='" + dcode + "' and ttype='f' and utype='" + utype + "'");
           if (temp != null)
           {
               r = temp.ttext + "<br><br><br>";
           }
           return r;
       }

       public string TempDiv(string dcode, string emcode, string utype)
       {
           string r = "";
           Sys_Templet temp = stb.Query(" and emcode='" + emcode + "' and dcode='" + dcode + "' and ttype='d' and utype='" + utype + "'");
           if (temp != null)
           {
               Sys_Domain sd = sdb.Query(" and dtype='p'");
               if (temp.limg != "")
               {
                   temp.ttext = temp.ttext.Replace("[LIMG]", "<img src='" + sd.url + temp.limg + "'/>");
               }
               else
               {
                   temp.ttext = temp.ttext.Replace("[LIMG]", "");
               }
               r = temp.ttext;
           }
           return r;
       }
       #endregion
   }
}
