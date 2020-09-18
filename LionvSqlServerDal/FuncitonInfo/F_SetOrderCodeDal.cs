using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvCommon;
using System.Data;
using LionvIDal.FuncitonInfo;

namespace LionvSqlServerDal.FuncitonInfo
{
    public class F_SetOrderCodeDal : IF_SetOrderCodeDal
    {
       public bool SetOrderCode(string tname, string codev, string where)
       {
           StringBuilder sql = new StringBuilder();
           sql.AppendFormat(" update {0} ", tname);
           sql.AppendFormat(" set scode='{0}' ", codev);
           sql.Append(" where 1=1 ");
           sql.Append("  " + where + "");
           int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, sql.ToString(), null);
           if (rows > 0)
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
