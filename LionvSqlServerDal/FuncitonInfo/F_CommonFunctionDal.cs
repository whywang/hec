using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.FuncitonInfo;
using LionvCommon;
using System.Data;
using System.Data.SqlClient;

namespace LionvSqlServerDal.FuncitonInfo
{
    public class F_CommonFunctionDal : IF_CommonFunctionDal
    {
        public bool ExceUpdate(string tname, string field, string fv, string where)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" update {0} ", tname);
            sql.AppendFormat(" set {0}='{1}' ",field, fv);
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
        public bool ExceProcess(string mtable, string stable, string sid, string nsid, string qtimg)
        {
            SqlParameter[] parms = { 
                                       new SqlParameter("@mtable", mtable), 
                                       new SqlParameter("@stable", stable), 
                                       new SqlParameter("@sid", sid), 
                                       new SqlParameter("@nsid", nsid) , 
                                       new SqlParameter("@qtimg", qtimg)};
            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.StoredProcedure, "b_CreateSubWorkFlow", parms);
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
