using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvModel.ProductionInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;

namespace LionvSqlServerDal.ProductionInfo
{
    public class Sys_LxDal : ISys_LxDal
    {
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Sys_Lx model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_Lx(");
            strSql.Append("lxname,lxcode,used)");
            strSql.Append(" values (");
            strSql.Append("@lxname,@lxcode,@used)");
 
            SqlParameter[] parameters = {
					new SqlParameter("@lxname", SqlDbType.NVarChar,30),
					new SqlParameter("@lxcode", SqlDbType.NVarChar,20),
                    new SqlParameter("@used", SqlDbType.Bit,1)}; 
            parameters[0].Value = model.lxname;
            parameters[1].Value = model.lxcode;
            parameters[2].Value = model.used;
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
        public bool Update( Sys_Lx model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_Lx set ");
            strSql.Append("lxname=@lxname,");
            strSql.Append("used=@used");
            strSql.Append(" where lxcode=@lxcode");
            SqlParameter[] parameters = {
					new SqlParameter("@lxname", SqlDbType.NVarChar,30),
					new SqlParameter("@used", SqlDbType.Bit,1),
					new SqlParameter("@lxcode", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.lxname;
            parameters[1].Value = model.used;
            parameters[2].Value = model.lxcode;

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
        public bool Delete(string lxcode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_Lx ");
            strSql.Append(" where lxcode=@lxcode ");
            SqlParameter[] parameters = {
					new SqlParameter("@lxcode", SqlDbType.NVarChar,20)			};
            parameters[0].Value = lxcode;

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
        public  Sys_Lx Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,lxname,lxcode,used from Sys_Lx ");
            strSql.AppendFormat(" where 1=1 {0}",where);
            Sys_Lx r = new Sys_Lx();
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
        public  Sys_Lx DataRowToModel(DataRow row)
        {
             Sys_Lx model = new  Sys_Lx();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["lxname"] != null)
                {
                    model.lxname = row["lxname"].ToString();
                }
                if (row["lxcode"] != null)
                {
                    model.lxcode = row["lxcode"].ToString();
                }
                if (row["used"] != null && row["used"].ToString() != "")
                {
                    if ((row["used"].ToString() == "1") || (row["used"].ToString().ToLower() == "true"))
                    {
                        model.used = true;
                    }
                    else
                    {
                        model.used = false;
                    }
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_Lx> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,lxname,lxcode,used ");
            strSql.Append(" FROM Sys_Lx ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sys_Lx> r = new List<Sys_Lx>();
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
            sql = "select isnull(max(lxcode),0) as n from Sys_Lx ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        #endregion  ExtensionMethod
    }
}
