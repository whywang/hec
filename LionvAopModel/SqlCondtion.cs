using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvAopModel
{
   public class SqlCondtion
    {
       public string  GetSqlWhere(string datefield,string sv,string stype,string svtype)
       {
           
           StringBuilder sql=new StringBuilder ();
           if (sv != "" && sv != null)
           {
               if (stype == "s" || stype == "")
               {
                   if (svtype == "s" || stype == "")
                   {
                       sql.AppendFormat(" and {0}='{1}'", datefield, sv);
                   }
                   if (svtype == "n")
                   {
                       sql.AppendFormat(" and {0}={1} ", datefield, sv);
                   }
               }
               if (stype == "l")
               {
                   sql.AppendFormat(" and {0} like '%{1}%' ", datefield, sv);
               }
           }
           return sql.ToString();
       }
    }
}
