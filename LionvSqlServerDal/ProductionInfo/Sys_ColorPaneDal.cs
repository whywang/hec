using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;
using LionvIDal.ProductionInfo;

namespace LionvSqlServerDal.ProductionInfo
{
    public class Sys_ColorPaneDal : ISys_ColorPaneDal
    {
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Sys_ColorPane model)
        {
            StringBuilder strSql = new StringBuilder();
         	strSql.Append("insert into Sys_ColorPane(");
			strSql.Append("sbname,sbcode,used)");
			strSql.Append(" values (");
			strSql.Append("@sbname,@sbcode,@used)");
			SqlParameter[] parameters = {
					new SqlParameter("@sbname", SqlDbType.NVarChar,30),
					new SqlParameter("@sbcode", SqlDbType.NVarChar,10),
					new SqlParameter("@used", SqlDbType.Bit,1)};
			parameters[0].Value = model.sbname;
			parameters[1].Value = model.sbcode;
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
        public bool Update( Sys_ColorPane model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_ColorPane set ");
            strSql.Append("sbname=@sbname,");
            strSql.Append("used=@used");
            strSql.Append(" where sbcode=@sbcode");
            SqlParameter[] parameters = {
					new SqlParameter("@sbname", SqlDbType.NVarChar,30),
					new SqlParameter("@used", SqlDbType.Bit,1),
					new SqlParameter("@sbcode", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.sbname;
            parameters[1].Value = model.used;
            parameters[2].Value = model.sbcode;

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
        public bool Delete(string sbcode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_ColorPane ");
            strSql.Append(" where sbcode=@sbcode ");
            SqlParameter[] parameters = {
					new SqlParameter("@sbcode", SqlDbType.NVarChar,10)			};
            parameters[0].Value = sbcode;

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
        public  Sys_ColorPane Query(string  where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sbname,sbcode,used from Sys_ColorPane ");
            strSql.AppendFormat(" where 1=1 {0}",where);
            Sys_ColorPane r = new Sys_ColorPane();
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
        public  Sys_ColorPane DataRowToModel(DataRow row)
        {
             Sys_ColorPane model = new  Sys_ColorPane();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["sbname"] != null)
                {
                    model.sbname = row["sbname"].ToString();
                }
                if (row["sbcode"] != null)
                {
                    model.sbcode = row["sbcode"].ToString();
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
        public List<Sys_ColorPane> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sbname,sbcode,used ");
            strSql.Append(" FROM Sys_ColorPane ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sys_ColorPane> r = new List<Sys_ColorPane>();
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
            sql = "select isnull(max(sbcode),0) as n from Sys_ColorPane ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        #endregion  ExtensionMethod
    }
}
