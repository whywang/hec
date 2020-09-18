using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvCommon;
using System.Data;
using LionvIDal.FuncitonInfo;

namespace LionvSqlServerDal.FuncitonInfo
{
    public class F_SetOrderTypeDal : IF_SetOrderTypeDal
    {
        public bool SetOrderType(string tname, string codev, string where)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" update {0} ", tname);
            sql.AppendFormat(" set otype='{0}' ", codev);
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
