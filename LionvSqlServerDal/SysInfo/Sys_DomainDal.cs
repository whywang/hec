using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvModel.SysInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;

namespace LionvSqlServerDal.SysInfo
{
    public class Sys_DomainDal : ISys_DomainDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_Domain");
            strSql.AppendFormat(" where 1=1 {0}",where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_Domain model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_Domain(");
            strSql.Append("dtype,url)");
            strSql.Append(" values (");
            strSql.Append("@dtype,@url)");
            SqlParameter[] parameters = {
					new SqlParameter("@dtype", SqlDbType.NVarChar,20),
					new SqlParameter("@url", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.dtype;
            parameters[1].Value = model.url;

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
        public bool Update(Sys_Domain model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_Domain set ");
            strSql.Append("dtype=@dtype,");
            strSql.Append("url=@url");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@dtype", SqlDbType.NVarChar,20),
					new SqlParameter("@url", SqlDbType.NVarChar,100),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.dtype;
            parameters[1].Value = model.url;
            parameters[2].Value = model.id;

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
        /// 批量删除数据
        /// </summary>
        public bool Delete(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_Domain ");
            strSql.AppendFormat(" where id={0} ;", id);
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
        public Sys_Domain Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,dtype,url from Sys_Domain ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_Domain r = new Sys_Domain();
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
        public Sys_Domain DataRowToModel(DataRow row)
        {
            Sys_Domain model = new Sys_Domain();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["dtype"] != null)
                {
                    model.dtype = row["dtype"].ToString();
                }
                if (row["url"] != null)
                {
                    model.url = row["url"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_Domain> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,dtype,url ");
            strSql.Append(" FROM Sys_Domain ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sys_Domain> r = new List<Sys_Domain>();
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

        #endregion  ExtensionMethod
    }
}
