using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;
using System.Data;
using LionvCommon;
using System.Data.SqlClient;
using LionvIDal.ProductionInfo;

namespace LionvSqlServerDal.ProductionInfo
{
    public class Sys_ComputeUnitDal : ISys_ComputeUnitDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_ComputeUnit");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_ComputeUnit model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_ComputeUnit(");
            strSql.Append("cname,ccode,ctype,cunit,bdcode)");
            strSql.Append(" values (");
            strSql.Append("@cname,@ccode,@ctype,@cunit,@bdcode)");
            SqlParameter[] parameters = {
					new SqlParameter("@cname", SqlDbType.NVarChar,30),
					new SqlParameter("@ccode", SqlDbType.NVarChar,30),
					new SqlParameter("@ctype", SqlDbType.NVarChar,30),
					new SqlParameter("@cunit", SqlDbType.NVarChar,30),
					new SqlParameter("@bdcode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.cname;
            parameters[1].Value = model.ccode;
            parameters[2].Value = model.ctype;
            parameters[3].Value = model.cunit;
            parameters[4].Value = model.bdcode;
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
        public bool Update(Sys_ComputeUnit model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_ComputeUnit set ");
            strSql.Append("cname=@cname,");
            strSql.Append("ctype=@ctype,");
            strSql.Append("cunit=@cunit");
            strSql.Append(" where ccode=@ccode");
            SqlParameter[] parameters = {
					new SqlParameter("@cname", SqlDbType.NVarChar,30),
					new SqlParameter("@ctype", SqlDbType.NVarChar,30),
					new SqlParameter("@cunit", SqlDbType.NVarChar,30),
					new SqlParameter("@ccode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.cname;
            parameters[1].Value = model.ctype;
            parameters[2].Value = model.cunit;
            parameters[3].Value = model.ccode;

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
        public bool Delete(string ccode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_ComputeUnit ");
            strSql.Append(" where ccode=@ccode ");
            SqlParameter[] parameters = {
					new SqlParameter("@ccode", SqlDbType.NVarChar,30)			};
            parameters[0].Value = ccode;
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
        /// 得到一个对象实体
        /// </summary>
        public Sys_ComputeUnit Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,cname,ccode,ctype,cunit,bdcode from Sys_ComputeUnit ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_ComputeUnit r = new Sys_ComputeUnit();
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
        public Sys_ComputeUnit DataRowToModel(DataRow row)
        {
            Sys_ComputeUnit model = new Sys_ComputeUnit();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["cname"] != null)
                {
                    model.cname = row["cname"].ToString();
                }
                if (row["ccode"] != null)
                {
                    model.ccode = row["ccode"].ToString();
                }
                if (row["ctype"] != null)
                {
                    model.ctype = row["ctype"].ToString();
                }
                if (row["cunit"] != null)
                {
                    model.cunit = row["cunit"].ToString();
                }
                if (row["bdcode"] != null)
                {
                    model.bdcode = row["bdcode"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_ComputeUnit> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,cname,ccode,ctype,cunit,bdcode ");
            strSql.Append(" FROM Sys_ComputeUnit ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sys_ComputeUnit> r = new List<Sys_ComputeUnit>();
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
            sql = "select isnull(max(ccode),0) as n from Sys_ComputeUnit ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        #endregion  ExtensionMethod
    }
}
