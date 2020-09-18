using LionvCommon;
using LionvIDal.NewsInfo;
using LionvModel.NewsInfo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace LionvSqlServerDal.NewsInfo
{
  public  class NB_DepNewsDal: INB_DepNewsDal
    {
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(string nid, ArrayList depcode)
        {
            if (depcode != null)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from NB_DepNews ");
                strSql.AppendFormat(" where nid={0}; ", nid);
                for (int i = 0; i < depcode.Count; i++)
                {
                    strSql.Append("insert into NB_DepNews(");
                    strSql.Append("nid,dcode)");
                    strSql.Append(" values (");
                    strSql.AppendFormat("{0},'{1}');", nid, depcode[i]);
                }
                object obj = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
                if (obj == null)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(obj);
                }
            }
            else
            {
                return 0;
            }
        }
        
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool Delete(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from NB_DepNews ");
            strSql.AppendFormat(" where 1=1 {0} ",idlist);
            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}