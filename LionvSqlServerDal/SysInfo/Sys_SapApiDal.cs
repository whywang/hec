using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using System.Data.SqlClient;
using LionvModel.SysInfo;
using System.Data;
using LionvCommon;

namespace LionvSqlServerDal.SysInfo
{
    public class Sys_SapApiDal : ISys_SapApiDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_SapApi");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_SapApi model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_SapApi(");
            strSql.Append("sname,scode,surl,suser,spwd,sfwname,sfwmethod)");
            strSql.Append(" values (");
            strSql.Append("@sname,@scode,@surl,@suser,@spwd,@sfwname,@sfwmethod)");
            SqlParameter[] parameters = {
					new SqlParameter("@sname", SqlDbType.NVarChar,30),
					new SqlParameter("@scode", SqlDbType.NVarChar,20),
					new SqlParameter("@surl", SqlDbType.NVarChar,100),
					new SqlParameter("@suser", SqlDbType.NVarChar,30),
					new SqlParameter("@spwd", SqlDbType.NVarChar,30),
					new SqlParameter("@sfwname", SqlDbType.NVarChar,50),
					new SqlParameter("@sfwmethod", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.sname;
            parameters[1].Value = model.scode;
            parameters[2].Value = model.surl;
            parameters[3].Value = model.suser;
            parameters[4].Value = model.spwd;
            parameters[5].Value = model.sfwname;
            parameters[6].Value = model.sfwmethod;

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
        public bool Update(Sys_SapApi model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_SapApi set ");
            strSql.Append("sname=@sname,");
            strSql.Append("surl=@surl,");
            strSql.Append("suser=@suser,");
            strSql.Append("spwd=@spwd,");
            strSql.Append("sfwname=@sfwname,");
            strSql.Append("sfwmethod=@sfwmethod");
            strSql.Append(" where scode=@scode");
            SqlParameter[] parameters = {
					new SqlParameter("@sname", SqlDbType.NVarChar,30),
					new SqlParameter("@surl", SqlDbType.NVarChar,100),
					new SqlParameter("@suser", SqlDbType.NVarChar,30),
					new SqlParameter("@spwd", SqlDbType.NVarChar,30),
					new SqlParameter("@sfwname", SqlDbType.NVarChar,50),
					new SqlParameter("@sfwmethod", SqlDbType.NVarChar,50),
					new SqlParameter("@scode", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.sname;
            parameters[1].Value = model.surl;
            parameters[2].Value = model.suser;
            parameters[3].Value = model.spwd;
            parameters[4].Value = model.sfwname;
            parameters[5].Value = model.sfwmethod;
            parameters[6].Value = model.scode;

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
            strSql.Append("delete from Sys_SapApi ");
            strSql.AppendFormat(" where 1=1 {0} ", where);
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
        public Sys_SapApi Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sname,scode,surl,suser,spwd,sfwname,sfwmethod from Sys_SapApi ");
            strSql.AppendFormat(" where 1=1 {0}",where);
            Sys_SapApi r = new Sys_SapApi();
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
        public Sys_SapApi DataRowToModel(DataRow row)
        {
            Sys_SapApi model = new Sys_SapApi();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["sname"] != null)
                {
                    model.sname = row["sname"].ToString();
                }
                if (row["scode"] != null)
                {
                    model.scode = row["scode"].ToString();
                }
                if (row["surl"] != null)
                {
                    model.surl = row["surl"].ToString();
                }
                if (row["suser"] != null)
                {
                    model.suser = row["suser"].ToString();
                }
                if (row["spwd"] != null)
                {
                    model.spwd = row["spwd"].ToString();
                }
                if (row["sfwname"] != null)
                {
                    model.sfwname = row["sfwname"].ToString();
                }
                if (row["sfwmethod"] != null)
                {
                    model.sfwmethod = row["sfwmethod"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_SapApi> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sname,scode,surl,suser,spwd,sfwname,sfwmethod ");
            strSql.AppendFormat(" FROM Sys_SapApi where 1=1 {0}", strWhere);
            List<Sys_SapApi> r = new List<Sys_SapApi>();
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
            string sql = "select isnull(max(convert(int,scode)),0) as n from Sys_SapApi ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        #endregion  ExtensionMethod
    }
}
