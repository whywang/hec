using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;
using LionvIDal.SysInfo;

namespace LionvSqlServerDal.SysInfo
{
    public class Sys_MzOrderTypeDal : ISys_MzOrderTypeDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
       public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_MzOrderType");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Sys_MzOrderType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_MzOrderType(");
            strSql.Append("mtname,mtcode,emcode,maker,otype,cdate)");
            strSql.Append(" values (");
            strSql.Append("@mtname,@mtcode,@emcode,@maker,@otype,@cdate)");
 
            SqlParameter[] parameters = {
					new SqlParameter("@mtname", SqlDbType.NVarChar,30),
					new SqlParameter("@mtcode", SqlDbType.NVarChar,30),
					new SqlParameter("@emcode", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
                    new SqlParameter("@otype", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.mtname;
            parameters[1].Value = model.mtcode;
            parameters[2].Value = model.emcode;
            parameters[3].Value = model.maker;
            parameters[4].Value = model.otype;
            parameters[5].Value = model.cdate;

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
        public bool Update( Sys_MzOrderType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_MzOrderType set ");
            strSql.Append("mtname=@mtname,");
            strSql.Append("emcode=@emcode,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate,");
            strSql.Append("otype=@otype");
            strSql.Append(" where mtcode=@mtcode");
            SqlParameter[] parameters = {
					new SqlParameter("@mtname", SqlDbType.NVarChar,30),
					new SqlParameter("@emcode", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
                    new SqlParameter("@otype", SqlDbType.NVarChar,30),
					new SqlParameter("@mtcode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.mtname;
            parameters[1].Value = model.emcode;
            parameters[2].Value = model.maker;
            parameters[3].Value = model.cdate;
            parameters[4].Value = model.otype;
            parameters[5].Value = model.mtcode;
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
        public bool Delete(string mtcode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_MzOrderType ");
            strSql.Append(" where mtcode=@mtcode ");
            SqlParameter[] parameters = {
					new SqlParameter("@mtcode", SqlDbType.NVarChar,30)			};
            parameters[0].Value = mtcode;

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
        public  Sys_MzOrderType Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,mtname,mtcode,emcode,maker,cdate,otype from Sys_MzOrderType ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_MzOrderType r = new Sys_MzOrderType();
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
        public  Sys_MzOrderType DataRowToModel(DataRow row)
        {
             Sys_MzOrderType model = new  Sys_MzOrderType();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["mtname"] != null)
                {
                    model.mtname = row["mtname"].ToString();
                }
                if (row["mtcode"] != null)
                {
                    model.mtcode = row["mtcode"].ToString();
                }
                if (row["emcode"] != null)
                {
                    model.emcode = row["emcode"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["otype"] != null)
                {
                    model.otype = row["otype"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString() ;
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_MzOrderType> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,mtname,mtcode,emcode,maker,cdate,otype ");
            strSql.Append(" FROM Sys_MzOrderType ");
            strSql.AppendFormat("  where 1=1 {0}", strWhere);
            List<Sys_MzOrderType> r = new List<Sys_MzOrderType>();
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
            string sql = "select isnull(max(convert(int,mtcode)),0) as n from Sys_MzOrderType ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        #endregion  ExtensionMethod
    }
}
