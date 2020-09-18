using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LionvCommonBll
{
   public class BusiExportBll
    {
       public string ExportHtm(string tname, string thead, ArrayList trow)
       {
           string r = "";
           StringBuilder thtm = new StringBuilder();
           StringBuilder hhtm = new StringBuilder();
           StringBuilder rhtm = new StringBuilder();
           StringBuilder fhtm = new StringBuilder();
           string[] arrh = thead.Split(';');
           if (arrh.Length > 0)
           {
               thtm.AppendFormat("<tr><td align='center' colspan='{0}'>{1}</td></tr>",arrh.Length,tname);
               hhtm.Append("<tr>");
               foreach (string cv in arrh)
               {
                   hhtm.AppendFormat("<td>{0}</td>",cv);
               }
               hhtm.Append("</tr>");
           }
           if (trow.Count > 0)
           {
               foreach (ArrayList al in trow)
               {
                   rhtm.Append("<tr>");
                   foreach (string v in al)
                   {
                       rhtm.AppendFormat("<td>{0}</td>",v);
                   }
                   rhtm.Append("</tr>");
               }
           }
           r = thtm.ToString() + hhtm.ToString() + rhtm.ToString();
           return r;
       }
    }
}
