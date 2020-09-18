using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvModel.ProductionInfo;
using System.Data;
using System.Data.SqlClient;
using LionvCommon;

namespace LionvSqlServerDal.ProductionInfo
{
    public class Sys_WorkLineDal : ISys_WorkLineDal
    {
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_WorkLine model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_WorkLine(");
            strSql.Append("wname,wcode,wcname,wccode,wrattr,wrlv,wrtv,wrtype)");
            strSql.Append(" values (");
            strSql.Append("@wname,@wcode,@wcname,@wccode,@wrattr,@wrlv,@wrtv,@wrtype)");
            SqlParameter[] parameters = {
					new SqlParameter("@wname", SqlDbType.NVarChar,30),
					new SqlParameter("@wcode", SqlDbType.NVarChar,20),
					new SqlParameter("@wcname", SqlDbType.NVarChar,30),
					new SqlParameter("@wccode", SqlDbType.NVarChar,30),
					new SqlParameter("@wrattr", SqlDbType.NVarChar,10),
					new SqlParameter("@wrlv", SqlDbType.Int,4),
					new SqlParameter("@wrtv", SqlDbType.Int,4),
					new SqlParameter("@wrtype", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.wname;
            parameters[1].Value = model.wcode;
            parameters[2].Value = model.wcname;
            parameters[3].Value = model.wccode;
            parameters[4].Value = model.wrattr;
            parameters[5].Value = model.wrlv;
            parameters[6].Value = model.wrtv;
            parameters[7].Value = model.wrtype;
            object obj = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Sys_WorkLine model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_WorkLine set ");
            strSql.Append("wname=@wname,");
            strSql.Append("wcname=@wcname,");
            strSql.Append("wccode=@wccode,");
            strSql.Append("wrattr=@wrattr,");
            strSql.Append("wrlv=@wrlv,");
            strSql.Append("wrtv=@wrtv,");
            strSql.Append("wrtype=@wrtype");
            strSql.Append(" where wcode=@wcode");
            SqlParameter[] parameters = {
					new SqlParameter("@wname", SqlDbType.NVarChar,30),
					new SqlParameter("@wcname", SqlDbType.NVarChar,30),
					new SqlParameter("@wccode", SqlDbType.NVarChar,30),
					new SqlParameter("@wrattr", SqlDbType.NVarChar,10),
					new SqlParameter("@wrlv", SqlDbType.Int,4),
					new SqlParameter("@wrtv", SqlDbType.Int,4),
                    new SqlParameter("@wrtype", SqlDbType.NVarChar,20),
					new SqlParameter("@wcode", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.wname;
            parameters[1].Value = model.wcname;
            parameters[2].Value = model.wccode;
            parameters[3].Value = model.wrattr;
            parameters[4].Value = model.wrlv;
            parameters[5].Value = model.wrtv;
            parameters[6].Value = model.wrtype;
            parameters[7].Value = model.wcode;

            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_WorkLine ");
            strSql.AppendFormat(" where 1=1 {0}",where);
            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sys_WorkLine Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,wname,wcode,wcname,wccode,wrattr,wrlv,wrtv,wrtype from Sys_WorkLine ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_WorkLine r = new Sys_WorkLine();
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r = DataRowToModel(dt.Rows[0]);
            }
            else
            {
                r = null;
            }
            return r;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sys_WorkLine DataRowToModel(DataRow row)
        {
            Sys_WorkLine model = new Sys_WorkLine();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["wname"] != null)
                {
                    model.wname = row["wname"].ToString();
                }
                if (row["wcode"] != null)
                {
                    model.wcode = row["wcode"].ToString();
                }
                if (row["wcname"] != null)
                {
                    model.wcname = row["wcname"].ToString();
                }
                if (row["wccode"] != null)
                {
                    model.wccode = row["wccode"].ToString();
                }
                if (row["wrattr"] != null)
                {
                    model.wrattr = row["wrattr"].ToString();
                }
                if (row["wrlv"] != null && row["wrlv"].ToString() != "")
                {
                    model.wrlv = int.Parse(row["wrlv"].ToString());
                }
                if (row["wrtv"] != null && row["wrtv"].ToString() != "")
                {
                    model.wrtv = int.Parse(row["wrtv"].ToString());
                }
                if (row["wrtype"] != null)
                {
                    model.wrtype = row["wrtype"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_WorkLine> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,wname,wcode,wcname,wccode,wrattr,wrlv,wrtv,wrtype ");
            strSql.Append(" FROM Sys_WorkLine ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sys_WorkLine> r = new List<Sys_WorkLine>();
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r.Add(DataRowToModel(dr));
                }
            }
            else
            {
                r = null;
            }
            return r;
        }

        
        #endregion  BasicMethod
        #region  ExtensionMethod
        public int CreateCode()
        {
            int r = -1;
            string sql = "";
            sql = "select isnull(max(convert(int, wcode)),0) as n from Sys_WorkLine ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        #endregion  ExtensionMethod
    }
}
