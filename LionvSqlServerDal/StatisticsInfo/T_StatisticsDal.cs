using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.StatisticsInfo;
using System.Data;
using LionvCommon;

namespace LionvSqlServerDal.StatisticsInfo
{
    public class T_StatisticsDal : IT_StatisticsDal
    {
        public DataTable QueryList(string tname, string vfield, string where, string sort)
        {
            DataTable r = new DataTable();
            StringBuilder sql = new StringBuilder();
            sql.Append(" select ");
            sql.Append(" " + vfield + "");
            sql.Append(" from " + tname + "");
            sql.Append(" where 1=1 ");
            sql.Append("  " + where + "");
            sql.Append("  " + sort + "");
            r = SqlHelp.GetDataTable2(CommandType.Text, sql.ToString(), null);
            return r;
        }
        public bool Exists(string tname,string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}", tname);
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
        }
        public bool BaseExists(string tname, string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}", tname);
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }
    }
}
