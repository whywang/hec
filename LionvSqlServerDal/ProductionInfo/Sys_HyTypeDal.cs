using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;
using LionvCommon;
using System.Data;
using System.Data.SqlClient;
using LionvIDal.ProductionInfo;

namespace LionvSqlServerDal.ProductionInfo
{
    public class Sys_HyTypeDal : ISys_HyTypeDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string hycode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_HyType");
            strSql.AppendFormat(" where 1=1 {0} ", hycode);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_HyType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_HyType(");
            strSql.Append("hyname,hycode,hyprice,bdcode,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@hyname,@hycode,@hyprice,@bdcode,@maker,@cdate)");

            SqlParameter[] parameters = {
					new SqlParameter("@hyname", SqlDbType.NVarChar,30),
					new SqlParameter("@hycode", SqlDbType.NVarChar,30),
					new SqlParameter("@hyprice", SqlDbType.Decimal,9),
					new SqlParameter("@bdcode", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.hyname;
            parameters[1].Value = model.hycode;
            parameters[2].Value = model.hyprice;
            parameters[3].Value = model.bdcode;
            parameters[4].Value = model.maker;
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
        public bool Update(Sys_HyType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_HyType set ");
            strSql.Append("hyname=@hyname,");
            strSql.Append("hyprice=@hyprice,");
            strSql.Append("bdcode=@bdcode,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where hycode=@hycode");
            SqlParameter[] parameters = {
					new SqlParameter("@hyname", SqlDbType.NVarChar,30),
					new SqlParameter("@hyprice", SqlDbType.Decimal,9),
					new SqlParameter("@bdcode", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@hycode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.hyname;
            parameters[1].Value = model.hyprice;
            parameters[2].Value = model.bdcode;
            parameters[3].Value = model.maker;
            parameters[4].Value = model.cdate;
            parameters[5].Value = model.hycode;

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
        public bool Delete(string hycode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_HyType ");
            strSql.Append(" where hycode=@hycode ");
            SqlParameter[] parameters = {
					new SqlParameter("@hycode", SqlDbType.NVarChar,30)			};
            parameters[0].Value = hycode;

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
        public Sys_HyType Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,hyname,hycode,hyprice,bdcode,maker,cdate from Sys_HyType ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_HyType r = new Sys_HyType();
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
        public Sys_HyType DataRowToModel(DataRow row)
        {
            Sys_HyType model = new Sys_HyType();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["hyname"] != null)
                {
                    model.hyname = row["hyname"].ToString();
                }
                if (row["hycode"] != null)
                {
                    model.hycode = row["hycode"].ToString();
                }
                if (row["hyprice"] != null && row["hyprice"].ToString() != "")
                {
                    model.hyprice = decimal.Parse(row["hyprice"].ToString());
                }
                if (row["bdcode"] != null)
                {
                    model.bdcode = row["bdcode"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_HyType> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,hyname,hycode,hyprice,bdcode,maker,cdate ");
            strSql.Append(" FROM Sys_HyType ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sys_HyType> r = new List<Sys_HyType>();
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
            sql = "select isnull(max(hycode),0) as n from Sys_HyType ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        #endregion  ExtensionMethod
    }
}
